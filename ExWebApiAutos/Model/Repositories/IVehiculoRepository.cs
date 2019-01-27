using ExWebApiAutos.Model.VehiculoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExWebApiAutos.Model.Repositories
{
    public interface IVehiculoRepository
    {
        IQueryable<TVehiculo> Vehiculos { get; }
        Task SaveVehiculo(TVehiculo vehiculo);
        void DeleteVehiculo(Guid VehiculoId);
    }
}
