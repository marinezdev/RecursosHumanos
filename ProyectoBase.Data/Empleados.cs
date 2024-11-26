using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Empleados
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Consultas.Empleados> Empleados_Listar()
        {
            const string consulta = "Empleados_Listar";
            b.ExecuteCommandSP(consulta);
            List<Models.Consultas.Empleados> resultado = new List<Models.Consultas.Empleados>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Consultas.Empleados>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
        public List<Models.Consultas.Empleados> Empleados_Listar_Consulta(int Id)
        {
            const string consulta = "Empleados_Listar_Consulta";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@count", Id, SqlDbType.Int);
            List<Models.Consultas.Empleados> resultado = new List<Models.Consultas.Empleados>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Consultas.Empleados>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }


        public Models.Consultas.EmpleadosGrafica Empleados_Total_Empleados()
        {
            b.ExecuteCommandSP("Empleados_Total_Empleados");
            Models.Consultas.EmpleadosGrafica resultado = new Models.Consultas.EmpleadosGrafica();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.EmpleadosGrafica>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Consultas.EmpleadosGrafica Empleados_Total_Activos()
        {
            b.ExecuteCommandSP("Empleados_Total_Activos");
            Models.Consultas.EmpleadosGrafica resultado = new Models.Consultas.EmpleadosGrafica();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.EmpleadosGrafica>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Consultas.EmpleadosGrafica Empleados_Total_Inactivos()
        {
            b.ExecuteCommandSP("Empleados_Total_Inactivos");
            Models.Consultas.EmpleadosGrafica resultado = new Models.Consultas.EmpleadosGrafica();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.EmpleadosGrafica>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Consultas.EmpleadosGrafica Empleados_ContratosVencidos()
        {
            b.ExecuteCommandSP("Empleados_ContratosVencidos");
            Models.Consultas.EmpleadosGrafica resultado = new Models.Consultas.EmpleadosGrafica();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.EmpleadosGrafica>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Consultas.EmpleadosGrafica Empleados_ContratosPorVencer()
        {
            b.ExecuteCommandSP("Empleados_ContratosPorVencer");
            Models.Consultas.EmpleadosGrafica resultado = new Models.Consultas.EmpleadosGrafica();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.EmpleadosGrafica>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Consultas.EmpleadosGrafica Empleados_DocumentosNoentregados()
        {
            b.ExecuteCommandSP("Empleados_DocumentosNoentregados");
            Models.Consultas.EmpleadosGrafica resultado = new Models.Consultas.EmpleadosGrafica();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.EmpleadosGrafica>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Consultas.EmpleadosGrafica Empleados_DocumentosPendiente()
        {
            b.ExecuteCommandSP("Empleados_DocumentosPendiente");
            Models.Consultas.EmpleadosGrafica resultado = new Models.Consultas.EmpleadosGrafica();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.EmpleadosGrafica>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Consultas.EmpleadosGrafica> Empleados_Cliente()
        {
            b.ExecuteCommandSP("Empleados_Cliente");
            List<Models.Consultas.EmpleadosGrafica> resultado = new List<Models.Consultas.EmpleadosGrafica>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Consultas.EmpleadosGrafica>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }

        public List<Models.Consultas.EmpleadosGrafica> Empleados_Cliente_IdEmprea(Models.Empresas empresas)
        {
            const string consulta = "Empleados_Cliente_IdEmprea";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdEmpresa", empresas.Id, SqlDbType.Int);
            List<Models.Consultas.EmpleadosGrafica> resultado = new List<Models.Consultas.EmpleadosGrafica>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Consultas.EmpleadosGrafica>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }


        public List<Models.Consultas.EmpleadosGrafica> Empleados_Proyecto()
        {
            b.ExecuteCommandSP("Empleados_Proyecto");
            List<Models.Consultas.EmpleadosGrafica> resultado = new List<Models.Consultas.EmpleadosGrafica>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Consultas.EmpleadosGrafica>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }

        

        

        public Models.Empleados Empleados_DarDeBaja(Models.Personas personas)
        {
            b.ExecuteCommandSP("Empleados_DarDeBaja");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            Models.Empleados resultado = new Models.Empleados();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Empleados>(reader.GetValue(0).ToString());
            }
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Empleados Empleados_DarDeAlta(Models.Personas personas)
        {
            b.ExecuteCommandSP("Empleados_DarDeAlta");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.VarChar);
            Models.Empleados resultado = new Models.Empleados();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Empleados>(reader.GetValue(0).ToString());
            }
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }
}
