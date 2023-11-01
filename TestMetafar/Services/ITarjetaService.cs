using TestMetafar.Models;

namespace TestMetafar.Services
{
    public interface ITarjetaService
    {
        bool ValidarTarjeta(string NroTarjeta, string Pin);
        ResponseGetSaldo GetSaldo(string sNroTarjeta);
        List<Transaccion> GetOperaciones(string sNroTarjeta, int Page);
        ResponseRetiro RetiroMonto(string sNroTarjeta, float fMonto);
    }
}
