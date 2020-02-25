using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.Adapter.Contractual
{
    /// <summary>
    /// Implementación del Adaptador de Contrato Párrafo Variable
    /// </summary>
    public class ContratoParrafoVariableAdapter
    {
        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Contrato Párrafo Variable con los datos a registrar</returns>
        public static ContratoParrafoVariableEntity RegistrarContratoParrafoVariable(ContratoParrafoVariableRequest data)
        {
            var contratoParrafoVariableEntity = new ContratoParrafoVariableEntity();
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = ".";
            numberFormatInfo.NumberGroupSeparator = ",";

            if (data.CodigoContratoParrafoVariable != null)
            {
                contratoParrafoVariableEntity.CodigoContratoParrafoVariable = new Guid(data.CodigoContratoParrafoVariable.ToString());
            }
            else
            {
                Guid code;
                code = Guid.NewGuid();
                contratoParrafoVariableEntity.CodigoContratoParrafoVariable = code;
            }

            contratoParrafoVariableEntity.CodigoContratoParrafo = new Guid(data.CodigoContratoParrafo);
            contratoParrafoVariableEntity.CodigoVariable = new Guid(data.CodigoVariable);
            contratoParrafoVariableEntity.ValorTexto = data.ValorTexto;
            if (!string.IsNullOrWhiteSpace(data.ValorNumeroString))
            {
                contratoParrafoVariableEntity.ValorNumero = Decimal.Parse(data.ValorNumeroString, numberFormatInfo);
            }

            if (!string.IsNullOrWhiteSpace(data.ValorFechaString))
            {
                contratoParrafoVariableEntity.ValorFecha = DateTime.ParseExact(data.ValorFechaString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture);
            }

            contratoParrafoVariableEntity.ValorImagen = data.ValorImagen;
            contratoParrafoVariableEntity.ValorTabla = data.ValorTabla;
            contratoParrafoVariableEntity.ValorTablaEditable = data.ValorTablaEditable;
            contratoParrafoVariableEntity.ValorBien = data.ValorBien;
            contratoParrafoVariableEntity.ValorBienEditable = data.ValorBienEditable;
            contratoParrafoVariableEntity.ValorFirmante = data.ValorFirmante;
            contratoParrafoVariableEntity.ValorFirmanteEditable = data.ValorFirmanteEditable;
            contratoParrafoVariableEntity.ValorLista = !string.IsNullOrEmpty(data.ValorLista) ? (Guid?)new Guid(data.ValorLista) : null;
            contratoParrafoVariableEntity.FechaCreacion = DateTime.Now;

            return contratoParrafoVariableEntity;
        }
    }
}
