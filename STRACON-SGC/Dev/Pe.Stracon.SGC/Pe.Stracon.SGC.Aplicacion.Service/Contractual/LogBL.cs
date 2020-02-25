using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

//Grivera. 06-02-2015. Registra Log de Errores, se necesita crear una carpeta de Nombre LogApp dentro del proyecto.
namespace Pe.Stracon.SGC.Aplicacion.Service.Contractual
{
    public class LogBL
    {
        public static void grabarLogError(Exception ex)
        {
            LogEN obeLog = new LogEN();
            if (ex.InnerException == null)
            {
                obeLog.MensajeError = "[Error]" + Environment.NewLine + ex.Message;
            }
            else
            {
                obeLog.MensajeError = "[Error]" + Environment.NewLine + ex.Message + Environment.NewLine + "[Error original]:" + Environment.NewLine + ex.GetBaseException().Message;
            }
            obeLog.DetalleError = "[Pila]" + Environment.NewLine + ex.StackTrace;
            grabarArchivoTxt<LogEN>(obeLog, Formato.ArchivoAMD("LogError.txt"));
        }

        public static void grabarArchivoTxt<T>(T obj, string archivo)
        {
            PropertyInfo[] propiedades = obj.GetType().GetProperties();
            object valor;
            using (StreamWriter sw = new StreamWriter(archivo, true))
            {
                foreach (PropertyInfo item in propiedades)
                {
                    valor = item.GetValue(obj, null);
                    if (valor != null) sw.WriteLine("{0} = {1}", item.Name, valor.ToString());
                }
                sw.WriteLine(new String('_', 50));
            }
        }

        public class Formato
        {
            public static string ArchivoAMD(string archivo)
            {
                String ls_dir = AppDomain.CurrentDomain.BaseDirectory;
                ls_dir = ls_dir + @"LogApp";
                //string archivoSinExt = Path.Combine(Path.GetDirectoryName(archivo), Path.GetFileNameWithoutExtension(archivo));
                string archivoSinExt = Path.Combine(ls_dir, Path.GetFileNameWithoutExtension(archivo));
                DateTime fechaHoy = DateTime.Now;
                string cadenaAMD = String.Format("{0}_{1}_{2}_{3}{4}", archivoSinExt, fechaHoy.Year, fechaHoy.Month.ToString().PadLeft(2, '0'), fechaHoy.Day.ToString().PadLeft(2, '0'), Path.GetExtension(archivo));
                return (cadenaAMD);
            }
        }
    }

    public class LogEN
    {
        public DateTime FechaHora { get; set; }
        public string Aplicacion { get; set; }
        public string Usuario { get; set; }
        public string NombrePC { get; set; }
        public string MensajeError { get; set; }
        public string DetalleError { get; set; }
        public LogEN()
        {
            FechaHora = DateTime.Now;
        }
    }
}
