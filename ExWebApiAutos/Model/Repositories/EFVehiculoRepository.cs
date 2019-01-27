using ExWebApiAutos.Model.VehiculoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExWebApiAutos.Model.Repositories
{
    public class EFVehiculoRepository : IVehiculoRepository
    {
        public IQueryable<TVehiculo> Vehiculos => context.TVehiculo;
        private VehiculoDbContext context;
        public EFVehiculoRepository(VehiculoDbContext ctx)
        {
            context = ctx;
        }
        public async Task SaveVehiculo(TVehiculo vehiculo)
        {
            if (vehiculo.VehiculoId == Guid.Empty)
            {
                vehiculo.VehiculoId = Guid.NewGuid();
                context.TVehiculo.Add(vehiculo);
            }
            else
            {
                TVehiculo dbEntry = context.TVehiculo
                .FirstOrDefault(p => p.VehiculoId == vehiculo.VehiculoId);
                if (dbEntry != null)
                {
                    dbEntry.VehiculoColor = vehiculo.VehiculoColor;
                    dbEntry.VehiculoAnioFabri = vehiculo.VehiculoAnioFabri;
                    dbEntry.VehiculoPlaca = vehiculo.VehiculoPlaca;
                    dbEntry.VehiculoNroAsientos = vehiculo.VehiculoNroAsientos;
                    dbEntry.VehiculoMecanico = vehiculo.VehiculoMecanico;
                    dbEntry.VehiculoFull = vehiculo.VehiculoMecanico;
                    dbEntry.MarcaId = vehiculo.MarcaId;
                }
            }
            await context.SaveChangesAsync();
        }
        public void DeleteVehiculo(Guid VehiculoId)
        {
            TVehiculo dbEntry = context.TVehiculo
            .FirstOrDefault(p => p.VehiculoId == VehiculoId);
            if (dbEntry != null)
            {
                context.TVehiculo.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}
