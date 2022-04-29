using System.Runtime.CompilerServices;

namespace DFE.Core.Utility
{
    internal static class ValueTypeBoxingPool
    {
        private const int MIN_CACHED_INT = -128;
        private const int MAX_CACHED_INT = 127;

        private static readonly object BoxedBoolTrue = true;
        private static readonly object BoxedBoolFalse = false;
        private static readonly object[] BoxedIntegers = new object[MAX_CACHED_INT - MIN_CACHED_INT + 1];
        static ValueTypeBoxingPool()
        {
            for (var i = MIN_CACHED_INT; i <= MAX_CACHED_INT; i++)
                BoxedIntegers[i - MIN_CACHED_INT] = i;
        }
        public static object Box(int value)
            => BoxInt(value);
        public static object Box(bool value)
            => BoxBool(value);
        public static object Box<T>(T value)
        {
            if (typeof(T) == typeof(int))
                return BoxInt((int)(object)value);

            if (typeof(T) == typeof(bool))
                return BoxBool((bool)(object)value);

            return value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static object BoxBool(bool value)
        {
            return value ? BoxedBoolTrue : BoxedBoolFalse;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static object BoxInt(int value)
        {
            if (value >= MIN_CACHED_INT && value <= MAX_CACHED_INT)
            {
                return BoxedIntegers[value - MIN_CACHED_INT];
            }
            else
            {
                return value;
            }
        }
    }
}
