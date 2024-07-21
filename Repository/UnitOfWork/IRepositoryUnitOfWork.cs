using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryUnitOfWork
{
    public interface IRepositoryUnitOfWork
    {
        Lazy<IUserRepository> userRepository { get; set; }
    }
}
