using TestMetafar.Helpers;
using TestMetafar.Models;
using CryptoHelper;

namespace TestMetafar.Services
{
    public class TarjetaService : ITarjetaService
    {
        private DataContext _context;

        public TarjetaService(DataContext context)
        {
            _context = context;
        }

        public List<Transaccion> GetOperaciones(string sNroTarjeta, int Page)
        {
            //var oObj = _context.Transaccion.Where(x => x.NroTarjeta == sNroTarjeta).ToList();

            var result = (from c in _context.Transaccion 
                          select c
              ).Skip(Page*10).Take(10).ToList();


            return result;
        }

        public ResponseGetSaldo GetSaldo(string sNroTarjeta)
        {
            ResponseGetSaldo oRta = new ResponseGetSaldo();

            var otarjeta = _context.Tarjeta.Where(x => x.NroTarjeta == sNroTarjeta).FirstOrDefault();
            if (otarjeta != null)
            {
                var ocliente = _context.Cliente.Where(x => x.ClienteId == otarjeta.ClienteId).FirstOrDefault();

                oRta = new ResponseGetSaldo
                {
                    FirstName = ocliente.FirstName,
                    LastName = ocliente.LastName,
                    NroCuenta = ocliente.NroCuenta,
                    SaldoActual = otarjeta.SaldoActual,
                    FechaUltimoMovimiento = otarjeta.FechaUltimoMovimiento
                };
            }

            return oRta;
        }

        public ResponseRetiro RetiroMonto(string sNroTarjeta, float fMonto)
        {
            ResponseRetiro oRta = null;

            var otarjeta = _context.Tarjeta.Where(x => x.NroTarjeta == sNroTarjeta).FirstOrDefault();
            if (otarjeta != null)
            {
                if (otarjeta.SaldoActual >= fMonto)
                {
                    var ocliente = _context.Cliente.Where(x => x.ClienteId == otarjeta.ClienteId).FirstOrDefault();

                    oRta = new ResponseRetiro
                    {
                        NroCuenta = ocliente.NroCuenta,
                        MontoRetirado = fMonto,
                        SaldoActual = otarjeta.SaldoActual - fMonto,
                        FechaProceso = DateTime.Now,
                    };

                    int maxId = 0;

                    if (_context.Transaccion.Count() > 0) { maxId = _context.Transaccion.Max(p => p.Id); }

                    maxId += 1;

                    Transaccion oObj = new Transaccion
                    {
                        Id = maxId,
                        NroTarjeta = otarjeta.NroTarjeta,
                        Retiro = fMonto,
                        SaldoAnterior = otarjeta.SaldoActual,
                        SaldoActual = otarjeta.SaldoActual - fMonto,
                        FechaMovimiento = DateTime.Now,
                    };

                    _context.Transaccion.Add(oObj);

                    otarjeta.SaldoActual = otarjeta.SaldoActual - fMonto;
                    otarjeta.FechaUltimoMovimiento = oObj.FechaMovimiento;


                    _context.SaveChanges();
                }



            }

            return oRta;
        }

        public bool ValidarTarjeta(string NroTarjeta, string Pin)
        {
            var otarjeta = _context.Tarjeta.Where(x => x.NroTarjeta == NroTarjeta).FirstOrDefault();
            if (otarjeta != null)
            {
                var IsOK = Crypto.VerifyHashedPassword(otarjeta.Pin, Pin);

                if (!IsOK)
                {
                    otarjeta.CantIntentos++;
                }

                if (otarjeta.CantIntentos > 4)
                {
                    return false;
                }

                return IsOK;
            }
            else
                return false;

        }
    }
}
