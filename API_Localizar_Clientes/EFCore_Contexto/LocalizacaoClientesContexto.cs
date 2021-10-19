using API_Localizar_Clientes.CSharp_Classes;
using Microsoft.EntityFrameworkCore;

namespace API_Localizar_Clientes.EFCore_Contexto
{
    //Fazendo a conexão do Entity Framework Core com o banco de dados...
    public class LocalizacaoClientesContexto : DbContext
    {
        //É por meio do DbSet que o Entity Framework Core entenderá que precisa configurar o banco baseado nas classes Cidade, Cliente e Endereco:
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LocalizacaoClientes;Trusted_connection=true;");
        }

        //No lugar de fazermos anotações nas classes, podemos configurá-las por meio deste método:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurando a tabela "Cidades":
            modelBuilder.Entity<Cidade>()
                .ToTable("Cidades");

            modelBuilder.Entity<Cidade>()
                .Property(x => x.Nome)
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<Cidade>()
                .Property(x => x.Estado)
                .HasColumnType("varchar(50)");

            //Configurando a tabela "Clientes":
            modelBuilder.Entity<Cliente>()
                .ToTable("Clientes");

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Nome)
                .HasColumnType("varchar(100)");
                //.IsRequired() não é necessário, já que informamos em uma anotação na própria classe (foi deixado lá apenas para exibir o erro de obrigatoriedade).

            modelBuilder.Entity<Cliente>()
                .Property(x => x.DataNascimento)
                .HasColumnName("Data_de_Nascimento")
                .HasColumnType("varchar(10)");

            modelBuilder.Entity<Cliente>()
                .Property(x => x.CidadeID)
                .HasColumnName("ID_Cidade");

            modelBuilder.Entity<Cliente>()
                .Property(x => x.CEP)
                .HasColumnType("varchar(9)");
                //.IsRequired() não é necessário, já que informamos em uma anotação na própria classe (foi deixado lá apenas para exibir o erro de obrigatoriedade).

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Logradouro)
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Bairro)
                .HasColumnType("varchar(50)");

            //Configurando a tabela de relacionamento "Enderecos":
            modelBuilder.Entity<Endereco>()
                .ToTable("Enderecos");

            modelBuilder.Entity<Endereco>()
                .Property<int>("ID_Cliente");

            modelBuilder.Entity<Endereco>()
                .Property<int>("ID_Cidade");

            modelBuilder.Entity<Endereco>()
                .HasKey("ID_Cliente", "ID_Cidade");
        }
    }
}