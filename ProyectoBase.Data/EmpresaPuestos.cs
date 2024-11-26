using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProyectoBase.Data
{
    public class EmpresaPuestos
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.EmpresaPuestos> EmpresaPuestos_Seleccionar(Models.EmpresasDepartamento empresasDepartamento)
        {
            b.ExecuteCommandSP("EmpresaPuestos_Seleccionar");
            b.AddParameter("@IdDepartamento", empresasDepartamento.Id, SqlDbType.Int);
            List<Models.EmpresaPuestos> resultado = new List<Models.EmpresaPuestos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.EmpresaPuestos item = new Models.EmpresaPuestos()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.EmpresaPuestos EmpresaPuestos_Agregar(Models.EmpresaPuestos empresaPuestos)
        {
            b.ExecuteCommandSP("EmpresaPuestos_Agregar");
            b.AddParameter("@IdDepartamento", empresaPuestos.IdDepartamento, SqlDbType.Int);
            b.AddParameter("@Nombre", empresaPuestos.Nombre, SqlDbType.VarChar);

            Models.EmpresaPuestos resultado = new Models.EmpresaPuestos();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public List<Models.EmpresaPuestos> EmpresaPuestos_Seleccionar_IdDepartamento(Models.EmpresasDepartamento empresasDepartamento)
        {
            const string consulta = "WebAsae.RH.EmpresaPuestos_Seleccionar_IdDepartamento";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdDepartamento", empresasDepartamento.Id, SqlDbType.Int);

            List<Models.EmpresaPuestos> resultado = new List<Models.EmpresaPuestos>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.EmpresaPuestos>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
