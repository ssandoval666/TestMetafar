using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestMetafar.Models
{
        public partial class Cliente
    {

        ///<Summary>
        /// Id de usuario
        ///</Summary>
        ///
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int ClienteId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }        

        public string Email { get; set; }

        public string NroCuenta { get; set; }

        public DateTime CreatedDate { get; set; }
    }
    }