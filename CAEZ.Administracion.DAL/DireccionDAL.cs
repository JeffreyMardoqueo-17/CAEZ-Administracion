using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAEZ.Administracion.EN;
using GestordeTareas.DAL;
using Microsoft.EntityFrameworkCore;

namespace CAEZ.Administracion.DAL
{
    public class DireccionDAL
    {
        //--------------------------------METODO CREAR Direccion.--------------------------
        public static async Task<int> CreateAsync(Direccion direccion)
        {
            int result = 0;
            using (var dbContexto = new ContextoBD()) //el comando using hace un proceso de ejecucion
            {
                dbContexto.Direccion.Add(direccion); //agrego un nueva direcion
                result = await dbContexto.SaveChangesAsync();//se guarda a la base de datos
            }
            return result;
        }
        //--------------------------------METODO MODIFICAR direccion.--------------------------
        public static async Task<int> UpdateAsync(Direccion direccion)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())//hago una instancia de la base de datos
            {
                //expresion landam
                var direcBD = await bdContexto.Direccion.FirstOrDefaultAsync(c => c.Id == direccion.Id); //lo busco 
                if (direcBD != null)//verifico que no este nulo
                {
                    direcBD.Nombre = direccion.Nombre; //actualizo las propiedades
                    bdContexto.Update(direcBD); //se guarda en memora
                    result = await bdContexto.SaveChangesAsync(); //guardo en la base de datos con SaveChangesAsync
                }
            }
            return result;
        }
        //--------------------------------METODO ELIMINAR Direeccion.--------------------------
        public static async Task<int> DeleteAsync(Direccion direccion)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD()) //istancio la coneccion
            {
                var direcBD = await bdContexto.Direccion.FirstOrDefaultAsync(c => c.Id == direccion.Id); //busco el id
                if (direcBD != null)//verifico que no este nulo
                {
                    bdContexto.Direccion.Remove(direcBD);//elimino anivel de memoria la categoria
                    result = await bdContexto.SaveChangesAsync();//le digo a la BD que se elimine y se guarde
                }
            }
            return result;
        }
        //--------------------------------METODO obtenerporID direcciones.--------------------------
        public static async Task<Direccion> GetByIdAsync(Direccion direccion)
        {
            var direcBD = new Direccion();
            using (var bdContexto = new ContextoBD())
            {
                direcBD = await bdContexto.Direccion.FirstOrDefaultAsync(c => c.Id == direccion.Id); //busco el id y asigno el resultado a cargoBD
            }
            return direcBD;
        }

        //--------------------------------METODO obtener todas las direccione.--------------------------
        public static async Task<List<Direccion>> GetAllAsync()
        {
            var direcciones = new List<Direccion>(); //una variable de lo que llevara una lista
            using (var bdContexto = new ContextoBD()) //creo el acceso a la BD
            {
                direcciones = await bdContexto.Direccion.ToListAsync(); //le digo que categories contenga la lista de categorias, osea lo de l BD
            }
            return direcciones;
        }
    }
}
