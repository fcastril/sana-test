using Sana.Backend.Domain.Common.Enums;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace Sana.Backend.Domain.Common
{
    public static class ExpressionHelper
    {
        public static MethodCallExpression? OrderBy<T>(this IQueryable<T> query, string orderByMember, DirectionOrder direction)
        {
            return query.OrderBy(orderByMember, direction, "OrderBy");
        }

        public static MethodCallExpression? ThenBy<T>(this IQueryable<T> query, string orderByMember, DirectionOrder direction)
        {
            return query.OrderBy(orderByMember, direction, "ThenBy");
        }

        private static MethodCallExpression? OrderBy<T>(this IQueryable<T> query, string orderByMember, DirectionOrder direction, string initOrder)
        {
            if (query.IsNotNull() && orderByMember.IsValid())
            {
                ParameterExpression parameterExpression = Expression.Parameter(typeof(T));
                MemberExpression memberExpression = GetMemberExpression(parameterExpression, orderByMember);
                LambdaExpression expression = Expression.Lambda(memberExpression, parameterExpression);
                return Expression.Call(typeof(Queryable), (direction == DirectionOrder.Ascending) ? initOrder : (initOrder + "Descending"), new Type[2]
                {
                typeof(T),
                memberExpression.Type
                }, query.Expression, Expression.Quote(expression));
            }

            return null;
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr, Expression<Func<T, bool>> or)
        {
            if (expr == null)
            {
                return or;
            }

            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(new AddExpression(expr.Parameters[0], or.Parameters[0]).Visit(expr.Body), or.Body), or.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr, Expression<Func<T, bool>> and)
        {
            if (expr == null)
            {
                return and;
            }

            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(new AddExpression(expr.Parameters[0], and.Parameters[0]).Visit(expr.Body), and.Body), and.Parameters);
        }

        private static MemberExpression? GetMemberExpression(ParameterExpression parameter, string propName)
        {
            if (string.IsNullOrEmpty(propName))
            {
                return null;
            }

            string[] array = propName.Split('.');
            if (array.Count() > 1)
            {
                MemberExpression memberExpression = Expression.Property(parameter, array[0]);
                for (int i = 1; i < array.Count(); i++)
                {
                    memberExpression = Expression.Property(memberExpression, array[i]);
                }

                return memberExpression;
            }

            return Expression.Property(parameter, propName);
        }

        public static Expression<Func<T, bool>> GetCriteriaWhere<T>(string fieldName, Operations selectedOperator, object fieldValue)
        {
            PropertyDescriptor property = GetProperty(TypeDescriptor.GetProperties(typeof(T)), fieldName, ignoreCase: true);
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T));
            MemberExpression memberExpression = GetMemberExpression(parameterExpression, fieldName);
            if (property != null && fieldValue != null)
            {
                Operations operations = selectedOperator;
                if ((property.PropertyType == typeof(bool) || property.PropertyType == typeof(bool?)) && selectedOperator != 0)
                {
                    operations = Operations.Equals;
                }

                Type conversionType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                object value = ((property.PropertyType == typeof(Guid)) ? ((object)Guid.Parse(fieldValue.ToString())) : Convert.ChangeType(fieldValue, conversionType));
                switch (operations)
                {
                    case Operations.Equals:
                        return Expression.Lambda<Func<T, bool>>(Expression.Equal(memberExpression, Expression.Constant(value, property.PropertyType)), new ParameterExpression[1] { parameterExpression });
                    case Operations.NotEquals:
                        return Expression.Lambda<Func<T, bool>>(Expression.NotEqual(memberExpression, Expression.Constant(value, property.PropertyType)), new ParameterExpression[1] { parameterExpression });
                    case Operations.Minor:
                        return Expression.Lambda<Func<T, bool>>(Expression.LessThan(memberExpression, Expression.Constant(value, property.PropertyType)), new ParameterExpression[1] { parameterExpression });
                    case Operations.MinorEquals:
                        return Expression.Lambda<Func<T, bool>>(Expression.LessThanOrEqual(memberExpression, Expression.Constant(value, property.PropertyType)), new ParameterExpression[1] { parameterExpression });
                    case Operations.Mayor:
                        return Expression.Lambda<Func<T, bool>>(Expression.GreaterThan(memberExpression, Expression.Constant(value, property.PropertyType)), new ParameterExpression[1] { parameterExpression });
                    case Operations.MayorEquals:
                        return Expression.Lambda<Func<T, bool>>(Expression.GreaterThanOrEqual(memberExpression, Expression.Constant(value, property.PropertyType)), new ParameterExpression[1] { parameterExpression });
                    case Operations.Like:
                        {
                            MethodInfo method6 = typeof(string).GetMethod("Contains", new Type[1] { typeof(string) });
                            return Expression.Lambda<Func<T, bool>>(ExpressionMethodString(property, fieldValue, memberExpression, method6), new ParameterExpression[1] { parameterExpression });
                        }
                    case Operations.NotLike:
                        {
                            MethodInfo method5 = typeof(string).GetMethod("Contains", new Type[1] { typeof(string) });
                            return Expression.Lambda<Func<T, bool>>(Expression.Not(ExpressionMethodString(property, fieldValue, memberExpression, method5)), new ParameterExpression[1] { parameterExpression });
                        }
                    case Operations.StartsWith:
                        {
                            MethodInfo method4 = typeof(string).GetMethod("StartsWith", new Type[1] { typeof(string) });
                            return Expression.Lambda<Func<T, bool>>(ExpressionMethodString(property, fieldValue, memberExpression, method4), new ParameterExpression[1] { parameterExpression });
                        }
                    case Operations.NotStartsWith:
                        {
                            MethodInfo method3 = typeof(string).GetMethod("StartsWith", new Type[1] { typeof(string) });
                            return Expression.Lambda<Func<T, bool>>(Expression.Not(ExpressionMethodString(property, fieldValue, memberExpression, method3)), new ParameterExpression[1] { parameterExpression });
                        }
                    case Operations.EndsWith:
                        {
                            MethodInfo method2 = typeof(string).GetMethod("EndsWith", new Type[1] { typeof(string) });
                            return Expression.Lambda<Func<T, bool>>(ExpressionMethodString(property, fieldValue, memberExpression, method2), new ParameterExpression[1] { parameterExpression });
                        }
                    case Operations.NotEndsWith:
                        {
                            MethodInfo method = typeof(string).GetMethod("EndsWith", new Type[1] { typeof(string) });
                            return Expression.Lambda<Func<T, bool>>(Expression.Not(ExpressionMethodString(property, fieldValue, memberExpression, method)), new ParameterExpression[1] { parameterExpression });
                        }
                    case Operations.Contains:
                        return Contains<T>(fieldValue, parameterExpression, memberExpression);
                    default:
                        throw new Exception("General Error - Not implement Operation");
                }
            }

            return (T x) => true;
        }

        private static PropertyDescriptor GetProperty(PropertyDescriptorCollection props, string fieldName, bool ignoreCase)
        {
            if (!fieldName.Contains('.'))
            {
                return props.Find(fieldName, ignoreCase);
            }

            string[] array = fieldName.Split('.');
            PropertyDescriptor propertyDescriptor = props.Find(array[0], ignoreCase);
            for (int i = 1; i < array.Count(); i++)
            {
                propertyDescriptor = propertyDescriptor.GetChildProperties().Find(array[i], ignoreCase);
            }

            return propertyDescriptor;
        }

        private static MethodCallExpression ExpressionMethodString(PropertyDescriptor prop, object fieldValue, MemberExpression memberExpression, MethodInfo methodInfo)
        {
            if (typeof(string) != prop.PropertyType)
            {
                MethodInfo method = typeof(object).GetMethod("ToString");
                MethodCallExpression instance = Expression.Call(memberExpression, method);
                return Expression.Call(instance, methodInfo, Expression.Constant(fieldValue, typeof(string)));
            }

            return Expression.Call(memberExpression, methodInfo, Expression.Constant(fieldValue, prop.PropertyType));
        }

        private static Expression<Func<T, bool>> Contains<T>(object fieldValue, ParameterExpression parameterExpression, MemberExpression memberExpression)
        {
            List<long> list = (List<long>)fieldValue;
            if (list == null || list.Count == 0)
            {
                return (T x) => true;
            }

            MethodInfo method = typeof(List<long>).GetMethod("Contains", new Type[1] { typeof(long) });
            MethodCallExpression body = Expression.Call(Expression.Constant(fieldValue), method, memberExpression);
            return Expression.Lambda<Func<T, bool>>(body, new ParameterExpression[1] { parameterExpression });
        }
    }
}
