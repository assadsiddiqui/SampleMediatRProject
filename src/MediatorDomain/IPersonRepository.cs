using System.Threading.Tasks;

namespace MediatorDomain
{
    public interface IPersonRepository
    {
        Task<string> GetPersonName(int personId);
    }
}
