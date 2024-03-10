using CAEZ.Administracion.EN;
using GestordeTareas.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAEZ.Administracion.DAL
{
    public class GradoDAL
    {
        //--------------------------------METODO CREAR GRADO.--------------------------
        public static async Task<int> CreateAsync(Grado grado)
        {
            int result = 0;
            using (var dbContexto = new ContextoBD())
            {
                dbContexto.Grado.Add(grado);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        //--------------------------------METODO MODIFICAR GRADO.--------------------------
        public static async Task<int> UpdateAsync(Grado grado)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var gradoBD = await bdContexto.Grado.FirstOrDefaultAsync(c => c.Id == grado.Id);
                if (gradoBD != null)
                {
                    gradoBD.Nombre = grado.Nombre;
                    bdContexto.Update(gradoBD);
                    result = await bdContexto.SaveChangesAsync();
                }
            }
            return result;
        }

        //--------------------------------METODO ELIMINAR GRADO.--------------------------
        public static async Task<int> DeleteAsync(Grado grado)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var gradoBD = await bdContexto.Grado.FirstOrDefaultAsync(c => c.Id == grado.Id);
                if (gradoBD != null)
                {
                    bdContexto.Grado.Remove(gradoBD);
                    result = await bdContexto.SaveChangesAsync();
                }
            }
            return result;
        }

        //--------------------------------METODO obtener por ID GRADO.--------------------------
        public static async Task<Grado> GetByIdAsync(Grado grado)
        {
            var gradoBD = new Grado();
            using (var bdContexto = new ContextoBD())
            {
                gradoBD = await bdContexto.Grado.FirstOrDefaultAsync(c => c.Id == grado.Id);
            }
            return gradoBD;
        }

        //--------------------------------METODO obtener todas los GRADOS.--------------------------
        public static async Task<List<Grado>> GetAllAsync()
        {
            var grados = new List<Grado>();
            using (var bdContexto = new ContextoBD())
            {
                grados = await bdContexto.Grado.ToListAsync();
            }
            return grados;
        }
    }
}
