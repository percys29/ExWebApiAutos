using ExWebApiAutos.Model.VehiculoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExWebApiAutos.Model.Repositories
{
    public class EFProyectoRepository : IProyectoRepository
    {
        public IQueryable<TMarca> Marcas => context.TMarca;
        private VehiculoDbContext context;
        public EFProyectoRepository(VehiculoDbContext ctx)
        {
            context = ctx;
        }
        public async Task SaveProject(TMarca marca)
        {
            if (marca.MarcaId == Guid.Empty)
            {
                marca.MarcaId = Guid.NewGuid();
                context.TMarca.Add(marca);
            }
            else
            {
                TMarca dbEntry = context.TMarca
                .FirstOrDefault(p => p.MarcaId == marca.MarcaId);
                if (dbEntry != null)
                {
                    dbEntry.MarcaNombre = marca.MarcaNombre;
                }
            }
            await context.SaveChangesAsync();
        }
        public void DeleteProyecto(Guid MarcaId)
        {
            TMarca dbEntry = context.TMarca
            .FirstOrDefault(p => p.MarcaId == MarcaId);
            if (dbEntry != null)
            {
                context.TMarca.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}
