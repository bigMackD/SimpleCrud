using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleCrud.Entities;
using SimpleCrud.Models;

namespace SimpleCrud.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly static IList<Role> _roles = new List<Role>()
        {
            new Role(){ Id = 1, RoleType="Administrator" },
            new Role(){Id = 2, RoleType="User"}
        };

        public void Add(AddRoleModel roleModel)
        {
            var role = new Role()
            {
                Id = GenerateId(),
                RoleType = roleModel.RoleType
            };
            _roles.Add(role);
        }

        public void Delete(long id)
        {
            var roleToDelete = _roles.Single(x => x.Id == id);
            _roles.Remove(roleToDelete);
        }

        public IEnumerable<RoleModel> GetRoleModels()
        {
            return _roles.Select(x => new RoleModel()
            {
                Id = x.Id,
                RoleType = x.RoleType
            }).ToList();
        }

        private long GenerateId()
        {
            return _roles.Max(x => x.Id) + 1;
        }
    }
}