using DataIntegration.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace DataIntegration.Infrastructure.Interfaces
{
	public interface IRepository<T> where T : class
	{
		// Table Operations
		Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null);
		Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> filter = null,
											Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
											string includeProperties = "");
		Task<IPagedList<T>> GetPagedAsync(int pageIndex, int pageSize,
											Expression<Func<T, bool>> filter = null,
											Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
											string includeProperties = "");
		Task<T> GetByPKAsync(params object[] keyValues);
		Task AddAsync(T entity); // OK - Tidak save changes
		Task AddBulkAsync(IEnumerable<T> entities); // OK - Tidak save changes (kecuali library memaksa)
		void Update(T entity); // OK - Tidak save changes
		Task UpdateBulkAsync(IEnumerable<T> entities); // GANTI: Jadi async Task, karena implementasi async

		Task BulkInsertOrUpdateAsync(IEnumerable<T> entities); // OK - Library async
		Task BulkInsertOrUpdateAsync(IEnumerable<T> entities, IEnumerable<string> conflictColumns); // OK - Library async
		Task BulkSynchronizeAsync(IEnumerable<T> entities); // OK - Library async
		Task BulkSynchronizeAsync(IEnumerable<T> entities, IEnumerable<string> conflictColumns); // OK - Library async

		Task DeleteByPKAsync(params object[] keyValues); // OK - Tidak save changes
		Task DeleteByFilterAsync(Expression<Func<T, bool>> filter); // OK - Tidak save changes

		//// View Operations (Pertimbangkan apakah perlu dipisah)
		//Task<int> GetViewCountAsync(Expression<Func<T, bool>> filter = null);
		//Task<IEnumerable<T>> GetViewListAsync(Expression<Func<T, bool>> filter = null,
		//										Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
		//Task<IPagedList<T>> GetViewPagedAsync(int pageIndex, int pageSize,
		//										Expression<Func<T, bool>> filter = null,
		//										Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
		//Task<T> GetViewByPKAsync(params object[] keyValues); // Perhatikan implementasi untuk keyless

		//Store Procedure Operations
		Task ExecuteStoredProcedureAsync(string procedureName, params SqlParameter[] parameters);
		Task<IEnumerable<TResult>> ExecuteStoredProcedureQueryAsync<TResult>(string procedureName, params SqlParameter[] parameters) where TResult : class;
    }
}
