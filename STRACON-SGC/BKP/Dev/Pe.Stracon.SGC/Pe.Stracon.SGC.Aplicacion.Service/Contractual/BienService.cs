using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Transactions;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.Adapter.Contractual;
using Pe.Stracon.SGC.Aplicacion.Core.Base;
using Pe.Stracon.SGC.Aplicacion.Core.ServiceContract;
using Pe.Stracon.SGC.Aplicacion.Service.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Cross.Core.Base;
using Pe.Stracon.SGC.Cross.Core.Exception;
using Pe.Stracon.SGC.Cross.Core.Util;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.CommandContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Proxy.AmtService;
using Pe.Stracon.SGC.Infraestructura.Proxy.Amt;
using Pe.Stracon.SGC.Infraestructura.Proxy.SAP;

namespace Pe.Stracon.SGC.Aplicacion.Service.Contractual
{
    /// <summary>
    /// Servicio que representa los Bienes
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20150710 <br />
    /// Modificación:<br />
    /// </remarks>
    public class BienService : GenericService, IBienService
    {
        #region propiedades
        /// <summary>
        /// Interfaz de comunicación con parámetro de políticas.
        /// </summary>
        public IPoliticaService politicaService { get; set; }
        /// <summary>
        /// Interface para obtener el entorno de la aplicación.
        /// </summary>
        public IEntornoActualAplicacion entornoAplicacion { get; set; }
        /// <summary>
        /// Interface para obtener informacion del Bien.
        /// </summary>
        public IBienEntityRepository bienRepository { get; set; }
        /// <summary>
        /// Interface para obtener informacion del Bien-Alquiler
        /// </summary>
        public IBienAlquilerEntityRepository bienAlquilerRepository { get; set; }
        /// <summary>
        /// Interface para obtener informacion de los bienes.
        /// </summary>
        public IBienLogicRepository bienLogicRepository { get; set; }
        /// <summary>
        /// Interface para obtener informacion de los bienes de alquiler
        /// </summary>
        public IBienAlquilerEntityRepository bienAlquilerLogicRepository { get; set; }

        /// <summary>
        /// Servcio Parámetro Valor
        /// </summary>
        public IParametroValorService parametroValorService { get; set; }

        #endregion

        #region metodos
        /// <summary>
        /// Método que retorna la Lista de Bienes
        /// </summary>
        /// <param name="filtro">objeto request del tipo Bien</param>
        /// <returns>Lista de Bienes</returns>  
        public ProcessResult<List<BienResponse>> ListarBienes(BienRequest filtro, List<CodigoValorResponse> plstTipoBien = null,
                                                                                  List<CodigoValorResponse> plstTipoTarifa = null,
                                                                                  List<CodigoValorResponse> plstMoneda = null,
                                                                                  List<CodigoValorResponse> plstPeriodoAlq = null)
        {
            ProcessResult<List<BienResponse>> rpta = new ProcessResult<List<BienResponse>>();
            List<CodigoValorResponse> listaTipoBien;
            List<CodigoValorResponse> listaTipoTarifa;
            List<CodigoValorResponse> listaPeriodoAlq;
            List<CodigoValorResponse> listaMoneda;
            BienResponse itemrpta;
            try
            {
                if (plstTipoBien != null)
                {
                    listaTipoBien = plstTipoBien;
                }
                else
                {
                    listaTipoBien = politicaService.ListaTipoBien().Result;
                }
                if (plstTipoTarifa != null)
                {
                    listaTipoTarifa = plstTipoTarifa;
                }
                else
                {
                    listaTipoTarifa = politicaService.ListaTipoTarifaBien().Result;
                }
                if (plstPeriodoAlq != null)
                {
                    listaPeriodoAlq = plstPeriodoAlq;
                }
                else
                {
                    listaPeriodoAlq = politicaService.ListaPeriodoAlquilerBien().Result;
                }
                if (plstMoneda != null)
                {
                    listaMoneda = plstMoneda;
                }
                else
                {
                    listaMoneda = politicaService.ListarMoneda().Result;
                }

                var listaBien = bienLogicRepository.ListaBandejaBien(filtro.CodigoIdentificacion, filtro.CodigoTipoBien, filtro.NumeroSerie, filtro.Descripcion,
                                        filtro.Marca, filtro.Modelo, filtro.FechaInicio, filtro.FechaFin, filtro.CodigoTipoTarifa);

                rpta.Result = new List<BienResponse>();
                foreach (BienLogic itemLogic in listaBien)
                {
                    itemrpta = new BienResponse();
                    itemrpta = BienAdapter.ObtenerBienResponseDeLogic(itemLogic, listaTipoBien, listaTipoTarifa, listaMoneda, listaPeriodoAlq);
                    rpta.Result.Add(itemrpta);
                }
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<BienService>(ex);
            }

            return rpta;
        }

        /// <summary>
        /// Realiza la búsqueda de bienes con su descripción completa
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de bienes con su descripción completa</returns>
        public ProcessResult<List<BienResponse>> ObtenerDescripcionCompletaBien(BienRequest filtro)
        {
            ProcessResult<List<BienResponse>> resultado = new ProcessResult<List<BienResponse>>();
            try
            {
                List<BienLogic> listado = bienLogicRepository.ObtenerDescripcionCompletaBien(filtro.Descripcion);

                var listaPeriodoAlquilerBien = politicaService.ListaPeriodoAlquilerBien().Result;
                resultado.Result = new List<BienResponse>();
                foreach (var registro in listado)
                {
                    var listaTarifa = new List<BienAlquilerResponse>();
                    if (registro.CodigoTipoTarifa == DatosConstantes.TipoTarifa.Escalonado)
                    {
                        listaTarifa = ListarBienAlquiler(registro.CodigoBien).Result;
                    }

                    var bien = BienAdapter.ObtenerDescripcionCompletaBien(registro, listaTarifa, listaPeriodoAlquilerBien);
                    resultado.Result.Add(bien);
                }
            }
            catch (Exception ex)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<BienService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Método que registra y/o Edita un Bien
        /// </summary>
        /// <param name="objRqst">objeto request del tipo Bien</param>
        /// <returns>Retorna entero, 1 transacción Ok.</returns>
        public ProcessResult<Object> RegistraEditaBien(BienRequest objRqst)
        {
            ProcessResult<Object> rpta = new ProcessResult<Object>();
            BienEntity entidad = BienAdapter.ObtenerBienEntityDeRequest(objRqst);
            try
            {
                using (TransactionScope tsc= new TransactionScope(TransactionScopeOption.Required))
                {
                    if (entidad.CodigoBien == Guid.Empty)
                    {
                        entidad.CodigoBien = Guid.NewGuid();
                        bienRepository.Insertar(entidad);
                    }
                    else
                    {
                        var entidadUpdate = bienRepository.GetById(entidad.CodigoBien);
                        entidadUpdate.CodigoTipoBien = entidad.CodigoTipoBien;
                        entidadUpdate.CodigoIdentificacion = entidad.CodigoIdentificacion;
                        entidadUpdate.NumeroSerie = entidad.NumeroSerie;
                        entidadUpdate.Descripcion = entidad.Descripcion;
                        entidadUpdate.Marca = entidad.Marca;
                        entidadUpdate.Modelo = entidad.Modelo;
                        entidadUpdate.FechaAdquisicion = entidad.FechaAdquisicion;                    
                        entidadUpdate.TiempoVida = entidad.TiempoVida;
                        entidadUpdate.ValorResidual = entidad.ValorResidual;
                        entidadUpdate.CodigoTipoTarifa = entidad.CodigoTipoTarifa;                                        
                        entidadUpdate.CodigoPeriodoAlquiler = entidad.CodigoPeriodoAlquiler;                    
                        entidadUpdate.ValorAlquiler = entidad.ValorAlquiler;
                        entidadUpdate.CodigoMoneda = entidad.CodigoMoneda;
                        entidadUpdate.MesInicioAlquiler = entidad.MesInicioAlquiler;
                        entidadUpdate.AnioInicioAlquiler = entidad.AnioInicioAlquiler;
                        bienRepository.Editar(entidadUpdate);
                    }
                    rpta.Result = bienRepository.GuardarCambios();

                    var RegistraHist = RegistraHistBienRegistro(entidad.NumeroSerie, entidad.Descripcion, entidad.Marca, entidad.Modelo);
                    tsc.Complete();
                }                                
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<BienService>(ex);
            }
            return rpta;
        }
        /// <summary>
        /// Retorna información del bien.
        /// </summary>
        /// <param name="codigoBien">código del bien</param>
        /// <returns>Información del Bien</returns>
        public ProcessResult<BienResponse> RetornaBienPorId(Guid codigoBien)
        {
            ProcessResult<BienResponse> rpta = new ProcessResult<BienResponse>();
            try
            {
                BienEntity entBien = bienRepository.GetById(codigoBien);
                rpta.Result = new BienResponse();
                rpta.Result = BienAdapter.ObtenerBienResponseDeEntity(entBien);
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<BienService>(ex);
            }
            return rpta;
        }
        /// <summary>
        /// Retorna información del bien alquiler por código.
        /// </summary>
        /// <param name="codigoBienAlquiler">código del bien alquiler</param>
        /// <returns>Información del bien alquiler</returns>
        public ProcessResult<BienAlquilerResponse> RetornaBienAlquilerPorId(Guid codigoBienAlquiler)
        {
            ProcessResult<BienAlquilerResponse> rpta = new ProcessResult<BienAlquilerResponse>();
            try
            {
                BienAlquilerEntity entBienAlquiler = bienAlquilerLogicRepository.GetById(codigoBienAlquiler);
                rpta.Result = new BienAlquilerResponse();
                rpta.Result = BienAdapter.ObtenerBienAlquilerResponseDeEntity(entBienAlquiler);
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<BienService>(ex);
            }
            return rpta;
        }
        /// <summary>
        /// Método que retorna la Lista de Bienes Alquiler
        /// </summary>
        /// <param name="filtro">objeto request del tipo Bien</param>
        /// <returns>Lista de Bien-Alquiler para la bandeja</returns>
        public ProcessResult<List<BienAlquilerResponse>> ListarBienAlquiler(Guid codigoBien)
        {
            ProcessResult<List<BienAlquilerResponse>> rpta = new ProcessResult<List<BienAlquilerResponse>>();
            BienAlquilerResponse itemrpta;
            try
            {
                var listaBienAlquiler = bienLogicRepository.ListaBienAlquiler(codigoBien);
                rpta.Result = new List<BienAlquilerResponse>();
                foreach (BienAlquilerLogic itemLogic in listaBienAlquiler)
                {
                    itemrpta = new BienAlquilerResponse();
                    itemrpta = BienAdapter.ObtenerBienAlquilerResponseDeLogic(itemLogic);
                    rpta.Result.Add(itemrpta);
                }
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<BienService>(ex);
            }

            return rpta;
        }
        /// <summary>
        /// Método que registra y/o Edita un Bien Alquiler
        /// </summary>
        /// <param name="objRqst">objeto request del tipo BienAlquiler</param>
        /// <returns>Retorna entero, 1 si transacción satisfactoria y -1 si hubo Error.</returns>
        public ProcessResult<Object> RegistraEditaBienAlquiler(BienAlquilerRequest objRqst)
        {
            ProcessResult<Object> rpta = new ProcessResult<Object>();
            BienAlquilerEntity entidad = BienAdapter.ObtenerBienAlquilerEntityDeRequest(objRqst);
            List<BienAlquilerLogic> listaAux = new List<BienAlquilerLogic>();
            int existeSinLimite = 0, existeCantidadHora = 0;

            listaAux = bienLogicRepository.ListaBienAlquiler((Guid)objRqst.CodigoBien);
            /*Verificamos si existe ya un registro con Limite.*/
            if (entidad.IndicadorSinLimite)
            {
                var listaBienAlquiler = listaAux.FindAll(x => x.IndicadorSinLimite == true).ToList();                                
                if (listaBienAlquiler.Count > 0)
                {
                    if (entidad.CodigoBienAlquiler == Guid.Empty)//es nu nuevo registro y ya existe uno con Indicador.
                    {
                        existeSinLimite = 1;
                    }
                    else
                    {
                        if (listaBienAlquiler[0].CodigoBienAlquiler != entidad.CodigoBienAlquiler)
                        {
                            existeSinLimite = 1;
                        }
                    }
                }
            }
            if (entidad.CantidadLimite > 0)
            {
                var listaBienAlquiler = listaAux.FindAll(x => x.CantidadLimite==entidad.CantidadLimite).ToList();
                if (listaBienAlquiler != null && listaBienAlquiler.Count > 0)
                {
                    if (entidad.CodigoBienAlquiler == Guid.Empty)//es nu nuevo registro y ya existe uno con esa Cantidad.
                    {
                        existeCantidadHora = 1;
                    }
                    else
                    {
                        if (listaBienAlquiler[0].CodigoBienAlquiler != entidad.CodigoBienAlquiler)
                        {
                            existeCantidadHora = 1;
                        }
                    }
                }
            }

            if (existeSinLimite > 0)
            {
                rpta.Result = "Sólo puede existir un registro con el indicador Sin Límite, verifique..";
                rpta.IsSuccess = false;                
                return rpta;
            }
            if (existeCantidadHora > 0)
            {
                rpta.Result = "No puede ingresar cantidad de horas duplicadas, verifique.";
                rpta.IsSuccess = false;
                return rpta;
            }
            try
            {
                if (entidad.CodigoBienAlquiler == Guid.Empty)
                {
                    entidad.CodigoBienAlquiler = Guid.NewGuid();
                    bienAlquilerRepository.Insertar(entidad);
                }
                else
                {
                    var entidadUpdate = bienAlquilerRepository.GetById(entidad.CodigoBienAlquiler);
                    entidadUpdate.CodigoBien = entidad.CodigoBien;
                    entidadUpdate.IndicadorSinLimite = entidad.IndicadorSinLimite;
                    entidadUpdate.CantidadLimite = entidad.CantidadLimite;
                    entidadUpdate.Monto = entidad.Monto;
                    bienAlquilerRepository.Editar(entidadUpdate);
                }
                rpta.Result = bienAlquilerRepository.GuardarCambios();
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<BienService>(ex);
            }
            return rpta;
        }
        /// <summary>
        ///  Retorna los periodos de alquiler.
        /// </summary>
        /// <param name="tipoTarifa">Código del Tipo de Tarifa</param>
        /// <returns>Periodos de alquiler por Tipo de Tarifa</returns>
        public ProcessResult<List<CodigoValorResponse>> PeriodoAlquilerPorTarifa(string tipoTarifa)
        {
            ProcessResult<List<CodigoValorResponse>> listaPeriodo = new ProcessResult<List<CodigoValorResponse>>();
            try
            {
                var lstMatriz = politicaService.ListaPeriodoAlquilerDinamico().Result;
                var filtroPeriodo = lstMatriz.Where(a => a.Atributo3 == tipoTarifa).ToList();
                listaPeriodo.Result = new List<CodigoValorResponse>();
                foreach (var item in filtroPeriodo)
                {
                    listaPeriodo.Result.Add(new CodigoValorResponse() { Codigo = item.Atributo1, Valor = item.Atributo2 });
                }
            }
            catch (Exception ex)
            {
                listaPeriodo.IsSuccess = false;
                listaPeriodo.Exception = new ApplicationLayerException<BienService>(ex);
            }
            return listaPeriodo;
        }
        /// <summary>
        /// Registro el tipo de texto en la tabla bien registro.
        /// </summary>
        /// <param name="numSerie">número de serie de bien</param>
        /// <param name="descrip">descripción de bien</param>
        /// <param name="marca">marca de bien</param>
        /// <param name="modelo">modelo de bien</param>
        /// <returns>Retorna entero, 1 transacción exitosa y -1 si hubo error.</returns>
        public ProcessResult<Object> RegistraHistBienRegistro(string numSerie, string descrip, string marca, string modelo)
        {
            ProcessResult<Object> rpta = new ProcessResult<Object>();
            int registroHBR = 0;
            string usuario = entornoAplicacion.UsuarioSession;
            string terminal = entornoAplicacion.Terminal;
            
                if (!string.IsNullOrEmpty(numSerie))
                {
                    registroHBR = bienLogicRepository.RegistraHSTBienRegistro(DatosConstantes.TipoContenidoBienRegistro.NumeroSerie,
                                                        numSerie, usuario, terminal);
                }
                if (!string.IsNullOrEmpty(numSerie))
                {
                    registroHBR = bienLogicRepository.RegistraHSTBienRegistro(DatosConstantes.TipoContenidoBienRegistro.Descripcion,
                                                        descrip, usuario, terminal);
                }
                if (!string.IsNullOrEmpty(numSerie))
                {
                    registroHBR = bienLogicRepository.RegistraHSTBienRegistro(DatosConstantes.TipoContenidoBienRegistro.Marca,
                                                        marca, usuario, terminal);
                }
                if (!string.IsNullOrEmpty(numSerie))
                {
                    registroHBR = bienLogicRepository.RegistraHSTBienRegistro(DatosConstantes.TipoContenidoBienRegistro.Modelo,
                                                        modelo, usuario, terminal);
                }
                rpta.Result = registroHBR;
            
            return rpta;
        }
        /// <summary>
        /// Retorna la lista del descripciones de campos del bien.
        /// </summary>
        /// <param name="tipoContenido">código del tipo de contenido</param>
        /// <returns>Lista información de descripciones de campos del bien por tipo de contenido</returns>
        public ProcessResult<List<BienRegistroResponse>> ListaBienRegistro(string tipoContenido)
        {
            ProcessResult<List<BienRegistroResponse>> rpta = new ProcessResult<List<BienRegistroResponse>>();
            BienRegistroResponse itemrpta ;
            try
            {
                rpta.Result = new List<BienRegistroResponse>();
                List<BienRegistroLogic> result = bienLogicRepository.ListaBienRegistro(tipoContenido);
                foreach (BienRegistroLogic item in result)
	            {
		            itemrpta = new BienRegistroResponse();
                    itemrpta = BienAdapter.ObtenerBienRegistroResponseDeLogic(item);
                    rpta.Result.Add(itemrpta);
	            }
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<BienService>(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Elimina uno o muchos bienes
        /// </summary>
        /// <param name="listaCodigosBien">Lista de códigos de bien a eliminar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> EliminarBien(List<object> listaCodigosBien)
        {
            ProcessResult<Object> resultado = new ProcessResult<Object>();
            try
            {
                foreach (var codigo in listaCodigosBien)
                {
                    var llaveEntidad = new Guid(codigo.ToString());
                    bienRepository.Eliminar(llaveEntidad);
                }

                resultado.Result = bienRepository.GuardarCambios();

                /*Eliminamos los detalles si hubiera*/
                //var lstBienAlquiler = bienLogicRepository.ListaBienAlquiler(codigoBien);
                //foreach (BienAlquilerLogic item in lstBienAlquiler)
                //{
                //    bienAlquilerRepository.Eliminar(item.CodigoBienAlquiler);
                //    rpta.Result = bienAlquilerRepository.GuardarCambios();
                //}
            }
            catch (Exception ex)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<BienService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Elimina uno o muchos bien alquiler
        /// </summary>
        /// <param name="listaCodigosBienAlquiler">Lista de códigos de bien alquiler a eliminar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> EliminarBienAlquiler(List<object> listaCodigosBienAlquiler)
        {
            ProcessResult<object> resultado = new ProcessResult<object>();
            try
            {
                foreach (var codigo in listaCodigosBienAlquiler)
                {
                    var llaveEntidad = new Guid(codigo.ToString());
                    bienAlquilerRepository.Eliminar(llaveEntidad);
                }

                resultado.Result = bienAlquilerRepository.GuardarCambios();
            }
            catch (Exception ex)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<BienService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Sincronizar bienes de servicio Amt
        /// </summary>
        /// <returns>Registro de nuevos equipos de Amt</returns>
        public ProcessResult<string> SincronizarBienesServicioAmt()
        {
            ProcessResult<string> resultado = new ProcessResult<string>();
            try
            {
                IAmtProxy amtService = new AmtProxy();
                List<BienLogic> equiposAmt = amtService.ObtenerEquipos();

                var listaBienes = ListarBienes(new BienRequest()).Result;
               
                var equiposAgregados = equiposAmt.Where(e => !listaBienes.Any(b => b.Modelo.ToUpper().Trim() == e.Modelo.ToUpper().Trim() && b.NumeroSerie.Trim() == e.NumeroSerie.Trim()));

                var parametros = parametroValorService.BuscarParametroValor(new ParametroValorRequest()
                {
                    CodigoParametro = DatosConstantes.ParametroValor.ConfiguracionEquiposAmt,               
                    CodigoValor = 1,
                    EstadoRegistro = "1"
                }).Result;

                if (parametros.Count > 0)
                {
                    var parametroTiempoVida = parametros[0].RegistroCadena[DatosConstantes.ParametroConfiguracionAmtValorSeccion.TiempoVida.ToString()];
                    var parametroValorResidual = parametros[0].RegistroCadena[DatosConstantes.ParametroConfiguracionAmtValorSeccion.ValorResidual.ToString()];
                    var parametroCodigoTipoTarifa = parametros[0].RegistroCadena[DatosConstantes.ParametroConfiguracionAmtValorSeccion.CodigoTipoTarifa.ToString()];
                    var parametroCodigoPeriodoAlquiler = parametros[0].RegistroCadena[DatosConstantes.ParametroConfiguracionAmtValorSeccion.CodigoPeriodoAlquiler.ToString()];
                    var parametroValorAlquiler = parametros[0].RegistroCadena[DatosConstantes.ParametroConfiguracionAmtValorSeccion.ValorAlquiler.ToString()];
                    var parametroCodigoMoneda = parametros[0].RegistroCadena[DatosConstantes.ParametroConfiguracionAmtValorSeccion.CodigoMoneda.ToString()];
                    var parametroCodigoTipoBien = parametros[0].RegistroCadena[DatosConstantes.ParametroConfiguracionAmtValorSeccion.CodigoTipoBien.ToString()];

                    decimal tiempoVida = 0;
                    decimal.TryParse(parametroTiempoVida, out tiempoVida);

                    decimal valorResidual = 0;
                    decimal.TryParse(parametroValorResidual, out valorResidual);

                    decimal valorAlquiler = 0;
                    decimal.TryParse(parametroValorAlquiler, out valorAlquiler);

                    foreach (var item in equiposAgregados)
                    {
                        BienEntity bienEntidad = new BienEntity();
                        bienEntidad.CodigoBien = Guid.NewGuid();
                        bienEntidad.Marca = item.Marca;
                        bienEntidad.Modelo = item.Modelo;
                        bienEntidad.NumeroSerie = item.NumeroSerie;
                        bienEntidad.CodigoIdentificacion = item.CodigoIdentificacion;
                        bienEntidad.Descripcion = item.Descripcion;
                        bienEntidad.FechaAdquisicion = (DateTime)item.FechaAdquisicion;

                        bienEntidad.TiempoVida = tiempoVida;
                        bienEntidad.ValorResidual = valorResidual;
                        bienEntidad.CodigoTipoTarifa = parametroCodigoTipoTarifa != null ? parametroCodigoTipoTarifa : string.Empty;
                        bienEntidad.CodigoPeriodoAlquiler = parametroCodigoPeriodoAlquiler != null ? parametroCodigoPeriodoAlquiler : string.Empty;
                        bienEntidad.ValorAlquiler = valorAlquiler;
                        bienEntidad.CodigoMoneda = parametroCodigoMoneda != null ? parametroCodigoMoneda : string.Empty;
                        bienEntidad.CodigoTipoBien = parametroCodigoTipoBien != null ? parametroCodigoTipoBien : string.Empty;
                        bienEntidad.MesInicioAlquiler = (byte)DateTime.Today.Month;
                        bienEntidad.AnioInicioAlquiler = (short)DateTime.Today.Year;

                        bienRepository.Insertar(bienEntidad);
                    }

                    resultado.Result = bienRepository.GuardarCambios().ToString();
                }
           
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ProveedorService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Sincronizar bienes de servicio SAP
        /// </summary>
        /// <returns>Registro de nuevos equipos de SAP</returns>
        public ProcessResult<string> SincronizarBienesServicioSAP()
        {
            ProcessResult<string> resultado = new ProcessResult<string>();
            try
            {
                ISAPProxy SAPService = new SAPProxy();
                List<BienLogic> equiposSAP = SAPService.ObtenerEquipos();

                var listaBienes = ListarBienes(new BienRequest()).Result;

                var equiposAgregados = equiposSAP.Where(e => !listaBienes.Any(b => b.CodigoIdentificacion.ToUpper().Trim() == e.CodigoIdentificacion.ToUpper().Trim() &&  b.Modelo.ToUpper().Trim() == e.Modelo.ToUpper().Trim() && b.NumeroSerie.Trim() == e.NumeroSerie.Trim()));

                var parametros = parametroValorService.BuscarParametroValor(new ParametroValorRequest()
                {
                    CodigoParametro = DatosConstantes.ParametroValor.ConfiguracionEquiposAmt,
                    CodigoValor = 1,
                    EstadoRegistro = "1"
                }).Result;

                if (parametros.Count > 0)
                {
                    var parametroTiempoVida = parametros[0].RegistroCadena[DatosConstantes.ParametroConfiguracionAmtValorSeccion.TiempoVida.ToString()];
                    var parametroValorResidual = parametros[0].RegistroCadena[DatosConstantes.ParametroConfiguracionAmtValorSeccion.ValorResidual.ToString()];
                    var parametroCodigoTipoTarifa = parametros[0].RegistroCadena[DatosConstantes.ParametroConfiguracionAmtValorSeccion.CodigoTipoTarifa.ToString()];
                    var parametroCodigoPeriodoAlquiler = parametros[0].RegistroCadena[DatosConstantes.ParametroConfiguracionAmtValorSeccion.CodigoPeriodoAlquiler.ToString()];
                    var parametroValorAlquiler = parametros[0].RegistroCadena[DatosConstantes.ParametroConfiguracionAmtValorSeccion.ValorAlquiler.ToString()];
                    var parametroCodigoMoneda = parametros[0].RegistroCadena[DatosConstantes.ParametroConfiguracionAmtValorSeccion.CodigoMoneda.ToString()];
                    var parametroCodigoTipoBien = parametros[0].RegistroCadena[DatosConstantes.ParametroConfiguracionAmtValorSeccion.CodigoTipoBien.ToString()];

                    decimal tiempoVida = 0;
                    decimal.TryParse(parametroTiempoVida, out tiempoVida);

                    decimal valorResidual = 0;
                    decimal.TryParse(parametroValorResidual, out valorResidual);

                    decimal valorAlquiler = 0;
                    decimal.TryParse(parametroValorAlquiler, out valorAlquiler);

                    foreach (var item in equiposAgregados)
                    {
                        BienEntity bienEntidad = new BienEntity();
                        bienEntidad.CodigoBien = Guid.NewGuid();
                        bienEntidad.Marca = item.Marca;
                        bienEntidad.Modelo = item.Modelo;
                        bienEntidad.NumeroSerie = item.NumeroSerie;
                        bienEntidad.CodigoIdentificacion = item.CodigoIdentificacion;
                        bienEntidad.Descripcion = item.Descripcion;
                        if (item.FechaAdquisicion != null)
                        {
                            bienEntidad.FechaAdquisicion = (DateTime)item.FechaAdquisicion;
                        }
                        else
                        {
                            bienEntidad.FechaAdquisicion = DateTime.Today;
                        }
                       

                        bienEntidad.TiempoVida = tiempoVida;
                        bienEntidad.ValorResidual = valorResidual;
                        bienEntidad.CodigoTipoTarifa = parametroCodigoTipoTarifa != null ? parametroCodigoTipoTarifa : string.Empty;
                        bienEntidad.CodigoPeriodoAlquiler = parametroCodigoPeriodoAlquiler != null ? parametroCodigoPeriodoAlquiler : string.Empty;
                        bienEntidad.ValorAlquiler = valorAlquiler;
                        bienEntidad.CodigoMoneda = parametroCodigoMoneda != null ? parametroCodigoMoneda : string.Empty;
                        bienEntidad.CodigoTipoBien = parametroCodigoTipoBien != null ? parametroCodigoTipoBien : string.Empty;
                        bienEntidad.MesInicioAlquiler = (byte)DateTime.Today.Month;
                        bienEntidad.AnioInicioAlquiler = (short)DateTime.Today.Year;

                        bienRepository.Insertar(bienEntidad);
                    }

                    resultado.Result = bienRepository.GuardarCambios().ToString();
                }

            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ProveedorService>(e);
            }

            return resultado;
        }


        #endregion

    }
}