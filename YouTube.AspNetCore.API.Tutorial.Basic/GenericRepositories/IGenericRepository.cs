namespace YouTube.AspNetCore.API.Tutorial.Basic.GenericRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        void CreateItem(TEntity request);
        void UpdateItem(TEntity request);
        void DeleteItem(TEntity request);
        TEntity GetItemById(int id);
    }
}
