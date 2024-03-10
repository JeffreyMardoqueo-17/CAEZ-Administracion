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
    public class TipoDocumentoDAL
    {
        public static async Task<int> CreateAsync(TipoDocumento tdocument)
        {
            int result = 0;
            using (var dbContexto = new ContextoBD()) //el comando using hace un proceso de ejecucion
            {
                dbContexto.TipoDocumento.Add(tdocument); //agrego un nuevo cargo
                result = await dbContexto.SaveChangesAsync();//se guarda a la base de datos
            }
            return result;
        }
        public static async Task<int> UpdateAsync(TipoDocumento tdocument)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())//hago una instancia de la base de datos
            {
                //expresion landam
                var tdocumentBD = await bdContexto.TipoDocumento.FirstOrDefaultAsync(c => c.Id == tdocument.Id); //lo busco 
                if (tdocumentBD != null)//verifico que no este nulo
                {
                    tdocumentBD.Nombre = tdocument.Nombre; //actualizo las propiedades
                    bdContexto.Update(tdocumentBD); //se guarda en memora
                    result = await bdContexto.SaveChangesAsync(); //guardo en la base de datos con SaveChangesAsync
                }
            }
            return result;
        }
        public static async Task<int> DeleteAsync(TipoDocumento tdocument)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD()) //istancio la coneccion
            {
                var tdocumentBD = await bdContexto.TipoDocumento.FirstOrDefaultAsync(c => c.Id == tdocument.Id); //busco el id
                if (tdocumentBD != null)//verifico que no este nulo
                {
                    bdContexto.TipoDocumento.Remove(tdocumentBD);//elimino anivel de memoria la categoria
                    result = await bdContexto.SaveChangesAsync();//le digo a la BD que se elimine y se guarde
                }
            }
            return result;
        }
        public static async Task<TipoDocumento> GetByIdAsync(TipoDocumento tdocument)
        {
            var tdocumentBD = new TipoDocumento();
            using (var bdContexto = new ContextoBD())
            {
                tdocumentBD = await bdContexto.TipoDocumento.FirstOrDefaultAsync(c => c.Id == tdocument.Id); //busco el id y asigno el resultado a cargoBD
            }
            return tdocumentBD;
        }

        public static async Task<List<TipoDocumento>> GetAllAsync()
        {
            var tdocument = new List<TipoDocumento>(); //una variable de lo que llevara una lista de Categorias
            using (var bdContexto = new ContextoBD()) //creo el acceso a la BD
            {
                tdocument = await bdContexto.TipoDocumento.ToListAsync(); //le digo que categories contenga la lista de categorias, osea lo de l BD
            }
            return tdocument;
        }
    }
}
