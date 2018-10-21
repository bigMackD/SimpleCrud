using SimpleCrud.Entities;
using SimpleCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCrud.Repositories
{
    public interface IPersonRepository
    {
        IList<UserModel> GetAllUsers();
        EditUserModel GetUser(long id);

        void Add(AddUserModel user);
        void Update(EditUserModel user);
        void Delete(long id);
    }
}
