using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2
{
    //Dessa vez usei a interface de usuário apenas como processos de entrada e saída e deixei a lógica para o controlador
    public class InterfaceUsuario
    {
        public void Inicio()
        {
            Console.WriteLine("Bem-vindo ao conversor de moedas!");
            Console.WriteLine("Digite a moeda de origem e de destino com 3 caracteres com letra maiúscula! (Para terminar, apenas aperte ENTER na moeda de origem)\n\n");
            this.Conversor();
        }

        public bool Conversor()
        {
            Form form = new Form();
            FormValidator validador = new FormValidator();
            bool isValid;

            form.lerDados();

            do
            {
                //Verifica a validade dos dados recebidos pelo usuário
                isValid = validador.isValid(form.MoedaOrigem, form.MoedaDestino, form.Valor);

                if (isValid)
                {
                    Moeda moeda = null;
                    moeda = Controlador.chamarAPI(validador.url.Url);

                    if (moeda != null)
                    {
                        if (moeda.rate == null || moeda.result == null || moeda.result <= 0)
                            Console.WriteLine("ERRO: Problema de conversão!");
                        else
                        {
                            Console.WriteLine();

                            Console.WriteLine(validador.url.moedaOrigem + " " + validador.url.amount.formatar(2) + " => " +
                                validador.url.moedaDestino + " " + moeda.result.formatar(2));
                            Console.WriteLine("Taxa: " + moeda.rate.formatar(6));

                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nERRO: Problema de conexão com a API!\n");
                    }

                }

                //Caso dados sejam inválidos, lê novamente
                else form.lerDados(validador);

            } while (!isValid);


            return true;
        }
    }
}
