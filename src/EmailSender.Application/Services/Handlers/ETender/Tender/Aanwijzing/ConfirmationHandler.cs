using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Application.Interfaces.Handlers;
using DataIntegration.Application.Interfaces.Modules;
using DataIntegration.Application.Interfaces.Modules.MessageBroker;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TBIG_e_Tender.Domain.Entities.TBIGSYSDB01.TBIGETender;
using DataIntegration.Application.Model;

namespace DataIntegration.Application.Services.Handlers.ETender.Tender.Aanwijzing
{
    public class ConfirmationHandler : IMessageHandler
    {
        private readonly IMessagePublisher _publisher;
        private readonly IServiceScopeFactory _scopeFactory;
        public ConfirmationHandler(IMessagePublisher publisher, IServiceScopeFactory scopeFactory)
        {
            _publisher = publisher;
            _scopeFactory = scopeFactory;
        }

        public async Task HandleAsync(string message)
        {
            using var scope = _scopeFactory.CreateScope();

            var data = JsonConvert.DeserializeObject<List<TenderAanwijzingConfirmation>>(message);
            if (data == null || data.Count == 0) return;

            long trxPRCETenderHeaderID = 0;
            var emailParticipants = new List<string>();
            var confirmationSvc = scope.ServiceProvider.GetRequiredService<ItrxPRCETenderAanwijzingConfirmationService>();

            foreach (var item in data)
            {
                try
                {
                    var entity = await confirmationSvc.GetByPKAsync(item.ID).ConfigureAwait(false);
                    if (entity != null)
                    {
                        if (trxPRCETenderHeaderID == 0)
                            trxPRCETenderHeaderID = entity.trxPRCETenderHeaderID;

                        emailParticipants.AddRange((entity.VendorEmail ?? "")
                            .Split(new[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(e => e.Trim()));

                        entity.IsConfirm = item.IsConfirm;
                        entity.Remarks = item.Remarks;
                        entity.IsSync = true;
                        entity.UpdatedBy = "Data Integration";
                        entity.UpdatedDate = DateTime.Now;

                        await confirmationSvc.UpdateAsync(entity).ConfigureAwait(false);
                        Console.WriteLine($"[ConfirmationHandler] Updated ID: {item.ID}");
                    }

                    item.IsSync = true;
                    item.UpdatedBy = "Data Integration";
                    item.UpdatedDate = DateTime.Now;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ConfirmationHandler] ERROR ID {item.ID}: {ex}");
                }
            }

            if (trxPRCETenderHeaderID != 0)
            {
                var activitySvc = scope.ServiceProvider.GetRequiredService<ItrxPRCETenderActivityService>();
                var invitationSvc = scope.ServiceProvider.GetRequiredService<ItrxPRCETenderScheduleInvitationAanwijzingService>();
                var meetingRoomVirtualSvc = scope.ServiceProvider.GetRequiredService<ItrxRequestMeetingRoomVirtualService>();

                var activity = (await activitySvc.GetListAsync(x => x.trxPRCETenderHeaderID == trxPRCETenderHeaderID && x.Sort == 9).ConfigureAwait(false)).FirstOrDefault();

                if (activity != null)
                {
                    var invitation = (await invitationSvc.GetListAsync(x => x.trxPRCETenderActivityID == activity.ID).ConfigureAwait(false)).FirstOrDefault();

                    if (invitation != null)
                    {
                        string subject = "";
                        if (invitation.trxRequestMeetingRoomVirtualID != null)
                        {
                            var room = await meetingRoomVirtualSvc.GetByPKAsync(invitation.trxRequestMeetingRoomVirtualID).ConfigureAwait(false);
                            subject = room?.Subject ?? "";
                        }

                        SendEmail(invitation.EmailBody, subject, emailParticipants.Distinct().ToList());
                    }
                }
            }

            Console.WriteLine($"[Confirmation] Processing: {message}");
            var update = JsonConvert.SerializeObject(data);
            await Task.Run(() => _publisher.Publish("tenderaanwijzing.confirmation.status", update));
            await Task.CompletedTask;
        }

        public void SendEmail(string emailBody, string subject, List<string> emailParticipants)
        {
            using var scope = _scopeFactory.CreateScope();
            try
            {
                var message = new RabbitMQMessage()
                {
                    ApplicationID = 37,
                    Module = "Confirmation Attendance Aanwijzing",
                    Subject = subject,
                    TemplateCode = null,
                    To = emailParticipants,
                    CC = new List<string>(),
                    BCC = new List<string> { "gustara.putra@tower-bersama.com" },
                    Attachment = new List<string>(),
                    HTMLBody = emailBody
                };

                scope.ServiceProvider.GetRequiredService<IEmailService>().SendEmail(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ConfirmationHandler] SendEmail ERROR: {ex}");
            }
        }
    }
}
