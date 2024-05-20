using Sana.Backend.Domain.Common.Attributes;
using Sana.Backend.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sana.Backend.Domain.Common
{
    public static class ExtensionMethod
    {
        public static bool IsNotNull<T>([ValidatedNotNull] this T valid) where T : class
        {
            return valid != null;
        }

        public static bool IsNotNull<T>([ValidatedNotNull] this List<T> valid) where T : class
        {
            return valid?.Any() ?? false;
        }

        public static bool IsValid([ValidatedNotNull] this string s)
        {
            return s.IsNotNull() && s.Trim().Length > 0;
        }

        public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> query, List<OrderPaginate> orders)
        {
            if (orders.IsNotNull())
            {
                for (int i = 0; i < orders.Count; i++)
                {
                    if (!Enum.TryParse<DirectionOrder>(orders[i].Direction.FirstCharToUpper(), out var result))
                    {
                        result = DirectionOrder.Ascending;
                    }

                    MethodCallExpression methodCallExpression = ((i == 0) ? query.OrderBy(orders[i].Name, result) : query.ThenBy(orders[i].Name, result));
                    if (methodCallExpression.IsNotNull())
                    {
                        query = query.Provider.CreateQuery<T>(methodCallExpression);
                    }
                }
            }

            return query;
        }

        public static string FirstCharToUpper(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            return char.ToUpper(s[0], CultureInfo.CurrentCulture) + s.Substring(1, s.Length - 1).ToLower(CultureInfo.CurrentCulture);
        }

        public static IQueryable<T> WhereDynamic<T>(this IQueryable<T> query, List<FilterPaginate> filters)
        {
            if (filters.IsNotNull())
            {
                return query.CreateWhereDynamic(filters);
            }

            return query;
        }

        private static IQueryable<T> CreateWhereDynamic<T>(this IQueryable<T> query, List<FilterPaginate> filters)
        {
            Expression<Func<T, bool>> expression = null;
            foreach (FilterPaginate filter in filters)
            {
                if (filter.Property.IsValid() && filter.Value.IsNotNull())
                {
                    expression = AddConditionalQuery(expression, filter);
                }
            }

            query = query.Where(expression);
            return query;
        }

        private static Expression<Func<T, bool>> AddConditionalQuery<T>(Expression<Func<T, bool>> queryFilter, FilterPaginate filter)
        {
            queryFilter = ((!queryFilter.IsNotNull()) ? ExpressionHelper.GetCriteriaWhere<T>(filter.Property, filter.Operator, filter.Value.ToString().Trim()) : ((filter.Conditional != LogicalOperators.Or) ? queryFilter.And(ExpressionHelper.GetCriteriaWhere<T>(filter.Property, filter.Operator, filter.Value.ToString().Trim())) : queryFilter.Or(ExpressionHelper.GetCriteriaWhere<T>(filter.Property, filter.Operator, filter.Value.ToString().Trim()))));
            return queryFilter;
        }
    }
}
