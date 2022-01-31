using System;

namespace Developist.Core.Utilities
{
    public static class NullableExtensions
    {
        public static bool IsNullOrDefault<T>(this T? value) where T : struct 
            => value.GetValueOrDefault().Equals(default(T));

        public static TResult IfNotNull<T, TResult>(this T target, Func<T, TResult> expression)
            => target != null ? expression(target) : default;

        public static void IfNotNull<T>(this T target, Action<T> expression)
        {
            if (target != null)
            {
                expression(target);
            }
        }
    }
}
