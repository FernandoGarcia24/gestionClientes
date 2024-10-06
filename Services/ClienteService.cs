using gestionVentas.Models;
using gestionVentas.Repositories;


namespace gestionVentas.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {
            return await _clienteRepository.GetAllClientes();
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            return await _clienteRepository.GetClienteById(id);
        }

        public async Task AddCliente(Cliente cliente)
        {
            await _clienteRepository.AddCliente(cliente);
        }

        public async Task UpdateCliente(int id, Cliente cliente)
        {
            if (id != cliente.ClienteID)
            {
                throw new Exception("El ID no coincide.");
            }

            await _clienteRepository.UpdateCliente(cliente);
        }

        public async Task DeleteCliente(int id)
        {
            var cliente = await _clienteRepository.GetClienteById(id);
            if (cliente == null)
            {
                throw new Exception("Cliente no encontrado.");
            }

            await _clienteRepository.DeleteCliente(cliente);
        }
    }
}
