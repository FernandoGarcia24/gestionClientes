using Microsoft.AspNetCore.Mvc;
using gestionVentas.Models;
using gestionVentas.Services;
using Microsoft.AspNetCore.Cors;

namespace gestionVentas.Controllers
{ 
    
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
        {
            var clientes = await _clienteService.GetAllClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            var cliente = await _clienteService.GetClienteById(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (cliente == null || string.IsNullOrWhiteSpace(cliente.Nombre) || string.IsNullOrWhiteSpace(cliente.Correo))
            {
                return BadRequest("El nombre y el correo son campos obligatorios.");
            }

            await _clienteService.AddCliente(cliente);
            return CreatedAtAction(nameof(GetById), new { id = cliente.ClienteID }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Cliente cliente)
        {
            try
            {
                await _clienteService.UpdateCliente(id, cliente);
                return Ok(new { message = "Cliente actualizado con éxito." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _clienteService.DeleteCliente(id);
                return Ok(new { message = "Cliente eliminado exitosamente." });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
