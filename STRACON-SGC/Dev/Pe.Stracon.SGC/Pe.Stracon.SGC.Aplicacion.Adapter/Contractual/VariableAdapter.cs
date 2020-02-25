using System;
using System.Collections.Generic;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using System.Linq;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;

namespace Pe.Stracon.SGC.Aplicacion.Adapter.Contractual
{
    /// <summary>
    /// Implementacion del adaptador de Variable
    /// </summary>
    public sealed class VariableAdapter
    {
        /// <summary>
        /// Realiza la adaptación de campos logic a response
        /// </summary>
        /// <param name="variableLogic">Lista de variables tipo Logic</param>
        /// <returns>Lista de variables tipo response</returns>
        public static VariableResponse ObtenerVariable(VariableLogic variableLogic, List<PlantillaResponse> plantilla, List<CodigoValorResponse> tipoVariable)
        {
            var variableResponse = new VariableResponse();
            string sPlantilla = null;
            string sTipos = null;

            if (plantilla != null)
            {
                var listaPlantilla = plantilla.Where(n => n.CodigoPlantilla.ToString() == variableLogic.CodigoPlantilla.ToString()).FirstOrDefault();
                sPlantilla = (listaPlantilla == null) ? null : listaPlantilla.Descripcion.ToString();
            }

            if (tipoVariable != null)
            {
                var tipos = tipoVariable.Where(t => variableLogic.CodigoTipo.Equals(t.Codigo)).FirstOrDefault();
                sTipos = tipos.Valor.ToString();
            }
            

            variableResponse.CodigoVariable = variableLogic.CodigoVariable;
            variableResponse.CodigoPlantilla = variableLogic.CodigoPlantilla;
            variableResponse.DescripcionCodigoPlantilla = sPlantilla;
            variableResponse.Identificador = variableLogic.Identificador;
            variableResponse.IdentificadorSinAlmohadilla = variableLogic.Identificador.Replace(DatosConstantes.IdentificadorVariable.Almohadilla, string.Empty);
            variableResponse.Nombre = variableLogic.Nombre;
            variableResponse.CodigoTipo = variableLogic.CodigoTipo;
            variableResponse.DescripcionCodigoTipo = sTipos;
            variableResponse.DescripcionTipoVariable = variableLogic.DescripcionTipoVariable;
            variableResponse.IndicadorGlobal = variableLogic.IndicadorGlobal;
            variableResponse.IndicadorVariableSistema = variableLogic.IndicadorVariableSistema;
            variableResponse.Descripcion = variableLogic.Descripcion;
            return variableResponse;
        }

        /// <summary>
        /// Realiza la adaptación de los campos del request al entity de variable
        /// </summary>
        /// <param name="variableRequest">Request de Variable</param>
        /// <returns>Entity de Variable</returns>
        public static VariableEntity ObtenerVariableEntityDesdeVariableRequest(VariableRequest variableRequest)
        {
            var variableEntity = new VariableEntity();

            variableEntity.CodigoVariable           = variableRequest.CodigoVariable != null ? new Guid(variableRequest.CodigoVariable) : Guid.NewGuid();
            variableEntity.CodigoPlantilla          = !Convert.ToBoolean(variableRequest.IndicadorGlobal) ? (variableRequest.CodigoPlantilla != null ? new Guid(variableRequest.CodigoPlantilla) : Guid.Empty) : (Guid?) null;
            variableEntity.Identificador            = variableRequest.Identificador;
            variableEntity.Nombre                   = variableRequest.Nombre;
            variableEntity.CodigoTipo               = variableRequest.CodigoTipo;
            variableEntity.IndicadorGlobal          = Convert.ToBoolean(variableRequest.IndicadorGlobal);
            variableEntity.IndicadorVariableSistema = Convert.ToBoolean(variableRequest.IndicadorVariableSistema);
            variableEntity.Descripcion              = variableRequest.Descripcion;

            return variableEntity;
        }

        /// <summary>
        /// Adaptador de Campo de Variable
        /// </summary>
        /// <param name="variableCampoLogic">Entidad Lógica de Campo de Variable</param>
        /// <returns>Entidad Response de Campo de Variable</returns>
        public static VariableCampoResponse ObtenerVariableCampo(VariableCampoLogic variableCampoLogic, List<CodigoValorResponse> listaTipoAlineamiento)
        {
            var tipoAlineamiento = listaTipoAlineamiento.Where(ta => ta.Codigo.Equals(variableCampoLogic.TipoAlineamiento)).FirstOrDefault();
            var descripcionTipoAlineamiento = tipoAlineamiento == null ? "" : tipoAlineamiento.Valor.ToString();

            return new VariableCampoResponse()
            {
                CodigoVariableCampo = variableCampoLogic.CodigoVariableCampo,
                CodigoVariable = variableCampoLogic.CodigoVariable,
                Nombre = variableCampoLogic.Nombre,
                Orden = variableCampoLogic.Orden,
                TipoAlineamiento = variableCampoLogic.TipoAlineamiento,
                DescripcionTipoAlineamiento = descripcionTipoAlineamiento,
                Tamanio = variableCampoLogic.Tamanio
            };
        }

        /// <summary>
        /// Obtiene la entidad de Campo de Variable
        /// </summary>
        /// <param name="variableCampoRequest">Request de Campo de Variable</param>
        /// <returns>Entidad de Campo de Variable</returns>
        public static VariableCampoEntity ObtenerVariableCampoEntity(VariableCampoRequest variableCampoRequest)
        {
            return new VariableCampoEntity()
            {
                CodigoVariableCampo = (variableCampoRequest.CodigoVariableCampo == null || variableCampoRequest.CodigoVariableCampo == "" || variableCampoRequest.CodigoVariableCampo == "00000000-0000-0000-0000-000000000000" ? Guid.NewGuid() : new Guid(variableCampoRequest.CodigoVariableCampo)),
                CodigoVariable = new Guid(variableCampoRequest.CodigoVariable),
                Orden = (byte)variableCampoRequest.Orden,
                Nombre = variableCampoRequest.Nombre,
                Tamanio = variableCampoRequest.Tamanio.Value,
                TipoAlineamiento = variableCampoRequest.TipoAlineamiento
            };
        }

        /// <summary>
        /// Adaptador de Lista de Variable
        /// </summary>
        /// <param name="variableListaLogic">Entidad Lógica de Lista de Variable</param>
        /// <returns>Entidad Response de Lista de Variable</returns>
        public static VariableListaResponse ObtenerVariableLista(VariableListaLogic variableListaLogic)
        {
          
            return new VariableListaResponse()
            {
                CodigoVariableLista = variableListaLogic.CodigoVariableLista,
                CodigoVariable = variableListaLogic.CodigoVariable,
                Nombre = variableListaLogic.Nombre,
               Descripcion = variableListaLogic.Descripcion
            };
        }

        /// <summary>
        /// Obtiene la entidad de Campo de Variable
        /// </summary>
        /// <param name="variableCampoRequest">Request de Campo de Variable</param>
        /// <returns>Entidad de Campo de Variable</returns>
        public static VariableListaEntity ObtenerVariableListaEntity(VariableListaRequest variableListaRequest)
        {
            return new VariableListaEntity()
            {
                CodigoVariableLista = (variableListaRequest.CodigoVariableLista == null || variableListaRequest.CodigoVariableLista == "" || variableListaRequest.CodigoVariableLista == "00000000-0000-0000-0000-000000000000" ? Guid.NewGuid() : new Guid(variableListaRequest.CodigoVariableLista)),
                CodigoVariable = new Guid(variableListaRequest.CodigoVariable),
                Nombre = variableListaRequest.Nombre,
                Descripcion = variableListaRequest.Descripcion
            };
        }
    }
}
