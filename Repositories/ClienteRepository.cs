using gestionVentas.Data;
using gestionVentas.Models;
using Microsoft.EntityFrameworkCore;

namespace gestionVentas.Repositories
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            { 
                throw new KeyNotFoundException($"Cliente con ID {id} no encontrado."); 
            }

            return cliente;
        }

        public async Task AddCliente(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCliente(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCliente(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ClienteExists(int id)
        {
            return await _context.Clientes.AnyAsync(e => e.ClienteID == id);
        }

    }
}
