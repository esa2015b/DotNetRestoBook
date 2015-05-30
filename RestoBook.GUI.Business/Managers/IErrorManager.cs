using System;

namespace RestoBook.Common.Business.Managers
{
    public interface IErrorManager
    {
        /// <summary>
        /// Checks the type of encountered exception and returns a formatted exception.
        /// </summary>
        /// <param name="e">The exception to intercept.</param>
        /// <returns>A personally created exception.</returns>
        Exception GetExceptionDetail(Exception e);
    }
}
