using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecPuntatoDef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dPuntato= new int[4];
            // Richiede all'utente di inserire 4 numeri decimali puntati
            for (int i=0;i<dPuntato.Length;i++)
            {
                Console.WriteLine($"Inserisci {i+1} numero");
                dPuntato[i] = Convert.ToInt32(Console.ReadLine());
            }
            bool[]Bin=Convert_Dp_toBin(dPuntato);
            for (int i=0;i<Bin.Length;i++)
            {
                Console.WriteLine(Convert.ToInt32(Bin[i]));
            }
            //chiamata metodi nel main
            Console.WriteLine(Convert_dp_toIntero(dPuntato));
            Console.WriteLine(Convert_Bin_toIntero(Bin));
            Console.WriteLine(Convert_Bin_toDec(Bin));


            Console.ReadLine();
        }
        static bool[] Convert_Dp_toBin(int[] decimalePuntato) //primo metodo
        {
            bool[] binario = new bool[32]; // Array booleano binario
            int j = binario.Length - 1; // Variabile j inizializzata all'ultimo indice dell'array

            // Itera su ciascun elemento dell'array decimalePuntato
            for (int i = 0; i < decimalePuntato.Length; i++)
            {
                int numero = decimalePuntato[i];

                // Itera per ottenere gli 8 bit dell'elemento corrente
                for (int z = 0; z < 8; z++)
                {
                    // Assegna il bit corrente in base al resto della divisione per 2
                    binario[j] = numero % 2 == 1;

                    // Dividi il numero per 2
                    numero = numero / 2; 
                    j--;
                }
            }

            return binario;
        }

        static int Convert_dp_toIntero(int[]decimalePuntato) //secondo metodo
        {
            int numeroDecimale = 0;
            int j = 3; // Inizializza j a 3, poiché stai convertendo un numero con 4 parti decimali
            // Itera su ciascuna parte decimale dell'array decimalePuntato
            for (int i=0;i<decimalePuntato.Length;i++)
            {
                // Moltiplica la parte decimale per 256 elevato alla potenza di j
                numeroDecimale += decimalePuntato[i] * (int)Math.Pow(256, j--); 
            }
            return numeroDecimale; // Restituisce il numero intero convertito
        }
        static int Convert_Bin_toIntero(bool[] binario) //terzo metodo
        {
            int numeroIntero = 0;
            int indice = binario.Length - 1; // Inizializza l'indice all'ultimo bit dell'array
            for (int i=0;i<binario.Length;i++) 
            {
                if (binario[i]) // Verifica se il bit corrente è true (1)
                {
                    // Aggiungi 2 elevato alla potenza dell'indice corrente al numeroIntero
                    numeroIntero += (int)Math.Pow(2, indice);
                }
                
                indice--; // Decrementa l'indice per considerare il bit successivo
            }
            return numeroIntero; //valore restituito
        }
        static int Convert_Bin_toDec(bool[] binario) //quarto metodo
        {
            int dex = 0;
            
            for (int i=0;i<binario.Length;i++) // Itera su ciascun bit dell'array binario
            {
                // Verifica se il bit corrente è true (1)
                if (binario[i])
                {
                    dex += (int)Math.Pow(2, binario.Length - 1 - i); // Aggiunge 2 elevato alla potenza dell'indice corrente al valore decimale
                }
            }
            return dex; //valore restituito
            

        }

    }
}
