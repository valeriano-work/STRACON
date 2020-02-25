using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.Core.Base
{
    /// <summary>
    ///  Clase de Conversión de Formatos
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150519 <br />
    /// Modificación:            <br />
    /// </remarks>
    public sealed class ConvertFormat
    {
        /// <summary>
        /// Permite obtener formato DateTime
        /// </summary>
        /// <param name="value">Valor</param>
        /// <param name="format">formato</param>
        /// <returns>Retorna cadena generada</returns>
        //public static DateTime? StringFormatDatetime(string value, string format = "dd/MM/yyyy")
        //{
        //    try
        //    {
        //        return string.IsNullOrEmpty(value) ? (DateTime?)null : DateTime.ParseExact(value, format, System.Globalization.CultureInfo.InvariantCulture);
        //    }
        //    catch (FormatException)
        //    {
        //        throw new CustomException("Formato de fecha invalido");
        //    }

        //}

        /// <summary>
        /// Permite obtener cadena con formato decimal
        /// </summary>
        /// <param name="value">Valor</param>
        /// <param name="format">Formato</param>
        /// <param name="numberFormat">Número Formato</param>
        /// <returns>Cadena con formato número</returns>
        //public static decimal? StringFormatDecimal(string value, string format = "{0:#,##0.00}", NumberFormat numberFormat = null)
        //{
        //    try
        //    {
        //        if (!format.Contains("{"))
        //            format = "{0:" + format + "}";

        //        NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
        //        numberFormatInfo.NumberDecimalSeparator = numberFormat.NumberDecimalSeparator; --.
        //        numberFormatInfo.NumberGroupSeparator = numberFormat.NumberGroupSeparator;    --,

        //        return string.IsNullOrEmpty(value) ? (decimal?)null : Decimal.Parse(value, numberFormatInfo);
        //    }
        //    catch (FormatException)
        //    {
        //        throw new CustomException("Formato decimal invalido");
        //    }
        //}

        /// <summary>
        /// Permite cadena con formato entero
        /// </summary>
        /// <param name="value">Valor</param>
        /// <param name="format">Formato</param>
        /// <param name="numberFormat">Número Formato</param>
        /// <returns>Cadena con formato entero.</returns>
        //public static int? StringFormatInt(string value, string format = "{0:#,##0}", NumberFormat numberFormat = null)
        //{
        //    try
        //    {
        //        if (!format.Contains("{"))
        //            format = "{0:" + format + "}";

        //        return string.IsNullOrEmpty(value) ? (int?)null : int.Parse(value.Replace(numberFormat.NumberGroupSeparator, ""));
        //    }
        //    catch (FormatException)
        //    {
        //        throw new CustomException("Formato int invalido");
        //    }
        //}

        /// <summary>
        /// Permite convertir el formato DateTime
        /// </summary>
        /// <param name="value">valor</param>
        /// <param name="format">Formato</param>
        /// <returns>Retorna formato DateTime</returns>
        public static string DatetimeFormatString(DateTime? value, string format = "dd/MM/yyyy")
        {
            if (value.HasValue)
                return Convert.ToDateTime(value).ToString(format, System.Globalization.CultureInfo.InvariantCulture);
            else
                return string.Empty;
        }

        /// <summary>
        /// Permite Formato cadena decimal
        /// </summary>
        /// <param name="value">valor</param>
        /// <param name="format">formato</param>
        /// <param name="numberFormat">número formato</param>
        /// <returns>Cadena de Decimal Formateada</returns>
        //public static string DecimalFormatString(decimal? value, string format = "{0:#,##0.00}", NumberFormat numberFormat = null)
        //{
        //    if (value.HasValue)
        //    {
        //        if (!format.Contains("{"))
        //            format = "{0:" + format + "}";

        //        NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
        //        numberFormatInfo.NumberDecimalSeparator = numberFormat.NumberDecimalSeparator;
        //        numberFormatInfo.NumberGroupSeparator = numberFormat.NumberGroupSeparator;

        //        format = format.Replace(numberFormat.NumberDecimalSeparator, "@");
        //        format = format.Replace(numberFormat.NumberGroupSeparator, ",");
        //        format = format.Replace("@", ".");

        //        return string.Format(numberFormatInfo, format, value);
        //    }
        //    else
        //        return string.Empty;
        //}

        /// <summary>
        /// Permite obtener cadena desde un entero 
        /// </summary>
        /// <param name="value">Valor a formatear</param>
        /// <param name="format">Formato de conversión</param>
        /// <param name="numberFormat">número formato</param>
        /// <returns>Cadena Entera Formateada</returns>
        /// <returns>Devuelve cadena desde un entero </returns>
        //public static string IntFormatString(int? value, string format = "#,##0", NumberFormat numberFormat = null)
        //{
        //    if (value.HasValue)
        //    {
        //        if (!format.Contains("{"))
        //            format = "{0:" + format + "}";

        //        format = format.Replace(numberFormat.NumberGroupSeparator, ",");

        //        NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
        //        numberFormatInfo.NumberGroupSeparator = numberFormat.NumberGroupSeparator;

        //        return string.Format(numberFormatInfo, format, value);
        //    }
        //    else
        //        return string.Empty;
        //}

        /// <summary>
        /// Permite retornar fecha por defecto
        /// </summary>
        /// <param name="fecha">Fecha en cadena</param>
        /// <param name="format">Formato de conversión</param>
        /// <returns>Fecha por Defecto</returns>
        public static DateTime RetornarFechaPorDefault(string fecha, string format = "dd/MM/yyyy")
        {
            DateTime? fechaDefault = null;
            if (string.IsNullOrWhiteSpace(fecha))
            {
                fechaDefault = new DateTime(1900, 1, 1);
            }
            else
            {
                fechaDefault = DateTime.ParseExact(fecha, format, CultureInfo.InvariantCulture);
            }

            return fechaDefault.Value;
        }

        /// <summary>
        /// Permite dar formato día/mes/año a valor DateTime
        /// </summary>
        /// <param name="date">Fecha</param>
        /// <param name="format">Formato</param>
        /// <returns>Cadena con formato fecha</returns>
        public static DateTime? DatetimeFormatedNull(DateTime? date, string format = "dd/MM/yyyy")
        {
            DateTime fecha = Convert.ToDateTime(Convert.ToDateTime(date).ToString(format));
            date = fecha;
            return date;
        }
    }
}
