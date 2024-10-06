using gestionVentas.Models;

namespace gestionVentas.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllClientes();
        Task<Cliente> GetClienteById(int id);
        Task AddCliente(Cliente cliente);
        Task UpdateCliente(Cliente cliente);
        Task DeleteCliente(Cliente cliente);
        Task<bool> ClienteExists(int id);
    }
}
