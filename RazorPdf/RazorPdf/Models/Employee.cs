namespace RazorPdf.Models
{
    /// <summary>
    /// Represents employee.
    /// </summary>
    public class Employee
    {
        #region [ Properties ]

        /// <summary>
        /// Unique identifier.
        /// </summary>
        public int Id
        {
            get; 
            set;
        }


        /// <summary>
        /// Name of the employee
        /// </summary>
        public string Name
        {
            get; 
            set;
        }


        /// <summary>
        /// Employee's email.
        /// </summary>
        public string Email
        {
            get; 
            set;
        }

        #endregion
    }
}