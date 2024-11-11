using DAL.Repository.Contracts;
using Models;

namespace BLL
{
    public class ToDoServices(ITodoRepository todoRepository)
    {

        private readonly ITodoRepository _todoRepository = todoRepository;
       

        public async Task<IEnumerable<Item>> GetItemsService()
        {
            return await _todoRepository.GetAlltItemsAsync();
        }

        public async Task<Item> GetByIdService(int id)
        {
            if (id == 0) throw new ArgumentException("informe uma tarefa valida");
            return await _todoRepository.GetAsync(id);
        }

        public async Task<bool> AddItemService(Item item)
        {
            ArgumentNullException.ThrowIfNull(item);
            await _todoRepository.AddAsync(item);
            return true;
        }

        public async Task<bool> DeleteItemService(int id)
        {
            if (id == 0) throw new ArgumentException($"{nameof(id)} cannot be deleted");
            await _todoRepository.DeleteAsync(id);
            return true;
             

        }

        public async Task<bool> UpdateItemService(int id, Item item)
        {

           if(item == null || id==0) throw new ArgumentNullException( nameof(item));
            if (item.IsCompleted == true) item.Completed = DateTime.Now;
            if (item.Completed != DateTime.MinValue) item.IsCompleted = true;
            await _todoRepository.UpdateAsync(item,id);
            return true;
        }
    }
}
