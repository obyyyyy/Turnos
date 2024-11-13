using Microsoft.EntityFrameworkCore.Design;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Turnos.Models
{
    public class TurnosContextFactory : IDesignTimeDbContextFactory<TurnosContext>{

        public TurnosContext CreateDbContext(String[] args)

        {
            //Configuración de la ruta de la cadena de Conexión 
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            
            //Crear las opciones de DBConext usando la cadena de conexión
            var optionBuilder = new DbContextOptionsBuilder<TurnosContext>();
            var connectionString = configuration.GetConnectionString("TurnosContext");
            optionBuilder.UseSqlServer(connectionString);

            return new TurnosContext(optionBuilder.Options);
        }
}

    
}