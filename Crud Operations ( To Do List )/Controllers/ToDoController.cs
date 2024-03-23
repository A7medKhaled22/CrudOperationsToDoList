using CrudOperationsToDoList.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Operations___To_Do_List__.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _todoService;

        public ToDoController(IToDoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoDTO>>> GetAllTodos()
        {
            var todos = await _todoService.GetAllTodos();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoDTO>> GetTodoById(int id)
        {
            var todo = await _todoService.GetTodoById(id);
            if (todo == null)
                return NotFound();

            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] ToDoDTO ToDoDTO)
        {
            await _todoService.CreateTodo(ToDoDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, [FromBody] ToDoDTO ToDoDTO)
        {
            try
            {
                await _todoService.UpdateTodo(id, ToDoDTO);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            await _todoService.DeleteTodo(id);
            return NoContent();
        }
    }
}