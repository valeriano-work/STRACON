using System;

namespace Pe.Stracon.Politicas.Aplicacion.Adapter.General
{
    /// <summary>
    /// Adaptador de Parámetro Valor
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150327 <br />
    /// Modificación:            <br />
    /// </remarks>
    public sealed class ParametroValorAdapter
    {
        /// <summary>
        /// Obtiene el valor del Parámetro en tipo texto (string)
        /// </summary>
        /// <param name="codigoTipoDato">Código del tipo de dato</param>
        /// <param name="valor">Valor</param>
        /// <returns>Valor</returns>
        public static string ObtenerParametroValorTexto(string codigoTipoDato, string valor)
        {
            string valorText = string.Empty;
            //Conversion al tipo de dato
            try
            {
                switch (codigoTipoDato)
                {
                    //Tipo entero
                    case "ENT":
                        valorText = valor;
                        break;
                    //Tipo decimal
                    case "DEC":
                        valorText = valor;
                        break;
                    //Tipo Fecha
                    case "FEC":
                        valorText = valor;
                        break;
                    //Tipo Encriptado
                    case "ENC":
                        valorText = valor /*string.Empty.PadRight(6, '*')*/;
                        break;
                    default:
                        valorText = valor;
                        break;
                }
            }
            catch (Exception)
            {
                valorText = null;
            }

            return valorText;
        }
        /// <summary>
        /// Adapta el valor obtenido en tipo de dato string al tipo de dato configurado en tipo Object
        /// </summary>
        /// <param name="codigoTipoDato">Código de Tipo de Dato</param>
        /// <param name="valor">Valor</param>
        /// <returns>Objeto con su tipo de dato</returns>
        public static object ObtenerParametroValorObjeto(string codigoTipoDato, string valor)
        {
            object valorObjeto = null;
            //Conversion al tipo de dato
            try
            {
                switch (codigoTipoDato)
                {
                    //Tipo entero
                    case "ENT":
                        valorObjeto = Convert.ToInt32(valor);
                        break;
                    //Tipo decimal
                    case "DEC":
                        string[] valorSeparado = valor.Split('.');
                        int partIntegerValue = 0;
                        int partDecimalValue = 0;

                        partIntegerValue = Convert.ToInt32(valorSeparado[0]);
                        partDecimalValue = 0;

                        if (valorSeparado.Length == 2)
                        {
                            partDecimalValue = Convert.ToInt32(valorSeparado[1]);
                        }
                        valorObjeto = Convert.ToDecimal(partIntegerValue + ((valorSeparado.Length == 2) ? (partDecimalValue / Math.Pow(10, valorSeparado[1].Length)) : 0));                        
                        break;
                    //Tipo Fecha
                    case "FEC":
                        valorObjeto = DateTime.ParseExact(valor, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        break;
                    default:
                        valorObjeto = valor;
                        break;
                }
            }
            catch (Exception)
            {
                valorObjeto = null;
            }
            
            return valorObjeto;
        }
    }
}
