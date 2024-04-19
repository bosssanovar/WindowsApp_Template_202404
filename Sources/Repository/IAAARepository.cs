





namespace Repository
{
    public interface IAAARepository
    {
        AAAEntity.AAAEntity Load();
        void Save(AAAEntity.AAAEntity aaaEntity);
    }
}