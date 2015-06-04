using System;

namespace RestoBook.Common.Business.Managers
{
    public class ErrorManager : IErrorManager
    {
        #region PROPERTIES

        #endregion PROPERTIES


        #region CONSTRUCTOR

        #endregion CONSTRUCTOR


        #region PUBLIC METHODS
        /// <summary>
        /// Checks the type of encountered exception and returns a formatted exception.
        /// </summary>
        /// <param name="e">The exception to intercept.</param>
        /// <returns>A personally created exception.</returns>
        public Exception GetExceptionDetail(Exception e)
        {
            Exception outException;
            if (e is NullReferenceException)
            {
                outException = new Exception("An object was expected, but none received. Please contact your administrator.");
            }
            else if(e is ArithmeticException)
            {
                outException = new Exception("A calculation problem was encounter. Please contact your administrator.");
            }
            else if(e is ArrayTypeMismatchException)
            {
                outException = new Exception("An arraytypemismatch error was encountered. Please contact your administrator.");
            }
            else if(e is DivideByZeroException)
            {
                outException = new Exception("You've tried to divide by zero! Please contact your administrator.");
            }
            else if(e is ArithmeticException)
            {
                outException = new Exception("An ArithmeticException was encountered. Please contact your administrator.");
            }
            else if(e is IndexOutOfRangeException)
            {
                outException = new Exception("We expected more items in a list than received. Please contact your administrator.");
            }
            else if(e is InvalidCastException)
            {
                outException = new Exception("An object was received in a different form than expected. Please contact your administrator.");
            }
            else if(e is NullReferenceException)
            {
                outException = new Exception("An object was expected but a null reference was received. Please contact your administrator.");
            }
            else if(e is OutOfMemoryException)
            {
                outException = new Exception("There seems to be a memory problem. Please contact your administrator.");
            }
            else if(e is OverflowException)
            {
                outException = new Exception("An overflow exception was encountered. Please contact your administrator.");
            }
            else if (e is StackOverflowException)
            {
                outException = new Exception("A stackoverflow exception was encountered. Please contact your administrator.");
            }
            else if (e is TypeInitializationException)
            {
                outException = new Exception("A TypeInitializationException error has occured. Please contact your administrator.");
            }
            else
            {
                outException = new Exception("An unexpected error has occured. Please contact your administrator.");
            }

            return outException;
        }
        #endregion PUBLIC METHODS
    }
}
