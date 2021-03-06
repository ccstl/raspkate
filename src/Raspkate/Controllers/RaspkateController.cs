﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Raspkate.Controllers
{
    /// <summary>
    /// Represents the base class of Raspkate controllers.
    /// </summary>
    public abstract class RaspkateController : IDisposable
    {
        /// <summary>
        /// The internal object used for locking and synchronzation.
        /// </summary>
        internal readonly object _syncObject = new object();

        ~RaspkateController()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) { }

        protected dynamic Error(object value)
        {
            return Error(HttpStatusCode.InternalServerError, value);
        }

        protected dynamic Error(HttpStatusCode httpStatusCode, object value)
        {
            return new
            {
                HttpStatusCode = httpStatusCode,
                Value = value
            };
        }
    }
}
