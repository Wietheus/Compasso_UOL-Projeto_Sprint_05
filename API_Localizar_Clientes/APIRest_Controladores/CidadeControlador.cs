using API_Localizar_Clientes.CSharp_Classes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API_Localizar_Clientes.APIRest_Controladores
{
    [ApiController]
    //[Route("[controller]")] seria para usar o nome da classe como rota, algo que não ficaria adequado neste caso...
    [Route("cidade")]
    public class CidadeControlador : ControllerBase
    {
        private static Cidade cidadeTemporaria;
        private static int codigo = 0;
        private static List<Cidade> listaCidades = new List<Cidade>();

        [HttpPut("{id}")]
        public IActionResult AtualizarCidade(int id, [FromBody] Cidade novaCidade)
        {
            /*
            [EXEMPLO DE CORPO DA REQUISIÇÃO]
            {
                "Nome" : "Nome Atualizado",
                "Estado" : "Estado Atualizado"
            }
            */
            foreach (Cidade cidade in listaCidades)
            {
                if (cidade.ID == id)
                {
                    if (novaCidade.Nome != null)
                    {
                        cidadeTemporaria.Nome = novaCidade.Nome;
                    }
                    if (novaCidade.Estado != null)
                    {
                        cidadeTemporaria.Estado = novaCidade.Estado;
                    }
                    if (VerificarExistenciaNaLista(cidadeTemporaria))
                    {
                        return BadRequest();
                    }
                    cidade.Nome = cidadeTemporaria.Nome;
                    cidade.Estado = cidadeTemporaria.Estado;
                    Console.WriteLine($"[CIDADE {cidade.ID} ATUALIZADA COM SUCESSO]\n");
                    return Ok(cidade);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult CadastrarCidade([FromBody] Cidade cidade)
        {
            /*
            [EXEMPLO DE CORPO DA REQUISIÇÃO]
            {
                "Nome" : "Nome Original",
                "Estado" : "Estado Original"
            }
            */
            if (!VerificarExistenciaNaLista(cidade))
            {
                codigo++;
                cidade.ID = codigo;
                listaCidades.Add(cidade);
                Console.WriteLine($"[CIDADE CADASTRADA COM SUCESSO]\n\nID: {cidade.ID}\nNome: {cidade.Nome}\nEstado: {cidade.Estado}\n");
                return Ok(cidade);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverCidade(int id)
        {
            foreach (Cidade cidade in listaCidades)
            {
                if (cidade.ID == id)
                {
                    listaCidades.Remove(cidade);
                    Console.WriteLine($"[CIDADE {cidade.ID} REMOVIDA COM SUCESSO]\n");
                    return Ok(cidade);
                }
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult VisualizarCidadeEspecifica(int id)
        {
            foreach (Cidade cidade in listaCidades)
            {
                if (cidade.ID == id)
                {
                    Console.WriteLine($"[CIDADE {cidade.ID} ENCONTRADA COM SUCESSO]\n");
                    return Ok(cidade);
                }
            }
            return NotFound();
        }

        //[HttpGet("lista")] seria interessante caso houvessem muitas requisições GET diferentes...
        [HttpGet]
        public IEnumerable<Cidade> VisualizarListaDeCidades()
        {
            Console.WriteLine("[EXIBINDO LISTA DE CIDADES]\n");
            return listaCidades;
        }

        public bool VerificarExistenciaNaLista(Cidade cidadeParaVerificar)
        {
            foreach (Cidade cidade in listaCidades)
            {
                if (cidade == cidadeParaVerificar)
                {
                    return true;
                }
            }
            return false;
        }
    }
}