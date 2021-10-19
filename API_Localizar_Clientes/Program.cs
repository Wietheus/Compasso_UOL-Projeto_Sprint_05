using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
Haverão anotações minhas durante todo projeto, já que estou utilizando-o para aprender e servir como referência futura.

Pacotes do NuGet necessários para o projeto:
- Microsoft.EntityFrameworkCore;
- Microsoft.EntityFrameworkCore.SqlServer;
- Microsoft.EntityFrameworkCore.Tools.
*/

namespace API_Localizar_Clientes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

/*
[OBJETIVOS]

~Criar uma API Rest utilizando .NET 5, Entity Framework Core e SQL Server local com o contexto de relacionar Clientes a Cidades.

~Deverá ser pensado e modelado as entidades "Cidades" e "Clientes", utilizando a abordagem Code First ou Database First e mapeando com Entity Framework.
~As classes criadas para mapeamento não deverão ser expostas pela API diretamente.
~Portanto, será necessário criar DTOs que serão mapeadas pelo AutoMapper para servirem como resposta final da API.

~O projeto deverá expor 2 endpoints diferentes: Um para Clientes e outro para Cidades.
~Para cada endpoint, deverá ter:
-Listagem de todos registros
-Criação de um registro
-Edição de um registro por Id
-Remoção de um registro por Id
-Busca de um registro por Id

~O endpoint de criar ou editar um novo Cliente deverá receber somente o CEP como informação de endereço.
~A cidade deverá ser obtida por uma consulta de API externa (https://viacep.com.br/ws/01001000/json/) pelo CEP e então cruzar a informação com as Cidades cadastradas no banco local

~Realizar Testes de Integração do contexto de Clientes.

[MODELOS]

o--------o o--------------------o
| Cidade | | Cliente            |
|--------| |--------------------|
| ID     | | ID                 |
| Nome   | | Nome               |
| Estado | | Data de Nascimento |
o--------o | ID da Cidade       |
           | CEP                |
           | Logradouro         |
           | Bairro             |
           o--------------------o

[BÔNUS]

~Para todos endpoints também deverá utilizar Fluent Validation para validar no mínimo 1 campo (de cada classe) que esteja vazio ou inválido, e retornar a mensagem de validação.
*/