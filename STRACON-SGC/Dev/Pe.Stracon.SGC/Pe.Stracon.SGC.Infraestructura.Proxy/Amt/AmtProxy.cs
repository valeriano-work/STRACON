using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Proxy.AmtService;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pe.Stracon.SGC.Infraestructura.Proxy.Amt
{
    /// <summary>
    /// Proxy del servicio AMT
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20170628 <br />
    /// Modificación:            <br />
    /// </remarks> 
    public class AmtProxy : IAmtProxy
    {
        /// <summary>
        /// Obtener los equipos de ATM
        /// </summary>
        /// <returns>Lista de equipos</returns>
        public List<BienLogic> ObtenerEquipos()
        {
            List<BienLogic> equipos = new List<BienLogic>();

            EquipmentSoapClient equipmentService = new EquipmentSoapClient();

            var equiposXml = equipmentService.ExportEquipment(string.Empty, string.Empty);

            XDocument document = XDocument.Parse(equiposXml);

            IEnumerable<XElement> listaEquipos = from equipo in document.Elements("I_EQUIPMENTs").Elements("I_EQUIPMENT")                                         
                                                 select equipo;

            foreach (var item in listaEquipos)
            {
                BienLogic bien = new BienLogic();
                bien.Marca = item.Element("Manufacturer").Value;
                bien.Modelo = item.Element("Model").Value;
                bien.NumeroSerie = item.Element("Serial_No").Value;
                bien.CodigoIdentificacion = item.Element("Equip_Name").Value;
                bien.Descripcion = item.Element("Equip_Description").Value;
                bien.FechaAdquisicion = DateTime.ParseExact(item.Element("Start_Date").Value, "yyyyMMdd", CultureInfo.InvariantCulture);

                equipos.Add(bien);
            }

            return equipos;
        }
    }
}
