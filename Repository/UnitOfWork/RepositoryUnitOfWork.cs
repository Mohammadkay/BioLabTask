using Repository.Interface;
using Repository.Repository;
using Repository.RepositoryUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public class RepositoryUnitOfWork:IRepositoryUnitOfWork
    {
        private string _ConnectionString;

        public Lazy<IUserRepository> userRepository { get; set; }

        public RepositoryUnitOfWork(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
            userRepository =new Lazy<IUserRepository> (()=>new UserRepository(_ConnectionString));
        }
    }
}
