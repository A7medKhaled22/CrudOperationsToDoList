using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperationsToDoList.DAL;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<ToDo> TodoItemRepository { get; }

    Task<int> SaveChangesAsync();
}