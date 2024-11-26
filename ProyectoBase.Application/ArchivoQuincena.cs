using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoBase.Application
{
    public class ArchivoQuincena
    {
        Data.ArchivoQuincena _archivoQuincena = new Data.ArchivoQuincena();
        Data.QuincenaImportada _QuincenaImportada = new Data.QuincenaImportada();


        public DataTable ArchivoQuincena_GeneraReporte(Models.Cat_Cuatrimestre cat_Cuatrimestre)
        {
            return _QuincenaImportada.QuincenaExportar_Selecionar_IdCuatrimestre(cat_Cuatrimestre);
        }

        public Models.ArchivoQuincena ArchivoQuincena_Consultar(Models.ArchivoQuincena archivoQuincena)
        {
            return _archivoQuincena.ArchivoQuincena_Consultar(archivoQuincena);
        }

        public List<Models.ArchivoQuincena> ArchivoQuincena_Consultar_Years()
        {
            return _archivoQuincena.ArchivoQuincena_Consultar_Years();
        }

        public DataTable ArchivoQuincena_Cargatxt(Models.ArchivoQuincena archivoQuincena)
        {
            DataTable workEmployees = new DataTable();
            string DirectorioUsuario = HttpContext.Current.Server.MapPath("~") + "\\DocumentosIMSS\\";
            workEmployees = ExportaTXT(DirectorioUsuario + archivoQuincena.NmArchivo);
       
            string[] charsToRemove = new string[] { "-", " "};

            Models.ArchivoQuincena archivoQuincena1 = _archivoQuincena.ArchivoQuincena_Agregar(archivoQuincena);
            if(archivoQuincena1.Id > 0)
            {
                for (int i = 0; i < workEmployees.Rows.Count; i++)
                {
                    Models.QuincenaImportada quincenaImportada = new Models.QuincenaImportada();
                    quincenaImportada.ArchivoQuincena = archivoQuincena1;
                    quincenaImportada.Quincena = archivoQuincena.Year + archivoQuincena.Cat_Quincena.Quincena;
                    quincenaImportada.Clave = workEmployees.Rows[i]["Clave"].ToString().Trim();
                    quincenaImportada.Nombre = workEmployees.Rows[i]["Nombre"].ToString().Trim();
                    quincenaImportada.RFC = workEmployees.Rows[i]["RFC"].ToString().Trim().Replace(charsToRemove[0], string.Empty);
                    quincenaImportada.NSS = workEmployees.Rows[i]["NSS"].ToString().Trim().Replace(charsToRemove[0], string.Empty);
                    quincenaImportada.CURP = workEmployees.Rows[i]["CURP"].ToString().Trim().Replace(charsToRemove[0], string.Empty);
                    quincenaImportada.Pago = workEmployees.Rows[i]["Pago"].ToString().Trim();
                    quincenaImportada.FechaIngreso = workEmployees.Rows[i]["FechaIngreso"].ToString().Trim();
                    quincenaImportada.DiasPagados = workEmployees.Rows[i]["DiasPagados"].ToString().Trim();
                    quincenaImportada.Baja = workEmployees.Rows[i]["Baja"].ToString().Trim();
                    quincenaImportada.DiasIncapacidad = workEmployees.Rows[i]["DiasIncapacidad"].ToString().Trim();

                    Models.QuincenaImportada dtQuincena = _QuincenaImportada.QuincenaImportada_Agregar(quincenaImportada);
                }
            }

            return workEmployees;
        }

        public DataTable ExportaTXT(string ruta)
        {
            DataTable workEmployees = new DataTable("Employees");
            string IMSS_QuincenaValue = "";
            //string readText = File.ReadAllText(path);
            string readText = System.IO.File.ReadAllText(ruta);

            int contadoEmployees = 0;
            int contadorLineaData = 0;
            int LineaPago = -1;
            string[] employeeData;
            string[] datoIMSS;
            string[] datoCURP;
            string[] datoPago;
            string[] datoDeducciones;
            string employeeNombre = "";
            string employeeClave = "";
            string employeeRFC = "";
            string employeeIMSS = "";
            string employeeCURP = "";
            string employeePago = "";
            int employeeDias = -1;
            bool employeeVacacionesEnTiempo = false;
            bool employeePrimaVacionesReportada = false;
            bool employeeAguinaldo = false;
            bool employeeBaja = false;
            DateTime employeeStart;
            bool FileEnd = false;
            decimal totalPersepciones = 0;
            string temporaly = "";

            // database structure
            DataColumn colQuincena = new DataColumn("Quincena");
            DataColumn colClave = new DataColumn("Clave");
            DataColumn colNombre = new DataColumn("Nombre");
            DataColumn colRFC = new DataColumn("RFC");
            DataColumn colNSS = new DataColumn("NSS");
            DataColumn colCURP = new DataColumn("CURP");
            DataColumn colPago = new DataColumn("Pago");
            DataColumn colFechaIngreso = new DataColumn("FechaIngreso");
            DataColumn ColDiasPagados = new DataColumn("DiasPagados");
            DataColumn ColBaja = new DataColumn("Baja");
            DataColumn ColDiasIncapacidad = new DataColumn("DiasIncapacidad");
            workEmployees.Columns.Add(colQuincena);
            workEmployees.Columns.Add(colClave);
            workEmployees.Columns.Add(colNombre);
            workEmployees.Columns.Add(colRFC);
            workEmployees.Columns.Add(colNSS);
            workEmployees.Columns.Add(colCURP);
            workEmployees.Columns.Add(colPago);
            workEmployees.Columns.Add(colFechaIngreso);
            workEmployees.Columns.Add(ColDiasPagados);
            workEmployees.Columns.Add(ColBaja);
            workEmployees.Columns.Add(ColDiasIncapacidad);
            DataRow drEmployee = workEmployees.NewRow();

            // Sepración de datos
            string[] employeeList = readText.Split(new string[] { "    ----------------------------------------------" }, StringSplitOptions.None);
            foreach (string list in employeeList)
            {
                try
                {
                    //MessageBox.Show(list);
                    employeeData = list.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                    contadoEmployees += 1;
                    contadorLineaData = 1;
                    LineaPago = -1;
                    employeeVacacionesEnTiempo = false;
                    employeePrimaVacionesReportada = false;
                    employeeAguinaldo = false;
                    employeeBaja = false;

                    foreach (string dataLine in employeeData)
                    {
                        if (!FileEnd)
                        {
                            if (dataLine.Trim().Length > 0)
                            {
                                if (dataLine.Trim() != "Total General")
                                {
                                    // show line content
                                    //MessageBox.Show("[Linea: " + contadorLineaData.ToString() + "] " + dataLine);

                                    switch (contadorLineaData)
                                    {
                                        // Clave y nombre del Empleado
                                        case 1:
                                            employeeClave = dataLine.Substring(0, 7);
                                            employeeNombre = dataLine.Substring(7);
                                            drEmployee["Quincena"] = IMSS_QuincenaValue;
                                            drEmployee["Clave"] = employeeClave;
                                            drEmployee["Nombre"] = employeeNombre;
                                            //MessageBox.Show("Clave  Empleado: " + employeeClave);
                                            //MessageBox.Show("Nombre Empleado: " + employeeNombre);
                                            break;

                                        // RFC & IMSS
                                        case 2:
                                            datoIMSS = dataLine.Split(new string[] { "RFC:" }, StringSplitOptions.None)[1].Split(new string[] { "Afiliaci�n IMSS:" }, StringSplitOptions.None);
                                            employeeRFC = datoIMSS[0];
                                            employeeIMSS = datoIMSS[1];
                                            drEmployee["RFC"] = employeeRFC;
                                            drEmployee["NSS"] = employeeIMSS;
                                            //MessageBox.Show("RFC  Empleado: " + employeeRFC);
                                            //MessageBox.Show("IMSS Empleado: " + employeeIMSS);
                                            break;

                                        // Fecha de ingreso
                                        case 3:
                                            temporaly = dataLine.Replace("Fecha Ingr: ", "").Replace("Fecha Reing: ", "").Substring(0, 10);
                                            employeeStart = new DateTime(int.Parse(temporaly.Substring(6, 4)), int.Parse(temporaly.Substring(3, 2)), int.Parse(temporaly.Substring(0, 2)));
                                            drEmployee["FechaIngreso"] = employeeStart.ToString("yyyy/MM/dd");
                                            break;

                                        // CURP & días trabajados
                                        case 4:
                                            temporaly = dataLine.Replace("D�as pagados: ", "");
                                            employeeDias = int.Parse(temporaly.Split(new string[] { "Tot Hrs trab:" }, StringSplitOptions.None)[0].ToString().Replace(".00", "").Trim());
                                            datoCURP = dataLine.Split(new string[] { "CURP:" }, StringSplitOptions.None);
                                            employeeCURP = datoCURP[1];
                                            drEmployee["CURP"] = employeeCURP;
                                            drEmployee["DiasPagados"] = employeeDias;
                                            //MessageBox.Show("CURP  Empleado: " + employeeCURP);
                                            //MessageBox.Show("Días Pagados: " + employeeDias.ToString());
                                            break;
                                        case 5:
                                            if (dataLine.Contains("Incapacidades"))
                                            {
                                                drEmployee["DiasIncapacidad"] = int.Parse(dataLine.Replace("Incapacidades", ""));
                                            }
                                            else
                                            {
                                                drEmployee["DiasIncapacidad"] = 0;
                                            }
                                            break;

                                        //case 9:
                                        //    string[] datoPago = dataLine.Split("Total Percepciones");
                                        //    string[] datoDeducciones = datoPago[1].Split("Total Deducciones");
                                        //    string employeePago = datoDeducciones[0].Trim().Replace(",","");
                                        //    MessageBox.Show("Pago Empleado: " + employeePago);
                                        //    break;

                                        default:
                                            //MessageBox.Show("[Linea: " + contadorLineaData.ToString() + "] " + dataLine);

                                            if (dataLine == "....................................................................... .......................................................................")
                                            {
                                                LineaPago = contadorLineaData + 1;
                                            }
                                            else
                                            {
                                                if (contadorLineaData == LineaPago)
                                                {
                                                    datoPago = dataLine.Split(new string[] { "Total Percepciones" }, StringSplitOptions.None);
                                                    datoDeducciones = datoPago[1].Split(new string[] { "Total Deducciones" }, StringSplitOptions.None);
                                                    employeePago = datoDeducciones[0].Trim().Replace(",", "");
                                                    drEmployee["Pago"] = employeePago;
                                                    totalPersepciones += Convert.ToDecimal(employeePago);
                                                    //MessageBox.Show("Pago Empleado: " + employeePago);

                                                    drEmployee["Baja"] = employeeBaja;
                                                    // Verificamos días de Incapacidad

                                                    // Ya no se utiliza debido a que si existe la inforamción de incapacidades

                                                    ////////////if (employeeDias != 15)
                                                    ////////////{
                                                    ////////////    if (employeeBaja)
                                                    ////////////    {
                                                    ////////////        drEmployee["DiasIncapacidad"] = 0;
                                                    ////////////    }
                                                    ////////////    else
                                                    ////////////    {
                                                    ////////////        // TODO: ### verificar fecha de ingreso
                                                    ////////////        var dateTime1 = new DateTime(employeeStart.Year, employeeStart.Month, employeeStart.Day, 0, 0, 0);
                                                    ////////////        var dateTime2 = new DateTime(IMSS_QuincenaFecha.Year, IMSS_QuincenaFecha.Month, IMSS_QuincenaFecha.Day, 0, 0, 0);
                                                    ////////////        System.TimeSpan diffResult = dateTime2.AddDays(1).Subtract(dateTime1);
                                                    ////////////        int diasFaltantes = (int)diffResult.Days;

                                                    ////////////        if ((int)diffResult.Days == employeeDias)
                                                    ////////////        {
                                                    ////////////            drEmployee["DiasIncapacidad"] = 0;
                                                    ////////////        }
                                                    ////////////        else 
                                                    ////////////        {
                                                    ////////////            // Se determinan los días de incapacidad
                                                    ////////////            drEmployee["DiasIncapacidad"] = 15 - employeeDias;
                                                    ////////////        }
                                                    ////////////    }
                                                    ////////////}
                                                    ////////////else
                                                    ////////////{
                                                    ////////////    drEmployee["DiasIncapacidad"] = 0;
                                                    ////////////}

                                                    employeeVacacionesEnTiempo = false;
                                                    employeePrimaVacionesReportada = false;
                                                    employeeAguinaldo = false;

                                                    // Employee Add     ****** Finaliza datos de empleado
                                                    workEmployees.Rows.Add(drEmployee);
                                                    drEmployee = workEmployees.NewRow();

                                                }
                                                else
                                                {
                                                    //MessageBox.Show("[Linea: " + contadorLineaData.ToString() + "] " + dataLine);
                                                    if (LineaPago == -1 && dataLine.Contains("19 Vacaciones a tiempo"))
                                                    {
                                                        employeeVacacionesEnTiempo = true;
                                                    }

                                                    if (LineaPago == -1 && dataLine.Contains("22 Prima de vacaciones reportada"))
                                                    {
                                                        employeePrimaVacionesReportada = true;
                                                    }

                                                    if (LineaPago == -1 && dataLine.Contains("24 Aguinaldo"))
                                                    {
                                                        employeeAguinaldo = true;
                                                    }

                                                    // Validmos si es una baja del empleado
                                                    if (employeeVacacionesEnTiempo && employeePrimaVacionesReportada && employeeAguinaldo)
                                                    {
                                                        employeeBaja = true;
                                                        employeeVacacionesEnTiempo = false;
                                                        employeePrimaVacionesReportada = false;
                                                        employeeAguinaldo = false;
                                                        //MessageBox.Show("se procedio con baja del empleado: " + employeeNombre);
                                                    }

                                                }
                                            }
                                            break;
                                    }
                                    contadorLineaData += 1;
                                }
                                else
                                {
                                    contadoEmployees -= 1;
                                    FileEnd = true;
                                }
                            }
                        }
                    }
                }
                catch (Exception _errorDefinition)
                {
                    Console.WriteLine("Error al procesar el empleado " + contadoEmployees.ToString() + Environment.NewLine + Environment.NewLine + "[" + employeeClave + "]" + employeeNombre + Environment.NewLine + Environment.NewLine + _errorDefinition.ToString(), "IMSS Reporte. Carga de informacion quincenal");
                }
            }


            return workEmployees;
        }
    }
}
