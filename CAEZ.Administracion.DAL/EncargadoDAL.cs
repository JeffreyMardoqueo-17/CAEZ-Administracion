using CAEZ.Administracion.EN;
using GestordeTareas.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAEZ.Administracion.DAL
{
    public static class EncargadoDAL
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
                var encargadoDb = await dbContext.Encargado.FirstOrDefaultAsync(e => e.Id == encargado.Id);
                if (encargadoDb != null)
                {
                    encargadoDb.Nombre = encargado.Nombre;
                    encargadoDb.Apellido = encargado.Apellido;
                    encargadoDb.IdTipoDoc = encargado.IdTipoDoc;
                    encargadoDb.NumeroDocumento = encargado.NumeroDocumento;
                    encargadoDb.Telefono = encargado.Telefono;
                    encargadoDb.IdDireccion = encargado.IdDireccion;
                    encargadoDb.IdParentezco = encargado.IdParentezco;
                    encargadoDb.IdAdministrador = encargado.IdAdministrador;
                    encargadoDb.FechaRegistro = encargado.FechaRegistro;

                    dbContext.Encargado.Update(encargadoDb);
                    result = await dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("No se encontró el encargado");
                }
            }
            return result;
        }

        public static async Task<int> DeleteAsync(Encargado encargado)
        {
            int result = 0;
            using (var dbContext = new ContextoBD())
            {
                var encargadoDb = await dbContext.Encargado.FirstOrDefaultAsync(e => e.Id == encargado.Id);
                if (encargadoDb != null)
                {
                    dbContext.Encargado.Remove(encargadoDb);
                    result = await dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("No se encontró el encargado");
                }
            }
            return result;
        }

        public static async Task<Encargado> GetByIdAsync(Encargado encargado)
        {
            Encargado encargadoDb = null;
            using (var dbContext = new ContextoBD())
            {
                encargadoDb = await dbContext.Encargado.FirstOrDefaultAsync(e => e.Id == encargado.Id);
            }
            return encargadoDb!;
        }

        public static async Task<List<Encargado>> GetAllAsync()
        {
            List<Encargado> encargados = new List<Encargado>();
            using (var dbContext = new ContextoBD())
            {
                encargados = await dbContext.Encargado.ToListAsync();
            }
            return encargados;
        }
            //Metodo para buscar por nomre o apellido
        public static async Task<List<Encargado>> SearchAsync(string searchCriteria)
        {
            List<Encargado> encargados = new List<Encargado>();
            using (var dbContext = new ContextoBD())
            {
                encargados = await dbContext.Encargado
                    .Where(e => EF.Functions.Like(e.Nombre, $"%{searchCriteria}%") || EF.Functions.Like(e.Apellido, $"%{searchCriteria}%"))
                    .ToListAsync();
            }
            return encargados;
        }

    }
}
