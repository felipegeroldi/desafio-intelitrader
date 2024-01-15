namespace Intellitrader.Desafios.MenorDistancia;

public class Program
{
    static int[] array1 = new[] { -1, 5 };
    static int[] array2 = new[] { 26, 6 };

    public static void Main(string[] args)
    {
        int menorDist = int.MaxValue;
        int menorDistPos1 = 0;
        int menorDistPos2 = 0;

        for(int i = 0; i < array1.Length; i++)
        {
            for(int j = 0; j < array2.Length; j++)
            {
                if(Math.Abs(array1[i]-array2[j]) < menorDist)
                {
                    menorDistPos1 = i;
                    menorDistPos2 = j;
                    menorDist = Math.Abs(array1[i]-array2[j]);
                }
            }
        }

        Console.WriteLine($"Menor Distancia (entre {array1[menorDistPos1]} e {array2[menorDistPos2]}): {menorDist} ");
    }
}