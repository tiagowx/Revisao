// See https://aka.ms/new-console-template for more information
namespace Revisao
{
  class Program
  {
    static void Main(string[] args)
    {
      Aluno[] alunos = new Aluno[5];
      var indiceAluno = 0;
      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            {
              Console.WriteLine("\nInforme o nome do aluno: ");

              Aluno aluno = new Aluno();

              aluno.Nome = Console.ReadLine();

              Console.WriteLine("\nInforme a nota do aluno: ");

              if (decimal.TryParse(Console.ReadLine(), out decimal nota))
              {
                aluno.Nota = nota;
              }
              else
              {
                throw new ArgumentException("\nO valor da nota deve ser decimal");
              }

              alunos[indiceAluno] = aluno;

              indiceAluno++;
            }
            break;
          case "2":
            {
              foreach (var a in alunos)
              {
                if (!string.IsNullOrEmpty(a.Nome))
                  Console.WriteLine($"ANUNO: {a.Nome} NOTA: {a.Nota}");
              }
            }
            break;
          case "3":
            {
              decimal notaTotal = 0;
              var nrAluno = 0;

              for (int i = 0; i < alunos.Length; i++)
              {
                if (!string.IsNullOrEmpty(alunos[i].Nome))
                {
                  notaTotal = notaTotal + alunos[i].Nota;
                  nrAluno++;
                }
              }
              var mediaGeral = notaTotal / nrAluno;

              Conceito conceitoGeral;

              if (mediaGeral < 3)
              {
                conceitoGeral = Conceito.E;
              }
              else if (mediaGeral < 4)
              {
                conceitoGeral = Conceito.D;

              }
              else if (mediaGeral < 6)
              {
                conceitoGeral = Conceito.C;

              }
              else if (mediaGeral < 8)
              {
                conceitoGeral = Conceito.B;

              }
              else
              {
                conceitoGeral = Conceito.A;

              }

                Console.WriteLine($"A média dos alunos é: {mediaGeral}");
                Console.WriteLine($"Conceito: {conceitoGeral}");
                Console.WriteLine();
            }
            break;
          default:
            throw new ArgumentOutOfRangeException("Valor digitado não é válido. Insira uma das opções listadas.");
        }
        opcaoUsuario = ObterOpcaoUsuario();
      }
    }

    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("Informa a opção desejada: \n");
      Console.WriteLine("1- Inserir novo aluno;");
      Console.WriteLine("2- Listar alunos;");
      Console.WriteLine("3- Calcular média geral; \n");
      Console.WriteLine("X- Sair; \n");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine();

      return opcaoUsuario;
    }
  }
}
