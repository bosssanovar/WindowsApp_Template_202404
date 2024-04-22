namespace DomainModelCommon
{
    public abstract record ValueObjectBase<T>(T Value) : RecordWithValidation
    {
    }
}
