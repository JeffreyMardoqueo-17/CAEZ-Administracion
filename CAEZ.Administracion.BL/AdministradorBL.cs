using CAEZ.Administracion.DAL;
using CAEZ.Administracion.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAEZ.Administracion.BL
{
    public class AdministradorBL
    {
        public async Task<int> CreateAsync(Administrador administrador)
        {
            return await AdministradorDAL.CreateAsync(administrador);
        }

        public async Task<int> UpdateAsync(Administrador administrador)
        {
            return await AdministradorDAL.UpdateAsync(administrador);
        }

        public async Task<int> DeleteAsync(Administrador administrador)
        {
            return await AdministradorDAL.DeleteAsync(administrador);
        }

        public async Task<Administrador> GetByIdAsync(Administrador administrador)
        {
            return await AdministradorDAL.GetByIdAsync(administrador);
        }

        public async Task<List<Administrador>> GetAllAsync()
        {
            return await AdministradorDAL.GetAllAsync();
        }
    }
}
