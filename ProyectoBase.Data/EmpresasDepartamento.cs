using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProyectoBase.Data
{
    public class EmpresasDepartamento
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.EmpresasDepartamento> EmpresasDepartamento_Seleccionar(Models.Empresas empresas)
        {
            b.ExecuteCommandSP("EmpresasDepartamento_Seleccionar");
            b.AddParameter("@IdEmpresa", empresas.Id, SqlDbType.Int);
            List<Models.EmpresasDepartamento> resultado = new List<Models.EmpresasDepartamento>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.EmpresasDepartamento item = new Models.EmpresasDepartamento()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.EmpresasDepartamento EmpresasDepartamento_Agregar(Models.EmpresasDepartamento empresasDepartamento)
        {
            b.ExecuteCommandSP("EmpresasDepartamento_Agregar");
            b.AddParameter("@IdEmpresa", empresasDepartamento.IdEmpresa, SqlDbType.Int);
            b.AddParameter("@Nombre", empresasDepartamento.Nombre, SqlDbType.VarChar);

            Models.EmpresasDepartamento resultado = new Models.EmpresasDepartamento();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }




        public List<Models.EmpresasDepartamento> EmpresasDepartamento_Seleccionar_IdEmpresa(Models.Empresas empresas)
        {
            const string consulta = "WebAsae.RH.EmpresasDepartamento_Seleccionar_IdEmpresa";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdEmpresa", empresas.Id, SqlDbType.Int);

            List<Models.EmpresasDepartamento> resultado = new List<Models.EmpresasDepartamento>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.EmpresasDepartamento>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
