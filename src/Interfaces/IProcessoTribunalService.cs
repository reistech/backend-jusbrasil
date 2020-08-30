using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using src.Models;

namespace src.Interfaces
{
    public interface IProcessoTribunalService
    {
        List<Processo> BuscarProcessos(string numeroProcesso);
    }
}
