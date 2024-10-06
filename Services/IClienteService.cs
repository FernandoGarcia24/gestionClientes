using gestionVentas.Models;


namespace gestionVentas.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAllClientes();
        Task<Cliente> GetClienteById(int id);
        Task AddCliente(Cliente cliente);
        Task UpdateCliente(int id, Cliente cliente);
        Task DeleteCliente(int id);
    }
}
