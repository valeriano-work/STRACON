using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Proxy.SAPProvService;
using Pe.Stracon.SGC.Infraestructura.Proxy.SAPBienService;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


namespace Pe.Stracon.SGC.Infraestructura.Proxy.SAP
{
    /// <summary>
    /// Proxy del servicio de SAP
    /// </summary>
    /// <remarks>
    /// Creación: Qualis-Tech : 12/12/2018  <br />
    /// </remarks> 
    public class SAPProxy : ISAPProxy
    {
      
        /// <summary>
        /// Obtiene los proveedores
        /// </summary>
        /// <param name="request">Request de búsqueda</param>
        /// <returns>Lista de Proveedores</returns>

        public List<ProveedorSAPLogic> ZSGC_OBTPROVEEDORES(string request)
        {



            List<ProveedorSAPLogic> Proveedores = new List<ProveedorSAPLogic>();

            ZWS_ZSGC_OBTPROVEEDORESClient get_SAPProveedor = new ZWS_ZSGC_OBTPROVEEDORESClient();

            get_SAPProveedor.ClientCredentials.UserName.UserName = "STRACON";
            get_SAPProveedor.ClientCredentials.UserName.Password = "seidor2018";

            var get_SAPProveedor_Input = new ZSGC_OBTPROVEEDORES();

            Int64 Num;
            bool isNum = Int64.TryParse(request.ToString(), out Num);

            if (isNum)               
              {
                get_SAPProveedor_Input.I_BP =  request.ToString() ;
              }
            else
              {
                get_SAPProveedor_Input.I_BP = "*" + request.ToString() + "*";
              }

          

            var get_SAPProveedor_Response = new ZSGC_OBTPROVEEDORESResponse();

            get_SAPProveedor_Response = get_SAPProveedor.ZSGC_OBTPROVEEDORES(get_SAPProveedor_Input);

            foreach (var item in get_SAPProveedor_Response.E_PROVEEDOR)
            {
                ProveedorSAPLogic proveedor = new ProveedorSAPLogic();
                proveedor.Ruc = item.IDENT_FISCAL.ToString();
                proveedor.Nombre = item.NOMBRE_BP.ToString();
                Proveedores.Add(proveedor);
            }

            return Proveedores;
        }

        /// <summary>
        /// Obtener los equipos de SAP
        /// </summary>
        /// <returns>Lista de equipos</returns>
        public List<BienLogic> ObtenerEquipos()
        {
            DateTime fromDateValue;

            List<BienLogic> equipos = new List<BienLogic>();

            ZWS_ZETM_DATOS_EQUIPOSClient get_SAPBien = new ZWS_ZETM_DATOS_EQUIPOSClient();
         
            get_SAPBien.ClientCredentials.UserName.UserName = "STRACON";
            get_SAPBien.ClientCredentials.UserName.Password = "seidor2018";

            var get_SAPBien_Input = new ZETM_DATOS_EQUIPOS();
            
            get_SAPBien_Input.I_MARCA_DESC = "*";

            var get_SAPBien_Response = new ZETM_DATOS_EQUIPOSResponse();

            get_SAPBien_Response = get_SAPBien.ZETM_DATOS_EQUIPOS(get_SAPBien_Input);

            foreach (var item in get_SAPBien_Response.T_RESULTADO)
            {
                BienLogic bien = new BienLogic();
                bien.Marca = item.HERST.ToString();
                bien.Modelo = item.TYPBZ.ToString();
                bien.NumeroSerie = item.SERGE.ToString();
                bien.CodigoIdentificacion = item.TIDNR.ToString();
                bien.Descripcion = item.EQKTX.ToString();

                var formats = new[] { "dd/MM/yyyy", "yyyy-MM-dd" };
                if (DateTime.TryParseExact(item.ANSDT, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out fromDateValue))
                {
                    bien.FechaAdquisicion = DateTime.ParseExact(item.ANSDT, "yyyyMMdd", CultureInfo.InvariantCulture);
                }
             
                equipos.Add(bien);
            }                    
            return equipos;
        }
    }
}

