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
        public async Task<int> CreateAsync(Turno turno)
        {
            return await TurnoDAL.CreateAsync(turno);
        }
        public async Task<int> UpdateAsync(Turno turno)
        {
            return await TurnoDAL.UpdateAsync(turno);
        }
        public async Task<int> DeleteAsync(Turno turno)
        {
            return await TurnoDAL.DeleteAsync(turno);
        }
        public async Task<Turno> GetById(Turno turno)
        {
            return await TurnoDAL.GetByIdAsync(turno);
        }
        public async Task<List<Turno>> GetAllAsync()
        {
            return await TurnoDAL.GetAllAsync();
        }
    }
}
