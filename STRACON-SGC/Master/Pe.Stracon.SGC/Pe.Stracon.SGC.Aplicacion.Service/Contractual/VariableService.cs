using Pe.Stracon.SGC.Aplicacion.Adapter.Contractual;
using Pe.Stracon.SGC.Aplicacion.Core.Base;
using Pe.Stracon.SGC.Aplicacion.Core.ServiceContract;
using Pe.Stracon.SGC.Aplicacion.Service.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Application.Core.ServiceContract;
using Pe.Stracon.SGC.Cross.Core.Exception;
using Pe.Stracon.SGC.Infraestructura.Core.CommandContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;

namespace Pe.Stracon.SGC.Aplicacion.Service.Contractual
{
    /// <summary>
    /// Servicio que representa las variables
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150518 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class VariableService : GenericService, IVariableService
    {
        #region Propiedades
        /// <summary>
        /// Repositorio de Variable
        /// </summary>
        public IVariableLogicRepository variableLogicRepository { get; set; }
        /// <summary>
        ///  Repositorio de Entidad de Variable
        /// </summary>
        public IVariableEntityRepository variableEntityRepository { get; set; }
        /// <summary>
        /// Repositorio de Campo de Variable
        /// </summary>
        public IVariableCampoLogicRepository variableCampoLogicRepository { get; set; }
        /// <summary>
        ///  Repositorio de Entidad de Campo de Variable
        /// </summary>
        public IVariableCampoEntityRepository variableCampoEntityRepository { get; set; }
        /// <summary>
        /// Repositorio de Lista de Variable
        /// </summary>
        public IVariableListaLogicRepository variableListaLogicRepository { get; set; }
        /// <summary>
        ///  Repositorio de Entidad de Lista de Variable
        /// </summary>
        public IVariableListaEntityRepository variableListaEntityRepository { get; set; }
        /// <summary>
        /// Servicio de Plantilla
        /// </summary>
        public IPlantillaService plantillaService { get; set; }
        /// <summary>
        /// Servicio de Unidad Operativa
        /// </summary>
        public IUnidadOperativaService unidadOperativaService { get; set; }
        /// <summary>
        /// Servicio de Trabajador
        /// </summary>
        public ITrabajadorService trabajadorService { get; set; }
        #endregion

        /// <summary>
        /// Realiza la busqueda de variables 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns>Lista de variables</returns>
        public ProcessResult<List<VariableResponse>> BuscarVariable(VariableRequest filtro)
        {
            ProcessResult<List<VariableResponse>> resultado = new ProcessResult<List<VariableResponse>>();

            try
            {
                Guid? codigoVariable = (filtro.CodigoVariable != null && filtro.CodigoVariable != "") ? new Guid(filtro.CodigoVariable) : (Guid?)null;
                Guid? codigoPlantilla = (filtro.CodigoPlantilla != null && filtro.CodigoPlantilla != "") ? new Guid(filtro.CodigoPlantilla) : (Guid?)null;

                if (filtro.IndicadorGlobalSelect == "0")
                {
                    filtro.IndicadorGlobal = false;
                }
                else if (filtro.IndicadorGlobalSelect == "1")
                {
                    filtro.IndicadorGlobal = true;
                }
                else
                {
                    filtro.IndicadorGlobal = null;
                }

                List<VariableLogic> listado = variableLogicRepository.BuscarVariable(
                    codigoVariable,
                    filtro.Identificador,
                    filtro.Nombre,
                    filtro.CodigoTipo,
                    filtro.IndicadorGlobal,
                    codigoPlantilla,
                    filtro.IndicadorVariableSistema
                );

                var tipoVariable = ListarTipoVariable().Result;

                var plantilla = plantillaService.BuscarPlantilla(new PlantillaRequest() { }).Result;

                resultado.Result = new List<VariableResponse>();

                foreach (var registro in listado)
                {
                    resultado.Result.Add(VariableAdapter.ObtenerVariable(registro, plantilla, tipoVariable));
                }

            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<VariableService>(e);
            }
            return resultado;
        }

        /// <summary>
        /// Retorna el valor por defecto de las variables de sistema
        /// </summary>
        /// <param name="filtro">Datos de la variable de sistema</param>
        /// <returns>Retorna el valor por defecto</returns>
        public ProcessResult<string> ObtenerValorDefecto(ValorPorDefectoRequest filtro, UnidadOperativaResponse unidadOperativa)
        {
            var resultado = new ProcessResult<string>();

            try
            {
                switch (filtro.IdentificadorVariable)
                {
                    case DatosConstantes.IdentificadorVariableDefecto.NumeroContrato:
                        resultado.Result = "";
                        break;
                    case DatosConstantes.IdentificadorVariableDefecto.NombreProyecto:
                        resultado.Result = filtro.NombreUnidadOperativa;
                        break;
                    case DatosConstantes.IdentificadorVariableDefecto.NombreEmpresa:
                    case DatosConstantes.IdentificadorVariableDefecto.DniPrimerRepresentanteEmpresa:
                    case DatosConstantes.IdentificadorVariableDefecto.PrimerRepresentanteEmpresa:
                    case DatosConstantes.IdentificadorVariableDefecto.DniSegundoRepresentanteEmpresa:
                    case DatosConstantes.IdentificadorVariableDefecto.SegundoRepresentanteEmpresa:
                        resultado.Result = ObtenerDatoUnidadOperativa(filtro.IdentificadorVariable, unidadOperativa);
                        break;
                    case DatosConstantes.IdentificadorVariableDefecto.RucProveedor:
                        resultado.Result = filtro.RucProveedor;
                        break;
                    case DatosConstantes.IdentificadorVariableDefecto.NombreProveedor:
                    case DatosConstantes.IdentificadorVariableDefecto.ProveedorNombre:
                        resultado.Result = filtro.NombreProveedor;
                        break;
                    case DatosConstantes.IdentificadorVariableDefecto.MonedaContrato:
                        resultado.Result = filtro.DescripcionMoneda;
                        break;
                    case DatosConstantes.IdentificadorVariableDefecto.MontoContrato:
                        resultado.Result = filtro.MontoContratoString;
                        break;
                    case DatosConstantes.IdentificadorVariableDefecto.PlazoVigenciaDesde:
                    case DatosConstantes.IdentificadorVariableDefecto.FechaInicioContrato:
                        resultado.Result = filtro.FechaInicioContratoString;
                        break;
                    case DatosConstantes.IdentificadorVariableDefecto.PlazoVigenciaHasta:
                    case DatosConstantes.IdentificadorVariableDefecto.FechaFinContrato:
                        resultado.Result = filtro.FechaFinContratoString;
                        break;
                    case DatosConstantes.IdentificadorVariableDefecto.FechaActual:
                        resultado.Result = DateTime.Today.ToString(DatosConstantes.Formato.FormatoFecha);
                        break;
                    case DatosConstantes.IdentificadorVariableDefecto.FechaActualLetra:
                        resultado.Result = DateTime.Today.ToString(DatosConstantes.Formato.FormatoFecha);
                        break;                 

                    default:
                        resultado.Result = "";
                        break;
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<VariableService>(e);
            }
            return resultado;
        }
        /// <summary>
        /// Obtiene unidad operativa
        /// </summary>
        /// <param name="codigoUnidadOperativa">Código de Unidad Operativa</param>
        /// <param name="identificadorVariable">Identificador Variable</param>
        /// <returns>Lista de variables</returns>
        public string ObtenerDatoUnidadOperativa(string identificadorVariable, UnidadOperativaResponse unidadOperativa)
        {
            string resultado = "";
            if (unidadOperativa != null)
            {
                if (unidadOperativa.UnidadOperativaPadre != null)
                {
                    switch (identificadorVariable)
                    {
                        case DatosConstantes.IdentificadorVariableDefecto.NombreEmpresa:
                            resultado = unidadOperativa.UnidadOperativaPadre.Nombre;
                            break;
                        case DatosConstantes.IdentificadorVariableDefecto.DireccionEmpresa:
                            resultado = unidadOperativa.UnidadOperativaPadre.Direccion;
                            break;
                        case DatosConstantes.IdentificadorVariableDefecto.DireccionProyecto:
                            resultado = unidadOperativa.Direccion;
                            break;
                        case DatosConstantes.IdentificadorVariableDefecto.PrimerRepresentanteEmpresa:
                            resultado = unidadOperativa.UnidadOperativaPadre.PrimerRepresentante == null ? "" : unidadOperativa.UnidadOperativaPadre.PrimerRepresentante.NombreCompleto;
                            break;
                        case DatosConstantes.IdentificadorVariableDefecto.DniPrimerRepresentanteEmpresa:
                            resultado = unidadOperativa.UnidadOperativaPadre.PrimerRepresentante == null ? "" : unidadOperativa.UnidadOperativaPadre.PrimerRepresentante.DescripcionTipoDocumentoIdentidad + ": " + unidadOperativa.UnidadOperativaPadre.PrimerRepresentante.NumeroDocumentoIdentidad;
                            break;
                        case DatosConstantes.IdentificadorVariableDefecto.SegundoRepresentanteEmpresa:
                            resultado = unidadOperativa.UnidadOperativaPadre.SegundoRepresentante == null ? "" : unidadOperativa.UnidadOperativaPadre.SegundoRepresentante.NombreCompleto;
                            break;
                        case DatosConstantes.IdentificadorVariableDefecto.DniSegundoRepresentanteEmpresa:
                            resultado = unidadOperativa.UnidadOperativaPadre.SegundoRepresentante == null ? "" : unidadOperativa.UnidadOperativaPadre.SegundoRepresentante.DescripcionTipoDocumentoIdentidad + ": " + unidadOperativa.UnidadOperativaPadre.SegundoRepresentante.NumeroDocumentoIdentidad;
                            break;
                        default:
                            resultado = "";
                            break;
                    }
                }
            }

            return resultado;
        }

        /// <summary>
        /// Registrar Variable
        /// </summary>
        /// <param name="filtro">Variable a registrar</param>
        /// <returns>Indicador de conformidad
        /// 0: Registro satisfactorio
        /// 2: Identificador repetido
        /// 3: Nombre repetido
        /// -1: Ocurrio un Error Inesperado</returns>
        public ProcessResult<string> RegistrarVariable(VariableRequest filtro)
        {
            ProcessResult<string> resultado = new ProcessResult<string>();
            resultado.Result = "0";
            try
            {
                var listaVariable = BuscarVariable(new VariableRequest() { }).Result;

                //Validar si el Idetificador de la variable es repetido
                if (listaVariable.Any(itemAny => (filtro.CodigoVariable == null || new Guid(filtro.CodigoVariable) != itemAny.CodigoVariable)
                    && (filtro.IndicadorGlobal == true || itemAny.CodigoPlantilla == new Guid(filtro.CodigoPlantilla))
                    && itemAny.Identificador == filtro.Identificador))
                {
                    resultado.Result = "2";
                    resultado.IsSuccess = false;
                    return resultado;
                }

                //Validar si el Nombre de la variable es repetido
                if (listaVariable.Any(itemAny => (filtro.CodigoVariable == null || new Guid(filtro.CodigoVariable) != itemAny.CodigoVariable)
                    && (filtro.IndicadorGlobal == true || itemAny.CodigoPlantilla == new Guid(filtro.CodigoPlantilla))
                    && itemAny.Nombre == filtro.Nombre))
                {
                    resultado.Result = "3";
                    resultado.IsSuccess = false;
                    return resultado;
                }

                var entidad = VariableAdapter.ObtenerVariableEntityDesdeVariableRequest(filtro);


                if (filtro.CodigoVariable == null)
                {
                    variableEntityRepository.Insertar(entidad);

                    variableEntityRepository.GuardarCambios();
                    //Agregar una columna por default si es tabla
                    if (entidad.CodigoTipo == DatosConstantes.TipoVariable.Tabla)
                    {
                        var campo = new VariableCampoEntity();
                        campo.CodigoVariableCampo = Guid.NewGuid();
                        campo.CodigoVariable = entidad.CodigoVariable;
                        campo.Nombre =  "Título";
                        campo.Orden = 1;
                        campo.Tamanio = 100;
                        campo.TipoAlineamiento = "center";
                        variableCampoEntityRepository.Insertar(campo);
                        variableCampoEntityRepository.GuardarCambios();
                    }
                }
                else
                {
                    var varibleActual = variableEntityRepository.GetById(entidad.CodigoVariable);
                    varibleActual.CodigoPlantilla = entidad.CodigoPlantilla;
                    varibleActual.CodigoTipo = entidad.CodigoTipo;
                    varibleActual.Identificador = entidad.Identificador;
                    varibleActual.Nombre = entidad.Nombre;
                    varibleActual.IndicadorGlobal = entidad.IndicadorGlobal;
                    varibleActual.Descripcion = entidad.Descripcion;
                    varibleActual.IndicadorVariableSistema = entidad.IndicadorVariableSistema;
                    variableEntityRepository.Editar(varibleActual);

                    variableEntityRepository.GuardarCambios();
                }
                
                resultado.IsSuccess = true;
            }
            catch (Exception e)
            {
                resultado.Result = "-1";
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<VariableService>(e);
            }

            return resultado;
        }


        /// <summary>
        /// Eliminar Variable plantilla
        /// </summary>
        /// <param name="listaCodigoVariable">Lista con registros a eliminar</param>
        /// <returns>Identificador con resultado</returns>
        public ProcessResult<object> EliminarVariablePlantilla(List<object> listaCodigoFlujoAprobacionEstadio)
        {
            ProcessResult<Object> resultado = new ProcessResult<Object>();
            try
            {

                foreach (var codigo in listaCodigoFlujoAprobacionEstadio)
                {
                    var llaveEntidad = new Guid(codigo.ToString());
                    variableEntityRepository.Eliminar(llaveEntidad);
                }


                resultado.Result = variableEntityRepository.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<VariableService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Lista los tipos de variable definidos para las plantillas
        /// </summary>
        /// <returns>Lista de Tipos de Variable</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarTipoVariable()
        {
            var resultado = new ProcessResult<List<CodigoValorResponse>>();

            resultado.Result = new List<CodigoValorResponse>() 
            {
                new CodigoValorResponse() {Codigo = DatosConstantes.TipoVariable.Texto, Valor = DatosConstantes.DescripcionTipoVariable.Texto},
                new CodigoValorResponse() {Codigo = DatosConstantes.TipoVariable.Numero, Valor = DatosConstantes.DescripcionTipoVariable.Numero},
                new CodigoValorResponse() {Codigo = DatosConstantes.TipoVariable.Fecha, Valor = DatosConstantes.DescripcionTipoVariable.Fecha},
                new CodigoValorResponse() {Codigo = DatosConstantes.TipoVariable.Tabla, Valor = DatosConstantes.DescripcionTipoVariable.Tabla},
                new CodigoValorResponse() {Codigo = DatosConstantes.TipoVariable.Imagen, Valor = DatosConstantes.DescripcionTipoVariable.Imagen},
                new CodigoValorResponse() {Codigo = DatosConstantes.TipoVariable.Bien, Valor = DatosConstantes.DescripcionTipoVariable.Bien},
                new CodigoValorResponse() {Codigo = DatosConstantes.TipoVariable.Firmante, Valor = DatosConstantes.DescripcionTipoVariable.Firmante},
                new CodigoValorResponse() {Codigo = DatosConstantes.TipoVariable.FirmanteStracon, Valor = DatosConstantes.DescripcionTipoVariable.FirmanteStracon},
                new CodigoValorResponse() {Codigo = DatosConstantes.TipoVariable.Lista, Valor = DatosConstantes.DescripcionTipoVariable.Lista},
            };

            return resultado;
        }

        /// <summary>
        /// Realiza la búsqueda de Campos de Variable
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda</param>
        /// <returns>Lista de Campos de Variable</returns>
        public ProcessResult<List<VariableCampoResponse>> BuscarVariableCampo(VariableCampoRequest filtro)
        {
            var resultado = new ProcessResult<List<VariableCampoResponse>>();

            try
            {
                Guid? codigoVariableCampo = filtro.CodigoVariableCampo == null ? (Guid?)null : new Guid(filtro.CodigoVariableCampo);
                Guid? codigoVariable = filtro.CodigoVariable == null ? (Guid?)null : new Guid(filtro.CodigoVariable);

                var listaConsulta = variableCampoLogicRepository.BuscarCampo(codigoVariableCampo, codigoVariable, filtro.Nombre, filtro.Orden);
                var listaTipoAlineamiento = this.ListarTipoAlineamiento().Result;

                resultado.Result = listaConsulta.Select(c => VariableAdapter.ObtenerVariableCampo(c, listaTipoAlineamiento)).ToList();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<VariableService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Realiza la búsqueda de Lista de Variable
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda</param>
        /// <returns>Lista de Variable Lista</returns>
        public ProcessResult<List<VariableListaResponse>> BuscarVariableLista(VariableListaRequest filtro)
        {
            var resultado = new ProcessResult<List<VariableListaResponse>>();

            try
            {
                Guid? codigoVariableLista = filtro.CodigoVariableLista == null ? (Guid?)null : new Guid(filtro.CodigoVariableLista);
                Guid? codigoVariable = filtro.CodigoVariable == null ? (Guid?)null : new Guid(filtro.CodigoVariable);

                var listaConsulta = variableListaLogicRepository.BuscarLista(codigoVariableLista, codigoVariable, filtro.Nombre);

                resultado.Result = listaConsulta.Select(c => VariableAdapter.ObtenerVariableLista(c)).ToList();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<VariableService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Registra los datos del Campo de Variable
        /// </summary>
        /// <param name="datos">Datos del Campo a Registrar</param>
        /// <returns>Código de resultado de operación</returns>
        public ProcessResult<string> RegistrarVariableCampo(VariableCampoRequest datos)
        {
            var resultado = new ProcessResult<string>();

            try
            {
                if (datos.CodigoVariableCampo == null || datos.CodigoVariableCampo == "" || datos.CodigoVariableCampo == "00000000-0000-0000-0000-000000000000")
                {
                    var entidad = VariableAdapter.ObtenerVariableCampoEntity(datos);
                    variableCampoEntityRepository.Insertar(entidad);
                }
                else
                {
                    var entidad = variableCampoEntityRepository.GetById(new Guid(datos.CodigoVariableCampo));
                    entidad.Orden = (byte)datos.Orden;
                    entidad.Nombre = datos.Nombre;
                    entidad.TipoAlineamiento = datos.TipoAlineamiento;
                    entidad.Tamanio = datos.Tamanio.Value;
                    variableCampoEntityRepository.Editar(entidad);
                }

                variableCampoEntityRepository.GuardarCambios();
                resultado.Result = "0";
            }
            catch (Exception e)
            {
                resultado.Result = "-1";
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<VariableService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Registra los datos del Lista de Variable
        /// </summary>
        /// <param name="datos">Datos del Lista a Registrar</param>
        /// <returns>Código de resultado de operación</returns>
        public ProcessResult<string> RegistrarVariableLista(VariableListaRequest datos)
        {
            var resultado = new ProcessResult<string>();

            try
            {
                if (datos.CodigoVariableLista == null || datos.CodigoVariableLista == "" || datos.CodigoVariableLista == "00000000-0000-0000-0000-000000000000")
                {
                    var entidad = VariableAdapter.ObtenerVariableListaEntity(datos);
                    variableListaEntityRepository.Insertar(entidad);
                }
                else
                {
                    var entidad = variableListaEntityRepository.GetById(new Guid(datos.CodigoVariableLista));
                    entidad.Nombre = datos.Nombre;
                    entidad.Descripcion = datos.Descripcion;
                    variableListaEntityRepository.Editar(entidad);
                }

                variableListaEntityRepository.GuardarCambios();
                resultado.Result = "0";
            }
            catch (Exception e)
            {
                resultado.Result = "-1";
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<VariableService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Método para eliminar campos de variable
        /// </summary>
        /// <param name="listaCodigos">Lista de Códigos de Campos de Variable</param>
        /// <returns>Código de resultado de operación</returns>
        public ProcessResult<object> EliminarVariableCampo(List<VariableCampoRequest> listaCodigos)
        {
            var resultado = new ProcessResult<object>();

            try
            {
                foreach (var campo in listaCodigos)
                {
                    variableCampoEntityRepository.Eliminar(new Guid(campo.CodigoVariableCampo));
                }
                resultado.Result = variableCampoEntityRepository.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<VariableService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Método para eliminar lista de variable
        /// </summary>
        /// <param name="listaCodigos">Lista de Códigos de Lista de Variable</param>
        /// <returns>Código de resultado de operación</returns>
        public ProcessResult<object> EliminarVariableLista(List<VariableListaRequest> listaCodigos)
        {
            var resultado = new ProcessResult<object>();

            try
            {
                foreach (var campo in listaCodigos)
                {
                    variableListaEntityRepository.Eliminar(new Guid(campo.CodigoVariableLista));
                }
                resultado.Result = variableListaEntityRepository.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<VariableService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Lista los tipos de alineamiento definidos para las columnas de un tabla
        /// </summary>
        /// <returns>Lista de Tipos de Alineamiento</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarTipoAlineamiento()
        {
            var resultado = new ProcessResult<List<CodigoValorResponse>>();

            resultado.Result = new List<CodigoValorResponse>()
            {
                new CodigoValorResponse(){Codigo = "left", Valor = "Izquierda"},
                new CodigoValorResponse(){Codigo = "center", Valor = "Centrado"},
                new CodigoValorResponse(){Codigo = "right", Valor = "Derecha"}
            };

            return resultado;
        }
    }
}
