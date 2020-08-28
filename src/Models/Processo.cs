using System;
using System.Collections.Generic;

namespace src.Models
{
    public class Processo
    {
        public int Id { get; set; }
        public string Classe { get; set; }
        public string Area { get; set; }
        public string Assunto { get; set; }
        public DateTime DataDistribuicao { get; set; }
        public string Juiz { get; set; }
        public decimal ValorAcao { get; set; }
        public List<ParteProcesso> partesProcesso { get; set; }
        public List<MovimentoProcesso> movimentacoes  { get; set; }

    }
}