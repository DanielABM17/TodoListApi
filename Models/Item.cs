
namespace Models
{
    public class Item
    {
        public int Id { get; set; }
        public required string Name { get; set; } 
        public DateTime Initial {  get; set; }
        public DateTime Completed { get; set; } =DateTime.MinValue;
        public bool IsCompleted { get; set; } = false;
    }
}
