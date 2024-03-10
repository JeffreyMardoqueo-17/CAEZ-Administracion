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
        //--------------------------------METODO CREAR Turno.--------------------------
        public static async Task<int> CreateAsync(Turno turno)
        {
            int result = 0;
            using (var dbContexto = new ContextoBD()) //el comando using hace un proceso de ejecucion
            {
                dbContexto.Turno.Add(turno); //agrego un nuevo turno
                result = await dbContexto.SaveChangesAsync();//se guarda a la base de datos
            }
            return result;
        }
        //--------------------------------METODO MODIFICAR turno.--------------------------
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
                    bdContexto.Update(turnoBD); //se guarda en memoria
                    result = await bdContexto.SaveChangesAsync(); //guardo en la base de datos con SaveChangesAsync
                }
            }
            return result;
        }
        //--------------------------------METODO ELIMINAR Turno.--------------------------
        public static async Task<int> DeleteAsync(Turno turno)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD()) //instancio la conexion
            {
                var turnoBD = await bdContexto.Turno.FirstOrDefaultAsync(c => c.Id == turno.Id); //busco el id
                if (turnoBD != null)//verifico que no este nulo
                {
                    bdContexto.Turno.Remove(turnoBD);//elimino a nivel de memoria la categoria
                    result = await bdContexto.SaveChangesAsync();//le digo a la BD que se elimine y se guarde
                }
            }
            return result;
        }
        //--------------------------------METODO obtenerporID Turno.--------------------------
        public static async Task<Turno> GetByIdAsync(Turno turno)
        {
            var turnoBD = new Turno();
            using (var bdContexto = new ContextoBD())
            {
                turnoBD = await bdContexto.Turno.FirstOrDefaultAsync(c => c.Id == turno.Id); //busco el id y asigno el resultado a turnoBD
            }
            return turnoBD;
        }

        //--------------------------------METODO obtener todos los Turnos.--------------------------
        public static async Task<List<Turno>> GetAllAsync()
        {
            var turnos = new List<Turno>(); //una variable de lo que llevara una lista de Turnos
            using (var bdContexto = new ContextoBD()) //creo el acceso a la BD
            {
                turnos = await bdContexto.Turno.ToListAsync(); //le digo que turnos contenga la lista de turnos, osea lo de la BD
            }
            return turnos;
        }
    }
}
