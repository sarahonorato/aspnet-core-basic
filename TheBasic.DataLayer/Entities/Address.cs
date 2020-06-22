using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheBasic.DataLayer.Entities
{
    /// <summary>
    /// Maps to a Address.
    /// </summary>
    [Table("Address", Schema = "dbo")]
    public class Address
    {
        /// <summary>
        /// Address Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// The customer id
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// The Address line one
        /// </summary>
        public string AddressOne { get; set; }
        /// <summary>
        /// The Address line two
        /// </summary>
        public string AddressTwo { get; set; }
        /// <summary>
        /// The City
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// The state id
        /// </summary>
        public int StateId { get; set; }
        /// <summary>
        /// The country id
        /// </summary>
        public int CountryId { get; set; }
        /// <summary>
        /// The ZIP code
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// The flag that indicates if the address is active or not
        /// </summary>
        public string IsActive { get; set; }
        /// <summary>
        /// Date Inserted
        /// </summary>
        public DateTime DateInsertedUtc { get; set; }
        /// <summary>
        /// Date Modified
        /// </summary>
        public DateTime? DateModifiedUtc { get; set; }
        /// <summary>
        /// The alias
        /// </summary>
        public string Alias { get; set; }
    }
}
