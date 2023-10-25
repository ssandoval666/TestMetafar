using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestMetafar.Models
{
    public class Tarjeta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

        ///<Summary>
        /// Nombre de Usuario
        ///</Summary>
        ///
        public string NroTarjeta { get; set; }

        ///<Summary>
        /// Contraseña
        ///</Summary>
        ///
        public string Pin { get; set; }

        public float SaldoActual { get; set; }

        public int CantIntentos { get; set; }
        
        public int ClienteId { get; set; }

        public DateTime FechaUltimoMovimiento { get; set; }

        ///<Summary>
        /// Fecha de Creacion
        ///</Summary>
        ///
        public DateTime CreatedDate { get; set; }
    }
}
