using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.pipeline.html;
using Microsoft.Reporting.WebForms;
using Pe.GyM.Security.Account.Model;
using Pe.GyM.SGC.Cross.Core.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Cross.Core.Util
{
    /// <summary>
    /// Clase Utilitaria
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319
    /// Modificación:   
    /// </remarks>
    public class Utilitario
    {
        /// <summary>
        /// Obtiene el nombre de un mes calendario.
        /// </summary>
        /// <param name="mes">Número de Mes</param>
        /// <returns>Nombre del Mes</returns>
        public static string ObtenerNombreMes(int mes)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mes));
        }

        /// <summary>
        /// Obtiene la lista de meses
        /// </summary>
        /// <returns>Retorna la lista de meses</returns>
        public static IDictionary<int, string> ObtenerListaMeses()
        {
            var listaMeses = new Dictionary<int, string>();

            for (var i = 1; i <= 12; i++)
            {
                listaMeses.Add(i, Utilitario.ObtenerNombreMes(i));
            }

            return listaMeses;
        }

        /// <summary>
        /// Retorna las iniciales de un nombre
        /// </summary>
        /// <param name="nombre">nombre a evaluar</param>
        /// <returns></returns>
        public static string RetornaIniciales(string nombre)
        {
            string result = string.Empty;
            foreach (char item in nombre)
            {
                if (Char.IsUpper(item))
                {
                    result += item;
                }
            }
            return result;
        }

        /// <summary>
        /// Retorna las iniciales de un nombre
        /// </summary>
        /// <param name="nombre">nombre a evaluar</param>
        /// <returns></returns>
        public static string HtmlACadena(string html)
        {
            var cadena = Regex.Replace(html, "<.*?>", string.Empty);
            cadena = cadena.Replace("&amp;","&");
            cadena = cadena.Replace("&nbsp;", " ");
            return cadena;
        }

        /// <summary>
        /// Obtiene los permisos de Lectura, Escritura y Control Total de la Opción seleccionada
        /// </summary>
        /// <param name="user">Cuenta de usuario de la sesión</param>
        /// <param name="url">Dirección Url de la opción seleccionada</param>
        /// <returns>Permisos de Lectura, Escritura y Control Total de la Opción seleccionada</returns>
        public static Control ObtenerControlPermisos(CuentaUsuario user, string url)
        {
            Control controles = new Control();

            bool lectura = false;
            bool escritura = false;
            bool controlTotal = false;
            bool urlEncontrada = false;

            foreach (var modulo in user.Modulos)
            {
                foreach (var subModulo in modulo.SubModulos)
                {
                    if (subModulo.Vistas.Exists(x => x.URL.EndsWith(url)))
                    {
                        lectura = subModulo.Vistas.Where(x => x.URL.EndsWith(url)).FirstOrDefault().Controles.FirstOrDefault().Lectura;
                        escritura = subModulo.Vistas.Where(x => x.URL.EndsWith(url)).FirstOrDefault().Controles.FirstOrDefault().Escritura;
                        controlTotal = subModulo.Vistas.Where(x => x.URL.EndsWith(url)).FirstOrDefault().Controles.FirstOrDefault().ControlTotal;
                        urlEncontrada = true;
                        break;
                    }
                }

                if (urlEncontrada)
                {
                    break;
                }
            }

            //Asignando los Permisos
            controles.ControlTotal = controlTotal;
            controles.Escritura = escritura;
            controles.Lectura = lectura;

            return controles;
        }

        /// <summary>
        /// Convierte formato string to datetime
        /// </summary>
        /// <param name="valor">valor</param>
        /// <param name="formato">formato</param>
        /// <returns></returns>
        public static DateTime? CadenaFormatoFecha(string valor, string formato)
        {
            try
            {
                return string.IsNullOrEmpty(valor) ? (DateTime?)null : DateTime.ParseExact(valor, formato, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                return null;
            }
        }

        /// <summary>
        /// Permite generar un Archivo desde un Reporting Service
        /// </summary>
        /// <param name="reporteServerUrl">Servidor del reporting</param>
        /// <param name="rutaReporte">Carpeta donde se ubica el reporte</param>
        /// <param name="nombreReporte">Nombre del reporte</param>
        /// <param name="formatoReporte">Formato a exportar</param>
        ///  /// <param name="parametros">Lista Parametros</param>
        /// <returns>Archivo en un arreglo de bytes</returns>
        public static byte[] GeneraArchivoDesdeReporting(
            string reporteServerUrl,
            string rutaReporte,
            string nombreReporte,
            string formatoReporte,
            List<ReportParameter> parametros)
        {
            try
            {
                var rswebVisor = new ReportViewer();
                rswebVisor.ServerReport.ReportServerUrl = new Uri(reporteServerUrl);
                rswebVisor.ServerReport.ReportServerCredentials = new ReporteCredencial();
                rswebVisor.ServerReport.ReportPath = string.Concat(rutaReporte, nombreReporte);

                rswebVisor.ShowParameterPrompts = false;
                rswebVisor.ServerReport.SetParameters(parametros);
                rswebVisor.ZoomMode = ZoomMode.Percent;
                rswebVisor.ZoomPercent = 100;
                rswebVisor.ServerReport.Refresh();

                string mimeType, encoding, extension;
                string[] streamids;
                Warning[] warnings;
                return rswebVisor.ServerReport.Render(formatoReporte, null, out mimeType, out encoding, out extension, out streamids, out warnings);

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
