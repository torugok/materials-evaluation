namespace MaterialsEvaluation.Shared.Domain
{
    public class BusinessException : Exception
    {
        public BusinessException(string msg) : base(msg) { }
    }
}
