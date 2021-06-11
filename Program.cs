using System;

namespace Prova7_CatalinaDorneanu
{
    class Program
    {
        static void Main(string[] args)
        {
            //------------RISPOSTE-------------
            //1.c
            //2.b
            //3.d
            //---------------------------------

            Console.WriteLine("--- Utenti ---");
            do
            {
                Console.WriteLine("\n------ Menu ------");
                Console.WriteLine("Premi 1 - Visualizza tutti gli utenti"); // ho inserito questa scelta per vedere che utenti avevo già inserito per poterne scegliere uno che non c'è
                Console.WriteLine("Premi 2 - Verifica se l'utente esiste");
                Console.WriteLine("Premi 0 - Exit");

                int scelta;
                do
                {
                    Console.Write("\nFai la tua scelta: ");
                } while (!int.TryParse(Console.ReadLine(), out scelta));

                switch (scelta)
                {
                    case 1:
                        DbConnectedMode.GetAll();
                        break;
                    case 2:
                        DbConnectedMode.GetUsername();
                        break;
                    case 0:
                        return;
                }
            } while (true);
        }
    }
}
