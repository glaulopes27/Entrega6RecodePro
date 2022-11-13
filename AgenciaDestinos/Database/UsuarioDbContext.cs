

using AgenciaDestinos.Model;
using Microsoft.EntityFrameworkCore;

namespace AgenciaDestinos.Database
{
    public class UsuarioDbContext : DbContext
    {
         public UsuarioDbContext(DbContextOptions<UsuarioDbContext>
        options) : base(options) { 

        }

        public DbSet<Usuario> Usuarios { get; set; }

        
    //construtores de novos cadastros metodo listar
        public DbSet<Destinos> Destinostodos { get; set; }

        // criar alterar mexer no Banco de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            var usuario = modelBuilder.Entity<Usuario>();
            usuario.ToTable("usuario");
            usuario.HasKey(x => x.Id);//chave primaria
            usuario.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();//auto increment ID
            usuario.Property(x => x.Nome).HasColumnName("nome").IsRequired();//colunas
            usuario.Property(x => x.DataNascimento).HasColumnName("data_nascimento");

            var destinos = modelBuilder.Entity<Destinos>();
            destinos.ToTable("destinos");
            destinos.HasKey(x => x.Id);//chave primaria
            destinos.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();//auto increment ID
            destinos.Property(x => x.Nome).HasColumnName("nome").IsRequired();//colunas
            destinos.Property(x => x.Descricao).HasColumnName("descricao").IsRequired();//colunas
            destinos.Property(x => x.DataPacote).HasColumnName("data_pacote");
        }
        
      
    }
}
    
