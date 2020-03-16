using System;
using System.Threading.Tasks;

namespace MediatorDomain
{
    public class PersonRepository : IPersonRepository
    {
        public Task<string> GetPersonName(int personId)
        {
            string name;
            switch (personId)
            {
                case 1:
                    name = "Assad";
                    break;
                case 2:
                    name = "John";
                    break;
                case 3:
                    name = "Jack";
                    break;
                case 4:
                    name = "David";
                    break;
                case 5:
                    name = "Jane";
                    break;
                default:
                    throw new ArgumentNullException("Person not found");
            }

            return Task.FromResult(name);
        }
    }
}
