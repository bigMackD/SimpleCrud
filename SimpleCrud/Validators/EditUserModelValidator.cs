using SimpleCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCrud.Validators
{
    public class EditUserModelValidator : IValidator<EditUserModel>
    {
        public IEnumerable<ValidateResult> Validate(EditUserModel model)
        {
            var result = new List<ValidateResult>();

            var firstName = model.FirstName?.Trim();
            var lastName = model.LastName?.Trim();
            var now = DateTime.UtcNow;


            if (HasStringContainsDigit(firstName))
            {
                result.Add(new ValidateResult
                {
                    Key = nameof(model.FirstName),
                    Message = "First name cannot contains numbers"
                });
            }

            if (HasStringContainsDigit(lastName))
            {
                result.Add(new ValidateResult
                {
                    Key = nameof(model.FirstName),
                    Message = "Last name cannot contains numbers"
                });
            }

           bool HasStringContainsDigit(string word)
            {
                return word?.Any(char.IsDigit) ?? false;
            }

            return result;
        }
    }
}