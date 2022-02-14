using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestructura.Exceptions
{
    [Serializable]
    public class ExceptionFuncional : BaseException
    {
        #region Constructors
        /// <summary>
        /// Constructor default.
        /// </summary>
        public ExceptionFuncional()
            : base()
        {
            // Add implementation.
        }

        /// <summary>
        /// Inicializa una nueva instancia de la excepción con un mensaje de error específico.
        /// </summary>
        /// <param name="message">Mensaje de error.</param>
        public ExceptionFuncional(string message)
            : base(message)
        {
            // Add implementation.
        }

        /// <summary>
        /// Inicializa una nueva instancia de la excepción con un mensaje de error específico
        /// y una inner exception (excepción anidada).
        /// </summary>
        /// <param name="message">Mensaje de error.</param>
        /// <param name="inner">Excepción interna que es la cause de ésta excepción.</param>
        public ExceptionFuncional(string message, Exception inner)
            : base(message, inner)
        {
            // Add implementation.
        }
        #endregion Constructors
    }
}
    