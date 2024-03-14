using CAEZ.Administracion.EN;
using GestordeTareas.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CAEZ.Administracion.DAL
{
    public class AdministradorDAL
    {

        // Método para cifrar la contraseña de un administrador utilizando el algoritmo MD5
        private static void EncryptMD5(Administrador administrador)
        {
            // Crear una instancia de MD5 para realizar el cifrado
            using (var md5 = MD5.Create())
            {
                // Calcular el hash MD5 de la contraseña del administrador
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(administrador.Pass));

                // Crear una cadena vacía donde se almacenará la representación hexadecimal del hash MD5
                var encryptedStr = "";

                // Recorrer cada byte del hash MD5
                for (int i = 0; i < result.Length; i++)
                {
                    // Convertir cada byte a su representación hexadecimal de dos dígitos en minúsculas
                    encryptedStr += result[i].ToString("x2").ToLower();
                }

                // Reemplazar la contraseña original del administrador con el hash MD5 en formato hexadecimal
                administrador.Pass = encryptedStr;
            }
        }
              // Método para verificar si existe un administrador con el mismo nombre y apellido en la base de datos
        private static async Task<bool> ExistsNombreApellido(Administrador administrador, ContextoBD contexto)
        {
            bool result = false; // Inicialmente asumimos que no existe un administrador con el mismo nombre y apellido
            // Consultamos la base de datos para encontrar un administrador con el mismo nombre y apellido, pero con un ID diferente
            var adminExists = await contexto.Administrador.FirstOrDefaultAsync(a => a.Nombre == administrador.Nombre && a.Apellido == administrador.Apellido && a.Id != administrador.Id);
            // Si encontramos un administrador con el mismo nombre y apellido, y su ID es mayor que cero, entonces existe
            if (adminExists != null && adminExists.Id > 0 && adminExists.Nombre == administrador.Nombre && adminExists.Apellido == administrador.Apellido)
                result = true; // Actualizamos el resultado a verdadero
            return result; // Devolvemos el resultado
        }
        public static async Task<int> CreateAsync(Administrador administrador)
        {
            using (var dbContext = new ContextoBD())
            {
                if (!await ExistsNombreApellido(administrador, dbContext))
                {
                    EncryptMD5(administrador);
                    dbContext.Administrador.Add(administrador);
                    return await dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("El nombre de usuario ya existe");
                }
            }
        }

        public static async Task<int> UpdateAsync(Administrador administrador)
        {
            using (var dbContext = new ContextoBD())
            {
                if (!await ExistsNombreApellido(administrador, dbContext))
                {
                    var adminDb = await dbContext.Administrador.FirstOrDefaultAsync(a => a.Id == administrador.Id);
                    if (adminDb != null)
                    {
                        adminDb.Nombre = administrador.Nombre;
                        adminDb.Apellido = administrador.Apellido;
                        adminDb.IdCargo = administrador.IdCargo;
                        adminDb.Telefono = administrador.Telefono;
                        adminDb.Pass = administrador.Pass;

                        return await dbContext.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("Administrador no encontrado");
                    }
                }
                else
                {
                    throw new Exception("El nombre de usuario ya existe");
                }
            }
        }

        public static async Task<int> DeleteAsync(Administrador administrador)
        {
            using (var dbContext = new ContextoBD())
            {
                var adminDb = await dbContext.Administrador.FirstOrDefaultAsync(a => a.Id == administrador.Id);
                if (adminDb != null)
                {
                    dbContext.Administrador.Remove(adminDb);
                    return await dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Administrador no encontrado");
                }
            }
        }

        public static async Task<Administrador> GetByIdAsync(Administrador administrador)
        {
            using (var dbContext = new ContextoBD())
            {
                return await dbContext.Administrador.FirstOrDefaultAsync(a => a.Id == administrador.Id);
            }
        }

        public static async Task<List<Administrador>> GetAllAsync()
        {
            using (var dbContext = new ContextoBD())
            {
                return await dbContext.Administrador.ToListAsync();
            }
        }
    }
}
