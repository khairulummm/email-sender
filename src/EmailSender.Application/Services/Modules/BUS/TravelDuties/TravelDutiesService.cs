using Dapper;
using DataIntegration.Application.Extensions;
using DataIntegration.Application.Helper;
using DataIntegration.Application.Interfaces.Entities;
using DataIntegration.Application.Interfaces.Entities.HTBGDBS03.HR_TBG;
using DataIntegration.Application.Interfaces.Entities.HTBGDWH01.TBiGSys;
using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Application.Interfaces.Modules;
using DataIntegration.Application.Interfaces.Modules.BUS.TravelDuties;
using DataIntegration.Application.Interfaces.Modules.BUS.TravelDuties.TravelAgent.KIA;
using DataIntegration.Application.Interfaces.Modules.BUS.TravelDuties.TravelAgent.Traveloka;
using DataIntegration.Application.Model;
using DataIntegration.Domain.Entities.HTBGDBS03.HR_TBG;
using DataIntegration.Domain.Entities.HTBGDWH01.TBiGSys;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Domain.Enums;
using DataIntegration.Domain.Enums.BUS.TravelDuties;
using DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties;
using DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent;
using DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA;
using DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka;
using DataIntegration.Infrastructure;
using DataIntegration.Infrastructure.Data;
using HandlebarsDotNet;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Text;

namespace DataIntegration.Application.Services.Modules.BUS.TravelDuties
{
    public class TravelDutiesService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider, ILogger<TravelDutiesService> logger)
        : ITravelDutiesService
    {
        private readonly IKiaService _kiaService;
        private readonly ITravelokaService _tvlService;
        private readonly IEmailService _emailService;

        private readonly ImstBUSTravelAgentService _otaService;
        private readonly ImstBUSTravelDutiesAirportService _airportService;
        private readonly ImstBUSTravelDutiesContactMappingService _contactMappingService;
        private readonly ImstBusTravelokaConfigurationService _tvlConfigService;
        private readonly ImstBUSKiaConfigurationService _kiaConfigService;

        private readonly ItrxBUSHCTravelDutiesRegistrationService _travelDutiesRegistService;
        private readonly ItrxBUSTravelDutiesBookingAccommodationService _bookAccomService;
        private readonly ItrxBUSTravelDutiesBookingAccommodationTravelokaService _bookAccomTvlService;
        private readonly ItrxBUSTravelDutiesBookingAccommodationKIAService _bookAccomKiaService;
        private readonly ItrxBUSTravelDutiesBookingAccommodationRequestService _bookAccomRequestService;
        private readonly ItrxBUSTravelDutiesBookingFlightService _bookFlightService;
        private readonly ItrxBUSTravelDutiesBookingFlightJourneyService _bookFlightJourneyService;
        private readonly ItrxBUSTravelDutiesBookingFlightContactService _bookFlightContactService;
        private readonly ItrxBUSTravelDutiesBookingFlightTravelokaService _bookFlightTvlService;
        private readonly ItrxBUSTravelDutiesBookingFlightKIAService _bookFlightKiaService;
        private readonly ItrxBUSTravelDutiesBookingFlightRequestService _bookFlightRequestService;

        private readonly IvwBUSTravelDutiesBookingAccommodationService _vwBookAccomService;
        private readonly IvwBUSHCTravelDutiesEmployeeService _vwTravelDutiesEmployeeService;

        private readonly ImstEmailService _mstEmailService;
        private readonly IMF_EMPLOYEEService _employeeService;

        public TravelDutiesService(IUnitOfWorkFactory unitOfWorkFactory,
                                   IServiceProvider serviceProvider,
                                   ILogger<TravelDutiesService> logger,

                                   IKiaService kiaService,
                                   ITravelokaService tvlService,
                                   IEmailService sendEmailService,

                                   ImstBUSTravelAgentService otaService,
                                   ImstBUSTravelDutiesAirportService airportService,
                                   ImstBUSTravelDutiesContactMappingService contactMappingService,
                                   ImstBusTravelokaConfigurationService tvlConfigService,
                                   ImstBUSKiaConfigurationService kiaConfigService,

                                   ItrxBUSHCTravelDutiesRegistrationService travelDutiesRegistService,
                                   ItrxBUSTravelDutiesBookingAccommodationService bookAccomService,
                                   ItrxBUSTravelDutiesBookingAccommodationTravelokaService bookAccomTvlService,
                                   ItrxBUSTravelDutiesBookingAccommodationKIAService bookAccomKiaService,
                                   ItrxBUSTravelDutiesBookingAccommodationRequestService bookAccomRequestService,
                                   ItrxBUSTravelDutiesBookingFlightService bookFlightService,
                                   ItrxBUSTravelDutiesBookingFlightJourneyService bookFlightJourneyService,
                                   ItrxBUSTravelDutiesBookingFlightContactService bookFlightContactService,
                                   ItrxBUSTravelDutiesBookingFlightTravelokaService bookFlightTvlService,
                                   ItrxBUSTravelDutiesBookingFlightKIAService bookFlightKiaService,
                                   ItrxBUSTravelDutiesBookingFlightRequestService bookFlightRequestService,

                                   IvwBUSTravelDutiesBookingAccommodationService vwBookAccomService,
                                   IvwBUSHCTravelDutiesEmployeeService vwTravelDutiesEmployeeService,

                                   ImstEmailService emailService,
                                   IMF_EMPLOYEEService employeeService
                                   ) : this(unitOfWorkFactory, serviceProvider, logger)
        {
            _kiaService = kiaService;
            _tvlService = tvlService;
            _emailService = sendEmailService;

            _otaService = otaService;
            _airportService = airportService;
            _contactMappingService = contactMappingService;
            _tvlConfigService = tvlConfigService;
            _kiaConfigService = kiaConfigService;

            _travelDutiesRegistService = travelDutiesRegistService;
            _bookAccomService = bookAccomService;
            _bookAccomTvlService = bookAccomTvlService;
            _bookAccomKiaService = bookAccomKiaService;
            _bookAccomRequestService = bookAccomRequestService;
            _bookFlightService = bookFlightService;
            _bookFlightJourneyService = bookFlightJourneyService;
            _bookFlightContactService = bookFlightContactService;
            _bookFlightTvlService = bookFlightTvlService;
            _bookFlightKiaService = bookFlightKiaService;
            _bookFlightRequestService = bookFlightRequestService;

            _vwBookAccomService = vwBookAccomService;
            _vwTravelDutiesEmployeeService = vwTravelDutiesEmployeeService;

            _mstEmailService = emailService;
            _employeeService = employeeService;
        }

        public async Task<vmTravelDutiesBookingOTAStatus> BookingOTAFromJson(dtPostBookingOTA param)
        {
            IUnitOfWork uoW = unitOfWorkFactory.Create("TBIGSYSDB01_TBiGSys");
            try
            {
                pAddLogger("Start", "Start Method BookingOTAFromJson");
                await uoW.BeginTransactionAsync();

                pAddLogger("Step 1", "Preparation");
                var travelDuties = await pGetTravelDuties(param.TravelDutiesID);
                if (travelDuties == null)
                    throw new Exception("Travel Duties not found");

                var employee = await pGetEmployeeData(travelDuties.ApplicantID);
                if (employee == null)
                    throw new Exception("Applicant not found");

                var employeeBTA = await pGetEmployeeBTA();
                if (employeeBTA == null)
                    throw new Exception("Business Trip Admin not found");

                var tvlBookType = await pGetConfigTraveloka(TravelokaConfiguration.AccommodationBookingType);
                var tvlDelayBook = await pGetConfigTraveloka(TravelokaConfiguration.DelayBookingFlight);
                var tvlDelayIssued = await pGetConfigTraveloka(TravelokaConfiguration.DelayIssuedFlight);
                var tvlLogPath = await pGetConfigTraveloka(TravelokaConfiguration.LogDocumentPath);

                string host = await pGetConfigKia(KiaConfiguration.HeaderHost);
                var kiaDelayBook = await pGetConfigKia(KiaConfiguration.DelayBookingFlight);
                var kiaDelayIssued = await pGetConfigKia(KiaConfiguration.DelayIssuedFlight);
                var kiaLogPath = await pGetConfigKia(KiaConfiguration.LogDocumentPath);

                var configBooking = new dtPostProcessBooking()
                {
                    UnitofWork = uoW,
                    UserID = employee.Employ_Id_TBGSYS,
                    SchedullerID = param.SchedullerID,

                    TravelokaBookType = tvlBookType,
                    TravelokaLogPath = tvlLogPath,
                    TravelokaDelayBook = tvlDelayBook,
                    TravelokaDelayIssued = tvlDelayIssued,

                    KiaHost = host,
                    KiaLogPath = kiaLogPath,
                    KiaDelayBook = kiaDelayBook,
                    KiaDelayIssued = kiaDelayIssued,
                };

                #region Accommodation
                pAddLogger("Step 2", "Process Booking Accommodation");
                Expression<Func<vwBUSTravelDutiesBookingAccommodation, bool>>
                    filterAccom = x => x.TravelDutiesID == param.TravelDutiesID
                                    && !string.IsNullOrWhiteSpace(x.AccommodationID)
                                    && x.TravelokaBookingStatus == null
                                    && x.KiaBookingStatus == null;
                var bookAccom = await _vwBookAccomService.GetListAsync(filter: filterAccom);

                var taskAccom = bookAccom.Select(item => pProcessBookingAccommodation(configBooking, item));
                var resultAccom = (await Task.WhenAll(taskAccom)).ToList();
                #endregion Accommodation

                #region Flight
                pAddLogger("Step 3", "Process Booking Flight");
                Expression<Func<trxBUSTravelDutiesBookingFlight, bool>>
                    filterView = x => x.trxBUSHCTravelDutiesRegistrationID == param.TravelDutiesID
                                    && x.IsDeleted == false;
                var bookFlight = await _bookFlightService.GetListAsync(filter: filterView);

                var taskFlight = bookFlight.Select(item => pProcessBookingFlight(configBooking, item));
                var resultFlight = (await Task.WhenAll(taskFlight)).ToList();
                #endregion Flight

                #region SaveResult
                pAddLogger("Step 4", "Update Booking Accommodation Request");
                var taskSaveAccom = resultAccom.Where(x => x.StatusCode != (int)HttpStatusCode.NotModified)
                                               .Select(async item =>
                                               {
                                                   var request = await pGetBookingAccommodationRequest(item.BookingAccommodationID);

                                                   request.SchedullerID = param.SchedullerID;
                                                   request.IsSuccess = item.IsSuccess;
                                                   request.Status = item.BookingStatus;

                                                   await _bookAccomRequestService.UpdateAsync(request);
                                               });
                await Task.WhenAll(taskSaveAccom);

                pAddLogger("Step 4", "Update Booking Flight Request");
                var taskSaveFlight = resultFlight.Where(x => x.StatusCode != (int)HttpStatusCode.NotModified)
                                                 .Select(async item =>
                                                 {
                                                     var request = await pGetBookingFlightRequest(item.BookingFlightID);
                                                     request.SchedullerID = param.SchedullerID;
                                                     request.IsSuccess = item.IsSuccess;
                                                     request.Status = item.BookingStatus;

                                                     await _bookFlightRequestService.UpdateAsync(request);
                                                 });
                await Task.WhenAll(taskSaveFlight);

                var AccomTravelAgentIDs = resultAccom.Where(x => x.StatusCode != (int)HttpStatusCode.NotModified).Select(x => x.TravelAgentID);
                var FlightTravelAgentIDs = resultFlight.Where(x => x.StatusCode != (int)HttpStatusCode.NotModified).Select(x => x.TravelAgentID);
                var TravelAgentIDs = AccomTravelAgentIDs.Union(FlightTravelAgentIDs).ToArray();
                var GetTravelAgents = await pGetTravelAgent(TravelAgentIDs);
                var TravelAgents = GetTravelAgents.Select(x => x.TravelAgent);

                pAddLogger("End", "End Method BookingOTAFromJson");

                pAddLogger("TravelDutiesID", travelDuties.ID);
                pAddLogger("TravelDutiesNumber", travelDuties.STDNumber);
                pAddLogger("TravelAgent", string.Join(",", TravelAgents));
                pAddLogger("Applicant", employee.Name);
                pAddLogger("ApplicantEmail", employee.Email);
                pAddLogger("BTAName", employeeBTA.Name);
                pAddLogger("BTAPhone", employeeBTA.Phone);
                pAddLogger("BTAEmail", employeeBTA.Email);
                pAddLogger("ListAccommodation", resultAccom.Where(x => x.StatusCode != (int)HttpStatusCode.NotModified));
                pAddLogger("ListFlight", resultFlight.Where(x => x.StatusCode != (int)HttpStatusCode.NotModified));

                return new vmTravelDutiesBookingOTAStatus()
                {
                    TravelDutiesID = travelDuties.ID,
                    TravelDutiesNumber = travelDuties.STDNumber,
                    TravelAgent = string.Join(",", TravelAgents),
                    Applicant = employee.Name,
                    ApplicantEmail = employee.Email,
                    BTAName = employeeBTA.Name,
                    BTAPhone = employeeBTA.Phone,
                    BTAEmail = employeeBTA.Email,
                    ListAccommodation = resultAccom,
                    ListFlight = resultFlight,
                };

                #endregion SaveResult
            }
            catch (Exception ex)
            {
                await logger.LogException(serviceProvider, ex, param.SchedullerID);
                throw;
            }
            finally
            {
                uoW.Dispose();
            }
        }

        public async Task SendEmail(vmTravelDutiesBookingOTAStatus bookResult, string schedullerID)
        {
            try
            {
                pAddLogger("Start", "Start Method SendEmail");

                pAddLogger("Step 0", "Checking Any Flight / Accommodation Processed");
                //jika tidak ada accom dan flight yg diproses, lewati tahap ini
                //case submit kosongan
                var anyAccom = bookResult.ListAccommodation.Any();
                var anyFlight = bookResult.ListFlight.Any();
                if (!anyAccom && !anyFlight)
                    return;

                pAddLogger("Step 1", "Preparation");
                var EncryptedID = CryptoHelper.EncodeBTOA(Convert.ToString(bookResult.TravelDutiesID));
                var travelAgent = bookResult.TravelAgent;
                var TravelDutiesNumber = bookResult.TravelDutiesNumber;
                var applicant = bookResult.Applicant;
                var applicantEmail = bookResult.ApplicantEmail;

                var btaName = bookResult.BTAName;
                var btaPhone = bookResult.BTAPhone;
                var btaEmail = bookResult.BTAEmail;

                pAddLogger("Step 2", "Generate HTML List Accommodation");
                StringBuilder listAccom = new StringBuilder();
                if (bookResult.ListAccommodation.Any())
                {
                    listAccom.Append("<table width='100%' cellpadding='0' cellspacing='0' border='0' style='margin-top:15px; border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;'>");
                    listAccom.Append("    <tr>");
                    listAccom.Append("        <td style='padding-bottom:5px;'>");
                    listAccom.Append("            <strong>Accommodation</strong>");
                    listAccom.Append("        </td>");
                    listAccom.Append("    </tr>");
                    listAccom.Append("    <tr>");
                    listAccom.Append("        <td>");
                    listAccom.Append("            <table width='100%' cellpadding='0' cellspacing='0' border='0' style='border-collapse:collapse; font-size:13px; mso-table-lspace:0pt; mso-table-rspace:0pt;'>");
                    listAccom.Append("                <tr style='background-color:#ecf0f1;'>");
                    listAccom.Append("	                <th align='left' style='padding:10px;'>Accommodation</th>");
                    listAccom.Append("	                <th align='left' style='padding:10px;'>Room</th>");
                    listAccom.Append("	                <th align='left' style='padding:10px;'>Check In</th>");
                    listAccom.Append("	                <th align='left' style='padding:10px;'>Check Out</th>");
                    listAccom.Append("	                <th align='left' style='padding:10px;'>Status</th>");
                    listAccom.Append("                </tr>");
                    foreach (var item in bookResult.ListAccommodation)
                    {
                        listAccom.Append("        <tr>");
                        listAccom.Append("          <td style='padding:10px; border-top:1px solid #bdc3c7;'>" + item.AcommodationName + "</td>");
                        listAccom.Append("          <td style='padding:10px; border-top:1px solid #bdc3c7;'>" + item.RoomName + "</td>");
                        listAccom.Append("          <td style='padding:10px; border-top:1px solid #bdc3c7;'>" + string.Format("{0: dd MMM yyyy}", item.CheckIn) + "</td>");
                        listAccom.Append("          <td style='padding:10px; border-top:1px solid #bdc3c7;'>" + string.Format("{0: dd MMM yyyy}", item.CheckOut) + "</td>");
                        if (item.IsSuccess == true)
                        {
                            listAccom.Append("          <td style='padding:10px; border-top:1px solid #bdc3c7; color:#27ae60; font-weight:bold;'>Confirmed</td>");
                        }
                        else if (item.IsSuccess == false)
                        {
                            listAccom.Append("          <td style='padding:10px; border-top:1px solid #bdc3c7; color:#e74c3c; font-weight:bold;'>");
                            listAccom.Append("		        <!--[if !mso]>");
                            listAccom.Append("		            <!-- --> Failed &#9432; <span title='" + item.JsonErrMessage + "' style='cursor:help;color:#e74c3c;'> &#9432;</span>");
                            listAccom.Append("		            <!--");
                            listAccom.Append("		        <![endif]-->");
                            listAccom.Append("		        <!--[if mso]>");
                            listAccom.Append("                  Failed - " + item.JsonErrMessage);
                            listAccom.Append("		        <![endif]-->");
                            listAccom.Append("          </td>");
                        }
                        else
                        {
                            listAccom.Append("          <td style='padding:10px; border-top:1px solid #bdc3c7; color:#ff8000; font-weight:bold;'>Pending</td>");
                        }
                        listAccom.Append("        </tr>");
                    }
                    listAccom.Append("            </table>");
                    listAccom.Append("        </td>");
                    listAccom.Append("    </tr>");
                    listAccom.Append("</table>");
                }

                pAddLogger("Step 3", "Generate HTML List Flight");
                StringBuilder listFlight = new StringBuilder();
                if (bookResult.ListFlight.Any())
                {
                    listFlight.Append("<table width='100%' cellpadding='0' cellspacing='0' border='0' style='margin-top:25px; border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;'>");
                    listFlight.Append("	<tr>");
                    listFlight.Append("		<td style='padding-bottom:5px;'>");
                    listFlight.Append("			<strong>Flight</strong>");
                    listFlight.Append("		</td>");
                    listFlight.Append("	</tr>");
                    listFlight.Append("	<tr>");
                    listFlight.Append("		<td>");
                    listFlight.Append("			<table width='100%' cellpadding='0' cellspacing='0' border='0' style='border-collapse:collapse; font-size:13px; mso-table-lspace:0pt; mso-table-rspace:0pt;'>");
                    listFlight.Append("				<tr style='background-color:#ecf0f1;'>");
                    listFlight.Append("					<th align='left' style='padding:10px;'>From</th>");
                    listFlight.Append("					<th align='left' style='padding:10px;'>To</th>");
                    listFlight.Append("					<th align='left' style='padding:10px;'>Flight Date</th>");
                    listFlight.Append("					<th align='left' style='padding:10px;'>Airline</th>");
                    listFlight.Append("					<th align='left' style='padding:10px;'>FlightCode</th>");
                    listFlight.Append("					<th align='left' style='padding:10px;'>BookingStatus</th>");
                    listFlight.Append("				</tr>");
                    foreach (var item in bookResult.ListFlight)
                    {
                        var journey = await pGetBookingFlightJourney(item.BookingFlightID);
                        var airline = journey.Select(x => x.AirlineName).Distinct().ToArray();
                        var flightCode = journey.Select(x => x.FlightCode).ToArray();
                        var origin = await pGetAirport(item.AirportOriginCode);
                        var destination = await pGetAirport(item.AirportDestinationCode);
                        var airportOrigin = origin != null ? origin.Airport + "(" + origin.AirportCode + ")" : item.AirportOriginCode;
                        var airportDestination = destination != null ? destination.Airport + "(" + destination.AirportCode + ")" : item.AirportDestinationCode;
                        listFlight.Append("        <tr>");
                        listFlight.Append("          <td style='padding:10px; border-top:1px solid #bdc3c7;'>" + airportOrigin + "</td>");
                        listFlight.Append("          <td style='padding:10px; border-top:1px solid #bdc3c7;'>" + airportDestination + "</td>");
                        listFlight.Append("          <td style='padding:10px; border-top:1px solid #bdc3c7;'>" + string.Format("{0: dd MMM yyyy}", item.FlightDate) + "</td>");
                        listFlight.Append("          <td style='padding:10px; border-top:1px solid #bdc3c7;'>" + string.Join(", ", airline) + "</td>");
                        listFlight.Append("          <td style='padding:10px; border-top:1px solid #bdc3c7;'>" + string.Join(", ", flightCode) + "</td>");
                        if (item.IsSuccess == true)
                        {
                            listFlight.Append("          <td style='padding:10px; border-top:1px solid #bdc3c7; color:#27ae60; font-weight:bold;'>Confirmed</td>");
                        }
                        else if (item.IsSuccess == false)
                        {
                            listFlight.Append("          <td style='padding:10px; border-top:1px solid #bdc3c7; color:#e74c3c; font-weight:bold;'>");
                            listFlight.Append("				<!--[if !mso]>");
                            listFlight.Append("					<!-- --> Failed <span title='" + item.JsonErrMessage + "' style='cursor:help;color:#e74c3c;'> &#9432;</span>");
                            listFlight.Append("				    <!--");
                            listFlight.Append("				<![endif]-->");
                            listFlight.Append("				<!--[if mso]>");
                            listFlight.Append("			        Failed - " + item.JsonErrMessage);
                            listFlight.Append("				<![endif]-->");
                            listFlight.Append("          </td>");
                        }
                        else
                        {
                            listFlight.Append("          <td style='padding:10px; border-top:1px solid #bdc3c7; color:#ff8000; font-weight:bold;'>Pending</td>");
                        }
                        listFlight.Append("        </tr>");
                    }
                    listFlight.Append("			</table>");
                    listFlight.Append("		</td>");
                    listFlight.Append("	</tr>");
                    listFlight.Append("</table>");
                }

                pAddLogger("Step 4", "Get Template");
                var getTemplate = await GetTemplate((int)EmailID.EmailBookingOTA);
                var templateSubject = getTemplate.Subject;
                var templateBody = getTemplate.Body;
                var subject = string.Format(templateSubject, TravelDutiesNumber);


                pAddLogger("Step 5", "Generate Email Body");
                var template = Handlebars.Compile(templateBody);
                var data = new
                {
                    TravelDutiesNumber = TravelDutiesNumber,
                    TravelAgent = travelAgent,
                    Applicant = applicant,
                    BTAName = btaName,
                    BTAPhone = btaPhone,
                    ListAccommodation = listAccom,     // HTML string
                    ListFlight = listFlight,   // HTML string
                    EncryptedID = EncryptedID
                };

                var htmlBody = template(data);

                pAddLogger("Step 6", "Sending Email");
                var message = new RabbitMQMessage()
                {
                    ApplicationID = (int)RabbitMQApplicationID.TBIGSys,
                    Module = "Travel Duties(STD)",
                    Subject = subject,
                    TemplateCode = null,
                    To = new List<string>() { applicantEmail },
                    CC = new List<string>() { btaEmail },
                    BCC = new List<string>() { "hendry.simanjuntak@tower-bersama.com" },
                    //Dev
                    //To = new List<string>() { "guruh.suananda@tower-bersama.com" },
                    //CC = new List<string>(),
                    //BCC = new List<string>(),
                    Attachment = new List<string>(),
                    HTMLBody = htmlBody
                };
                _emailService.SendEmail(message);

                pAddLogger("End", "End Method SendEmail");
            }
            catch (Exception ex)
            {
                await logger.LogException(serviceProvider, ex, schedullerID);
                throw;
            }
        }

        public async Task TestEmail(dtPostBookingOTA param)
        {
            try
            {
                var getTemplate = await GetTemplate((int)EmailID.EmailBookingOTA);
                var templateSubject = getTemplate.Subject;
                var templateBody = getTemplate.Body;

                string listAccom = @"
                                    <table width='100%' cellpadding='0' cellspacing='0' border='0' style='margin-top:15px; border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;'>
						                <tr>
							                <td style='padding-bottom:5px;'>
								                <strong>Accommodation</strong>
							                </td>
						                </tr>
						                <tr>
							                <td>
								                <table width='100%' cellpadding='0' cellspacing='0' border='0' style='border-collapse:collapse; font-size:13px; mso-table-lspace:0pt; mso-table-rspace:0pt;'>
									                <tr style='background-color:#ecf0f1;'>
										                <th align='left' style='padding:10px;'>Accommodation</th>
										                <th align='left' style='padding:10px;'>Room</th>
										                <th align='left' style='padding:10px;'>Check In</th>
										                <th align='left' style='padding:10px;'>Check Out</th>
										                <th align='left' style='padding:10px;'>Status</th>
									                </tr>
									                <tr>
										                <td style='padding:10px; border-top:1px solid #bdc3c7;'>Bali Island Villas & Spa</td>
										                <td style='padding:10px; border-top:1px solid #bdc3c7;'>Villa 1 bedroom - Pool</td>
										                <td style='padding:10px; border-top:1px solid #bdc3c7;'> 07 Oct 2025</td>
										                <td style='padding:10px; border-top:1px solid #bdc3c7;'> 08 Oct 2025</td>
										                <td style='padding:10px; border-top:1px solid #bdc3c7; color:#e74c3c; font-weight:bold;'>
											            <!--[if !mso]>
											                <!-- --> Failed &#9432; <span title='Expired correlation ID. Valid only for 60 minutes after creation.'></span>
											                <!--
											            <![endif]-->
											            <!--[if mso]>
				                                            Failed - Expired correlation ID (valid for 60 minutes)
											            <![endif]-->
										                </td>
									                </tr>
								                </table>
							                </td>
						                </tr>
					                </table>
                                ";

                string listFlight = @"
                                    <table width='100%' cellpadding='0' cellspacing='0' border='0' style='margin-top:25px; border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;'>
						                <tr>
							                <td style='padding-bottom:5px;'>
								                <strong>Flight</strong>
							                </td>
						                </tr>
						                <tr>
							                <td>
								                <table width='100%' cellpadding='0' cellspacing='0' border='0' style='border-collapse:collapse; font-size:13px; mso-table-lspace:0pt; mso-table-rspace:0pt;'>
									                <tr style='background-color:#ecf0f1;'>
										                <th align='left' style='padding:10px;'>From</th>
										                <th align='left' style='padding:10px;'>To</th>
										                <th align='left' style='padding:10px;'>Flight Date</th>
										                <th align='left' style='padding:10px;'>Airline</th>
										                <th align='left' style='padding:10px;'>FlightCode</th>
										                <th align='left' style='padding:10px;'>BookingStatus</th>
									                </tr>
									                <tr>
										                <td style='padding:10px; border-top:1px solid #bdc3c7;'>Soekarno Hatta(CGK)</td>
										                <td style='padding:10px; border-top:1px solid #bdc3c7;'>Ngurah Rai International Airport(DPS)</td>
										                <td style='padding:10px; border-top:1px solid #bdc3c7;'> 07 Oct 2025</td>
										                <td style='padding:10px; border-top:1px solid #bdc3c7;'>Lion</td>
										                <td style='padding:10px; border-top:1px solid #bdc3c7;'>JT 690, JT 990</td>
										                <td style='padding:10px; border-top:1px solid #bdc3c7; color:#e74c3c; font-weight:bold;'>
											            <!--[if !mso]>
											                <!-- --> Failed &#9432; <span title='This flight is already booked.'></span>
											            <!--
											            <![endif]-->
											            <!--[if mso]>
				                                            Failed - This flight is already booked
											            <![endif]-->
										                </td>
									                </tr>
								                </table>
							                </td>
						                </tr>
					                </table>
                                ";

                string htmlContent = @"
                    <table width='100%' cellpadding='0' cellspacing='0' border='0' style='background-color:#f4f6f8; font-family:Arial, sans-serif; mso-table-lspace:0pt; mso-table-rspace:0pt;'>
                       <tr>
	                       <td align='center'>
		                       <table width='600' cellpadding='0' cellspacing='0' border='0' style='background-color:#ffffff; border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;'>
			                       <!-- Header -->
			                       <tr>
				                       <td align='center' style='background-color:#08429f; padding:20px;'>
					                       <img src='https://vendregdev.tower-bersama.com/storage/tbig-logo.png' alt='Tower Bersama Group Logo' width='150' style='display:block; border:0; outline:none; text-decoration:none;' />
				                       </td>
			                       </tr>
			                       <!-- Content -->
			                       <tr>
				                       <td style='padding:20px; color:#2c3e50; font-size:14px; line-height:20px;'>
					                       <h2 style='margin:0; color:#2c3e50;'>Travel Booking Confirmation</h2>
					                       <p style='margin:10px 0;'>Reference Number: <strong>{{TravelDutiesNumber}}</strong>
					                       </p>
					                       <p style='margin:10px 0;'>Travel Agent: <strong>{{TravelAgent}}</strong>
					                       </p>
					                       <p style='margin:20px 0 10px 0;'>Dear <strong>{{Applicant}}</strong>, </p>
					                       <p style='margin:10px 0;'> Below is the OTA booking result for your Travel Duties. If any status is marked as <span style='color:#e74c3c; font-weight:bold;'>[Failed]</span>, please contact Business Trip Administration (<a href='http://wa.me/{{BTAPhone}}'>{{BTAName}}</a>) for manual booking assistance. </p>
					                       <!-- Accoomodation Section -->
					                       {{{ListAccommodation}}}
					                       <!-- Flight Section -->
					                       {{{ListFlight}}}
					                       <!-- Separator -->
					                       <table width='100%' cellpadding='0' cellspacing='0' border='0' style='margin:30px 0 25px 0; border-collapse:collapse;'>
						                       <tr>
							                       <td style='border-top:1px solid #dcdcdc; line-height:1px; height:1px;'>&nbsp;</td>
						                       </tr>
					                       </table>
					                       <!-- Buttons -->
					                       <table align='center' cellpadding='0' cellspacing='0' border='0' style='margin-top:10px;'>
                                                <tr>
                                                    <td align='center'>
                                                        <!--[if mso]>
									                        <v:roundrect
										                        xmlns:v='urn:schemas-microsoft-com:vml'
										                        xmlns:w='urn:schemas-microsoft-com:office:word'
                                                                href='https://tbigsystem.tower-bersama.com/BusinessSupport/TravelDuties/List'
                                                                style='height:40px;v-text-anchor:middle;width:220px;' arcsize='10%' stroke='f' fillcolor='#08429f'>
										                        <w:anchorlock/>
										                        <center style='color:#ffffff;font-family:Arial,sans-serif;font-size:13px;font-weight:bold;'>
                                                                  View All Submission
                                                                </center>
									                        </v:roundrect>
									                    <![endif]-->
                                                        <!--[if !mso]>
									                        <!-- -->
                                                            <a href='https://tbigsystem.tower-bersama.com/BusinessSupport/TravelDuties/List' style='background-color:#08429f; color:#ffffff; display:inline-block; font-family:Arial,sans-serif;
                                                                font-size:13px; font-weight:bold; line-height:40px; text-align:center; text-decoration:none;
                                                                width:220px; border-radius:5px;'>View All Submission</a>
                                                            <!--
									                    <![endif]-->
                                                        </td>
                                                        <td width='10'></td>
                                                        <td align='center'>
                                                        <!--[if mso]>
									                        <v:roundrect
										                        xmlns:v='urn:schemas-microsoft-com:vml'
										                        xmlns:w='urn:schemas-microsoft-com:office:word'
                                                                href='https://tbigsystem.tower-bersama.com/BusinessSupport/TravelDuties/DetailRealization/EncryptedID'
                                                                style='height:40px;v-text-anchor:middle;width:220px;' arcsize='10%' stroke='f' fillcolor='#08429f'>
										                        <w:anchorlock/>
										                        <center style='color:#ffffff;font-family:Arial,sans-serif;font-size:13px;font-weight:bold;'>
                                                                  View Current Submission
                                                                </center>
									                        </v:roundrect>
									                    <![endif]-->
                                                        <!--[if !mso]>
									                    <!-- -->
                                                        <a href='https://tbigsystem.tower-bersama.com/BusinessSupport/TravelDuties/DetailRealization/EncryptedID' style='background-color:#08429f; color:#ffffff; display:inline-block; font-family:Arial,sans-serif;
                                                            font-size:13px; font-weight:bold; line-height:40px; text-align:center; text-decoration:none;
                                                            width:220px; border-radius:5px;'>View Current Submission</a>
                                                        <!--
									                    <![endif]-->
                                                    </td>
                                                </tr>
                                           </table>
				                       </td>
			                       </tr>
			                       <!-- Footer -->
			                       <tr>
				                       <td style='background-color:#f4f6f8; text-align:center; font-size:12px; color:#7f8c8d; padding:20px;'>
					                       <hr style='border:none; border-top:1px solid #dcdcdc; margin-bottom:15px;'>
					                       <p>
						                       <strong style='color:#08429f;'>TBiGSys Notification</strong>
					                       </p>
					                       <p>
						                       <em>This is an automated email generated by <strong>TBiGSys</strong>, Tower Bersama Group's Business Travel System. </em>
					                       </p>
					                       <p>© 2025 Tower Bersama Group. All rights reserved.</p>
					                       <p>
						                       <a href='https://www.tower-bersama.com' style='color:#08429f; text-decoration:none;'>www.tower-bersama.com</a>
					                       </p>
					                       <p style='margin-top:15px; font-size:11px; color:#2c3e50;'>Please consider the environment before printing this email.</p>
				                       </td>
			                       </tr>
		                       </table>
	                       </td>
                       </tr>
                    </table>
                    ";

                var subject = string.Format(templateSubject, "TravelDutiesNumber");
                var template = Handlebars.Compile(htmlContent);

                var data = new
                {
                    TravelDutiesNumber = "TravelDutiesNumber",
                    TravelAgent = "travelAgent",
                    Applicant = "applicant",
                    BTAName = "btaName",
                    BTAPhone = "btaPhone",
                    ListAccommodation = listAccom,     // HTML string
                    ListFlight = listFlight,   // HTML string
                    EncryptedID = "EncryptedID"
                };

                var htmlBody = template(data);

                var message = new RabbitMQMessage()
                {
                    ApplicationID = (int)RabbitMQApplicationID.TBIGSys,
                    Module = "Travel Duties(STD)",
                    Subject = subject,
                    TemplateCode = null,
                    To = new List<string>() { "guruh.suananda@tower-bersama.com" },
                    CC = new List<string>(),
                    BCC = new List<string>(),
                    Attachment = new List<string>(),
                    HTMLBody = htmlBody
                };
                _emailService.SendEmail(message);
            }
            catch (Exception ex)
            {
                await logger.LogException(serviceProvider, ex, param.SchedullerID);
                throw;
            }
        }

        #region Get Data
        private async Task<mstEmail> GetTemplate(int emailID)
        {
            var email = await _mstEmailService.GetListAsync(x => x.MstEmailID == emailID);
            return email.FirstOrDefault() ?? new mstEmail();
        }

        private async Task<IEnumerable<mstBUSTravelAgent>> pGetTravelAgent(int[] TravelAgentIDs)
        {
            var _aData = await _otaService.GetListAsync(filter: x => TravelAgentIDs.Contains(x.ID));
            return _aData;
        }

        private async Task<MF_EMPLOYEE> pGetEmployeeData(string employeeID)
        {
            var _aEmployee = await _employeeService.GetListAsync(filter: x => x.Employ_Id == employeeID && x.Resign_status == "N");
            var employee = _aEmployee.FirstOrDefault();
            return employee;
        }

        private async Task<MF_EMPLOYEE> pGetEmployeeBTA()
        {
            var contactMapping = await _contactMappingService.GetListAsync(x => x.IsActive);
            var btaJobTitle = contactMapping.FirstOrDefault();

            if (btaJobTitle != null)
            {
                var _aEmployee = await _employeeService.GetListAsync(filter: x => x.JobTitleID == btaJobTitle.JobTitleID && x.Resign_status == "N");
                return _aEmployee.FirstOrDefault();
            }
            else
            {
                var _aEmployee = await _employeeService.GetListAsync(filter: x => x.Employ_Id == "200803180358" && x.Resign_status == "N");
                return _aEmployee.FirstOrDefault();
            }
        }

        private async Task<mstBUSTravelDutiesAirport> pGetAirport(string airportCode)
        {
            var airport = await _airportService.GetListAsync(filter: x => x.AirportCode == airportCode && x.IsActive);
            return airport.FirstOrDefault();
        }

        private async Task<trxBUSHCTravelDutiesRegistration> pGetTravelDuties(long ID)
        {
            var _aTravelDuties = await _travelDutiesRegistService.GetListAsync(filter: x => x.ID == ID);
            return _aTravelDuties.FirstOrDefault();
        }

        private async Task<trxBUSTravelDutiesBookingAccommodationRequest> pGetBookingAccommodationRequest(int bookingAccomID)
        {
            var _aJourney = await _bookAccomRequestService.GetListAsync(filter: x => x.trxBUSTravelDutiesBookingAccommodationID == bookingAccomID && !x.IsDeleted);
            return _aJourney.FirstOrDefault();
        }

        private async Task<trxBUSTravelDutiesBookingAccommodationTraveloka> pGetBookingAccommodationTraveloka(int bookingAccomID)
        {
            var _aTraveloka = await _bookAccomTvlService.GetListAsync(filter: x => x.trxBUSTravelDutiesBookingAccommodationID == bookingAccomID && !x.IsDeleted);
            var traveloka = _aTraveloka.FirstOrDefault();
            return traveloka;
        }

        private async Task<trxBUSTravelDutiesBookingAccommodationKIA> pGetBookingAccommodationKia(int bookingAccomID)
        {
            var _aTraveloka = await _bookAccomKiaService.GetListAsync(filter: x => x.trxBUSTravelDutiesBookingAccommodationID == bookingAccomID && !x.IsDeleted);
            var traveloka = _aTraveloka.FirstOrDefault();
            return traveloka;
        }

        private async Task<trxBUSTravelDutiesBookingFlightRequest> pGetBookingFlightRequest(int bookingFlightID)
        {
            var _aJourney = await _bookFlightRequestService.GetListAsync(filter: x => x.trxBUSTravelDutiesBookingFlightID == bookingFlightID && !x.IsDeleted);
            return _aJourney.FirstOrDefault();
        }

        private async Task<IEnumerable<trxBUSTravelDutiesBookingFlightJourney>> pGetBookingFlightJourney(int bookingFlightID)
        {
            var _aJourney = await _bookFlightJourneyService.GetListAsync(filter: x => x.trxBUSTravelDutiesBookingFlightID == bookingFlightID && !x.IsDeleted);
            return _aJourney;
        }

        private async Task<trxBUSTravelDutiesBookingFlightTraveloka> pGetBookingFlightTraveloka(int bookingFlightID)
        {
            var _aTraveloka = await _bookFlightTvlService.GetListAsync(filter: x => x.trxBUSTravelDutiesBookingFlightID == bookingFlightID && !x.IsDeleted);
            var traveloka = _aTraveloka.FirstOrDefault();
            return traveloka;
        }

        private async Task<trxBUSTravelDutiesBookingFlightKIA> pGetBookingFlightKia(int bookingFlightID)
        {
            var _aKia = await _bookFlightKiaService.GetListAsync(filter: x => x.trxBUSTravelDutiesBookingFlightID == bookingFlightID && !x.IsDeleted);
            var kia = _aKia.FirstOrDefault();
            return kia;
        }

        private string pFixPhoneNumber(string phoneNumber)
        {
            var trim = phoneNumber.Trim();
            var _1digit = trim.Substring(0, 1);
            var _2digit = trim.Substring(0, 2);
            var _3digit = trim.Substring(0, 3);

            //var phoneNumber = empData.HP_No;
            if (_2digit == "62")
            {
                //Remove 2 digit awal dan isi 0;
                return "0" + trim.Substring(2, trim.Length - 2);
            }
            if (_3digit == "+62")
            {
                return "0" + trim.Substring(3, trim.Length - 3);
            }
            if (_1digit != "0")
            {
                return "0" + trim;
            }
            return trim;

        }

        private void pAddLogger(string LogName, object LogData)
        {
            logger.LogInformation(LogName, LogData);
            Console.WriteLine(string.Format("[{0}] {1}", LogName, LogData));
        }
        #endregion Get Data

        #region Processing
        private async Task<vmTravelDutiesBookingAccommodationStatus> pProcessBookingAccommodation(dtPostProcessBooking parameter, vwBUSTravelDutiesBookingAccommodation item)
        {
            /*------------
             *Step Booking
             *------------
             *  1. Set Total Booking(Accommodation + Flight)
             *  2. Booking
             *  3. Check Status
             *      -Jika Booking Gagal, Retry sejumlah x dengan delay 1 * loop increment. 
             *          Jika sampai Jumlah max masih gagal, Set Status Failed untuk bookingan ini
             *      -Jika Berhasil, lanjut Step 4
             *  4. Issued
             *  5. Check Status
             *      -Jika Issued Gagal, Retry sejumlah x dengan delay 5 x loop increment
             *          Jika sampai Jumlah max masih gagal, Set Status Failed untuk bookingan ini
             *      -Jika Issued, Set Status Success untuk bookingan ini
             *  6. Setelah semua Bookingan selesai dilakukan, kumpulkan yang mana yang berhasil dan yang mana yang gagal
             *  7. Infokan bookingan berhasil dan gagal kepada user melalui email
             *  8. DONE
             */

            var accomStatus = new vmTravelDutiesBookingAccommodationStatus()
            {
                TravelDutiesID = item.TravelDutiesID,
                ApplicantID = item.ApplicantID,
                OtherTravelDutiesID = item.OtherTravelDutiesID,
                OtherApplicantID = item.ShareRoomID,
                BookingAccommodationID = Convert.ToInt32(item.BookingAccommodationID),
                AcommodationID = item.AccommodationID,
                AcommodationName = item.AccommodationName,
                RoomName = item.RoomName,
                CheckIn = Convert.ToDateTime(item.CheckIn),
                CheckOut = Convert.ToDateTime(item.CheckOut),
                TravelAgentID = Convert.ToInt32(item.TravelAgentID),
                TravelAgent = item.TravelAgent,
            };

            var uoW = parameter.UnitofWork;
            var userID = parameter.UserID;
            try
            {
                decimal Total = 0;
                int bookingAccommodationID = Convert.ToInt32(item.BookingAccommodationID);

                pAddLogger("Step 2", "Get Booking Accommodation Request");
                var request = await pGetBookingAccommodationRequest(bookingAccommodationID);
                if (!string.IsNullOrEmpty(request.Status))
                {
                    accomStatus.StatusCode = (int)HttpStatusCode.NotModified;
                    accomStatus.IsSuccess = null;
                    accomStatus.BookingStatus = "This Accommodation is already processed";

                    return accomStatus;
                }

                var confirmJson = request.ConfirmJson;
                var issuedJson = request.IssuedJson;

                if (item.TravelAgentID == Convert.ToInt32(OnlineTravelAgent.Traveloka))
                {
                    pAddLogger("Step 2", "Get Booking Accommodation Traveloka");
                    var baTraveloka = await pGetBookingAccommodationTraveloka(bookingAccommodationID);
                    if (baTraveloka != null && !string.IsNullOrEmpty(baTraveloka.BookingID))
                    {
                        accomStatus.StatusCode = (int)HttpStatusCode.NotModified;
                        accomStatus.IsSuccess = null;
                        accomStatus.BookingStatus = "This Accommodation is already booked";

                        return accomStatus;
                    }

                    if (parameter.TravelokaBookType == "1")
                    {
                        pAddLogger("Step 2", "1 Step Booking Accommodation Traveloka");

                        pAddLogger("Step 2", "Create Booking");
                        var bookParam = JsonConvert.DeserializeObject<vmAccomAffiliateBookingAPISpec>(confirmJson);
                        var dtPostBooking = new dtPostApi<vmAccomAffiliateBookingAPISpec>()
                        {
                            BookingCoreID = bookingAccommodationID,
                            UserID = userID,
                            SchedullerID = parameter.SchedullerID,
                            LogPath = parameter.TravelokaLogPath,
                            Model = bookParam
                        };
                        var submit = await _tvlService.CreateBooking(uoW, dtPostBooking);
                        if (submit.ErrorType != (int)Helper.Helper.ErrorType.None)
                            throw new Exception(submit.ErrorMessage);

                        #region GetSubmitData
                        var bookingId = submit.bookingId;
                        var itineraryId = submit.itineraryId;
                        var status = submit.status;
                        Total = submit.totalChargeableRate != null ? Convert.ToDecimal(submit.totalChargeableRate.amount) : 0;
                        #endregion GetSubmitData

                        pAddLogger("Step 2", "Check Status");
                        var paramItin = await pGenerateParameterViewItineraryTraveloka(uoW, item.TravelokaConfirmationID, parameter.SchedullerID);
                        var dtPostItin = new dtPostApi<vmAccomAffiliateViewItinerariesSpec>
                        {
                            BookingCoreID = bookingAccommodationID,
                            UserID = userID,
                            SchedullerID = parameter.SchedullerID,
                            LogPath = parameter.TravelokaLogPath,
                            Model = paramItin
                        };
                        var itinerary = await pLoopCheckAccommodationStatusTraveloka(uoW, dtPostItin, Convert.ToInt32(parameter.TravelokaDelayBook)); //Delay 1 minute

                        pAddLogger("Step 2", "Update Booking Accommodation Traveloka");
                        var asBookTvl = await _bookAccomTvlService.GetListAsync(filter: f => f.trxBUSTravelDutiesBookingAccommodationID == item.BookingAccommodationID);
                        var bookTraveloka = asBookTvl.FirstOrDefault();
                        bookTraveloka.BookingID = itinerary.BookingID;
                        bookTraveloka.ItineraryID = itinerary.ItineraryID;
                        bookTraveloka.BookingStatus = itinerary.Status;
                        bookTraveloka.IsDeleted = false;
                        bookTraveloka.UpdatedBy = "Data Integration";
                        bookTraveloka.UpdatedDate = DateTime.Now;
                        await _bookAccomTvlService.UpdateAsync(bookTraveloka);

                        pAddLogger("Step 2", "Update Booking Accommodation");
                        var asBook = await _bookAccomService.GetListAsync(filter: f => f.ID == item.BookingAccommodationID);
                        var book = asBook.FirstOrDefault();
                        book.Total = Total;
                        book.IsDeleted = false;
                        book.UpdatedBy = "Data Integration";
                        book.UpdatedDate = DateTime.Now;
                        await _bookAccomService.UpdateAsync(book);

                        pAddLogger("Step 2", "Set Result");
                        accomStatus.StatusCode = (int)HttpStatusCode.OK;
                        accomStatus.BookingStatus = itinerary.Status;
                        accomStatus.IsSuccess = itinerary.IsSuccess;
                        accomStatus.JsonErrMessage = itinerary.Status;
                    }
                    else if (parameter.TravelokaBookType == "2")
                    {
                        pAddLogger("Step 2", "2 Step Booking Accommodation Traveloka");

                    }
                }
                else if (item.TravelAgentID == Convert.ToInt32(OnlineTravelAgent.KIA))
                {
                    pAddLogger("Step 2", "Get Booking Accommodation KIA");
                    var baKia = await pGetBookingAccommodationKia(bookingAccommodationID);
                    if (baKia != null && !string.IsNullOrEmpty(baKia.BookingID))
                    {
                        accomStatus.StatusCode = (int)HttpStatusCode.NotModified;
                        accomStatus.IsSuccess = null;
                        accomStatus.BookingStatus = "This Accommodation is already booked";
                        accomStatus.JsonErrMessage = "This Accommodation is already booked";

                        return accomStatus;
                    }

                    pAddLogger("Step 2", "Hotel Confirmation");
                    var pConfirm = JsonConvert.DeserializeObject<vmRequestHotelConfirmation>(confirmJson);
                    var dtPostConfirmation = new dtPostApi<vmRequestHotelConfirmation>()
                    {
                        BookingCoreID = bookingAccommodationID,
                        Host = parameter.KiaHost,
                        UserID = userID,
                        SchedullerID = parameter.SchedullerID,
                        LogPath = parameter.KiaLogPath,
                        Model = pConfirm,
                    };

                    var confirmation = await _kiaService.HotelConfirmation(uoW, dtPostConfirmation);
                    if (confirmation.ErrorType != (int)Helper.Helper.ErrorType.None)
                        throw new Exception(confirmation.ErrorMessage);
                    if (confirmation.IsError)
                        throw new Exception(confirmation.Message);

                    #region getConfirmData
                    var confirmationID = confirmation.Confirmation.ConfirmationId;
                    Total = Convert.ToDecimal(confirmation.Confirmation.TotalPrice);

                    var pIssued = JsonConvert.DeserializeObject<vmRequestHotelIssued>(issuedJson);
                    pIssued.ConfirmationId = confirmationID;
                    #endregion getConfirmData

                    await Task.Delay(Convert.ToInt32(parameter.KiaDelayBook));

                    pAddLogger("Step 2", "Hotel Issued");
                    var dtPostIssued = new dtPostApi<vmRequestHotelIssued>()
                    {
                        BookingCoreID = bookingAccommodationID,
                        Host = parameter.KiaHost,
                        UserID = userID,
                        SchedullerID = parameter.SchedullerID,
                        LogPath = parameter.KiaLogPath,
                        Model = pIssued,
                    };
                    var issued = await _kiaService.HotelIssued(uoW, dtPostIssued);
                    if (issued.ErrorType != (int)Helper.Helper.ErrorType.None)
                        throw new Exception(issued.ErrorMessage);
                    if (issued.IsError)
                        throw new Exception(issued.Message);

                    #region getIssuedData
                    var pnrID = issued.PnrId;

                    item.KiaPnrID = pnrID;
                    #endregion getIssuedData

                    pAddLogger("Step 2", "Check Status");
                    var dtPostCheckAccom = new dtPostApi<string>()
                    {
                        BookingCoreID = bookingAccommodationID,
                        Host = parameter.KiaHost,
                        UserID = userID,
                        SchedullerID = parameter.SchedullerID,
                        LogPath = parameter.KiaLogPath,
                        Model = item.KiaPnrID,
                    };
                    var reservation = await pLoopCheckAccommodationStatusKia(uoW, dtPostCheckAccom, Convert.ToInt32(parameter.KiaDelayIssued));

                    pAddLogger("Step 2", "Update Booking Accommodation KIA");
                    var asBookKia = await _bookAccomKiaService.GetListAsync(filter: f => f.trxBUSTravelDutiesBookingAccommodationID == item.BookingAccommodationID);
                    var bookKia = asBookKia.FirstOrDefault();
                    bookKia.ConfirmationID = confirmationID;
                    bookKia.BookingID = reservation.BookingID;
                    bookKia.BookingCode = reservation.BookingCode;
                    bookKia.BookingStatus = reservation.Status;
                    bookKia.PnrID = pnrID;
                    bookKia.IsDeleted = false;
                    bookKia.UpdatedBy = "Data Integration";
                    bookKia.UpdatedDate = DateTime.Now;
                    await _bookAccomKiaService.UpdateAsync(bookKia);

                    pAddLogger("Step 2", "Update Booking Accommodation");
                    var asBook = await _bookAccomService.GetListAsync(filter: f => f.ID == item.BookingAccommodationID);
                    var book = asBook.FirstOrDefault();
                    book.Total = Total;
                    book.IsDeleted = false;
                    book.UpdatedBy = "Data Integration";
                    book.UpdatedDate = DateTime.Now;
                    await _bookAccomService.UpdateAsync(book);

                    pAddLogger("Step 2", "Set Result");
                    accomStatus.StatusCode = (int)HttpStatusCode.OK;
                    accomStatus.BookingStatus = reservation.Status;
                    accomStatus.IsSuccess = reservation.IsSuccess;
                    accomStatus.JsonErrMessage = reservation.Status;
                }
            }
            catch (ApiException ex)
            {
                pAddLogger("[ApiException]Step 2", "Set Result");

                accomStatus.StatusCode = (int)ex.StatusCode;
                accomStatus.ErrorMessage = ex.Message;
                accomStatus.BookingStatus = "Failed";
                accomStatus.IsSuccess = false;

                if (item.TravelAgentID == Convert.ToInt32(OnlineTravelAgent.Traveloka))
                {
                    pAddLogger("[ApiException]Step 2", "Get JsonError Traveloka");
                    try
                    {
                        var data = JsonConvert.DeserializeObject<vmAccomResponseException>(ex.JsonError);
                        accomStatus.JsonErrMessage = data.message;

                        if (data.message == Convert.ToString(TravelokaAccommodationBookingStatus.PENDING))
                            accomStatus.IsSuccess = null;
                    }
                    catch (JsonSerializationException)
                    {
                        accomStatus.JsonErrMessage = ex.JsonError;
                    }
                    catch (Exception)
                    {
                        accomStatus.JsonErrMessage = ex.JsonError;
                    }
                }
                //untuk KIA akan dicatch di Exception

            }
            catch (Exception ex)
            {
                pAddLogger("[ApiException]Step 2", "Set Result");
                accomStatus.ErrorMessage = ex.Message;
                accomStatus.BookingStatus = "Failed";
                accomStatus.IsSuccess = false;
                accomStatus.JsonErrMessage = ex.Message;
            }

            await uoW.SaveChangesAsync();
            return accomStatus;
        }

        private async Task<vmTravelDutiesBookingFlightStatus> pProcessBookingFlight(dtPostProcessBooking parameter, trxBUSTravelDutiesBookingFlight item)
        {

            /*------------
             *Step Booking
             *------------
             *  1. Set Total Booking(Accommodation + Flight)
             *  2. Booking
             *  3. Check Status
             *      -Jika Booking Gagal, Retry sejumlah x dengan delay 1 * loop increment. 
             *          Jika sampai Jumlah max masih gagal, Set Status Failed untuk bookingan ini
             *      -Jika Berhasil, lanjut Step 4
             *  4. Issued
             *  5. Check Status
             *      -Jika Issued Gagal, Retry sejumlah x dengan delay 5 x loop increment
             *          Jika sampai Jumlah max masih gagal, Set Status Failed untuk bookingan ini
             *      -Jika Issued, Set Status Success untuk bookingan ini
             *  6. Setelah semua Bookingan selesai dilakukan, kumpulkan yang mana yang berhasil dan yang mana yang gagal
             *  7. Infokan bookingan berhasil dan gagal kepada user melalui email
             *  8. DONE
             */
            var flightStatus = new vmTravelDutiesBookingFlightStatus()
            {
                TravelDutiesID = item.trxBUSHCTravelDutiesRegistrationID,
                //ApplicantID = item.ApplicantID,
                BookingFlightID = item.ID,
                AirportOriginCode = item.AirportOrigin,
                //AirportOriginName = item.,
                AirportDestinationCode = item.AirportDestination,
                //AirportDestinationName = item.,
                FlightDate = item.FlightDate,
                LandingDate = item.LandingDate,
                TravelAgentID = Convert.ToInt32(item.mstBUSTravelAgentID),
                //TravelAgent = item.,
            };

            var reBookStatus = new string[1]
            {
                Convert.ToString(TravelokaTransportationSubmitBooking.TIMEOUT)
            };

            var uoW = parameter.UnitofWork;
            var userID = item.CreatedBy;
            try
            {
                pAddLogger("Step 3", "Get Booking Flight Request");
                int bookingFlightID = Convert.ToInt32(item.ID);
                var request = await pGetBookingFlightRequest(bookingFlightID);
                if (!string.IsNullOrEmpty(request.Status))
                {
                    flightStatus.StatusCode = (int)HttpStatusCode.NotModified;
                    flightStatus.IsSuccess = null;
                    flightStatus.BookingStatus = "This Flight is already processed";

                    return flightStatus;
                }

                var confirmJson = request.ConfirmJson;
                var issuedJson = request.IssuedJson;

                if (item.mstBUSTravelAgentID == Convert.ToInt32(OnlineTravelAgent.Traveloka))
                {
                    pAddLogger("Step 3", "Get Booking Flight Traveloka");
                    var bfTraveloka = await pGetBookingFlightTraveloka(bookingFlightID);
                    if (bfTraveloka != null && !string.IsNullOrEmpty(bfTraveloka.BookingID))
                    {
                        flightStatus.StatusCode = (int)HttpStatusCode.NotModified;
                        flightStatus.IsSuccess = null;
                        flightStatus.BookingStatus = "This Flight is already booked";

                        return flightStatus;
                    }

                    bool isNeedBook = true;
                    int counterBooking = 0;
                    var BookingID = "";
                    pAddLogger("Step 3", "Flight Booking");
                    while (isNeedBook && counterBooking <= 5)
                    {
                        if (counterBooking > 0)
                            await Task.Delay(40000);

                        var bookParam = JsonConvert.DeserializeObject<vmFlightBookingRQ>(confirmJson);
                        var dtPostBooking = new dtPostApi<vmFlightBookingRQ>()
                        {
                            BookingCoreID = bookingFlightID,
                            UserID = userID,
                            SchedullerID = parameter.SchedullerID,
                            LogPath = parameter.TravelokaLogPath,
                            Model = bookParam
                        };
                        var submitBooking = await _tvlService.FlightBooking(uoW, dtPostBooking);
                        if (submitBooking.ErrorType != (int)Helper.Helper.ErrorType.None)
                            throw new Exception(submitBooking.errorMessage);
                        if (!submitBooking.success && !reBookStatus.Contains(submitBooking.errorMessage))
                            throw new Exception(submitBooking.errorMessage);
                        if (submitBooking.success && !reBookStatus.Contains(submitBooking.errorMessage))
                        {
                            isNeedBook = false;

                            #region GetBookingID
                            BookingID = submitBooking.data.bookingId;
                            #endregion GetBookingID
                        }

                        counterBooking++;
                    }

                    if (isNeedBook && counterBooking > 5)
                        throw new Exception("Booking timeout 5 times. You cannot proceed further.");

                    pAddLogger("Step 3", "Check Flight Booking Status");
                    var pCheckStatus = await pGenerateParameterFlightBookingStatusTraveloka(uoW, BookingID, parameter.SchedullerID);
                    var dtPostCheck = new dtPostApi<vmFlightBookingStatusRQ>()
                    {
                        BookingCoreID = bookingFlightID,
                        UserID = userID,
                        SchedullerID = parameter.SchedullerID,
                        LogPath = parameter.TravelokaLogPath,
                        Model = pCheckStatus
                    };
                    var status = await pLoopCheckFlightStatusTraveloka(uoW, dtPostCheck, Convert.ToInt32(parameter.TravelokaDelayBook)); //Delay 1 minute

                    if (status.IsSuccess == true)
                    {
                        pAddLogger("Step 3", "Flight Confirm");
                        var pConfirmFlight = JsonConvert.DeserializeObject<vmPaymentConfirmationRQ>(issuedJson);
                        pConfirmFlight.bookingId = BookingID;

                        var dtPostConfirm = new dtPostApi<vmPaymentConfirmationRQ>()
                        {
                            BookingCoreID = bookingFlightID,
                            UserID = userID,
                            SchedullerID = parameter.SchedullerID,
                            LogPath = parameter.TravelokaLogPath,
                            Model = pConfirmFlight
                        };
                        var confirmFlight = await _tvlService.FlightConfirm(uoW, dtPostConfirm);

                        if (confirmFlight.ErrorType != (int)Helper.Helper.ErrorType.None)
                            throw new Exception(confirmFlight.errorMessage);

                        pAddLogger("Step 3", "Check Flight Confirm Status");
                        status = await pLoopCheckFlightStatusTraveloka(uoW, dtPostCheck, Convert.ToInt32(parameter.TravelokaDelayIssued)); //Delay 1 minute
                    }

                    pAddLogger("Step 3", "Update Booking Flight Traveloka");
                    var bookTvl = await pGetBookingFlightTraveloka(item.ID);
                    bookTvl.BookingID = BookingID;
                    bookTvl.PnrCode = status.Pnr;
                    bookTvl.PaymentConfirmation = status.PaymentConfirmation;
                    bookTvl.PaymentStatus = status.PaymentStatus;
                    bookTvl.TicketStatus = status.TicketStatus;
                    bookTvl.IsDeleted = false;
                    bookTvl.UpdatedBy = "Data Integration";
                    bookTvl.UpdatedDate = DateTime.Now;

                    await _bookFlightTvlService.UpdateAsync(bookTvl);

                    pAddLogger("Step 3", "Set Result");
                    flightStatus.StatusCode = (int)HttpStatusCode.OK;
                    flightStatus.IsSuccess = status.IsSuccess;
                    flightStatus.BookingStatus = status.Status;
                    flightStatus.JsonErrMessage = status.Status;
                }
                else if (item.mstBUSTravelAgentID == Convert.ToInt32(OnlineTravelAgent.KIA))
                {
                    pAddLogger("Step 3", "Get Booking Flight KIA");
                    var bfKia = await pGetBookingFlightKia(bookingFlightID);
                    if (bfKia != null && !string.IsNullOrEmpty(bfKia.PnrID))
                    {
                        flightStatus.StatusCode = (int)HttpStatusCode.NotModified;
                        flightStatus.IsSuccess = null;
                        flightStatus.BookingStatus = "This Flight is already booked";
                        flightStatus.JsonErrMessage = "This Flight is already booked";

                        return flightStatus;
                    }

                    pAddLogger("Step 3", "Flight Reservation");
                    var pFlightReservation = JsonConvert.DeserializeObject<vmRequestFlightReservation>(confirmJson);
                    var dtPostReservation = new dtPostApi<vmRequestFlightReservation>()
                    {
                        BookingCoreID = bookingFlightID,
                        Host = parameter.KiaHost,
                        UserID = userID,
                        SchedullerID = parameter.SchedullerID,
                        LogPath = parameter.KiaLogPath,
                        Model = pFlightReservation,
                    };
                    var flightRsv = await _kiaService.FlightReservation(uoW, dtPostReservation);
                    if (flightRsv.ErrorType != (int)Helper.Helper.ErrorType.None)
                        throw new Exception(flightRsv.ErrorMessage);

                    pAddLogger("Step 3", "Check Flight Reservation");
                    var PnrID = flightRsv.PnrId;
                    var dtPostCheckFlight = new dtPostApi<string>()
                    {
                        BookingCoreID = bookingFlightID,
                        Host = parameter.KiaHost,
                        UserID = userID,
                        SchedullerID = parameter.SchedullerID,
                        LogPath = parameter.KiaLogPath,
                        Model = PnrID,
                    };
                    var status = await pLoopCheckFlightStatusKia(uoW, dtPostCheckFlight, Convert.ToInt32(parameter.KiaDelayBook), false);
                    if (status.Status == Convert.ToString(KiaFlightStatus.Reserved))
                    {
                        pAddLogger("Step 3", "Flight Issued");

                        var pFlightIssued = JsonConvert.DeserializeObject<vmRequestFlightIssued>(issuedJson);
                        pFlightIssued.PnrId = PnrID;

                        var dtPostIssued = new dtPostApi<vmRequestFlightIssued>()
                        {
                            BookingCoreID = bookingFlightID,
                            Host = parameter.KiaHost,
                            UserID = userID,
                            SchedullerID = parameter.SchedullerID,
                            LogPath = parameter.KiaLogPath,
                            Model = pFlightIssued,
                        };
                        var confirmFlight = await _kiaService.FlightIssued(uoW, dtPostIssued);
                        if (confirmFlight.ErrorType != (int)Helper.Helper.ErrorType.None)
                            throw new Exception(confirmFlight.ErrorMessage);

                        pAddLogger("Step 3", "Check Flight Issued");
                        status = await pLoopCheckFlightStatusKia(uoW, dtPostCheckFlight, Convert.ToInt32(parameter.KiaDelayIssued), true); //Delay 1 minute
                    }

                    pAddLogger("Step 3", "Update Booking Flight KIA");
                    var bookKia = await pGetBookingFlightKia(item.ID);
                    bookKia.PnrID = PnrID;
                    bookKia.TicketNumber = status.TicketNumber;
                    bookKia.PnrCode = status.BookingCode;
                    bookKia.ReservationStatus = status.Status;
                    bookKia.IsDeleted = false;
                    bookKia.UpdatedBy = "Data Integration";
                    bookKia.UpdatedDate = DateTime.Now;

                    await _bookFlightKiaService.UpdateAsync(bookKia);

                    pAddLogger("Step 3", "Set Result");
                    flightStatus.StatusCode = (int)HttpStatusCode.OK;
                    flightStatus.IsSuccess = status.IsSuccess;
                    flightStatus.BookingStatus = status.Status;
                    flightStatus.JsonErrMessage = status.Status;
                }
            }
            catch (ApiException ex)
            {
                pAddLogger("[ApiException]Step 3", "Set Result");
                flightStatus.ErrorMessage = ex.Message;
                flightStatus.StatusCode = (int)ex.StatusCode;
                flightStatus.BookingStatus = "Failed";
                flightStatus.IsSuccess = false;

                if (item.mstBUSTravelAgentID == Convert.ToInt32(OnlineTravelAgent.Traveloka))
                {
                    pAddLogger("[ApiException]Step 2", "Get JsonError Traveloka");
                    try
                    {
                        var data = JsonConvert.DeserializeObject<vmFlightResponseException>(ex.JsonError);
                        flightStatus.JsonErrMessage = data.errorMessage;
                    }
                    catch (JsonSerializationException)
                    {
                        flightStatus.JsonErrMessage = ex.JsonError;
                    }
                    catch (Exception)
                    {
                        flightStatus.JsonErrMessage = ex.JsonError;
                    }
                }
                else if (item.mstBUSTravelAgentID == Convert.ToInt32(OnlineTravelAgent.KIA))
                {
                    pAddLogger("[ApiException]Step 2", "Get JsonError KIA");
                    try
                    {
                        JObject json = JObject.Parse(ex.JsonError);

                        // Jika ada properti "Error"
                        if (json["Error"] != null)
                        {
                            flightStatus.JsonErrMessage = Convert.ToString(json["Error"]);
                        }
                        else if (json["Message"] != null)
                        {
                            flightStatus.JsonErrMessage = Convert.ToString(json["Message"]);
                        }
                        else
                        {
                            flightStatus.JsonErrMessage = ex.JsonError;
                        }
                    }
                    catch (JsonSerializationException)
                    {
                        flightStatus.JsonErrMessage = ex.JsonError;
                    }
                    catch (Exception)
                    {
                        flightStatus.JsonErrMessage = ex.JsonError;
                    }
                }
            }
            catch (Exception ex)
            {
                pAddLogger("[Exception]Step 3", "Set Result");
                flightStatus.ErrorMessage = ex.Message;
                flightStatus.BookingStatus = "Failed";
                flightStatus.IsSuccess = false;
                flightStatus.JsonErrMessage = ex.Message;
            }
            await uoW.SaveChangesAsync();

            return flightStatus;
        }
        #endregion Processing

        #region Traveloka
        private async Task<string> pGetConfigTraveloka(TravelokaConfiguration key)
        {

            var _config = await _tvlConfigService.GetListAsync(filter: x => x.ConfigKey == Convert.ToString(key));
            var config = _config.FirstOrDefault();
            return config?.ConfigValue;
        }

        private async Task<vmAccomAffiliateViewItinerariesSpec> pGenerateParameterViewItineraryTraveloka(IUnitOfWork uow, string confirmationID, string schedullerID)
        {
            try
            {
                var request = new vmAccomAffiliateViewItinerariesSpec()
                {
                    metadata = new vmMetadata()
                    {
                        locale = "id_ID",
                        customerSessionId = "MB766GFDJ88",
                        customerIpAddress = "24.10.220.655",
                        currencyCode = "IDR"
                    },
                    affiliateConfirmationId = confirmationID,
                };

                return request;
            }
            catch (Exception ex)
            {
                return new vmAccomAffiliateViewItinerariesSpec((int)Helper.Helper.ErrorType.Error, await logger.LogException(serviceProvider, ex, schedullerID), 0);
            }
        }

        public async Task<vmFlightBookingStatusRQ> pGenerateParameterFlightBookingStatusTraveloka(IUnitOfWork uow, string bookingID, string schedullerID)
        {
            try
            {
                var request = new vmFlightBookingStatusRQ()
                {
                    bookingIds = new string[1] { bookingID },
                };

                return request;
            }
            catch (Exception ex)
            {
                return new vmFlightBookingStatusRQ((int)Helper.Helper.ErrorType.Error, await logger.LogException(serviceProvider, ex, schedullerID), 0);
            }
        }

        private async Task<vmTravelDutiesTravelokaCheckBookingAccommodationStatus> pLoopCheckAccommodationStatusTraveloka(IUnitOfWork uoW, dtPostApi<vmAccomAffiliateViewItinerariesSpec> dtPostItin, int delayTime)
        {
            var result = new vmTravelDutiesTravelokaCheckBookingAccommodationStatus();
            string loopStatus = await pGetConfigTraveloka(TravelokaConfiguration.LoopViewItinerary);

            //set jumlah loop view itin
            var loop = loopStatus != "" ? Convert.ToInt32(loopStatus) : 0;

            int counter = 0;
            while (counter < loop)
            {
                await Task.Delay(delayTime * counter);
                counter++;

                //View Itinerary
                try
                {
                    var viewItin = await _tvlService.ViewItinerary(uoW, dtPostItin);
                    if (viewItin.ErrorType == 0)
                    {
                        var itin = viewItin.itineraries.FirstOrDefault();
                        result.BookingID = itin.bookingId;
                        result.ItineraryID = itin.itineraryId;
                        result.Status = itin.status;

                        if (itin.status != Convert.ToString(TravelokaAccommodationItineraryStatus.PENDING))
                        {
                            if (itin.status == Convert.ToString(TravelokaAccommodationItineraryStatus.FAILED)
                                || itin.status == Convert.ToString(TravelokaAccommodationItineraryStatus.CANCELLED))
                            {
                                result.IsSuccess = false;
                            }
                            else
                            {
                                result.IsSuccess = true;
                            }
                            break;
                        }
                    }
                }
                catch (ApiException ex)
                {
                    continue;
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return result;
        }

        private async Task<vmTravelDutiesTravelokaCheckBookingFlightStatus> pLoopCheckFlightStatusTraveloka(IUnitOfWork uoW, dtPostApi<vmFlightBookingStatusRQ> param, int delayTime)
        {
            var result = new vmTravelDutiesTravelokaCheckBookingFlightStatus();
            string loopStatus = await pGetConfigTraveloka(TravelokaConfiguration.LoopFlightStatus);

            //set jumlah loop view itin
            var loop = loopStatus != "" ? Convert.ToInt32(loopStatus) : 0;

            int counter = 0;
            while (counter < loop)
            {
                try
                {
                    await Task.Delay(delayTime * counter);

                    counter++;

                    var checkStatus = await _tvlService.FlightBookingStatus(uoW, param);
                    if (checkStatus.APIStatusCode == (int)HttpStatusCode.OK)
                    {
                        var getStatus = checkStatus.data.bookingStatusResult.FirstOrDefault();
                        result.Status = getStatus != null ? getStatus.status : "";
                        result.Pnr = getStatus != null && getStatus.pnrCode.Length > 0 ? getStatus.pnrCode[0] : "";
                        if (result.Status == Convert.ToString(TravelokaTransportationBookingStatus.BOOKED))
                        {
                            result.IsSuccess = true;
                            result.PaymentConfirmation = false;
                            result.PaymentStatus = Convert.ToString(TravelokaTransportationPaymentStatus.ALREADY_CONFIRMED);
                            result.TicketStatus = result.Status;

                            break;
                        }
                        else if (result.Status == Convert.ToString(TravelokaTransportationBookingStatus.ISSUED))
                        {
                            result.IsSuccess = true;
                            result.PaymentConfirmation = true;
                            result.PaymentStatus = Convert.ToString(TravelokaTransportationPaymentStatus.SUCCESS);
                            result.TicketStatus = result.Status;

                            break;
                        }
                        else if (result.Status == Convert.ToString(TravelokaTransportationBookingStatus.WAITING_FOR_ISSUANCE))
                        {
                            result.IsSuccess = true;
                            result.PaymentConfirmation = true;
                            result.PaymentStatus = Convert.ToString(TravelokaTransportationPaymentStatus.SUCCESS);
                            result.TicketStatus = result.Status;

                            break;
                        }
                        else //Canceled, failed
                        {
                            result.IsSuccess = false;
                        }
                    }
                }
                catch (ApiException ex)
                {
                    continue;
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            return result;
        }
        #endregion Traveloka

        #region KIA
        private async Task<string> pGetConfigKia(KiaConfiguration key)
        {
            var _config = await _kiaConfigService.GetListAsync(filter: x => x.ConfigKey == Convert.ToString(key));
            var config = _config.FirstOrDefault();
            return config?.ConfigValue;
        }

        private async Task<vmTravelDutiesKiaCheckBookingAccommodationStatus> pLoopCheckAccommodationStatusKia(IUnitOfWork uoW, dtPostApi<string> dtPost, int delayTime)
        {
            var result = new vmTravelDutiesKiaCheckBookingAccommodationStatus();
            string loopStatus = await pGetConfigKia(KiaConfiguration.LoopGetHotelReservation);

            //set jumlah loop view itin
            var loop = loopStatus != "" ? Convert.ToInt32(loopStatus) : 0;

            int counter = 0;
            while (counter < loop)
            {
                await Task.Delay(delayTime * counter);
                counter++;
                try
                {
                    var reservation = await _kiaService.GetHotelReservation(uoW, dtPost);
                    if (reservation.ErrorType == (int)Helper.Helper.ErrorType.None)
                    {
                        result.Status = reservation.Status;
                        result.BookingID = reservation.BookingId;
                        result.BookingCode = reservation.BookingCode;
                        result.Total = reservation.Payments.FirstOrDefault(x => x.Code == Convert.ToString(KiaHotelPaymentCode.TOTAL_PAID)).Amount;

                        if (reservation.Status == Convert.ToString(KiaHotelStatus.Ticketed))
                        {
                            result.IsSuccess = true;
                            break;
                        }
                        else if (reservation.Status == Convert.ToString(KiaHotelStatus.BookingError))
                        {
                            result.IsSuccess = false;
                            break;
                        }
                    }
                }
                catch (ApiException ex)
                {
                    continue;
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return result;
        }

        private async Task<vmTravelDutiesKiaCheckBookingFlightStatus> pLoopCheckFlightStatusKia(IUnitOfWork uoW, dtPostApi<string> dtPost, int delayTime, bool isIssued)
        {
            var result = new vmTravelDutiesKiaCheckBookingFlightStatus();
            string loopStatus = await pGetConfigKia(KiaConfiguration.LoopGetFlightReservation);

            //set jumlah loop view itin
            var loop = loopStatus != "" ? Convert.ToInt32(loopStatus) : 0;

            int counter = 0;
            while (counter < loop)
            {
                await Task.Delay(delayTime * counter);
                counter++;
                try
                {
                    var reservation = await _kiaService.GetFlightReservation(uoW, dtPost);
                    if (reservation.ErrorType == (int)Helper.Helper.ErrorType.None)
                    {
                        var ticket = reservation.Passengers.FirstOrDefault();
                        if (ticket != null)
                            result.TicketNumber = ticket.TicketNumber;

                        result.Status = reservation.Status;
                        result.BookingCode = reservation.BookingCode;
                        result.Total = reservation.Payments.FirstOrDefault(x => x.Code == Convert.ToString(KiaHotelPaymentCode.TOTAL_PAID)).Amount;

                        var allowed = new string[2]
                        {
                            Convert.ToString(KiaFlightStatus.Ticketed),
                            isIssued ? "":Convert.ToString(KiaFlightStatus.Reserved)
                        };
                        var failed = new string[6] {
                            Convert.ToString(KiaFlightStatus.BookingError),
                            Convert.ToString(KiaFlightStatus.TicketingError),
                            Convert.ToString(KiaFlightStatus.FlightUnavailable),
                            Convert.ToString(KiaFlightStatus.Expired),
                            Convert.ToString(KiaFlightStatus.FormValidationError),
                            Convert.ToString(KiaFlightStatus.TimeoutError),
                        };

                        if (allowed.Contains(reservation.Status))
                        {
                            result.IsSuccess = true;
                            break;
                        }
                        else if (failed.Contains(reservation.Status))
                        {
                            result.IsSuccess = false;
                            break;
                        }
                    }
                }
                catch (ApiException ex)
                {
                    continue;
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return result;
        }
        #endregion KIA


        private class dtPostProcessBooking
        {
            public IUnitOfWork UnitofWork { get; set; }
            public string SchedullerID { get; set; }
            public string UserID { get; set; }
            public string TravelokaBookType { get; set; }
            public string TravelokaLogPath { get; set; }
            public string TravelokaDelayBook { get; set; }
            public string TravelokaDelayIssued { get; set; }

            public string KiaHost { get; set; }
            public string KiaLogPath { get; set; }
            public string KiaDelayBook { get; set; }
            public string KiaDelayIssued { get; set; }
        }

    }
}
