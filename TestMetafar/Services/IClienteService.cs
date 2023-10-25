using TestMetafar.Helpers;
using TestMetafar.Models;

namespace TestMetafar.Services
{
    public interface IClienteService
    {

    }

    public class ClienteService : IClienteService
    {
        private DataContext _context;

        public ClienteService(DataContext context)
        {
            _context = context;
        }        

        
    }
}
