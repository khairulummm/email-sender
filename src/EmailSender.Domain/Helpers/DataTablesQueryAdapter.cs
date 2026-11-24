using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Linq.Expressions;
using DataIntegration.Domain.Models.Datatables;

namespace DataIntegration.Domain.Helpers
{

    // Helper/Builder Class
    public static class DataTablesQueryAdapter<T> where T : class
    {
        // Helper untuk menggabungkan dua Expression<Func<T, bool>> dengan AND
        private static Expression<Func<T, bool>>? CombineFilters(Expression<Func<T, bool>>? first, Expression<Func<T, bool>>? second)
        {
            if (first == null) return second;
            if (second == null) return first;

            var parameter = Expression.Parameter(typeof(T), "x"); // Gunakan parameter baru yang konsisten
            var visitor = new ParameterUpdateVisitor(second.Parameters.First(), parameter); // Ganti parameter ekspresi kedua
            var secondBody = visitor.Visit(second.Body);

            visitor = new ParameterUpdateVisitor(first.Parameters.First(), parameter); // Ganti parameter ekspresi pertama
            var firstBody = visitor.Visit(first.Body);

            var body = Expression.AndAlso(firstBody, secondBody);
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        // Membangun Filter Expression dari DataTablesRequest
        public static Expression<Func<T, bool>>? BuildFilterExpression(DataTablesRequest dtRequest)
        {
            Expression<Func<T, bool>>? combinedFilter = null;
            var parameter = Expression.Parameter(typeof(T), "x");

            // 1. Global Filter
            var globalSearchValue = dtRequest.Search?.Value?.Trim();
            if (!string.IsNullOrWhiteSpace(globalSearchValue))
            {
                Expression? globalFilterBody = null;
                foreach (var column in dtRequest.Columns.Where(c => c.Searchable && !string.IsNullOrWhiteSpace(c.Data)))
                {
                    try
                    {
                        var propertyExpr = Expression.Property(parameter, column.Data);
                        Expression? currentColumnExpr = BuildStringContainsExpression(propertyExpr, globalSearchValue);
                        // TODO: Tambahkan logika untuk tipe data lain (angka, tanggal, bool) di sini
                        // if (currentColumnExpr == null && IsNumericType(propertyExpr.Type)) { ... }
                        // else if (currentColumnExpr == null && IsDateTimeType(propertyExpr.Type)) { ... }

                        if (currentColumnExpr != null)
                        {
                            globalFilterBody = globalFilterBody == null
                                ? currentColumnExpr
                                : Expression.OrElse(globalFilterBody, currentColumnExpr);
                        }
                    }
                    catch (ArgumentException) { /* Abaikan jika properti tidak ditemukan */ }
                }
                if (globalFilterBody != null)
                {
                    combinedFilter = Expression.Lambda<Func<T, bool>>(globalFilterBody, parameter);
                }
            }

            // 2. Column Filters
            foreach (var column in dtRequest.Columns.Where(c => c.Searchable && !string.IsNullOrWhiteSpace(c.Data) && !string.IsNullOrWhiteSpace(c.Search?.Value)))
            {
                string columnSearchValue = column.Search.Value.Trim();
                try
                {
                    var propertyExpr = Expression.Property(parameter, column.Data);
                    Expression? columnFilterBody = BuildStringContainsExpression(propertyExpr, columnSearchValue);
                    // TODO: Tambahkan logika tipe data lain jika diperlukan untuk filter per kolom

                    if (columnFilterBody != null)
                    {
                        var columnLambda = Expression.Lambda<Func<T, bool>>(columnFilterBody, parameter);
                        combinedFilter = CombineFilters(combinedFilter, columnLambda); // Gabungkan dengan AND
                    }
                }
                catch (ArgumentException) { /* Abaikan jika properti tidak ditemukan */ }
            }

            return combinedFilter;
        }

        // Membangun OrderBy Function dari DataTablesRequest
        public static Func<IQueryable<T>, IOrderedQueryable<T>>? BuildOrderByFunc(DataTablesRequest dtRequest)
        {
            if (dtRequest.Order == null || !dtRequest.Order.Any()) return null;

            var orderClauses = new List<string>();
            foreach (var order in dtRequest.Order)
            {
                if (order.Column < 0 || order.Column >= dtRequest.Columns.Count) continue;
                var column = dtRequest.Columns[order.Column];
                if (column.Orderable && !string.IsNullOrWhiteSpace(column.Data))
                {
                    // Validasi sederhana untuk nama properti (opsional tapi bagus)
                    if (typeof(T).GetProperty(column.Data, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) != null)
                    {
                        string direction = order.Dir?.ToLowerInvariant() == "desc" ? "descending" : "ascending"; // Atau desc / asc
                        orderClauses.Add($"{column.Data} {direction}");
                    }
                }
            }

            if (orderClauses.Any())
            {
                string orderByString = string.Join(", ", orderClauses);
                // Gunakan System.Linq.Dynamic.Core untuk kemudahan membuat Func dari string
                return query => query.OrderBy(orderByString);
            }
            return null;
        }

        // Helper kecil untuk membuat expression x.Property.Contains(value) (untuk string)
        private static Expression? BuildStringContainsExpression(Expression propertyExpr, string value)
        {
            if (propertyExpr.Type != typeof(string) || string.IsNullOrEmpty(value))
                return null;

            var searchValueConstant = Expression.Constant(value);
            var containsMethodInfo = typeof(string).GetMethod("Contains", new[] { typeof(string) });

            if (containsMethodInfo == null) return null; // Seharusnya tidak terjadi

            var nullCheck = Expression.NotEqual(propertyExpr, Expression.Constant(null, typeof(string)));
            var containsCall = Expression.Call(propertyExpr, containsMethodInfo, searchValueConstant);

            return Expression.AndAlso(nullCheck, containsCall);
        }

        // Helper Visitor untuk mengganti parameter dalam Expression Tree (diperlukan oleh CombineFilters)
        public class ParameterUpdateVisitor : ExpressionVisitor
        {
            private readonly ParameterExpression _oldParameter;
            private readonly ParameterExpression _newParameter;

            public ParameterUpdateVisitor(ParameterExpression oldParameter, ParameterExpression newParameter)
            {
                _oldParameter = oldParameter;
                _newParameter = newParameter;
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return ReferenceEquals(node, _oldParameter) ? _newParameter : base.VisitParameter(node);
            }
        }
    }
}


