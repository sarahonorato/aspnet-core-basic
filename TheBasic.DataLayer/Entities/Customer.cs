using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheBasic.DataLayer.Entities
{
    /// <summary>
    /// Maps to a Customer.
    /// </summary>
    [Table("Customer", Schema = "dbo")]
    public class Customer
    {
        /// <summary>
        /// Customer Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Customer first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Customer last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Customer email address
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Date Inserted
        /// </summary>
        public DateTime DateInsertedUtc { get; set; }
        /// <summary>
        /// Date Modified
        /// </summary>
        public DateTime? DateModifiedUtc { get; set; }
    }
}
