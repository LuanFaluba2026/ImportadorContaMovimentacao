namespace ImportadorContaMovimentacao.Scripts
{
    public class EmpresasCadastradas
    {
        public string? numEmpresa { get; set; }
        public string? nomeEmpresa { get; set; }
        public char erpSelecionado { get; set; }
    }

    public class Conta
    {
        public string? numConta { get; set; }

        // S - Conta Sintética. A - Conta Analítica.
        public string? tipo { get; set; }
        public string? nomeConta { get; set; }
        public string? contaAnalitica { get; set; }
    }
    public class Fornecedor
    {
        public long ID { get; set; }
        public string? cnpj { get; set; }
        public string? nome { get; set; }
        public string? contaCredito { get; set; }
        public string? contaDebito { get; set; }
    }
    public class Movimento
    {
        public DateTime dataMovimento { get; set; }
        public string? contaDebito { get; set; }
        public string? descricaoDebito { get; set; }
        public string? contaCredito { get; set; }
        public string? descricaoCredito { get; set; }
        public double valorMovimento { get; set; }
        public string? historico { get; set; }
        public string? codigoEmpresa { get; set; }

        public string? fornecedor { get; set; }
        public string? cnpj { get; set; }
    }
}
