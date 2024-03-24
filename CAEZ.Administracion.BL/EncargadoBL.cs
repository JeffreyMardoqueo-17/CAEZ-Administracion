using CAEZ.Administracion.DAL;
using CAEZ.Administracion.EN;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CAEZ.Administracion.BL
{
    public class EncargadoBL
    {
        public static async Task<int> CreateAsync(Encargado encargado)
        {
            return await EncargadoDAL.CreateAsync(encargado);
        }

        public static async Task<int> UpdateAsync(Encargado encargado)
        {
            return await EncargadoDAL.UpdateAsync(encargado);
        }

        public static async Task<int> DeleteAsync(Encargado encargado)
        {
            return await EncargadoDAL.DeleteAsync(encargado);
        }

        public static async Task<Encargado> GetByIdAsync(Encargado encargado)
        {
            return await EncargadoDAL.GetByIdAsync(encargado);
        }

        public static async Task<List<Encargado>> GetAllAsync()
        {
            return await EncargadoDAL.GetAllAsync();
        }

        public static async Task<List<Encargado>> SearchAsync(string searchCriteria)
        {
            return await EncargadoDAL.SearchAsync(searchCriteria);
        }
    }
}
