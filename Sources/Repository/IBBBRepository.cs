namespace Repository
{
    public interface IBBBRepository
    {
        BBBEntity.Entity.BBBEntity Pull();
        void Commit(BBBEntity.Entity.BBBEntity aaaEntity);
    }
}