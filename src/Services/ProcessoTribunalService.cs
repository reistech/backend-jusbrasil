using System;
using System.Collections.Generic;
using src.Interfaces;
using src.Models;

namespace src.Services
{
    public class ProcessoTribunalService : IProcessoTribunalService
    {
        public Processo ObterProcessoTribunal(string numeroProcesso)
        {
            return new Processo();
        }
    }
}
