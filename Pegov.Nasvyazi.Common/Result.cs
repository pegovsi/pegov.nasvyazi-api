using System;

namespace Pegov.Nasvyazi.Common
{
    public class Result<T>
    {
        public Result(T value, string[] errors = null)
        {
            Value = value;
            Errors = errors ?? Array.Empty<string>();
        }

        public T Value { get; }

        public string[] Errors { get; }
    }
}