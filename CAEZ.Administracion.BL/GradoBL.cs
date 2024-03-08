using CAEZ.Administracion.DAL;
using CAEZ.Administracion.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAEZ.Administracion.BL
{
    public class GradoBL
    {
        public async Task<int> CreateAsync(Grado grado)
        {
            return await GradoDAL.CreateAsync(grado);
        }
        public async Task<int> UpdateAsync(Grado grado)
        {
            return await GradoDAL.UpdateAsync(grado);
        }
        public async Task<int> DeleteAsync(Grado grado)
        {
            return await GradoDAL.DeleteAsync(grado);
        }
        public async Task<Grado> GetById(Grado grado)
        {
            return await GradoDAL.GetByIdAsync(grado);
        }
        public async Task<List<Grado>> GetAllAsync()
        {
            return await GradoDAL.GetAllAsync();
        }
    }
}
