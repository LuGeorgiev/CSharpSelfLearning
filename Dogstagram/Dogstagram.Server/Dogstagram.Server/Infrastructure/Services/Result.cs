namespace Dogstagram.Server.Infrastructure.Services
{
    public class Result
    {
        public bool Succeeded { get; private set; }

        public string Error { get; private set; }

        public bool Failure => ! this.Succeeded;

        public static implicit operator Result (bool succeeded)
            => new Result { Succeeded = succeeded};

        public static implicit operator Result(string error)
            => new Result { Succeeded = false, Error = error };
    }
}
