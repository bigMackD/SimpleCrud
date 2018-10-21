using SimpleCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCrud.Validators
{
    public class AddUserModelValidator : IValidator<AddUserModel>
    {
        public IEnumerable<ValidateResult> Validate(AddUserModel model)
        {
            var result = new List<ValidateResult>();

            var dateOfBirth = model.DateOfBirth;
            var now = DateTime.UtcNow;

            var yearsDifference = now.Year - dateOfBirth.Year;

            if(yearsDifference <= 10)
            {
                result.Add(new ValidateResult
                {
                    Key = nameof(model.DateOfBirth),
                    Message = "User must be at least 10 years old!"
                });
            }

            return result;
        }
    }
}