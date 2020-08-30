using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Interfaces;
using src.Models;
using src.ViewModel;

namespace src.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessoTribunalController : Controller
    {
        private readonly IProcessoTribunalService processoTribunalService;

        /// <summary>
        /// Método constructor do processo tribunal controller que receber como parametro um processo tribunal service
        /// </summary>
        /// <param name="processoTribunalService"></param>
        public ProcessoTribunalController( IProcessoTribunalService processoTribunalService)
        {
            this.processoTribunalService = processoTribunalService;
        }

        /// <summary>
        ///  Buscar todos os processos nos Tribunais de TJAL e TJMS 
        ///  <param name="numeroProcesso"></param>
        /// </summary>
        [HttpGet("ObterProcessoTribunal/{numeroProcesso}")]
        public ActionResult Get(string numeroProcesso )
        {
            if (numeroProcesso == "" || numeroProcesso == null)
            {
                return BadRequest(new Response() { Result = false, Message = "Requisição inválida" });
            }

            Processo result = this.processoTribunalService.ObterProcessoTribunal(numeroProcesso);

            return Ok(new Response() { Data = result, Result = true });

        }
    }
}
