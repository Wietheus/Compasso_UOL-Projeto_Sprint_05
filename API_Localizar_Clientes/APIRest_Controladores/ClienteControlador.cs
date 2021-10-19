using API_Localizar_Clientes.CSharp_Classes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API_Localizar_Clientes.APIRest_Controladores
{
    [ApiController]
    //[Route("[controller]")] seria para usar o nome da classe como rota, algo que não ficaria adequado neste caso...
    [Route("cliente")]
    public class ClienteControlador : ControllerBase
    {
        private static int codigo = 0;
        private static List<Cliente> listaClientes = new List<Cliente>();

        [HttpPut("{id}")]
        public IActionResult AtualizarCliente(int id, [FromBody] Cliente novoCliente)
        {
            /*
            [EXEMPLO DE CORPO DA REQUISIÇÃO]
            {
                "Nome" : "Nome Atualizado",
                "DataNascimento" : "31-12-2021",
                "CEP" : "87654-321"
            }
            */
            foreach (Cliente cliente in listaClientes)
            {
                if (cliente.ID == id)
                {
                    if (novoCliente.Nome != null)
                    {
                        cliente.Nome = novoCliente.Nome;
                    }
                    if (novoCliente.DataNascimento != null)
                    {
                        cliente.DataNascimento = novoCliente.DataNascimento;
                    }
                    if (novoCliente.CEP != null)
                    {
                        cliente.CEP = novoCliente.CEP;
                    }
                    Console.WriteLine($"[CLIENTE {cliente.ID} ATUALIZADO COM SUCESSO]\n");
                    return Ok(cliente);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public void CadastrarCliente([FromBody] Cliente cliente)
        {
            /*
            [EXEMPLO DE CORPO DA REQUISIÇÃO]
            {
                "Nome" : "Nome Original",
                "DataNascimento" : "01-01-2021",
                "CEP" : "12345-678"
            }
            */
            codigo++;
            cliente.ID = codigo;
            listaClientes.Add(cliente);
            Console.WriteLine($"[CLIENTE CADASTRADO COM SUCESSO]\n\nID: {cliente.ID}\nNome: {cliente.Nome}\nCEP: {cliente.CEP}\n");
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverCliente(int id)
        {
            foreach (Cliente cliente in listaClientes)
            {
                if (cliente.ID == id)
                {
                    listaClientes.Remove(cliente);
                    Console.WriteLine($"[CLIENTE {cliente.ID} REMOVIDO COM SUCESSO]\n");
                    return Ok(cliente);
                }
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult VisualizarClienteEspecifico(int id)
        {
            foreach (Cliente cliente in listaClientes)
            {
                if (cliente.ID == id)
                {
                    Console.WriteLine($"[CLIENTE {cliente.ID} ENCONTRADO COM SUCESSO]\n");
                    return Ok(cliente);
                }
            }
            return NotFound();
        }

        //[HttpGet("lista")] seria interessante caso houvessem muitas requisições GET diferentes...
        [HttpGet]
        public IEnumerable<Cliente> VisualizarListaDeClientes()
        {
            Console.WriteLine("[EXIBINDO LISTA DE CLIENTES]\n");
            return listaClientes;
        }
    }
}