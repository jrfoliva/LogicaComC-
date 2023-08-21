using System.Globalization;
using System.Net.Security;

namespace ExercRevisaoRepeticao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("### Exercícios de Revisão - Estruturas de repetições ###\n\n");

                //Menu de exercícios
                Console.WriteLine("Exercício 1 - Leia um valor inteiro X (1 <= X <= 1000). Em seguida mostre os ímpares de 1 até X, um valor por linha, inclusive o\r\nX, se for o caso.\n");
                Console.WriteLine("Exercício 2 - Leia um valor inteiro N. Este valor será a quantidade de valores inteiros X que serão lidos em seguida.\r\nMostre quantos destes valores X estão dentro do intervalo [10,20] e quantos estão fora do intervalo, mostrando\r\nessas informações conforme exemplo (use a palavra \"in\" para dentro do intervalo, e \"out\" para fora do intervalo).\n");
                Console.WriteLine("Exercício 3 - Leia 1 valor inteiro N, que representa o número de casos de teste que vem a seguir. Cada caso de teste consiste de 3 valores reais, cada um deles com uma casa decimal. Apresente a média ponderada para cada um destes conjuntos de 3 valores, sendo que o primeiro valor tem peso 2, o segundo valor tem peso 3 e o terceiro valor tem peso 5.\n");
                Console.WriteLine("Exercício 4 - Fazer um programa para ler um número N. Depois leia N pares de números e mostre a divisão do primeiro pelo segundo. Se o denominador for igual a zero, mostrar a mensagem divisao impossivel.\n");
                Console.WriteLine("Exercício 5 - Ler um valor N. Calcular e escrever seu respectivo fatorial. Fatorial de N = N * (N-1) * (N-2) * (N-3) * ... * 1.\r\nLembrando que, por definição, fatorial de 0 é 1.\n");
                Console.WriteLine("Exercício 6 - Ler um número inteiro N e calcular todos os seus divisores.\n");
                Console.WriteLine("Exercício 7 - Fazer um programa para ler um número inteiro positivo N. O programa deve então mostrar na tela N linhas,\r\ncomeçando de 1 até N. Para cada linha, mostrar o número da linha, depois o quadrado e o cubo do valor, conforme\r\nexemplo.\n");
                Console.WriteLine("Escolha o exercício ou 0 P/ sair.");
                Console.Write("Informe o número do exercício: ");

                byte resp;
                try
                {
                    resp = byte.Parse(Console.ReadLine());
                }
                catch
                {
                    resp = 0;
                }

                bool sair = false;
                switch (resp)
                {
                    case 0:
                        Console.Write("Sair do sistema? (S/N) : ");
                        if (Console.ReadLine().ToUpper() == "S")
                            sair = true;
                        break;
                    case 1:
                        MostreImparesDoIntervalo();
                        break;
                    case 2:
                        MostreNumDentroForaIntervalo();
                        break;
                    case 3:
                        CalculeMediaPonderada();
                        break;
                    case 4:
                        CalculeDivisaoDoisNumeros();
                        break;
                    case 5:
                        CalculeFatorial();
                        break;
                    case 6:
                        VerificaDivisores();
                        break;
                    case 7:
                        ImprimeQuadradoCubo();
                        break;
                }
                
                if (sair)
                    break;
            }
        }

        private static void ImprimeQuadradoCubo()
        {
            Console.Clear();
            Console.Write("Informe a quantidade de linha para a impressão: ");
            int linha = int.Parse(Console.ReadLine());
            if (linha < 1)
            {
                Console.WriteLine("O Número precisa ser maior que zero!");
                Console.ReadLine();
                return;
            }
            
            for(int i = 1; i<=linha; i++)
                Console.WriteLine($"{i} {Math.Pow(i, 2)} {Math.Pow(i, 3)}");
            Console.ReadLine();
        }

        private static void VerificaDivisores()
        {
            Console.Clear();
            Console.Write("Informe o número para a verificação dos divisores: ");
            int n = int.Parse(Console.ReadLine());
            int aux = 1;
            Console.WriteLine("Divisores ...");
            while (aux <= n ) 
            {
                if(n % aux == 0)
                    Console.WriteLine(aux);
                aux++;
            }
            Console.ReadLine();
        }

        private static void CalculeFatorial()
        {
            Console.Clear();
            Console.Write("Calcular o fatorial de? : ");
            int n = int.Parse(Console.ReadLine());
            int fat = 1;
            for (int i = 1; i <= n; i++)
                fat *= i;

            Console.WriteLine($"O Valor Fatorial de {n} é: {fat}");
            Console.ReadLine();
        }

        private static void CalculeDivisaoDoisNumeros()
        {
            Console.Clear();
            Console.Write("Informe a quantidade de pares de números a serem lidos: ");
            int tam = int.Parse(Console.ReadLine());
            for (int i = 0; i < tam; i++)
            {
                Console.Write($"Informe o #{i + 1} par de valores: ");
                string[] line = Console.ReadLine().Split(' ');
                if (double.Parse(line[0]) == 0)
                    Console.WriteLine("Divisão impossível!");
                double resultado = double.Parse(line[0]) / double.Parse(line[1]);
                Console.WriteLine(resultado.ToString("F1", CultureInfo.InvariantCulture));
                Console.ReadLine();
            }
        }

        private static void CalculeMediaPonderada()
        {
            Console.Clear();
            Console.Write("Informe o número de casos de testes: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Teste #{i + 1}: ");
                string[] line = Console.ReadLine().Split(' ');
                double a = double.Parse(line[0], CultureInfo.InvariantCulture);
                double b = double.Parse(line[1], CultureInfo.InvariantCulture);
                double c = double.Parse(line[2], CultureInfo.InvariantCulture);

                double media = (a * 2.0 + b * 3.0 + c * 5.0) / 10;

                Console.WriteLine(media.ToString("F1", CultureInfo.InvariantCulture));
                Console.ReadLine();
            }
        }

        private static void MostreNumDentroForaIntervalo()
        {
            Console.Clear();
            Console.Write("Quantos números inteiros deseja informar? :");
            byte tam = byte.Parse(Console.ReadLine());
            int[] vet = new int[tam];

            for (int i = 0; i < vet.Length; i++)
            {
                Console.Write($"Informe o #{i + 1}: ");
                vet[i] = int.Parse(Console.ReadLine());
            }

            int _in = 0;
            int _out = 0;
            for (int i = 0; i < vet.Length; i++)
            {
                if (vet[i] >= 10 && vet[i] <= 20)
                    _in++;
                else
                    _out++;
            }
            Console.WriteLine("No intervalo entre [10..20] temos ...");
            Console.WriteLine(_in + " in");
            Console.WriteLine(_out + " out");
            Console.ReadLine();
        }

        private static void MostreImparesDoIntervalo()
        {
            Console.Clear();
            Console.Write("Informe um número no intervalo entre 1 a 1000 : ");
            int x = int.Parse(Console.ReadLine());
            if (x < 1 || x > 1000)
            {
                Console.WriteLine("Número inválido!");
                Console.ReadLine();
                return;
            }

            for (int i = 1; i <= x; i++)
            {
                if (i % 2 != 0)
                    Console.WriteLine("Número Ímpar: " + i);
            }

            Console.ReadLine();
        }
    }
}
