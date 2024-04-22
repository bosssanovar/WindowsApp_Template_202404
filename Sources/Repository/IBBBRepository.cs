namespace Repository
{
    public interface IBBBRepository
    {
        BBBEntity.Entity.BBBEntity Load();
        void Save(BBBEntity.Entity.BBBEntity aaaEntity);
    }
}