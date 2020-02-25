using System;
namespace Pe.GyM.Security.Account.Model
{
    /// <summary>
    /// Objecto que representa un control de una vista
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319
    /// Modificación:   
    /// </remarks>
    [Serializable]
    public class Control
    {
        /// <summary>
        /// Código   
        /// </summary>
        public string Codigo { get; set; }
           
        /// <summary>
        /// Texto de etiqueta
        /// </summary>   
        public string Texto { get; set; }         
          
        /// <summary>
        /// Indicador de Lectura
        /// </summary>
        public bool Lectura { get; set; }             
           
        /// <summary> 
        /// Indicador de Escritura
        /// </summary>
        public bool Escritura { get; set; }            
             
        /// <summary>  
        /// Indicador de Control Total
        /// </summary>
        public bool ControlTotal { get; set; }       

    } 
} 
