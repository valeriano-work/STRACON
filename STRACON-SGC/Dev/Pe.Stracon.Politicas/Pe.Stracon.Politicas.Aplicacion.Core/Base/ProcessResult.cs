using Pe.Stracon.PoliticasCross.Core.Base;


namespace Pe.Stracon.Politicas.Aplicacion.Core.Base
{
    /// <summary>
    /// Respuesta unica de los procesos de la capa de aplicación
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ProcessResult<T> where T : class
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public ProcessResult()
        {
            this.IsSuccess = true;

        }
        /// <summary>
        /// Indicador del estado de la operación
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Exceción generada en caso de error
        /// </summary>
        public IGenericException Exception { get; set; }
        /// <summary>
        /// Resultado del proceso
        /// </summary>
        public T Result { get; set; }
    }
}
