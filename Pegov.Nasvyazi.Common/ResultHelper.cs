using System;
using System.Collections.Generic;
using System.Linq;

namespace Pegov.Nasvayzi.Common
{
    public static class ResultHelper
    {
        public static Result<T> Success<T>(T value) =>
            new Result<T>(value);

        public static Result<T> Warn<T>(T value, string error)
        {
            if (string.IsNullOrEmpty(error))
            {
                throw new ArgumentNullException(nameof(error));
            }

            return new Result<T>(value, new[] { error });
        }

        public static Result<T> Warn<T>(T value, IEnumerable<string> errors)
        {
            if (errors is null)
            {
                throw new ArgumentNullException(nameof(errors));
            }

            return new Result<T>(value, errors.ToArray());
        }

        public static Result<T> Error<T>(string error)
        {
            if (string.IsNullOrEmpty(error))
            {
                throw new ArgumentNullException(nameof(error));
            }

            return new Result<T>(default, new[] { error });
        }

        public static Result<T> Error<T>(IEnumerable<string> errors)
        {
            if (errors is null)
            {
                throw new ArgumentNullException(nameof(errors));
            }

            return new Result<T>(default, errors.ToArray());
        }
    }
}