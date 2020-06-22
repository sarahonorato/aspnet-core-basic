using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheBasic.DataLayer.Entities
{
    /// <summary>
    /// Maps to a State.
    /// </summary>
    [Table("State", Schema = "dbo")]
    public class State
    {
        /// <summary>
        /// State Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Country Id
        /// </summary>
        public int CountryId { get; set; }
    }
}
