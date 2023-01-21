namespace MaterialsEvaluation.Shared.Domain
{
    public class BusinessException : Exception
    {
        public BusinessException(string msg)
            : base(msg) { }

        public BusinessException()
            : base() { }

        public BusinessException(string? message, Exception? innerException)
            : base(message, innerException) { }
    }
}
