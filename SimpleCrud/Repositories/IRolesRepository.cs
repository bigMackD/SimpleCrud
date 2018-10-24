using SimpleCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCrud.Repositories
{
    public interface IRolesRepository
    {
        void Add(AddRoleModel roleModel);
        void Delete(long id);
        IEnumerable<RoleModel> GetRoleModels();
    }
}