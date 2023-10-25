using TestMetafar.Models;
using TestMetafar.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TestMetafar.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CuentasController : ControllerBase
    {
        ///<Summary>
        /// Parametros de configuracion
        ///</Summary>
        ///
        public IConfiguration _configuration;
        private ITarjetaService _TarjetaService;

        ///<Summary>
        /// Creacion de Instancia con parametos de configuracion
        ///</Summary>
        ///
        public CuentasController(IConfiguration config, ITarjetaService oService)
        {
            _TarjetaService = oService;
            _configuration = config;
        }

        [HttpGet("GetSaldo")]
        [Authorize]
        public ResponseGetSaldo GetSaldo(string sNroTarjeta)
        {
            return _TarjetaService.GetSaldo(sNroTarjeta);
        }
        
        /// <summary>  
        /// Envio de Notificaciones JWT Token Authentication  
        /// </summary>  
        [HttpPost("Retiro")]
        [Authorize]
#pragma warning disable 1998
        public async Task<IActionResult> Retiro(string sNroTarjeta, float fMonto)
        {

            var oRta = _TarjetaService.RetiroMonto(sNroTarjeta, fMonto);

            if (oRta == null)
            {
                return BadRequest("Monto insuficiente para la operacion");
            }
            else
            {
                return Ok(oRta);
            }
        }

        [HttpGet("GetTransacciones")]
        [Authorize]
#pragma warning disable 1998
        public async Task<IActionResult> GetTransacciones(string sNroTarjeta, int Page)
        {

            var oRta = _TarjetaService.GetOperaciones(sNroTarjeta, Page);

            if (oRta.Count == 0)
            {
                return BadRequest("No hay Transacciones disponibles");
            }
            else
            {
                return Ok(oRta);
            }
        }
    }
}