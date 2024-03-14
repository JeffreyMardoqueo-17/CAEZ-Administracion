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
    public class TipoPagoDAL
    {
        public static async Task<int> CreateAsync(TipoPago tpago)
        {
            int result = 0;
            using (var dbContexto = new ContextoBD()) //el comando using hace un proceso de ejecucion
            {
                dbContexto.TipoPago.Add(tpago); //agrego un nuevo cargo
                result = await dbContexto.SaveChangesAsync();//se guarda a la base de datos
            }
            return result;
        }
        public static async Task<int> UpdateAsync(TipoPago tpago)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())//hago una instancia de la base de datos
            {
                //expresion landam
                var tpagoBD = await bdContexto.TipoPago.FirstOrDefaultAsync(c => c.Id == tpago.Id); //lo busco 
                if (tpagoBD != null)//verifico que no este nulo
                {
                    tpagoBD.Nombre = tpago.Nombre; //actualizo las propiedades
                    bdContexto.Update(tpagoBD); //se guarda en memora
                    result = await bdContexto.SaveChangesAsync(); //guardo en la base de datos con SaveChangesAsync
                }
            }
            return result;
        }
        public static async Task<int> DeleteAsync(TipoPago tpago)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD()) //istancio la coneccion
            {
                var tpagoBD = await bdContexto.TipoPago.FirstOrDefaultAsync(c => c.Id == tpago.Id); //busco el id
                if (tpagoBD != null)//verifico que no este nulo
                {
                    bdContexto.TipoPago.Remove(tpagoBD);//elimino anivel de memoria la categoria
                    result = await bdContexto.SaveChangesAsync();//le digo a la BD que se elimine y se guarde
                }
            }
            return result;
        }

        public static async Task<TipoPago> GetByIdAsync(TipoPago tpago)
        {
            var tpagoBD = new TipoPago();
            using (var bdContexto = new ContextoBD())
            {
                tpagoBD = await bdContexto.TipoPago.FirstOrDefaultAsync(c => c.Id == tpago.Id); //busco el id y asigno el resultado a cargoBD
            }
            return tpagoBD;
        }


        public static async Task<List<TipoPago>> GetAllAsync()
        {
            var ctpagos = new List<TipoPago>(); //una variable de lo que llevara una lista de Categorias
            using (var bdContexto = new ContextoBD()) //creo el acceso a la BD
            {
                ctpagos = await bdContexto.TipoPago.ToListAsync(); //le digo que categories contenga la lista de categorias, osea lo de l BD
            }
            return ctpagos;
        }
    }
}
