using System;
using System.Collections.Generic;
using src.Interfaces;
using src.Models;

namespace src.Services
{
    
    public class ProcessoTribunalService : IProcessoTribunalService
    {
        const string urlTribunalAlagoas1grau = "https://www2.tjal.jus.br/cpopg/open.do";
        const string urlTribunalAlagoas2grau = "https://www2.tjal.jus.br/cposg5/open.do";
        const string urlTribunalMatoGrossoSul1grau = "https://esaj.tjms.jus.br/cpopg5/open.do";
        const string urlTribunalMatoGrossoSul2grau = "https://esaj.tjms.jus.br/cposg5/open.do";


        public Processo ObterProcessoTribunal(string numeroProcesso)
        {
            //padrão numero Processo


            //Consulta em cada grau


            //Chamada do crawller
            return new Processo();
        }
    }
}
