using AutoMapper;
using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Models;

namespace TodoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController(ToDoServices services, IMapper mapper) : ControllerBase
    {
        private readonly ToDoServices _services = services;
        private readonly IMapper _mapper = mapper;


        [HttpGet("Get all")]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetAllItemsAsync()
        {
            var list = await _services.GetItemsService();
            return Ok(_mapper.Map<IEnumerable<ItemDto>>(list));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync1(int id)
        {
            var item = await _services.GetByIdService(id);
            var itemDto = _mapper.Map<ItemDto>(item);
            return Ok(itemDto);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> AddItem(CreateTaskDto itemDto)
        {
            var item = _mapper.Map<Item>(itemDto);
            var response = await _services.AddItemService(item);
            if (!response) return BadRequest(response);
            return Ok("Salvo!!");
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            var response = await _services.DeleteItemService(id);

            if (!response) return BadRequest(response);
            return Ok("Deletado!!");



        }

        [HttpPut("Edit")]
        public async Task<ActionResult> UpdateItem(int id, ItemDto updateDto)
        {
            var item = _mapper.Map<Item>(updateDto);

            var result = await _services.UpdateItemService(id, item);
            return Ok(result);
        }



    }
}
