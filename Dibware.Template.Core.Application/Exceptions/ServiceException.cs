using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dibware.Template.Core.Application.Exceptions
{
    public class ServiceException : ApplicationException
    {
        #region Private Members

        private String _errorMessage;

        #endregion

        #region Public Properties

        public override String Message
        {
            get
            {
                return this._errorMessage;
            }
        }

        #endregion

        #region Construct

        public ServiceException(String errorMessage)
        {
            this._errorMessage = errorMessage;
        }

        #endregion
    }
}