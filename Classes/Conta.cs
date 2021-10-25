using System;
namespace bancocsharp
{
    public class Conta
    {

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;

        }
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }
        private readonly double valorSaque;

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;
            Console.WriteLine($"Saldo atual da conta é de {this.Nome} é {this.Saldo}");
            return true;
        }
        public void Depositar(double valorDeposito)
        {
            if (valorDeposito > 0)
            {
                this.Saldo += valorDeposito;
                Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
            }
            else
            {
                Console.WriteLine("Depósito inválido");
            }
        }

        public void Transferir (double valorTransferencia, Conta contaDestino)
        {   
             if (this.Sacar(valorTransferencia))
             {
                contaDestino.Depositar(valorTransferencia);
             }
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | " ;
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
            return retorno;
        }

 
  }
}