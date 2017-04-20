namespace EMS.Core.Domain.Validation
{
    public interface ISelfValidation
    {
        //ValidationResult ValidationResult { get; }
        bool IsValid { get; }
    }
}