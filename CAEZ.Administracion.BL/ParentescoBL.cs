using CAEZ.Administracion.DAL;
using CAEZ.Administracion.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAEZ.Administracion.BL
{
    public class ParentescoBL
    {
        public async Task<int> CreateAsync(Parentezco parentezco)
        {
            return await ParentescoDAL.CreateAsync(parentezco);
        }
        public async Task<int> UpdateAsync(Parentezco parentezco)
        {
            return await ParentescoDAL.UpdateAsync(parentezco);
        }
        public async Task<int> DeleteAsync(Parentezco parentezco)
        {
            return await ParentescoDAL.DeleteAsync(parentezco);
        }
        public async Task<Parentezco> GetById(Parentezco parentezco)
        {
            return await ParentescoDAL.GetByIdAsync(parentezco);
        }
        public async Task<List<Parentezco>> GetAllAsync()
        {
            return await ParentescoDAL.GetAllAsync();
        }
    }
}
