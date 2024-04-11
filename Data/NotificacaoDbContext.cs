using BackendNotificacaoDeAudiecia.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendNotificacaoDeAudiecia.Data
{
    public class NotificacaoDbContext : DbContext
    {
        public NotificacaoDbContext(DbContextOptions<NotificacaoDbContext> options) : base(options)
        {
                
        }

        public DbSet<AudienciaModels> Audiencia { get; set; }
    }
}

