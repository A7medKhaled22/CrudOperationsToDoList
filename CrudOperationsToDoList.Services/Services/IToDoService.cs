using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperationsToDoList.Services;

public interface IToDoService
{
    Task<IEnumerable<ToDoDTO>> GetAllTodos();

    Task<ToDoDTO> GetTodoById(int id);

    Task CreateTodo(ToDoDTO todoDTO);

    Task UpdateTodo(int id, ToDoDTO todoDTO);

    Task DeleteTodo(int id);
}