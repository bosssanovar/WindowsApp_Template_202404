namespace Repository
{
    public interface IAAARepository
    {
        AAAEntity.Entity.AAAEntity Load();
        void Save(AAAEntity.Entity.AAAEntity aaaEntity);
    }
}