using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pe.Stracon.SGC.Infraestructura.Proxy.OracleService;
using System.Data;
using Pe.Stracon.SGC.Infraestructura.Core.Context;

namespace Pe.Stracon.SGC.Infraestructura.Proxy.Oracle
{
    /// <summary>
    /// Proxy del servicio de Oracle
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150424 <br />
    /// Modificación:            <br />
    /// </remarks> 
    public class OracleProxy : IOracleProxy
    {
        /// <summary>
        /// Obtiene los proveedores
        /// </summary>
        /// <param name="request">Request de búsqueda</param>
        /// <returns>Lista de Proveedores</returns>
        public List<ProveedorOracleLogic> ObtenerProveedores(string request)
        {
            var responseProxy = new List<ProveedorOracleLogic>();

            ServiceSoapClient cliente = new ServiceSoapClient();

            var response = cliente.ObtenerProveedores(request);

            foreach (DataTable itemTable in response.Tables)
            {
                foreach (DataRow itemRow in itemTable.Rows)
                {
                    ProveedorOracleLogic proveedorLogic = new ProveedorOracleLogic();
                    foreach (DataColumn column in itemTable.Columns)
                    {
                        switch (column.ToString())
                        {
                            case DatosConstantes.OperacionObtenerProveedorServicioOracle.ColumnaRuc:
                                proveedorLogic.Ruc = itemRow[column].ToString();
                                break;
                            case DatosConstantes.OperacionObtenerProveedorServicioOracle.ColumnaNombre:
                                proveedorLogic.Nombre = itemRow[column].ToString();
                                break;
                        }
                    }
                    responseProxy.Add(proveedorLogic);
                }
            }
            return responseProxy;
        }
    }
}
