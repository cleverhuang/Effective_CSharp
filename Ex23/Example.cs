using System;

namespace Ex23
{
    public static class Example
    {
        public static T Add<T>(T left, T right, Func<T, T, T> AddFunc) =>
            AddFunc(left, right);
    }
}
