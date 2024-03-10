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
    public class ParentescoDAL
    {
        public static async Task<int> CreateAsync(Parentezco parentezco)
        {
            int result = 0;
            using (var dbContexto = new ContextoBD()) //el comando using hace un proceso de ejecucion
            {
                dbContexto.Parentezco.Add(parentezco); //agrego un nuevo cargo
                result = await dbContexto.SaveChangesAsync();//se guarda a la base de datos
            }
            return result;
        }
        public static async Task<int> UpdateAsync(Parentezco parentezco)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())//hago una instancia de la base de datos
            {
                //expresion landam
                var parentezcoBD = await bdContexto.Parentezco.FirstOrDefaultAsync(c => c.Id == parentezco.Id); //lo busco 
                if (parentezcoBD != null)//verifico que no este nulo
                {
                    parentezcoBD.Nombre = parentezco.Nombre; //actualizo las propiedades
                    bdContexto.Update(parentezcoBD); //se guarda en memora
                    result = await bdContexto.SaveChangesAsync(); //guardo en la base de datos con SaveChangesAsync
                }
            }
            return result;
        }
        public static async Task<int> DeleteAsync(Parentezco parentezco)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD()) //istancio la coneccion
            {
                var parentezcoBD = await bdContexto.Parentezco.FirstOrDefaultAsync(c => c.Id == parentezco.Id); //busco el id
                if (parentezcoBD != null)//verifico que no este nulo
                {
                    bdContexto.Parentezco.Remove(parentezcoBD);//elimino anivel de memoria la categoria
                    result = await bdContexto.SaveChangesAsync();//le digo a la BD que se elimine y se guarde
                }
            }
            return result;
        }
        public static async Task<Parentezco> GetByIdAsync(Parentezco parentezco)
        {
            var parentezcoBD = new Parentezco();
            using (var bdContexto = new ContextoBD())
            {
                parentezcoBD = await bdContexto.Parentezco.FirstOrDefaultAsync(c => c.Id == parentezco.Id); //busco el id y asigno el resultado a cargoBD
            }
            return parentezcoBD;
        }

        public static async Task<List<Parentezco>> GetAllAsync()
        {
            var parentezcos = new List<Parentezco>(); //una variable de lo que llevara una lista de Categorias
            using (var bdContexto = new ContextoBD()) //creo el acceso a la BD
            {
                parentezcos = await bdContexto.Parentezco.ToListAsync(); //le digo que categories contenga la lista de categorias, osea lo de l BD
            }
            return parentezcos;
        }
    }
}
