using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestMetafar.Models
{
    public partial class ResponseGetSaldo
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string NroCuenta { get; set; }
        public float SaldoActual { get; set; }
        public DateTime FechaUltimoMovimiento { get; set; }
    }
}