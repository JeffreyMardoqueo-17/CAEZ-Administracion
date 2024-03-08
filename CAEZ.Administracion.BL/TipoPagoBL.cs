using CAEZ.Administracion.DAL;
using CAEZ.Administracion.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAEZ.Administracion.BL
{
    public class TipoPagoBL
    {
        public async Task<int> CreateAsync(TipoPago tpago)
        {
            return await TipoPagoDAL.CreateAsync(tpago);
        }
        public async Task<int> UpdateAsync(TipoPago tpago)
        {
            return await TipoPagoDAL.UpdateAsync(tpago);
        }
        public async Task<int> DeleteAsync(TipoPago tpago)
        {
            return await TipoPagoDAL.DeleteAsync(tpago);
        }
        public async Task<TipoPago> GetById(TipoPago tpago)
        {
            return await TipoPagoDAL.GetByIdAsync(tpago);
        }
        public async Task<List<TipoPago>> GetAllAsync()
        {
            return await TipoPagoDAL.GetAllAsync();
        }
    }
}
