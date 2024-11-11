using DAL.Context;
using DAL.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL.Repository
{
    public class TodoRepository(ToDoContext context) : ITodoRepository
    {

        private readonly ToDoContext _context = context;


        public async Task AddAsync(Item item)
        {
            await _context.Items.AddAsync(item);
           await _context.SaveChangesAsync();
           

       

        }

        public async Task DeleteAsync(int id)
        {

            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id==id);
            if (item != null)
            {
                _context.Remove(item);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Id invalido");
            }
           
        }

        public async Task<IEnumerable<Item>> GetAlltItemsAsync()
        {
            var listItems = await _context.Items.ToListAsync();
            return listItems;
        }

        public async Task<Item> GetAsync(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("nao encontrado");

            return item;
        }

        public async Task UpdateAsync(Item item, int id)
        {

            
            var existingItem = await _context.Items.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("nao encontrado");

            if (existingItem.Completed != DateTime.MinValue) throw new Exception("Tarefa finalizada não pode ser modificada");
            existingItem.Name = item.Name;
            existingItem.Completed = item.Completed;
            existingItem.IsCompleted = item.IsCompleted;

            await _context.SaveChangesAsync();



        }
    }
}
