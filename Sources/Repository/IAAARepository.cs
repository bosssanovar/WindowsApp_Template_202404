namespace Repository
{
    public interface IAAARepository
    {
        AAAEntity.Entity.AAAEntity Pull();
        void Commit(AAAEntity.Entity.AAAEntity aaaEntity);
    }
}