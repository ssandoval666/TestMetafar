using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestMetafar.Models
{
    public partial class ResponseRetiro
    {
        public string NroCuenta { get; set; }

        public float MontoRetirado { get; set; }
        public float SaldoActual { get; set; }

        public DateTime FechaProceso { get; set; }
    }
}