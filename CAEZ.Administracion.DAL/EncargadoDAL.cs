using CAEZ.Administracion.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAEZ.Administracion.DAL;
{
    public class EncargadoDAL
    {
        public static async Task<int> CreateAsync(Encargado encargado)
        {
            int result = 0;
            using (var dbContext = new ContextoBD())
            {
                dbContext.Encargado.Add(encargado);
                result = await dbContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> UpdateAsync(Encargado encargado)
        {
            int result = 0;
            using (var dbContext = new ContextoBD())
            {
                var existingEncargado = await dbContext.Encargado.FirstOrDefaultAsync(e => e.Id == encargado.Id);

                if (existingEncargado != null)
                {
                    existingEncargado.Nombre = encargado.Nombre;
                    existingEncargado.Apellido = encargado.Apellido;
                    existingEncargado.Telefono = encargado.Telefono;

                    dbContext.Update(existingEncargado);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }

        public static async Task<int> DeleteAsync(Encargado encargado)
        {
            int result = 0;
            using (var dbContext = new ContextoBD())
            {
                var existingEncargado = await dbContext.Encargado.FirstOrDefaultAsync(e => e.Id == encargado.Id);
                if (existingEncargado != null)
                {
                    dbContext.Encargado.Remove(existingEncargado);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }

        public static async Task<Encargado> GetByIdAsync(Encargado encargado)
        {
            var encargadoBD = new Encargado();
            using (var bdContexto = new ContextoBD())
            {
                encargadoBD = await bdContexto.Encargado.FirstOrDefaultAsync(e => e.Id == encargado.Id);
            }
            return encargadoBD;
        }

        public static async Task<List<Encargado>> GetAllAsync()
        {
            using (var dbContext = new ContextoBD())
            {
                var encargados = await dbContext.Encargado.ToListAsync();
                return encargados;
            }
        }

    }
}