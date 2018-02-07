using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalho_ATP_Teorico
{
    /*
     Curso de Sistemas perido noturno primeiro semestre
     Trabalho final de Algoritimos e Tecnicas de Programação Teorico (LocaMais)
     Professora: Ivre
     Dupla: Thiago Moraes e Breno Vieira */

    class Program
    {
        public static void CadastroCliente()             
        {
            string nome, endereço;
            int codcliente;
            double telefone;
            FileStream arq = new FileStream("Cadastro Cliente.txt", FileMode.Append);
            StreamWriter escreve = new StreamWriter(arq);
            Console.WriteLine("Digite o nome do cliente:");
            nome = Console.ReadLine();
            Console.WriteLine("Digite o endereço do cliete:");
            endereço = Console.ReadLine();
            Console.WriteLine("Digite o telefone do cliente:");
            telefone = double.Parse(Console.ReadLine());
            Random rdn = new Random();
            codcliente = rdn.Next(0, 99999999);
            escreve.WriteLine(nome + "|" + codcliente + "|" + endereço + "|" + telefone + ".");
            escreve.Close();
            Console.Clear();

        }
        public static void Cadastrofuncionario()        
        {
            string nome, cargo;
            int codfuncionario;
            double salario, telefone;
            FileStream arq1 = new FileStream("Cadastro Funcionario.txt", FileMode.Append);
            StreamWriter escreve = new StreamWriter(arq1);
            Console.WriteLine("Digite o nome do funcionario:");
            nome = Console.ReadLine();
            Console.WriteLine("Digite o telefone do funcionario:");
            telefone = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite o cargo do funcionario:");
            cargo = Console.ReadLine();
            Console.WriteLine("Digite o salario do funcionario:");
            salario = double.Parse(Console.ReadLine());
            Random rdn = new Random();
            codfuncionario = rdn.Next(0, 99999999);
            escreve.WriteLine(nome + "|" + codfuncionario + "|" + cargo + "|" + salario + "|" + telefone + ".");
            escreve.Close();
            Console.Clear();

        }
        public static void CadastroVeiculo()            
        {
            string modelo, cor, placa, descriçao, status;
            double valordia;
            int qtdeocupantes, codveiculo;
            FileStream arq3 = new FileStream("Cadastro Veiculo.txt", FileMode.Append);
            StreamWriter escreve = new StreamWriter(arq3);
            Console.WriteLine("Digite o modelo do veiculo:");
            modelo = Console.ReadLine();
            Console.WriteLine("Digite a cor do veiculo:");
            cor = Console.ReadLine();
            Console.WriteLine("Digite a placa do veiculo:");
            placa = Console.ReadLine();
            Console.WriteLine("Descreva o veiculo:");
            descriçao = Console.ReadLine();
            Console.WriteLine("Qual o valor da diaria do veiculo em reais?");
            valordia = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite a quantidade de ocupantes que cabem no veiculo:");
            qtdeocupantes = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o status do veiculo:");
            status = Console.ReadLine();
            Random rdn = new Random();
            codveiculo = rdn.Next(0, 99999999);
            escreve.WriteLine(codveiculo + "|" + modelo + "|" + cor + "|" + placa + "|" + qtdeocupantes + "|" + valordia + "|" + status + "|" + descriçao + ".");
            escreve.Close();
            Console.Clear();

        }

        public static string Dataretirada()             
        {
            string vet;
            Console.WriteLine("Digite a data da RETIRADA do veiculo, no formato DD/MM/AAAA:");
            vet = Console.ReadLine();
            return vet;
        }
        public static string Datadevoluçao()
        {
            string vet2;
            Console.WriteLine("Digite a data da DEVOLUÇÃO veiculo, no formato DD/MM/AAAA:");
            vet2 = Console.ReadLine();
            return vet2;

        }         
        public static void CadastroLocação()            
        {
            int qtdeocupantes;
            double codcliente, codveiculo, codlocação;
            string seguro;
            FileStream arq4 = new FileStream("Cadastro locação.txt", FileMode.Append);
            StreamWriter escreve = new StreamWriter(arq4);
            FileStream arq5 = new FileStream("Cadastro Cliente.txt", FileMode.Open);
            StreamReader ler = new StreamReader(arq5);

            string[] cliente;
            string nomecliente;
            Console.WriteLine("Contando com o motorista deseja um veiculo que caiba quantos passageiros?");
            qtdeocupantes = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o nome do cliente que deseja alugar um veiculo:");
            nomecliente = Console.ReadLine();
            Console.Write("\n");
            string linha;
            do
            {
                linha = ler.ReadLine();
                if (linha != null)
                {
                    cliente = linha.Split('|');
                    if (cliente[0] == nomecliente)
                    {
                        Console.Write("\n");
                        Console.WriteLine(linha);
                        Console.Write("\n");
                    }
                }

            } while (linha != null);
            ler.Close();
            string modveiculo;
            Console.WriteLine("Digite o codigo do cliente:");
            codcliente = int.Parse(Console.ReadLine());
            FileStream arq7 = new FileStream("Cadastro Veiculo.txt", FileMode.Open);
            StreamReader leri = new StreamReader(arq7);
            string lin;
            string[] veiculo;
            Console.WriteLine("Digite o modelo do veiculo que tem interresse:");
            modveiculo = Console.ReadLine();
            Console.Write("\n");
            do
            {
                lin = leri.ReadLine();

                if (lin != null)
                {
                    veiculo = lin.Split('|');

                    if (veiculo[1] == modveiculo)
                    {
                        if (int.Parse(veiculo[4]) >= qtdeocupantes)
                        {
                            if (veiculo[6] == "Disponivel")
                            {
                                Console.Write("\n");
                                Console.WriteLine(lin);
                                Console.Write("\n");
                            }
                            if (veiculo[6] == "Alugado")
                            {
                                Console.WriteLine("Todos os veiculos com essa quantidade de lugares estão Alugados.");
                            }
                        }
                        if (int.Parse(veiculo[4]) < qtdeocupantes)
                        {
                            Console.WriteLine("A quantidade de lugares nesse veiculo é menor do que a que você necessita.\n");
                            Console.WriteLine("Digite o modelo do veiculo que tem interresse:");
                            modveiculo = Console.ReadLine();
                            if (veiculo[6] == "Disponivel")
                            {
                                Console.Write("\n");
                                Console.WriteLine(lin);
                                Console.Write("\n");
                            }
                            if (veiculo[6] == "Alugado")
                            {
                                Console.WriteLine("Todos os veiculos com essa quantidade de lugares estão Alugados.");
                            }

                        }
                    }
                }
            } while (lin != null);
            leri.Close();
            double valordia13;
            Console.WriteLine("Digite o codigo do veiculo que está sendo locado:");
            codveiculo = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor da diaria do veiculo:");
            valordia13 = double.Parse(Console.ReadLine());
            leri.Close();
            Console.WriteLine("Deseja que tenha seguro ?");
            seguro = Console.ReadLine().ToUpper();
            Random rdn = new Random();
            codlocação = rdn.Next(0, 99999999);
            string datadev, dataret;
            dataret = Dataretirada();
            datadev = Datadevoluçao();

            escreve.WriteLine(codlocação + "|" + dataret + "|" + datadev + "|" + codcliente + "|" + codveiculo + "|" + qtdeocupantes + "|" + seguro + "|" + valordia13);

            escreve.Close();
            string[] gads = File.ReadAllLines("Cadastro Veiculo.txt");
            string[] vetorzin;
            string ajudavetorzin = "";
            for (int g = 0; g < gads.Length; g++)
            {
                string[] limi = gads[g].Split('|');
                if (int.Parse(limi[0]) == codveiculo)
                {
                    ajudavetorzin = gads[g];

                }

            }
            vetorzin = ajudavetorzin.Split('|');
            StreamReader aa = new StreamReader("Cadastro Veiculo.txt");
            StringBuilder bb = new StringBuilder();
            while (!aa.EndOfStream)
            {
                string a = aa.ReadLine();
                if (a.IndexOf(ajudavetorzin) > -1)
                {
                    a = a.Replace(ajudavetorzin, vetorzin[0] + "|" + vetorzin[1] + "|" + vetorzin[2] + "|" + vetorzin[3] + "|" + vetorzin[4] + "|" + vetorzin[5] + "|" + "Alugado" + "|" + vetorzin[7]);
                }
                bb.AppendLine(a);
            }
            aa.Close();
            StreamWriter cc = new StreamWriter("Cadastro Veiculo.txt ");
            cc.Write(bb);
            cc.Close();
            Console.Clear();
        }
        public static void Pesquisa()
        {
            int escolha;

            do
            {
                Console.WriteLine("Deseja pesquisar o que:\n1- Cliente.\n2- Veiculo.\n3- Funcionario.\n4- Locação.\n5- Creditos Fidelidade\n6- Cancelar");
                escolha = int.Parse(Console.ReadLine());
                if (escolha == 1)
                {
                    FileStream arq1 = new FileStream("Cadastro Cliente.txt", FileMode.Open);
                    StreamReader ler = new StreamReader(arq1);
                    string[] cliente;
                    string nomecliente;
                    Console.WriteLine("Digite o nome do cliente que deseja:");
                    nomecliente = Console.ReadLine();
                    Console.Write("\n");
                    string linha;
                    do
                    {
                        linha = ler.ReadLine();
                        if (linha != null)
                        {
                            cliente = linha.Split('|');
                            if (cliente[0] == nomecliente)
                            {
                                Console.Clear();
                                Console.Write("\n");
                                Console.WriteLine("Nome |Codigo |Endereço |Numero de Contato");
                                Console.WriteLine(linha);
                                Console.Write("\n");
                            }
                        }

                    } while (linha != null);
                    ler.Close();

                }
                if (escolha == 2)
                {
                    FileStream arq3 = new FileStream("Cadastro Veiculo.txt", FileMode.Open);
                    StreamReader ler = new StreamReader(arq3);
                    string[] veiculo;
                    string linha;
                    double codigoveiculo;
                    Console.WriteLine("Digite o codigo do veiculo que deseja pesquisar:");
                    codigoveiculo = int.Parse(Console.ReadLine());
                    Console.Write("\n");
                    do
                    {

                        linha = ler.ReadLine();
                        if (linha != null)
                        {
                            veiculo = linha.Split('|');
                            if (Convert.ToInt32(veiculo[0]) == (codigoveiculo))
                            {
                                Console.Clear();
                                Console.Write("\n");
                                Console.WriteLine("Codigo | Modelo | Cor | Placa|Qtde Lugares|Preço dia| Status |Descrição");
                                Console.WriteLine(linha);
                                Console.Write("\n");
                            }
                        }
                    } while (linha != null);

                }
                if (escolha == 3)
                {
                    FileStream arq2 = new FileStream("Cadastro Funcionario.txt", FileMode.Open);
                    StreamReader ler = new StreamReader(arq2);
                    string[] funcionario;
                    string linha;
                    double codigofuncionario;
                    Console.WriteLine("Digite o codigo do funcionario que deseja pesquisar:");
                    codigofuncionario = double.Parse(Console.ReadLine());
                    do
                    {
                        linha = ler.ReadLine();
                        if (linha != null)
                        {
                            funcionario = linha.Split('|');
                            if (Convert.ToInt32(funcionario[1]) == (codigofuncionario))
                            {
                                Console.Clear();
                                Console.Write("\n");
                                Console.WriteLine("Nome | Codigo | Cargo | Salario |Numero de contato");
                                Console.Write(linha);
                                Console.Write("\n");
                            }
                        }
                    } while (linha != null);
                }
                if (escolha == 4)
                {
                    FileStream arq4 = new FileStream("Cadastro locação.txt", FileMode.Open);
                    StreamReader ler = new StreamReader(arq4);
                    string[] locaçao;
                    string linha;
                    double codigolocação;
                    Console.Write("\n");
                    Console.WriteLine("Digite o codigo da locação que deseja pesquisar:");
                    codigolocação = double.Parse(Console.ReadLine());
                    Console.Write("\n");
                    do
                    {

                        linha = ler.ReadLine();
                        if (linha != null)
                        {
                            locaçao = linha.Split('|');
                            if (Convert.ToInt32(locaçao[0]) == (codigolocação))
                            {
                                Console.Clear();
                                Console.Write("\n");
                                Console.WriteLine("Codigo |Data Retirada| Data Devolução|Codigo Cliente|Codigo Funcionario|Qtde Lugares| Seguro |Preço Dia");
                                Console.Write(linha);
                                Console.WriteLine("\n");
                            }

                        }
                    } while (linha != null);
                }
                if (escolha == 5)
                {
                    PontosFidelidade();
                }

            } while (escolha > 0 && escolha < 6);

        }
        public static void PontosFidelidade()
        {
            string nha, name;
            int f = 0, d, s = 0;
            FileStream arq21 = new FileStream("Pontos Fidelidade.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(arq21);
            FileStream fs = new FileStream("Baixa Locação.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            Console.WriteLine("Digite o nome do cliente:");
            name = Console.ReadLine();
            Console.Clear();
            string[] pesfi;
            do
            {
                nha = sr.ReadLine();
                if (nha != null)
                {
                    pesfi = nha.Split('|');
                    if (pesfi[0] == name)
                    {
                        d = int.Parse(pesfi[3]);
                        f = 10 * d;
                        s = s + f;
                    }

                }
            } while (nha != null);
            sr.Close();
            sw.WriteLine(name + "-" + s);
            sw.Close();
            Console.WriteLine("A quantidade de pontos que o(a) cliente "+ name +" tem é:\n"+name + " - " + s + " pontos");
            Console.Write("\n");

        }
        public static void BaixaLocaçao()
        {
            FileStream arq13 = new FileStream("Cadastro Cliente.txt", FileMode.Open);
            StreamReader ler88 = new StreamReader(arq13);
            FileStream arq22 = new FileStream("Baixa Locação.txt", FileMode.Append);
            StreamWriter esc = new StreamWriter(arq22);
            string[] cliente;
            string nomecliente;
            Console.WriteLine("Digite o nome do cliente que deseja dar baixa em um veiculo:");
            nomecliente = Console.ReadLine();
            Console.Write("\n");
            string linha;
            do
            {
                linha = ler88.ReadLine();
                if (linha != null)
                {
                    cliente = linha.Split('|');
                    if (cliente[0] == nomecliente)
                    {
                        Console.Clear();
                        Console.Write("\n");
                        Console.WriteLine(linha);
                        Console.Write("\n");
                    }
                }

            } while (linha != null);
            ler88.Close();
            FileStream arq14 = new FileStream("Cadastro locação.txt", FileMode.Open);
            StreamReader ler14 = new StreamReader(arq14);
            double codclientebaixa, codlocaçaobaixa;
            Console.WriteLine("Digite o codigo do cliente:");
            codclientebaixa = double.Parse(Console.ReadLine());
            Console.Write("\n");
            string l;
            string[] locaçao;
            do
            {
                l = ler14.ReadLine();
                if (l != null)
                {
                    locaçao = l.Split('|');
                    if (double.Parse(locaçao[3]) == codclientebaixa)
                    {
                        Console.Clear();
                        Console.Write("\n");
                        Console.WriteLine("Codigo |Data Retirada| Data Devolução|Codigo Cliente|Codigo Veiculo|Qtde Lugares| Seguro |Preço Dia");
                        Console.WriteLine(l);
                        Console.Write("\n");
                    }
                }

            } while (l != null);
            Console.WriteLine("Digite o codigo da locação que desejar dar baixa:");
            codlocaçaobaixa = double.Parse(Console.ReadLine());
            ler14.Close();
            int qtdedia = 0, diaret, diadev, mesret, mesdev, anoret, anodev, diadevdev, mesdevdev, anodevdev;
            Console.WriteLine("Digite o DIA em que o veiculo foi LOCADO:");
            diaret = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o número do MES em que o veiculo foi LOCADO:");
            mesret = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o ANO em que o veiculo foi LOCADO:");
            anoret = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o DIA em que o veiculo DEVERIA ser DEVOLVIDO:");
            diadevdev = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o número do MES em que o veiculo DEVERIA ser DEVOLVIDO:");
            mesdevdev = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o ANO em que o veiculo DEVERIA ser DEVOLVIDO:");
            anodevdev = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o DIA em que o veiculo está sendo DEVOLVIDO:");
            diadev = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o número do MES em que o veiculo está sendo DEVOLVIDO:");
            mesdev = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o ANO em que o veiculo está sendo DEVOVIDO:");
            anodev = int.Parse(Console.ReadLine());
            if (mesdevdev == mesret && anodevdev == anoret)
            {
                qtdedia = (diadevdev - diaret) + 1;
            }
            else if (mesdevdev != mesret && anodevdev == anoret)
            {
                if (mesret == 01)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = (31 + (diadevdev - diaret)) + 1;
                    }
                    else
                    {
                        qtdedia = ((diaret - diadevdev - 31) * 1) + 1;
                    }
                }
                if (mesret == 02)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = (28 + (diadevdev - diaret)) + 1;
                    }
                    else
                    {
                        qtdedia = ((diaret - diadevdev - 28) * 1) + 1;
                    }
                }
                if (mesret == 03)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = (31 + (diadevdev - diaret)) + 1;
                    }
                    else
                    {
                        qtdedia = ((diaret - diadevdev - 31) * 1) + 1;
                    }
                }
                if (mesret == 04)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = (30 + (diadevdev - diaret)) + 1;
                    }
                    else
                    {
                        qtdedia = ((diaret - diadevdev - 30) * 1) + 1;
                    }
                }
                if (mesret == 05)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = (31 + (diadevdev - diaret)) + 1;
                    }
                    else
                    {
                        qtdedia = ((diaret - diadevdev - 31) * 1) + 1;
                    }
                }
                if (mesret == 06)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = (30 + (diadevdev - diaret)) + 1;
                    }
                    else
                    {
                        qtdedia = ((diaret - diadevdev - 30) * 1) + 1;
                    }
                }
                if (mesret == 07)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = (31 + (diadevdev - diaret)) + 1;
                    }
                    else
                    {
                        qtdedia = ((diaret - diadevdev - 31) * 1) + 1;
                    }
                }
                if (mesret == 08)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = (31 + (diadevdev - diaret)) + 1;
                    }
                    else
                    {
                        qtdedia = ((diaret - diadevdev - 31) * 1) + 1;
                    }
                }
                if (mesret == 09)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = (30 + (diadevdev - diaret)) + 1;
                    }
                    else
                    {
                        qtdedia = ((diaret - diadevdev - 30) * 1) + 1;
                    }
                }
                if (mesret == 10)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = (31 + (diadevdev - diaret)) + 1;
                    }
                    else
                    {
                        qtdedia = ((diaret - diadevdev - 31) * 1) + 1;
                    }
                }
                if (mesret == 11)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = (30 + (diadevdev - diaret)) + 1;
                    }
                    else
                    {
                        qtdedia = ((diaret - diadevdev - 30) * 1) + 1;
                    }
                }
                if (mesret == 12)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = (31 + (diadevdev - diaret)) + 1;
                    }
                    else
                    {
                        qtdedia = ((diaret - diadevdev - 31) * 1) + 1;
                    }
                }
            }
            else if (mesdevdev == mesret && anodevdev != anoret)
            {
                qtdedia = ((diadevdev - diaret) + ((anodevdev - anoret) * 365)) + 1;

            }
            else
            {
                if (mesret == 01)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = ((31 + (diadevdev - diaret)) + ((anodevdev - anoret) * 365)) + 1;
                    }
                    else
                    {
                        qtdedia = (((diaret - diadevdev - 31) * -1) + ((anodevdev - anoret) * 365)) + 1;
                    }
                }
                if (mesret == 02)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = ((28 + (diadevdev - diaret)) + ((anodevdev - anoret) * 365)) + 1;
                    }
                    else
                    {
                        qtdedia = (((diaret - diadevdev - 28) * -1) + ((anodevdev - anoret) * 365)) + 1;
                    }
                }
                if (mesret == 03)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = ((31 + (diadevdev - diaret)) + ((anodevdev - anoret) * 365)) + 1;
                    }
                    else
                    {
                        qtdedia = (((diaret - diadevdev - 31) * -1) + ((anodevdev - anoret) * 365)) + 1;
                    }
                }
                if (mesret == 04)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = ((30 + (diadevdev - diaret)) + ((anodevdev - anoret) * 365)) + 1;
                    }
                    else
                    {
                        qtdedia = (((diaret - diadevdev - 30) * -1) + ((anodevdev - anoret) * 365)) + 1;
                    }
                }
                if (mesret == 05)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = ((31 + (diadevdev - diaret)) + ((anodevdev - anoret) * 365)) + 1;
                    }
                    else
                    {
                        qtdedia = (((diaret - diadevdev - 31) * -1) + ((anodevdev - anoret) * 365)) + 1;
                    }
                }
                if (mesret == 06)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = ((30 + (diadevdev - diaret)) + ((anodevdev - anoret) * 365)) + 1;
                    }
                    else
                    {
                        qtdedia = (((diaret - diadevdev - 30) * -1) + ((anodevdev - anoret) * 365)) + 1;
                    }
                }
                if (mesret == 07)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = ((31 + (diadevdev - diaret)) + ((anodevdev - anoret) * 365)) + 1;
                    }
                    else
                    {
                        qtdedia = (((diaret - diadevdev - 31) * -1) + ((anodevdev - anoret) * 365)) + 1;
                    }
                }
                if (mesret == 08)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = ((31 + (diadevdev - diaret)) + ((anodevdev - anoret) * 365)) + 1;
                    }
                    else
                    {
                        qtdedia = (((diaret - diadevdev - 31) * -1) + ((anodevdev - anoret) * 365)) + 1;
                    }
                }
                if (mesret == 09)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = ((30 + (diadevdev - diaret)) + ((anodevdev - anoret) * 365)) + 1;
                    }
                    else
                    {
                        qtdedia = (((diaret - diadevdev - 30) * -1) + ((anodevdev - anoret) * 365)) + 1;
                    }
                }
                if (mesret == 10)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = ((31 + (diadevdev - diaret)) + ((anodevdev - anoret) * 365)) + 1;
                    }
                    else
                    {
                        qtdedia = (((diaret - diadevdev - 31) * -1) + ((anodevdev - anoret) * 365)) + 1;
                    }
                }
                if (mesret == 11)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = ((30 + (diadevdev - diaret)) + ((anodevdev - anoret) * 365)) + 1;
                    }
                    else
                    {
                        qtdedia = (((diaret - diadevdev - 30) * -1) + ((anodevdev - anoret) * 365)) + 1;
                    }
                }
                if (mesret == 12)
                {
                    if (diadevdev >= diaret)
                    {
                        qtdedia = ((31 + (diadevdev - diaret)) + ((anodevdev - anoret) * 365)) + 1;
                    }
                    else
                    {
                        qtdedia = (((diaret - diadevdev - 31) * -1) + ((anodevdev - anoret) * 365)) + 1;
                    }
                }
            }
            double valoraserpago = 0, vd;
            Console.WriteLine("Digite o valor da diaria do veiculo:");
            vd = double.Parse(Console.ReadLine());
            if (diadevdev == diadev && mesdevdev == mesdev && anodevdev == anodev)
            {
                valoraserpago = qtdedia * vd;
            }
            else if (diadevdev != diadev && mesdevdev == mesdev && anodevdev == anodev)
            {
                valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * (diadev - diadevdev));
            }
            else if (diadevdev != diadev && mesdevdev != mesdev && anodevdev == anodev)
            {
                if (mesret == 01)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 31));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 31) * -1));

                    }
                }
                if (mesret == 02)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 28));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 28) * -1));

                    }
                }

                if (mesret == 03)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 31));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 31) * -1));

                    }
                }
                if (mesret == 04)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 30));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 30) * -1));

                    }
                }
                if (mesret == 05)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 31));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 31) * -1));

                    }
                }
                if (mesret == 06)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 30));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 30) * -1));

                    }
                }
                if (mesret == 07)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 31));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 31) * -1));

                    }
                }
                if (mesret == 08)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 31));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 31) * -1));

                    }
                }
                if (mesret == 09)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 30));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 30) * -1));

                    }
                }
                if (mesret == 10)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 31));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 31) * -1));

                    }
                }
                if (mesret == 11)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 30));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 30) * -1));

                    }
                }
                if (mesret == 12)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 31));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 31) * -1));

                    }
                }
            }
            else if (diadevdev == diadev && mesdevdev != mesdev && anodevdev == anodev)
            {
                if (mesret == 01)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * 31);

                    }
                }
                if (mesret == 02)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * +28);

                    }
                }

                if (mesret == 03)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * 31);

                    }
                }
                if (mesret == 04)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * 30);

                    }
                }
                if (mesret == 05)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * 31);

                    }
                }
                if (mesret == 06)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * 30);

                    }
                }
                if (mesret == 07)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * 31);

                    }
                }
                if (mesret == 08)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * 31);

                    }
                }
                if (mesret == 09)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * 30);

                    }
                }
                if (mesret == 10)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * 31);

                    }
                }
                if (mesret == 11)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * 30);

                    }
                }
                if (mesret == 12)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * 31);

                    }
                }
            }
            else
            {
                if (mesret == 01)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 31)) + (365 * (anodev - anodevdev));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 31) * -1)) + (365 * (anodev - anodevdev));

                    }
                }
                if (mesret == 02)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 28)) + (365 * (anodev - anodevdev));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 28) * -1)) + (365 * (anodev - anodevdev));

                    }
                }

                if (mesret == 03)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 31)) + (365 * (anodev - anodevdev));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 31) * -1)) + (365 * (anodev - anodevdev));

                    }
                }
                if (mesret == 04)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 30)) + (365 * (anodev - anodevdev));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 30) * -1)) + (365 * (anodev - anodevdev));

                    }
                }
                if (mesret == 05)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 31)) + (365 * (anodev - anodevdev));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 31) * -1)) + (365 * (anodev - anodevdev));

                    }
                }
                if (mesret == 06)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 30)) + (365 * (anodev - anodevdev));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 30) * -1)) + (365 * (anodev - anodevdev));

                    }
                }
                if (mesret == 07)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 31)) + (365 * (anodev - anodevdev));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 31) * -1)) + (365 * (anodev - anodevdev));

                    }
                }
                if (mesret == 08)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 31)) + (365 * (anodev - anodevdev));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 31) * -1)) + (365 * (anodev - anodevdev));

                    }
                }
                if (mesret == 09)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 30)) + (365 * (anodev - anodevdev));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 30) * -1)) + (365 * (anodev - anodevdev));

                    }
                }
                if (mesret == 10)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 31)) + (365 * (anodev - anodevdev));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 31) * -1)) + (365 * (anodev - anodevdev));

                    }
                }
                if (mesret == 11)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 30)) + (365 * (anodev - anodevdev));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 30) * -1)) + (365 * (anodev - anodevdev));

                    }
                }
                if (mesret == 12)
                {
                    if (diadevdev >= diaret)
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadev - diadevdev) + 31)) + (365 * (anodev - anodevdev));

                    }
                    else
                    {
                        valoraserpago = ((qtdedia * vd) * 5 / 100) + (20 * ((diadevdev - diadev - 31) * -1)) + (365 * (anodev - anodevdev));

                    }
                }
            }
            string seguro;
            Console.WriteLine("A locação foi feita com seguro? Sim ou Não?");
            seguro = Console.ReadLine().ToUpper();
            if(seguro=="SIM")
            {
                valoraserpago = valoraserpago + 50;
            }
            double vdddia=qtdedia, vddvalor=valoraserpago;
            if (qtdedia < 0)
            {
                vdddia = qtdedia * -1;
            }
            if(valoraserpago<0)
            {
                vddvalor = valoraserpago * -1;

            }
            esc.WriteLine(nomecliente + "|" + codlocaçaobaixa + "|" + "R$" + vd + "|" + vdddia + "|" + seguro +"|"+ "R$" + vddvalor);
            esc.Close();
            string[] ttt = File.ReadAllLines("Cadastro locação.txt");
            string help = "";
            double codveiculo;
            Console.WriteLine("Digite o codigo do veiculo que está sendo devolvido:");
            codveiculo = double.Parse(Console.ReadLine());
            for (int v = 0; v < ttt.Length; v++)
            {
                string[] dem = ttt[v].Split('|');
                if (int.Parse(dem[0]) == codlocaçaobaixa)
                {
                    help = ttt[v];

                }

            }
            StreamReader dd = new StreamReader("Cadastro locação.txt");
            StringBuilder ee = new StringBuilder();
            while (!dd.EndOfStream)
            {
                string d = dd.ReadLine();
                if (d.IndexOf(help) == -1)
                {
                    ee.AppendLine(d);
                }
            }
            dd.Close();
            StreamWriter ff = new StreamWriter("Cadastro locação.txt ");
            ff.Write(ee);
            ff.Close();
            string[] tacm = File.ReadAllLines("Cadastro Veiculo.txt");
            string[] z;
            string hr = "";
            for (int j = 0; j < tacm.Length; j++)
            {
                string[] camaro = tacm[j].Split('|');
                if (int.Parse(camaro[0]) == codveiculo)
                {
                    hr = tacm[j];

                }

            }
            z = hr.Split('|');
            StreamReader pp = new StreamReader("Cadastro Veiculo.txt");
            StringBuilder oo = new StringBuilder();
            while (!pp.EndOfStream)
            {
                string p = pp.ReadLine();
                if (p.IndexOf(hr) > -1)
                {
                    p = p.Replace(hr, z[0] + "|" + z[1] + "|" + z[2] + "|" + z[3] + "|" + z[4] + "|" + z[5] + "|" + "Disponivel" + "|" + z[7]);
                }
                oo.AppendLine(p);
            }
            pp.Close();
            StreamWriter uu = new StreamWriter("Cadastro Veiculo.txt ");
            uu.Write(oo);
            uu.Close();
            Console.Clear();

        }

        static void Main(string[] args)
        {
            int horas;
            Console.WriteLine("Bem vindo!\nPor favor, informe quantas horas são, digite somente as horas, não é necessario os minutos:");
            horas = int.Parse(Console.ReadLine());

            Console.Clear();
            int op, escolha2;

            do
            {
                Console.WriteLine("Escolha uma opção:\n1- Para Cadastros.\n2- Para Fazer uma Locação.\n3- Para Pesquisar.\n4- Para Fazer baixa em uma Locação.\n5- Para Sair");
                op = int.Parse(Console.ReadLine());
                Console.Clear();
                if (op == 1)
                {
                    do
                    {
                        Console.WriteLine("Deseja cadastrar:\n1- Cliente.\n2- Funcionario.\n3- Veiculo.\n4- Para cancelar");
                        escolha2 = int.Parse(Console.ReadLine());
                        Console.Clear();
                        if (escolha2 == 1)
                        {
                            CadastroCliente();
                            Console.WriteLine("Cadastro de Cliente feito com sucesso.");
                            Console.Write("\n");
                        }
                        if (escolha2 == 2)
                        {
                            Cadastrofuncionario();
                            Console.WriteLine("Cadastro de funcionario feito com sucesso.");
                            Console.Write("\n");

                        }
                        if (escolha2 == 3)
                        {
                            CadastroVeiculo();
                            Console.WriteLine("Cadastro de veiculo feito com sucesso.");
                            Console.Write("\n");

                        }

                    } while (escolha2 < 4);
                }

                if (op == 2)
                {
                    if (horas >= 8 && horas < 18)
                    {
                        CadastroLocação();
                        Console.WriteLine("Cadastro de locação feita com sucesso.");
                        Console.Write("\n");
                    }
                    else
                    {
                        Console.WriteLine("\nFora do horario de funcionamento desta parte do programa.\n");
                    }

                }
                if (op == 3)
                {
                    Pesquisa();
                }
                if (op == 4)
                {
                    BaixaLocaçao();               
                }
            } while (op > 0 && op < 5);
            if (op > 4)
            {
                Console.WriteLine("Tecle enter para fechar o programa.");
            }
            Console.ReadKey();
        }

    }
}
