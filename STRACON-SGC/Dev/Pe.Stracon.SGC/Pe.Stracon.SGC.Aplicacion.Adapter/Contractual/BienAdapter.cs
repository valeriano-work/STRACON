using System;
using System.Collections.Generic;
using System.Linq;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using System.Globalization;

namespace Pe.Stracon.SGC.Aplicacion.Adapter.Contractual
{
    /// <summary>
    /// Implementacion del adaptador de Bien
    /// </summary>
    public sealed class BienAdapter
    {
        /// <summary>
        /// Obtiene la entidad response de una entidad Logic
        /// </summary>
        /// <param name="objLogic">objeto logic</param>
        /// <param name="lstTipoBien">lista con los tipos de bien</param>
        /// <param name="lstTipoTarifa">lista tipos de tarifa</param>
        /// <param name="lstMoneda">listas de moneda</param>
        /// <returns>Entidad Response de entidad Logic</returns>
        public static BienResponse ObtenerBienResponseDeLogic(BienLogic objLogic,List<CodigoValorResponse> lstTipoBien = null,
                                                              List<CodigoValorResponse> lstTipoTarifa = null,
                                                              List<CodigoValorResponse> lstMoneda = null,
                                                              List<CodigoValorResponse> lstPeriodoAl = null)
        {
            int li_index = -1;
            BienResponse objRpta = new BienResponse();
            objRpta.CodigoBien = objLogic.CodigoBien.ToString();
            objRpta.CodigoTipoBien = objLogic.CodigoTipoBien;
            objRpta.CodigoIdentificacion = objLogic.CodigoIdentificacion;
            objRpta.NumeroSerie = objLogic.NumeroSerie;
            objRpta.Descripcion = objLogic.Descripcion;
            objRpta.Marca = objLogic.Marca;
            objRpta.Modelo = objLogic.Modelo;
            objRpta.FechaAdquisicion = objLogic.FechaAdquisicion.Value.ToString(DatosConstantes.Formato.FormatoFecha);
            objRpta.TiempoVidaString = objLogic.TiempoVida.ToString(DatosConstantes.Formato.FormatoNumeroDecimal);
            objRpta.ValorResidualString = objLogic.ValorResidual.ToString(DatosConstantes.Formato.FormatoNumeroDecimal);
            objRpta.CodigoTipoTarifa = objLogic.CodigoTipoTarifa;
            objRpta.CodigoPeriodoAlquiler = objLogic.CodigoPeriodoAlquiler;
            objRpta.ValorAlquilerString = objLogic.ValorAlquiler.HasValue ? objLogic.ValorAlquiler.Value.ToString(DatosConstantes.Formato.FormatoNumeroDecimal) : null;
            objRpta.CodigoMoneda = objLogic.CodigoMoneda;
            objRpta.MesInicioAlquiler = objLogic.MesInicioAlquiler;

            if (objRpta.MesInicioAlquiler > 0)
            {
                objRpta.DescripcionMesInicioAlquiler = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(int.Parse(objRpta.MesInicioAlquiler.ToString())));
            }

            objRpta.AnioInicioAlquiler = objLogic.AnioInicioAlquiler;

            if (objRpta.AnioInicioAlquiler > 0)
            {
                objRpta.MesAnioInicioAlquiler = objRpta.DescripcionMesInicioAlquiler + " - " + objRpta.AnioInicioAlquiler;
            }

            if (lstTipoBien != null && lstTipoBien.Count > 0)
            {
                li_index = lstTipoBien.FindIndex(x => x.Codigo.ToString() == objLogic.CodigoTipoBien);
                if (li_index > -1)
                {
                    objRpta.NombreTipoBien = lstTipoBien[li_index].Valor.ToString();
                }
            }
            li_index = -1;
            if (lstTipoTarifa != null && lstTipoTarifa.Count > 0)
            {
                li_index = lstTipoTarifa.FindIndex(x => x.Codigo.ToString() == objLogic.CodigoTipoTarifa);
                if (li_index > -1)
                {
                    objRpta.NombreTipoTarifa = lstTipoTarifa[li_index].Valor.ToString();
                }
            }
            li_index = -1;
            if (lstMoneda != null && lstMoneda.Count > 0)
            {
                li_index = lstMoneda.FindIndex(x => x.Codigo.ToString() == objLogic.CodigoMoneda);
                if (li_index > -1)
                {
                    objRpta.NombreMoneda = lstMoneda[li_index].Valor.ToString();
                }
            }
            li_index = -1;
            if (lstPeriodoAl != null && lstPeriodoAl.Count > 0)
            {
                li_index = lstPeriodoAl.FindIndex(x => x.Codigo.ToString() == objLogic.CodigoPeriodoAlquiler);
                if (li_index > -1)
                {
                    objRpta.NombrePeriodoAlquiler = lstPeriodoAl[li_index].Valor.ToString();
                }
            }            
            return objRpta;
        }
        /// <summary>
        /// Obtiene la entidad de una entidad request
        /// </summary>
        /// <param name="objRqst">objeto request</param>
        /// <returns>Entidad de objeto Bien</returns>
        public static BienEntity ObtenerBienEntityDeRequest(BienRequest objRqst)
        {
            BienEntity rpta = new BienEntity();
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = ".";
            numberFormatInfo.NumberGroupSeparator = ",";

            if (objRqst.CodigoBien == null)
            {
                objRqst.CodigoBien = Guid.Empty;
            }
            rpta.CodigoBien = (Guid)objRqst.CodigoBien;
            rpta.CodigoTipoBien = objRqst.CodigoTipoBien;
            rpta.CodigoIdentificacion = objRqst.CodigoIdentificacion;
            rpta.NumeroSerie = objRqst.NumeroSerie;
            rpta.Descripcion = objRqst.Descripcion.ToUpper();
            rpta.Marca = objRqst.Marca.ToUpper();
            rpta.Modelo = objRqst.Modelo.ToUpper();
            rpta.FechaAdquisicion = DateTime.ParseExact(objRqst.FechaAdquisicionString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture);
            rpta.TiempoVida = Decimal.Parse(objRqst.TiempoVidaString, numberFormatInfo);
            rpta.ValorResidual = Decimal.Parse(objRqst.ValorResidualString, numberFormatInfo);
            rpta.CodigoTipoTarifa = objRqst.CodigoTipoTarifa;
            rpta.CodigoPeriodoAlquiler = objRqst.CodigoPeriodoAlquiler;
            if (!string.IsNullOrWhiteSpace(objRqst.ValorAlquilerString))
            {
                rpta.ValorAlquiler = Decimal.Parse(objRqst.ValorAlquilerString, numberFormatInfo);
            }
            rpta.CodigoMoneda = objRqst.CodigoMoneda;
            rpta.MesInicioAlquiler = Byte.Parse(objRqst.MesInicioAlquiler.ToString());
            rpta.AnioInicioAlquiler = Int16.Parse(objRqst.AnioInicioAlquiler.ToString());

            return rpta;
        }
        /// <summary>
        /// Obtiene el responde Bien de una entidad Bien
        /// </summary>
        /// <param name="objEnt">Objeti entidad</param>
        /// <returns>Entidad Response de objeto Bien</returns>
        public static BienResponse ObtenerBienResponseDeEntity(BienEntity objEnt)
        {
            BienResponse rpta = new BienResponse();
            rpta.CodigoBien = objEnt.CodigoBien.ToString();
            rpta.CodigoTipoBien = objEnt.CodigoTipoBien;
            rpta.CodigoIdentificacion = objEnt.CodigoIdentificacion;
            rpta.NumeroSerie = objEnt.NumeroSerie;
            rpta.Descripcion = objEnt.Descripcion;
            rpta.Marca = objEnt.Marca;
            rpta.Modelo = objEnt.Modelo;
            rpta.FechaAdquisicion = objEnt.FechaAdquisicion.ToString(DatosConstantes.Formato.FormatoFecha);
            rpta.TiempoVida = objEnt.TiempoVida;
            rpta.TiempoVidaString = objEnt.TiempoVida.ToString(DatosConstantes.Formato.FormatoNumeroDecimal);
            rpta.ValorResidual = objEnt.ValorResidual;
            rpta.ValorResidualString = objEnt.ValorResidual.ToString(DatosConstantes.Formato.FormatoNumeroDecimal);
            rpta.CodigoTipoTarifa = objEnt.CodigoTipoTarifa;
            rpta.CodigoPeriodoAlquiler = objEnt.CodigoPeriodoAlquiler;
            rpta.ValorAlquiler = objEnt.ValorAlquiler;
            rpta.ValorAlquilerString = objEnt.ValorAlquiler.HasValue ? objEnt.ValorAlquiler.Value.ToString(DatosConstantes.Formato.FormatoNumeroDecimal) : null;
            rpta.CodigoMoneda = objEnt.CodigoMoneda;
            rpta.MesInicioAlquiler = objEnt.MesInicioAlquiler;
            rpta.AnioInicioAlquiler = objEnt.AnioInicioAlquiler;
            return rpta;
        }
        /// <summary>
        /// Obtiene el responde Bien de una entidad Bien
        /// </summary>
        /// <param name="objEnt">Objeti entidad</param>
        /// <returns>Entidad Response de objeto Bien Alquiler</returns>
        public static BienAlquilerResponse ObtenerBienAlquilerResponseDeEntity(BienAlquilerEntity objEnt)
        {
            BienAlquilerResponse rpta = new BienAlquilerResponse();
            rpta.CodigoBienAlquiler = objEnt.CodigoBienAlquiler.ToString();
            rpta.CodigoBien = objEnt.CodigoBien.ToString();
            rpta.IndicadorSinLimite = objEnt.IndicadorSinLimite;
            rpta.CantidadLimite = objEnt.CantidadLimite;
            rpta.CantidadLimiteString = objEnt.CantidadLimite.HasValue ? objEnt.CantidadLimite.Value.ToString(DatosConstantes.Formato.FormatoNumeroDecimal) : null;
            rpta.Monto = objEnt.Monto;
            rpta.MontoString = objEnt.Monto.ToString(DatosConstantes.Formato.FormatoNumeroDecimal);
            return rpta;
        }
        /// <summary>
        /// Obtiene el responde Bien de una entidad Bien
        /// </summary>
        /// <param name="objEnt">Objeti entidad</param>
        /// <returns>Entidad Response de objeto Bien Alquiler</returns>
        public static BienAlquilerResponse ObtenerBienAlquilerResponseDeLogic(BienAlquilerLogic objLogic)
        {
            BienAlquilerResponse rpta = new BienAlquilerResponse();
            rpta.CodigoBienAlquiler = objLogic.CodigoBienAlquiler.ToString();
            rpta.CodigoBien = objLogic.CodigoBien.ToString();
            rpta.IndicadorSinLimite = objLogic.IndicadorSinLimite;
            rpta.CantidadLimite = objLogic.CantidadLimite;
            rpta.CantidadLimiteString = objLogic.CantidadLimite.HasValue ? objLogic.CantidadLimite.Value.ToString(DatosConstantes.Formato.FormatoNumeroDecimal) : null;
            rpta.Monto = objLogic.Monto;
            rpta.MontoString = objLogic.Monto.ToString(DatosConstantes.Formato.FormatoNumeroDecimal);
            return rpta;
        }
        /// <summary>
        /// Obtiene la entidad BienAlquiler de una entidad request
        /// </summary>
        /// <param name="objRqst">objeto request bienAlquiler</param>
        /// <returns>Entidad de objeto Bien Alquiler</returns>
        public static BienAlquilerEntity ObtenerBienAlquilerEntityDeRequest(BienAlquilerRequest objRqst)
        {
            BienAlquilerEntity rpta = new BienAlquilerEntity();
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = ".";
            numberFormatInfo.NumberGroupSeparator = ",";

            if (objRqst.CodigoBienAlquiler == null)
            {
                objRqst.CodigoBienAlquiler = Guid.Empty;
            }
            if (objRqst.CodigoBien == null)
            {
                objRqst.CodigoBien = Guid.Empty;
            }
            rpta.CodigoBienAlquiler = (Guid)objRqst.CodigoBienAlquiler;
            rpta.CodigoBien = (Guid)objRqst.CodigoBien;
            rpta.IndicadorSinLimite = objRqst.IndicadorSinLimite;
            if (!rpta.IndicadorSinLimite)
            {
                rpta.CantidadLimite = Decimal.Parse(objRqst.CantidadLimiteString, numberFormatInfo);
            }

            rpta.Monto = Decimal.Parse(objRqst.MontoString, numberFormatInfo);            
            return rpta;
        }
        /// <summary>
        /// Obtiene la entidad Bien Registro response de una entidad logic
        /// </summary>
        /// <param name="objRqst">objeto Response bienRegistro</param>
        /// <returns>Entidad BienRegistroResponse</returns>
        public static BienRegistroResponse ObtenerBienRegistroResponseDeLogic(BienRegistroLogic objRqst)
        {
            BienRegistroResponse rpta = new BienRegistroResponse();
            rpta.Tipo = objRqst.CodigoTipoContenido;
            rpta.Valor = objRqst.Contenido;
            return rpta;
        }

        /// <summary>
        /// Realiza la adaptación de campos para la búsqueda
        /// </summary>
        /// <param name="bienLogic">Entidad Lógica Bien</param>
        /// <returns>Clase Bien Response con los datos de búsqueda</returns>
        public static BienResponse ObtenerDescripcionCompletaBien(BienLogic bienLogic, List<BienAlquilerResponse> listaAlquiler, List<CodigoValorResponse> listaPeriodoAlquilerBien)
        {
            var bienResponse = new BienResponse();

            bienResponse.CodigoBien = bienLogic.CodigoBien.ToString();
            bienResponse.CodigoIdentificacion = bienLogic.CodigoIdentificacion;
            bienResponse.NumeroSerie = bienLogic.NumeroSerie;
            bienResponse.Descripcion = bienLogic.Descripcion;
            bienResponse.Marca = bienLogic.Marca;
            bienResponse.Modelo = bienLogic.Modelo;
            bienResponse.CodigoMoneda = bienLogic.CodigoMoneda;
            if (bienLogic.FechaAdquisicion != null)
            {
                bienResponse.FechaAdquisicion = Convert.ToDateTime(bienLogic.FechaAdquisicion).ToString(DatosConstantes.Formato.FormatoFecha);
            }
            bienResponse.MesInicioAlquiler = bienLogic.MesInicioAlquiler;
            bienResponse.AnioInicioAlquiler = bienLogic.AnioInicioAlquiler;
            bienResponse.DescripcionMesInicioAlquiler = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(int.Parse(bienResponse.MesInicioAlquiler.ToString())));

            if (listaAlquiler != null && listaAlquiler.Count > 0)
            {
                bienResponse.ValorAlquilerString = string.Empty;
                decimal limiteInferiorActual = 0.01M;

                var alquilerSinLimite = listaAlquiler.Where(item => item.IndicadorSinLimite).FirstOrDefault();

                var periodoAlquilerBien = listaPeriodoAlquilerBien.Where(itemWhere => itemWhere.Codigo.ToString() == bienLogic.CodigoPeriodoAlquiler).FirstOrDefault().Valor;

                foreach (var item in listaAlquiler.Where(item => !item.IndicadorSinLimite).ToList())
                {
                    bienResponse.ValorAlquilerString += limiteInferiorActual + " - " + item.CantidadLimiteString + " " + periodoAlquilerBien + " " + bienLogic.CodigoMoneda + " " + item.MontoString + "<br></br>";
                    limiteInferiorActual = Convert.ToDecimal(item.CantidadLimite) + 0.01M;
                }
            }
            else
            {
                bienResponse.ValorAlquilerString = bienLogic.ValorAlquiler.HasValue ? bienLogic.ValorAlquiler.Value.ToString(DatosConstantes.Formato.FormatoNumeroDecimal) : null;
            }
            bienResponse.DescripcionCompleta = bienLogic.CodigoIdentificacion + " - " + bienLogic.NumeroSerie + " - " + bienLogic.Descripcion + " - " + bienLogic.Marca + " - " + bienLogic.Modelo + " - " + bienResponse.FechaAdquisicion + " - " + bienResponse.DescripcionMesInicioAlquiler + " " + bienResponse.AnioInicioAlquiler;

            return bienResponse;
        }
    }
}