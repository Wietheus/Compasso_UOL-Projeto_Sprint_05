using System.ComponentModel.DataAnnotations;

/*
Anotações:
[Table("NomeDesejado")] => Explicitando o nome da tabela para o Entity Framework Core, que usaria como padrão o nome da classe.
[Required] => Evidenciando que é um campo obrigatório no corpo da requisição, podendo inclusive conter uma mensagem de erro.
[Column("NomeDesejado")] => Explicitando o nome da coluna para o Entity Framework Core, que usaria como padrão o nome da propriedade.
[Column(TypeName = "varchar(10)")] => Nesse caso, deixa claro o tipo de dado no padrão SQL ("varchar(10)" é apenas um exemplo).

Com as devidas anotações feitas nas propriedades e o pacote "Microsoft.EntityFrameworkCore.Tools" instalado:
- Abrir o "Console do Gerenciador de Pacotes";
- Inserir o comando "add-migration";
- Informar o nome desejado para a classe de migração (ou passá-lo como parâmetro na instrução anterior: "add-migration NomeDaClasse");
- Com a migração criada, utilizar o comando "script-migration" para gerar o script de criação do banco;
- Em caso de dúvida sobre os comandos, utilizar o comando "get-help entityframework" no mesmo console.
*/

namespace API_Localizar_Clientes.CSharp_Classes
{
    public class Cliente
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Você precisa preencher um nome!")]
        public string Nome { get; set; }

        [RegularExpression("[0-3][0-9]-[0-1][0-9]-[1,2][0,9][0-9][0-9]", ErrorMessage = "A data de nascimento deve ser informada no formato DD-MM-AAAA!")]
        public string DataNascimento { get; set; }

        public int CidadeID { get; set; }

        [RegularExpression("[0-9]{5}-?[0-9]{3}", ErrorMessage = "Devem ser informados os 8 números do CEP no formato 00000000 ou 00000-000!")]
        [Required(ErrorMessage = "Você precisa informar o CEP do endereço!")]
        public string CEP { get; set; }

        public string Logradouro { get; set; }

        public string Bairro { get; set; }
    }
}