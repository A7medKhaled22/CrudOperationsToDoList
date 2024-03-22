using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperationsToDoList.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly ToDoContext _context;

    public UnitOfWork(ToDoContext context)
    {
        _context = context;
        TodoItemRepository = new GenericRepository<ToDo>(_context);
    }

    public IGenericRepository<ToDo> TodoItemRepository { get; }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}