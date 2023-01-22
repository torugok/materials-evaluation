namespace MaterialsEvaluation.Shared.Application
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string msg)
            : base(msg) { }

        public NotFoundException()
            : base() { }

        public NotFoundException(string? message, Exception? innerException)
            : base(message, innerException) { }
    }
}
