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
    public class MesDAL
    {
        public static async Task<Mes> GetByIdAsync(Mes mes)
        {
            var mesBD = new Mes();
            using (var bdContexto = new ContextoBD())
            {
                mesBD = await bdContexto.Mes.FirstOrDefaultAsync(c => c.Id == mes.Id); //busco el id y asigno el resultado a cargoBD
            }
            return mesBD;
        }

        //--------------------------------METODO obtener todas las CATEGORIAS.--------------------------
        public static async Task<List<Mes>> GetAllAsync()
        {
            var meses = new List<Mes>(); //una variable de lo que llevara una lista de Categorias
            using (var bdContexto = new ContextoBD()) //creo el acceso a la BD
            {
                meses = await bdContexto.Mes.ToListAsync(); //le digo que categories contenga la lista de categorias, osea lo de l BD
            }
            return meses;
        }
    }
}
