using CAEZ.Administracion.EN;
using GestordeTareas.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CAEZ.Administracion.DAL
{
    public class GradoDAL
    {
        //--------------------------------METODO CREAR CARGO.--------------------------
        public static async Task<int> CreateAsync(Grado grado)
        {
            int result = 0;
            using (var dbContexto = new ContextoBD()) //el comando using hace un proceso de ejecucion
            {
                dbContexto.Grado.Add(grado); //agrego un nuevo cargo
                result = await dbContexto.SaveChangesAsync();//se guarda a la base de datos
            }
            return result;
        }
        //--------------------------------METODO MODIFICAR cargo.--------------------------
        public static async Task<int> UpdateAsync(Grado grado)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())//hago una instancia de la base de datos
            {
                //expresion landam
                var gradoBD = await bdContexto.Grado.FirstOrDefaultAsync(c => c.Id == grado.Id); //lo busco 
                if (gradoBD != null)//verifico que no este nulo
                {
                    gradoBD.Nombre = grado.Nombre; //actualizo las propiedades
                    bdContexto.Update(gradoBD); //se guarda en memora
                    result = await bdContexto.SaveChangesAsync(); //guardo en la base de datos con SaveChangesAsync
                }
            }
            return result;
        }
        //--------------------------------METODO ELIMINAR gradp.--------------------------
        public static async Task<int> DeleteAsync(Grado grado)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD()) //istancio la coneccion
            {
                var gradoBD = await bdContexto.Grado.FirstOrDefaultAsync(c => c.Id == grado.Id); //busco el id
                if (gradoBD != null)//verifico que no este nulo
                {
                    bdContexto.Grado.Remove(gradoBD);//elimino anivel de memoria la categoria
                    result = await bdContexto.SaveChangesAsync();//le digo a la BD que se elimine y se guarde
                }
            }
            return result;
        }
        //--------------------------------METODO obtenerporID grado.--------------------------
        public static async Task<Grado> GetByIdAsync(Grado grado)
        {
            var gradoBD = new Grado();
            using (var bdContexto = new ContextoBD())
            {
                gradoBD = await bdContexto.Grado.FirstOrDefaultAsync(c => c.Id == grado.Id); //busco el id y asigno el resultado a cargoBD
            }
            return gradoBD;
        }

        //--------------------------------METODO obtener todas las gados.--------------------------
        public static async Task<List<Grado>> GetAllAsync()
        {
            var cgrado = new List<Grado>(); //una variable de lo que llevara una lista
            using (var bdContexto = new ContextoBD()) //creo el acceso a la BD
            {
                cgrado = await bdContexto.Grado.ToListAsync(); //le digo que categories contenga la lista de categorias, osea lo de l BD
            }
            return cgrado;
        }
    }
}
