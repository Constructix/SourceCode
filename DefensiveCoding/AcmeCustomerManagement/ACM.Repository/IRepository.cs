namespace ACM.Repository
{
    public interface IRepository<IModel>
    {
        void Add(IModel entityToAdd);
    }
}