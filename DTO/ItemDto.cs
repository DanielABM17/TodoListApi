using System;
using System.Collections.Generic;

namespace DTO
{
    public class ItemDto
    {

        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Initial { get; set; }
        public string? Completed { get; set; }
        public int IsCompleted { get; set; }
    }
}
