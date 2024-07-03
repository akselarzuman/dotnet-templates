using System.Threading.Tasks;

namespace Aksel.ModelValidators.FluentValidator
{
    public interface IModelValidator
    {
        Task ValidateAsync<T>(T model);
    }
}