using Microsoft.EntityFrameworkCore;
using MiniATM.Domain;

namespace MiniATM.Infrastructure
{
    internal class AppDbContext : DbContext //  
    {
        public DbSet<Conta> Contas => Set<Conta>();
        public DbSet<Transacao> Transacoes => Set<Transacao>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mini_atm.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conta>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Numero)
                      .IsRequired(); // not null

                entity.Property(c => c.Saldo)
                      .HasPrecision(18, 2);

                entity.HasMany(c => c.Transacoes)
                      .WithOne(t => t.Conta)
                      .HasForeignKey(t => t.ContaId);
            });

            modelBuilder.Entity<Transacao>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Valor)
                      .HasPrecision(18, 2);

                entity.Property(t => t.Tipo)
                      .IsRequired();

                entity.Property(t => t.Data)
                      .IsRequired();
            });
        }

    }
}
