using Dapper;
using DataIntegration.Application.Interfaces.Entities;
using DataIntegration.Domain.Helpers;
using DataIntegration.Domain.Models;
using DataIntegration.Domain.Models.Datatables;
using DataIntegration.Infrastructure.Data;
using DataIntegration.Infrastructure.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Services.Entities
{
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        protected readonly IRepository<T>? _repository;
        protected readonly IUnitOfWorkFactory _unitOfWorkFactory;
        protected readonly IServiceProvider _serviceProvider;
        protected string _connectionStringName;

        public BaseService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider, string connectionStringName = "TBIGSYSDB01_TBiGSys")
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _serviceProvider = serviceProvider;
            _connectionStringName = connectionStringName;
        }

        public string ConnectionStringName
        {
            get => _connectionStringName;
            set => _connectionStringName = value;
        }

        public async Task<T> GetByPKAsync(params object[] keyValues)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create(_connectionStringName))
            {
                return await unitOfWork.GetRepository<T>().GetByPKAsync(keyValues);
            }
        }
        public async Task<T> GetByPKAsync(IUnitOfWork unitOfWork, params object[] keyValues)
        {
            return await unitOfWork.GetRepository<T>().GetByPKAsync(keyValues);
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>>? filter = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                        string includeProperties = "")
        {
            using (var unitOfWork = _unitOfWorkFactory.Create(_connectionStringName))
            {
                return await unitOfWork.GetRepository<T>().GetListAsync(filter, orderBy, includeProperties);
            }
        }

        public async Task<IEnumerable<T>> GetListAsync(IUnitOfWork unitOfWork,
                                        Expression<Func<T, bool>>? filter = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                        string includeProperties = "")
        {
            return await unitOfWork.GetRepository<T>().GetListAsync(filter, orderBy, includeProperties);
        }

        public async Task<int> GetCountAsync(Expression<Func<T, bool>>? filter = null)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create(_connectionStringName))
            {
                Console.WriteLine(_connectionStringName);
                Console.WriteLine(unitOfWork.Context.Database.GetDbConnection().ConnectionString);
                Console.WriteLine(unitOfWork.Context.Database.GetDbConnection().Database);
                return await unitOfWork.GetRepository<T>().GetCountAsync(filter);
            }
        }

        public async Task<int> GetCountAsync(IUnitOfWork unitOfWork, Expression<Func<T, bool>>? filter = null)
        {
            return await unitOfWork.GetRepository<T>().GetCountAsync(filter);
        }

        public async Task<IPagedList<T>> GetPagedAsync(int pageIndex, int pageSize,
                                        Expression<Func<T, bool>>? filter = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                        string includeProperties = "")
        {
            using (var unitOfWork = _unitOfWorkFactory.Create(_connectionStringName))
            {
                return await unitOfWork.GetRepository<T>().GetPagedAsync(pageIndex, pageSize, filter, orderBy, includeProperties);
            }
        }

        public async Task<IPagedList<T>> GetPagedAsync(IUnitOfWork unitOfWork,
                                        int pageIndex, int pageSize,
                                        Expression<Func<T, bool>>? filter = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                        string includeProperties = "")
        {
            return await unitOfWork.GetRepository<T>().GetPagedAsync(pageIndex, pageSize, filter, orderBy, includeProperties);
        }

        public async Task AddAsync(T entity)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create(_connectionStringName))
            {
                try
                {
                    await unitOfWork.GetRepository<T>().AddAsync(entity);
                    await unitOfWork.CommitAsync();
                }
                catch
                {
                    throw;
                }
            }
        }

        public async Task AddAsync(IUnitOfWork unitOfWork, T entity)
        {
            await unitOfWork.GetRepository<T>().AddAsync(entity);
        }


        public async Task AddBulkAsync(IEnumerable<T> entities)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create(_connectionStringName))
            {
                await unitOfWork.GetRepository<T>().AddBulkAsync(entities);
                await unitOfWork.CommitAsync(true);
            }
        }

        public async Task AddBulkAsync(IUnitOfWork unitOfWork, IEnumerable<T> entities)
        {
            await unitOfWork.GetRepository<T>().AddBulkAsync(entities);
        }

        public async Task UpdateAsync(T entity)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create(_connectionStringName))
            {
                unitOfWork.GetRepository<T>().Update(entity);
                await unitOfWork.CommitAsync();
            }
        }

        public async Task UpdateAsync(IUnitOfWork unitOfWork, T entity)
        {
            unitOfWork.GetRepository<T>().Update(entity);
        }

        public async Task UpdateBulkAsync(IEnumerable<T> entities)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create(_connectionStringName))
            {
                await unitOfWork.GetRepository<T>().UpdateBulkAsync(entities);
                await unitOfWork.CommitAsync(true);
            }
        }

        public async Task UpdateBulkAsync(IUnitOfWork unitOfWork, IEnumerable<T> entities)
        {
            unitOfWork.GetRepository<T>().UpdateBulkAsync(entities);
        }

        public async Task DeleteByPKAsync(params object[] keyValues)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create(_connectionStringName))
            {
                await unitOfWork.GetRepository<T>().DeleteByPKAsync(keyValues);
                await unitOfWork.CommitAsync();
            }
        }

        public async Task DeleteByPKAsync(IUnitOfWork unitOfWork, params object[] keyValues)
        {
            await unitOfWork.GetRepository<T>().DeleteByPKAsync(keyValues);
        }

        public async Task DeleteByFilterAsync(Expression<Func<T, bool>> filter)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create(_connectionStringName))
            {
                await unitOfWork.GetRepository<T>().DeleteByFilterAsync(filter);
                await unitOfWork.CommitAsync();
            }
        }

        public async Task DeleteByFilterAsync(IUnitOfWork unitOfWork, Expression<Func<T, bool>> filter)
        {
            await unitOfWork.GetRepository<T>().DeleteByFilterAsync(filter);
        }


        public async Task BulkInsertOrUpdateAsync(IEnumerable<T> entities)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create(_connectionStringName))
            {
                await unitOfWork.GetRepository<T>().BulkInsertOrUpdateAsync(entities);
                await unitOfWork.CommitAsync(true);
            }
        }

        public async Task BulkInsertOrUpdateAsync(IUnitOfWork unitOfWork, IEnumerable<T> entities)
        {
            await unitOfWork.GetRepository<T>().BulkInsertOrUpdateAsync(entities);
        }

        public async Task BulkInsertOrUpdateAsync(IEnumerable<T> entities, IEnumerable<string> conflictColumns)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create(_connectionStringName))
            {
                await unitOfWork.GetRepository<T>().BulkInsertOrUpdateAsync(entities, conflictColumns);
                await unitOfWork.CommitAsync(true);
            }
        }

        public async Task BulkInsertOrUpdateAsync(IUnitOfWork unitOfWork, IEnumerable<T> entities, IEnumerable<string> conflictColumns)
        {
            await unitOfWork.GetRepository<T>().BulkInsertOrUpdateAsync(entities, conflictColumns);
        }

        public async Task BulkSynchronizeAsync(IEnumerable<T> entities)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create(_connectionStringName))
            {
                await unitOfWork.GetRepository<T>().BulkSynchronizeAsync(entities);
                await unitOfWork.CommitAsync(true);
            }
        }

        public async Task BulkSynchronizeAsync(IUnitOfWork unitOfWork, IEnumerable<T> entities)
        {
            await unitOfWork.GetRepository<T>().BulkSynchronizeAsync(entities);
        }

        public async Task BulkSynchronizeAsync(IEnumerable<T> entities, IEnumerable<string> conflictColumns)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create(_connectionStringName))
            {
                await unitOfWork.GetRepository<T>().BulkSynchronizeAsync(entities, conflictColumns);
                await unitOfWork.CommitAsync(true);
            }
        }

        public async Task BulkSynchronizeAsync(IUnitOfWork unitOfWork, IEnumerable<T> entities, IEnumerable<string> conflictColumns)
        {
            await unitOfWork.GetRepository<T>().BulkSynchronizeAsync(entities, conflictColumns);
        }


        public async Task ExecuteStoredProcedureAsync(string procedureName, params SqlParameter[] parameters)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create(_connectionStringName))
            {
                await unitOfWork.GetRepository<T>().ExecuteStoredProcedureAsync(procedureName, parameters);
            }
        }
        public async Task<IEnumerable<T>> ExecuteStoredProcedureQueryAsync(string procedureName, params SqlParameter[] parameters)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create(_connectionStringName))
            {
                return await unitOfWork.GetRepository<T>().ExecuteStoredProcedureQueryAsync<T>(procedureName, parameters);
            }
        }

        public async Task<DataTablesResponse<T>> GetDataForDataTablesAsync<TRequest>(
                                                                                        TRequest request,
                                                                                        Func<TRequest, Expression<Func<T, bool>>?>? buildCustomFilter = null
                                                                                    ) where TRequest : DataTablesRequest
        {
            var response = new DataTablesResponse<T> { Draw = request.Draw };

            try
            {
                int pageSize = request.Length > 0 ? request.Length : 10;
                int pageIndex = (request.Start / pageSize) + 1;

                // Build filters
                Expression<Func<T, bool>>? dtFilter = DataTablesQueryAdapter<T>.BuildFilterExpression(request);
                Expression<Func<T, bool>>? customFilter = buildCustomFilter?.Invoke(request);
                Expression<Func<T, bool>>? finalFilter = CombineFiltersHelper(customFilter, dtFilter);

                // Build order by
                var finalOrderBy = DataTablesQueryAdapter<T>.BuildOrderByFunc(request);

                // Get total count
                response.RecordsTotal = await GetCountAsync(finalFilter);

                // Get paged data
                var pagedResult = await GetPagedAsync(pageIndex, pageSize, finalFilter, finalOrderBy);

                response.RecordsFiltered = pagedResult.TotalCount;
                response.Data = pagedResult.Items.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing DataTables request: {ex}");
                response.Error = "Terjadi kesalahan saat memproses data.";
            }

            return response;
        }

        public IEnumerable<T> ExecuteStoredProcedureQuery<T>(
            string storedProcedureName,
            object parameters = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null)
        {
            IDbConnection connection = _unitOfWorkFactory.Create(_connectionStringName).Context.Database.GetDbConnection();
            bool wasConnectionClosed = false;

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    wasConnectionClosed = true; // Tandai bahwa koneksi dibuka oleh metode ini
                }

                // Eksekusi SP menggunakan Dapper
                return connection.Query<T>(
                    sql: storedProcedureName,
                    param: parameters,
                    commandType: CommandType.StoredProcedure,
                    transaction: transaction,
                    commandTimeout: commandTimeout
                );
            }
            finally
            {
                // Tutup koneksi hanya jika dibuka oleh metode ini
                if (wasConnectionClosed && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        // Helper untuk menggabungkan filter (sama seperti di Adapter, bisa ditaruh di tempat terpusat)
        public Expression<Func<T, bool>>? CombineFiltersHelper(Expression<Func<T, bool>>? first, Expression<Func<T, bool>>? second)
        {
            if (first == null) return second;
            if (second == null) return first;

            var parameter = Expression.Parameter(typeof(T), "x");
            var visitor = new DataTablesQueryAdapter<T>.ParameterUpdateVisitor(second.Parameters.First(), parameter);
            var secondBody = visitor.Visit(second.Body);
            visitor = new DataTablesQueryAdapter<T>.ParameterUpdateVisitor(first.Parameters.First(), parameter);
            var firstBody = visitor.Visit(first.Body);

            var body = Expression.AndAlso(firstBody, secondBody);
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
}
