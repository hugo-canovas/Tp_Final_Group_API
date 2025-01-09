namespace tp_app_back.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        public Task<List<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(int id);
        public Task<T> CreateAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task<bool> DeleteAsync(int id);
    }
}
