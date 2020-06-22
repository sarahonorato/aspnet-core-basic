using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheBasic.DataLayer.Entities
{
    /// <summary>
    /// Maps to a Country.
    /// </summary>
    [Table("Country", Schema = "dbo")]
    public class Country
    {
        /// <summary>
        /// Country Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Abbreviation
        /// </summary>
        public string Abbreviation { get; set; }
    }
}
