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
    public class TurnoDAL
    {
        //--------------------------------METODO CREAR Direccion.--------------------------
        public static async Task<int> CreateAsync(Turno turno)
        {
            int result = 0;
            using (var dbContexto = new ContextoBD()) //el comando using hace un proceso de ejecucion
            {
                dbContexto.Turno.Add(turno); //agrego un nuevo cargo
                result = await dbContexto.SaveChangesAsync();//se guarda a la base de datos
            }
            return result;
        }
        //--------------------------------METODO MODIFICAR cargo.--------------------------
        public static async Task<int> UpdateAsync(Turno turno)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())//hago una instancia de la base de datos
            {
                //expresion landam
                var turnoBD = await bdContexto.Turno.FirstOrDefaultAsync(c => c.Id == turno.Id); //lo busco 
                if (turnoBD != null)//verifico que no este nulo
                {
                    turnoBD.Nombre = turno.Nombre; //actualizo las propiedades
                    bdContexto.Update(turnoBD); //se guarda en memora
                    result = await bdContexto.SaveChangesAsync(); //guardo en la base de datos con SaveChangesAsync
                }
            }
            return result;
        }
        //--------------------------------METODO ELIMINAR CARGO.--------------------------
        public static async Task<int> DeleteAsync(Turno turno)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD()) //istancio la coneccion
            {
                var turnoBD = await bdContexto.Turno.FirstOrDefaultAsync(c => c.Id == turno.Id); //busco el id
                if (turnoBD != null)//verifico que no este nulo
                {
                    bdContexto.Turno.Remove(turnoBD);//elimino anivel de memoria la categoria
                    result = await bdContexto.SaveChangesAsync();//le digo a la BD que se elimine y se guarde
                }
            }
            return result;
        }
        //--------------------------------METODO obtenerporID CARGO.--------------------------
        public static async Task<Turno> GetByIdAsync(Turno turno)
        {
            var turnoBD = new Turno();
            using (var bdContexto = new ContextoBD())
            {
                turnoBD = await bdContexto.Turno.FirstOrDefaultAsync(c => c.Id == turno.Id); //busco el id y asigno el resultado a cargoBD
            }
            return turnoBD;
        }

        //--------------------------------METODO obtener todas las CATEGORIAS.--------------------------
        public static async Task<List<Turno>> GetAllAsync()
        {
            var turnos = new List<Turno>(); //una variable de lo que llevara una lista de Categorias
            using (var bdContexto = new ContextoBD()) //creo el acceso a la BD
            {
                turnos = await bdContexto.Turno.ToListAsync(); //le digo que categories contenga la lista de categorias, osea lo de l BD
            }
            return turnos;
        }
    }
}
