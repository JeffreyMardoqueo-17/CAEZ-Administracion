using CAEZ.Administracion.EN;
using GestordeTareas.DAL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CAEZ.Administracion.BL
{
    public class EncargadoBL
    {
        public static async Task<int> CrearEncargadoAsync(Encargado encargado)
        {
            try
            {
                return await EncargadoDAL.CreateAsync(encargado);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, registro de errores, etc.
                throw;
            }
        }

        public static async Task<int> ActualizarEncargadoAsync(Encargado encargado)
        {
            try
            {
                return await EncargadoDAL.UpdateAsync(encargado);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, registro de errores, etc.
                throw;
            }
        }

        public static async Task<int> EliminarEncargadoAsync(Encargado encargado)
        {
            try
            {
                return await EncargadoDAL.DeleteAsync(encargado);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, registro de errores, etc.
                throw;
            }
        }

        public static async Task<Encargado> ObtenerEncargadoPorIdAsync(int id)
        {
            try
            {
                Encargado encargado = new Encargado { Id = id };
                return await EncargadoDAL.GetByIdAsync(encargado);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, registro de errores, etc.
                throw;
            }
        }

        public static async Task<List<Encargado>> ObtenerTodosLosEncargadosAsync()
        {
            try
            {
                return await EncargadoDAL.GetAllAsync();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, registro de errores, etc.
                throw;
            }
        }
    }
}
