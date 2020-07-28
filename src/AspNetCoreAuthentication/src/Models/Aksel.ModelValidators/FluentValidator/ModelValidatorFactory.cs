using System;
using FluentValidation;

namespace Aksel.ModelValidators.FluentValidator
{
    public class ModelValidatorFactory : ValidatorFactoryBase
    {
        private readonly Func<Type, IValidator> _factory;

        public ModelValidatorFactory(Func<Type, IValidator> factory)
        {
            _factory = factory;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            IValidator validator = _factory(validatorType);

            return validator;
        }
    }
}