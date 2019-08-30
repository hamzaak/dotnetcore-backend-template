using Ponente.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ponente.Entity.Concrete
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [NotMapped]
        public bool Remember { get; set; }
    }
}
