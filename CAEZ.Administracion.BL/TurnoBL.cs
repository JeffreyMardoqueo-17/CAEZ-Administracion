using CAEZ.Administracion.DAL;
using CAEZ.Administracion.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAEZ.Administracion.BL
{
    public class TurnoBL
    {
        public async Task<int> CreateAsync(Direccion direccion)
        {
            return await DireccionDAL.CreateAsync(direccion);
        }
        public async Task<int> UpdateAsync(Direccion direccion)
        {
            return await DireccionDAL.UpdateAsync(direccion);
        }
        public async Task<int> DeleteAsync(Direccion direccion)
        {
            return await DireccionDAL.DeleteAsync(direccion);
        }
        public async Task<Direccion> GetById(Direccion direccion)
        {
            return await DireccionDAL.GetByIdAsync(direccion);
        }
        public async Task<List<Direccion>> GetAllAsync()
        {
            return await DireccionDAL.GetAllAsync();
        }
    }
}
