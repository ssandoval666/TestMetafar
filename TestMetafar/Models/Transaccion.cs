using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestMetafar.Models
{
        public partial class Transaccion
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

        public string NroTarjeta { get; set; }

        public float SaldoAnterior { get; set; }

        public float Retiro { get; set; }

        public float SaldoActual { get; set; }
        
        public DateTime FechaMovimiento { get; set; }
    }
    }