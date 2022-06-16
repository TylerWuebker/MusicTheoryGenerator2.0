using MusicTheoryGenerator2._0;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

class Program
{
    static void Main(string[] args)
    {
        bool cont = true;

        while (cont)
        {
            cont = Menu();
        }
    }


    public static bool Menu()
    {
        var MKS = new MusicalKeyService();
        bool cont = true;

        Console.WriteLine("**************************************");
        Console.WriteLine("Welcome to the Music Theory Generator 2.0!");
        Console.WriteLine("This program randomly generates musical sequences\n" +
                          "based off a selected key.\n" +
                          "It then generates a code and automatically copies that code\n" +
                          "as well as opens up a virtual piano where you can paste the\n" +
                          "code, press play, and enjoy!");
        Console.WriteLine("Here are a few options to get started!\n" +
                          "Generate a random:");
        Console.WriteLine("1) Note sequence");
        Console.WriteLine("2) Chord progression");
        Console.WriteLine("3) ADMIN - Generate Json");
        Console.WriteLine("-99 to exit");

        try
        {
            int select = int.Parse(Console.ReadLine());
            string sequence = "";

            switch (select)
            {
                case 1: //Note Sequence
                    sequence = MKS.GenerateNoteSequence();
                    Console.WriteLine("Here is your generated note sequence: \n" + sequence);
                    break;
                case 2: //Chord Progression
                    sequence = MKS.GenerateChordProgression();
                    Console.WriteLine("Here is your generated chord progression: \n" + sequence);
                    break;
                case 3:
                    MKS.GenerateJson();
                    Console.WriteLine("JSON File Completed!");
                    break;
                case -99:
                    return false;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("\nInvalid Input try again\n " + e.ToString());
            return true;
        }

        return cont;
    }
}