using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCrud.Entities;
using SimpleCrud.Models;

namespace SimpleCrud.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly static IList<User> _users = new List<User>()
        {
            new User(){ Id = 1, FirstName = "Maciek", LastName = "Drzd", DateOfBirth = new DateTime(1987,11,11)},
            new User(){ Id = 2, FirstName = "Agnieszka", LastName = "Orzeszka", DateOfBirth = new DateTime(1998,9,10)}
        };

        public void Add(AddUserModel userModel)
        {
            var user = new User()
            {
                Id = GenerateKey(),
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                DateOfBirth = userModel.DateOfBirth,
                IsActive = true,
            };
            _users.Add(user);
        }

        public void Delete(long id)
        {
            var userToDelete = _users.Single(x => x.Id == id);
            _users.Remove(userToDelete);
        }

        public IList<UserModel> GetAllUsers()
        {
            return _users.Select(u => new UserModel
            {
                Id = u.Id,
                FullName = string.Format("{0} {1}", u.FirstName, u.LastName),
                Age = DateTime.Now.Year - u.DateOfBirth.Year,
                IsActiveAsString = u.IsActive ? "Yes" : "No"
            })
            .ToList();
        }

        public EditUserModel GetUser(long id)
        {
            return _users.Select(x => new EditUserModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                IsActive = x.IsActive
            })
            .SingleOrDefault(x => x.Id == id);
        }

        public void Update(EditUserModel user)
        {
            var userToUpdate = _users.Single(x => x.Id == user.Id);

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;

            userToUpdate.IsActive = user.IsActive;
        }

        private long GenerateKey()
        {
            return _users.Max(x => x.Id) + 1;
        }
    }
}
