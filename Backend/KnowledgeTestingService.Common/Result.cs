using System.Diagnostics.CodeAnalysis;

namespace KnowledgeTestingService.Common
{
    public class Result
    {
        public bool Success { get; }
        public int Status { get; }

        public bool Failure => !Success;

        protected Result(bool success, int status)
        {
            Success = success;
            Status = status;
        }

        public static Result Fail(int status)
        {
            return new Result(false, status);
        }

        public static Result<TV> Fail<TV>(int status)
        {
            return new Result<TV>(false, status, default);
        }

        public static Result Ok()
        {
            return new Result(true, default);
        }

        public static Result<TV> Ok<TV>(TV value)
        {
            return new Result<TV>(true, default, value);
        }
    }

    public class Result<TValue> : Result
    {
        public TValue Value { get; }

        protected internal Result(bool success, int status, [AllowNull]TValue value)
            : base(success, status)
        {
            Value = value;
        }
    }
}
