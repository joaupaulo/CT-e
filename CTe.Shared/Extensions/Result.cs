
namespace CTe.Shared.Extensions
{
    public class Result
    {
        public bool IsSuccess { get; private set; }
        public bool IsFailure => !IsSuccess;
        public List<string> Errors { get; private set; }

        protected Result(bool isSuccess, List<string> errors)
        {
            IsSuccess = isSuccess;
            Errors = errors ?? new List<string>();
        }

        public static Result Ok() => new Result(true, null);
        public static Result Fail(List<string> errors) => new Result(false, errors);

        public static Result Fail(string error) => new Result(false, new List<string> { error });
    }
}
