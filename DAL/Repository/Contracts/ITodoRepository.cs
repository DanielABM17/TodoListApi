using Models;

namespace DAL.Repository.Contracts
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Item>> GetAlltItemsAsync();

        Task AddAsync(Item item);
        
        Task<Item> GetAsync(int id);

        Task DeleteAsync(int id);

        Task UpdateAsync(Item item, int id);
    }
}
