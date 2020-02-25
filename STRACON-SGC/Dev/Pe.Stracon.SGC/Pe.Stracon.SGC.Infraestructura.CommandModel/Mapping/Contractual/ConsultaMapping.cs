using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Mapping.Contractual
{
    /// <summary>
    /// Implementación del mapeo de la entidad Consulta
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150527 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ConsultaMapping : BaseEntityMapping<ConsultaEntity>
    {
        public ConsultaMapping()
            :base()
        {
            HasKey(x => x.CodigoConsulta).ToTable("CONSULTA", "CTR");
            Property(u => u.CodigoConsulta).HasColumnName("CODIGO_CONSULTA");
            Property(u => u.CodigoRemitente).HasColumnName("CODIGO_REMITENTE");
            Property(u => u.CodigoDestinatario).HasColumnName("CODIGO_DESTINATARIO");
            Property(u => u.Tipo).HasColumnName("TIPO");
            Property(u => u.Asunto).HasColumnName("ASUNTO");
            Property(u => u.Contenido).HasColumnName("CONTENIDO");
            Property(u => u.EstadoConsulta).HasColumnName("ESTADO_CONSULTA");
            Property(u => u.FechaEnvio).HasColumnName("FECHA_ENVIO");
            Property(u => u.Respuesta).HasColumnName("RESPUESTA");
            Property(u => u.FechaRespuesta).HasColumnName("FECHA_RESPUESTA");
            Property(u => u.CodigoUnidadOperativa).HasColumnName("CODIGO_UNIDAD_OPERATIVA");
            Property(u => u.CodigoArea).HasColumnName("CODIGO_AREA");
            Property(u => u.EsValido).HasColumnName("ES_VALIDO");
            Property(u => u.CodigoConsultaRelacionado).HasColumnName("CODIGO_CONSULTA_RELACIONADO");
            Property(u => u.CodigoConsultaOriginal).HasColumnName("CODIGO_CONSULTA_ORIGINAL");
            Property(u => u.VistoRemitenteOriginal).HasColumnName("VISTO_REMITENTE_ORIGINAL");
            Property(u => u.EstadoRegistro).HasColumnName("ESTADO_REGISTRO");
            Property(u => u.UsuarioCreacion).HasColumnName("USUARIO_CREACION");
            Property(u => u.FechaCreacion).HasColumnName("FECHA_CREACION");
            Property(u => u.TerminalCreacion).HasColumnName("TERMINAL_CREACION");
            Property(u => u.UsuarioModificacion).HasColumnName("USUARIO_MODIFICACION");
            Property(u => u.FechaModificacion).HasColumnName("FECHA_MODIFICACION");
            Property(u => u.TerminalModificacion).HasColumnName("TERMINAL_MODIFICACION");
        }
    }
}
