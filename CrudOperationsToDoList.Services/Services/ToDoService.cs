using AutoMapper;
using CrudOperationsToDoList.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperationsToDoList.Services;

public class ToDoService : IToDoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ToDoService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ToDoDTO>> GetAllTodos()
    {
        var todos = await _unitOfWork.TodoItemRepository.GetAll();
        return _mapper.Map<IEnumerable<ToDoDTO>>(todos);
    }

    public async Task<ToDoDTO> GetTodoById(int id)
    {
        var todo = await _unitOfWork.TodoItemRepository.GetById(id);
        return _mapper.Map<ToDoDTO>(todo);
    }

    public async Task CreateTodo(ToDoDTO ToDoDTO)
    {
        var todo = _mapper.Map<ToDo>(ToDoDTO);
        await _unitOfWork.TodoItemRepository.Create(todo);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateTodo(int id, ToDoDTO ToDoDTO)
    {
        var existingTodo = await _unitOfWork.TodoItemRepository.GetById(id);
        if (existingTodo == null)
            throw new Exception("Todo not found");

        _mapper.Map(ToDoDTO, existingTodo);
        await _unitOfWork.TodoItemRepository.Update(existingTodo);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteTodo(int id)
    {
        var existingTodo = await _unitOfWork.TodoItemRepository.GetById(id);
        await _unitOfWork.TodoItemRepository.Delete(existingTodo);
        await _unitOfWork.SaveChangesAsync();
    }
}