using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Aksel.ModelValidators.FluentValidator
{
    public class ModelValidator : IModelValidator
    {
        private readonly ModelValidatorFactory _modelValidatorFactory;

        public ModelValidator(ModelValidatorFactory modelValidatorFactory)
        {
            _modelValidatorFactory = modelValidatorFactory;
        }

        public async Task ValidateAsync<T>(T model)
        {
            Type type = typeof(T);
            IValidator validator = _modelValidatorFactory.GetValidator(type);

            if (validator == null)
            {
                return;
            }

            ValidationContext<T> validationContext = new ValidationContext<T>(model);
            ValidationResult validationResult = await validator.ValidateAsync(validationContext);

            if (validationResult != null && !validationResult.IsValid)
            {
                string exceptionMessage = GetExceptionMessage(validationResult);
                throw new ValidationException(exceptionMessage);
            }
        }

        private static string GetExceptionMessage(ValidationResult validationResult)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> errors = validationResult.Errors.Select(error => $"{error.ErrorCode} {error.ErrorMessage}").Distinct();

            foreach (string error in errors)
            {
                sb.AppendLine(error);
            }

            return sb.ToString();
        }
    }
}