using System.ComponentModel.DataAnnotations.Schema;

namespace Restaraunt.RestarauntSystem.DAL.Entities
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
    }
}
