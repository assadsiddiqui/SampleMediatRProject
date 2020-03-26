using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace MediatorDomain.Generic
{
    public class ValidatorCode : IValidator<GreetingsRequest>
    {
        private readonly IPersonRepository personRepository;

        public ValidatorCode(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
            CascadeMode = CascadeMode.Continue;
        }

        public CascadeMode CascadeMode { get; set; }

        public bool CanValidateInstancesOfType(Type type)
        {
            return true;
        }

        public IValidatorDescriptor CreateDescriptor()
        {
            throw new NotImplementedException();
        }

        public ValidationResult Validate(GreetingsRequest instance)
        {
            var result = new ValidationResult();

            try
            {
               var personId = personRepository.GetPersonName(instance.PersonId);
            }
            catch (ArgumentNullException ex)
            {
                //throw new Exception($"System can't find user with Id {request.PersonId}. Error: {ex.Message}");
                result.Errors.Add(new ValidationFailure("PersonId", $"System can't find user with Id {instance.PersonId}"));
            }
            return result;
        }

        public ValidationResult Validate(object instance)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Validate(ValidationContext context)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> ValidateAsync(GreetingsRequest instance, CancellationToken cancellation = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> ValidateAsync(object instance, CancellationToken cancellation = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> ValidateAsync(ValidationContext context, CancellationToken cancellation = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
