using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportadorContaMovimentacao.Scripts
{
    public class EmpresasCadastradas
    {
        public string? numEmpresa { get; set; }
        public string? nomeEmpresa { get; set; }
        public char erpSelecionado { get; set; }
    }

    public class ContasPassivas
    {
        public int numConta { get; set; }
        public string? nomeConta { get; set; }
        public string? contaAnalitica { get; set; }
    }
    public class Movimentos
    { 
        public DateTime dataMovimento { get; set; }
        public string? contaAtiva { get; set; }
        public string? contaPassiva { get; set; }
        public double valorMovimento { get; set; }
        public string? historico { get; set; }
        public string? codigoEmpresa { get; set; }
    }
}
