using CAEZ.Administracion.DAL;
using CAEZ.Administracion.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAEZ.Administracion.BL
{
    public class TipoDocumentoBL
    {
        public async Task<int> CreateAsync(TipoDocumento tdocumento)
        {
            return await TipoDocumentoDAL.CreateAsync(tdocumento);
        }
        public async Task<int> UpdateAsync(TipoDocumento tdocumento)
        {
            return await TipoDocumentoDAL.UpdateAsync(tdocumento);
        }
        public async Task<int> DeleteAsync(TipoDocumento tdocumento)
        {
            return await TipoDocumentoDAL.DeleteAsync(tdocumento);
        }
        public async Task<TipoDocumento> GetById(TipoDocumento tdocumento)
        {
            return await TipoDocumentoDAL.GetByIdAsync(tdocumento);
        }
        public async Task<List<TipoDocumento>> GetAllAsync()
        {
            return await TipoDocumentoDAL.GetAllAsync();
        }
    }
}
