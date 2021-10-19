using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
Haver�o anota��es minhas durante todo projeto, j� que estou utilizando-o para aprender e servir como refer�ncia futura.

Pacotes do NuGet necess�rios para o projeto:
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

~Dever� ser pensado e modelado as entidades "Cidades" e "Clientes", utilizando a abordagem Code First ou Database First e mapeando com Entity Framework.
~As classes criadas para mapeamento n�o dever�o ser expostas pela API diretamente.
~Portanto, ser� necess�rio criar DTOs que ser�o mapeadas pelo AutoMapper para servirem como resposta final da API.

~O projeto dever� expor 2 endpoints diferentes: Um para Clientes e outro para Cidades.
~Para cada endpoint, dever� ter:
-Listagem de todos registros
-Cria��o de um registro
-Edi��o de um registro por Id
-Remo��o de um registro por Id
-Busca de um registro por Id

~O endpoint de criar ou editar um novo Cliente dever� receber somente o CEP como informa��o de endere�o.
~A cidade dever� ser obtida por uma consulta de API externa (https://viacep.com.br/ws/01001000/json/) pelo CEP e ent�o cruzar a informa��o com as Cidades cadastradas no banco local

~Realizar Testes de Integra��o do contexto de Clientes.

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

[B�NUS]

~Para todos endpoints tamb�m dever� utilizar Fluent Validation para validar no m�nimo 1 campo (de cada classe) que esteja vazio ou inv�lido, e retornar a mensagem de valida��o.
*/