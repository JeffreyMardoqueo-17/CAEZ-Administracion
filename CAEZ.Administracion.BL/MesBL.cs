using CAEZ.Administracion.DAL;
using CAEZ.Administracion.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAEZ.Administracion.BL
{
    public class MesBL
    {
        public async Task<Mes> GetById(Mes mes)
        {
            return await MesDAL.GetByIdAsync(mes);
        }
        public async Task<List<Mes>> GetAllAsync()
        {
            return await MesDAL.GetAllAsync();
        }
    }
}
