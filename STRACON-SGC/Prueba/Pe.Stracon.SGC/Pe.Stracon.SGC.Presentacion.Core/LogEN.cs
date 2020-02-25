using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Collections;

namespace Pe.Stracon.SGC.Presentacion.Core.LogError
{
    public class LogEN
    {
        public DateTime FechaHora { get; set; }
        public string Aplicacion { get; set; }
        public string Usuario { get; set; }
        public string NombrePC { get; set; }
        public string MensajeError { get; set; }
        public string DetalleError { get; set; }
        public IDictionary DetalleErrorOtro { get; set; }
        public string optional { get; set; }
        public string MensajeInfo { get; set; }
        public LogEN()
        {
            FechaHora = DateTime.Now;
        }

        public static void grabarArchivoTxt<T>(T obj, string archivo)
        {
            PropertyInfo[] propiedades = obj.GetType().GetProperties();
            object valor;
            using (StreamWriter sw = new StreamWriter(archivo, true))
            {
                foreach (PropertyInfo propiedad in propiedades)
                {
                    valor = propiedad.GetValue(obj, null);
                    if (valor != null) sw.WriteLine("{0} = {1}", propiedad.Name, valor.ToString());
                }
                sw.WriteLine(new String('_', 130));
            }
        }
        public static void grabarLogError(Exception ex, string optional = "")
        {
            LogEN obeLog = new LogEN();

            obeLog.MensajeError       = ex.Message.ToString();
            obeLog.DetalleError       = ex.StackTrace.ToString();
            obeLog.DetalleErrorOtro   = ex.Data;
            obeLog.optional           = optional;

            LogEN.grabarArchivoTxt<LogEN>(obeLog, Formato.ArchivoAMD("LogErrorSGC.txt"));
        }

        public static void grabarLogInfo(string info)
        {
            LogEN obeLog = new LogEN();

            obeLog.MensajeInfo = info;

            LogEN.grabarArchivoTxt<LogEN>(obeLog, Formato.ArchivoAMD("LogInfoSGC.txt"));
        }
        public static string[] listarPropiedades<T>(T obj)
        {
            List<string> listaPropiedades = new List<string>();
            PropertyInfo[] propiedades = obj.GetType().GetProperties();
            foreach (PropertyInfo propiedad in propiedades)
            {
                listaPropiedades.Add(propiedad.Name);
            }
            return (listaPropiedades.ToArray());
        }
        public static void grabarListaArchivoTxt<T>(List<T> lista, string archivo, string separador = ",")
        {
            PropertyInfo[] propiedades = lista[0].GetType().GetProperties();
            using (StreamWriter sw = new StreamWriter(archivo))
            {
                //Escribir la primera fila con las cabeceras de los campos
                for (int i = 0; i < propiedades.Length - 1; i++)
                {
                    sw.Write(propiedades[i].Name);
                    sw.Write(separador);
                }
                sw.WriteLine(propiedades[propiedades.Length - 1].Name);
                //Escribir cada fila de datos
                for (int j = 0; j < lista.Count; j++)
                {
                    for (int i = 0; i < propiedades.Length - 1; i++)
                    {
                        sw.Write(propiedades[i].GetValue(lista[j], null).ToString());
                        sw.Write(separador);
                    }
                    sw.WriteLine(propiedades[propiedades.Length - 1].GetValue(lista[j], null).ToString());
                }
            }
        }
        public class Formato
        {
            public static string ArchivoAMD(string archivo)
            {
                String ls_dir = AppDomain.CurrentDomain.BaseDirectory;
                ls_dir = ls_dir + @"Docs";
                string archivoSinExt = Path.Combine(ls_dir, Path.GetFileNameWithoutExtension(archivo));
                DateTime fechaHoy = DateTime.Now;
                string cadenaAMD = String.Format("{0}_{1}_{2}_{3}{4}", archivoSinExt, fechaHoy.Year, fechaHoy.Month.ToString().PadLeft(2, '0'), fechaHoy.Day.ToString().PadLeft(2, '0'), Path.GetExtension(archivo));
                return (cadenaAMD);
            }
        }
    }
}