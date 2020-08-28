using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using src.Interfaces;
using src.Models;

namespace src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessoTribunalController
    {
        private readonly IProcessoTribunalService _processoTribunalService;

        /// <summary>
        /// Método constructor do processo tribunal controller que receber como parametro um processo tribunal service
        /// </summary>
        /// <param name="processoTribunalService"></param>
        public ProcessoTribunalController( IProcessoTribunalService processoTribunalService)
        {
            _processoTribunalService = processoTribunalService;
        }

        /// <summary>
        ///  Buscar todos os processos nos Tribunais de TJAL e TJMS 
        ///
        /// </summary>
        [HttpGet]
        public List<Processo>  Get ()
        {

            return   new List<Processo>();

        }
    }
}
