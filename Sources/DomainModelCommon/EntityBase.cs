namespace DomainModelCommon
{
    public abstract class EntityBase<T>
    {
        virtual public T Clone()
        {
            return (T)MemberwiseClone();
        }
    }
}
