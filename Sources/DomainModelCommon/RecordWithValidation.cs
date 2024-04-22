namespace DomainModelCommon
{
    public abstract record RecordWithValidation
    {
        protected RecordWithValidation()
        {
            Validate();
        }

        protected abstract void Validate();
    }
}
