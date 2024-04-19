





namespace Repository
{
    public interface IBBBRepository
    {
        BBBEntity.BBBEntity Load();
        void Save(BBBEntity.BBBEntity aaaEntity);
    }
}