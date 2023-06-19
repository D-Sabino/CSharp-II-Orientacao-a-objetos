using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico
{
    class Conta
    {
        public int Numero { get; set; }
        public string Titular { get; set; }
        public double Saldo { get; private set; }
        private int agencia;

        public Cliente cliente;

        public bool Saca(double valorASerSacado)
        {
            if (this.Saldo >= valorASerSacado && valorASerSacado >= 0)
            {
                if (this.cliente.EhMaiorDeIdade())
                {
                    this.Saldo -= valorASerSacado;
                    return true;
                }
                else if (valorASerSacado <= 200)
                {
                    this.Saldo -= valorASerSacado;
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public void Deposita(double valor)
        {
            this.Saldo += valor;
        }

        public void Transfere(double valor, Conta destino)
        {
            this.Saca(valor);
            destino.Deposita(valor);
        }
    }
}
