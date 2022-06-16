using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTheoryGenerator2._0
{
    public interface IMusicalKeyService
    {
        string GenerateNoteSequence();
        string GenerateChordProgression();
        string RandomNoteMeasureGenerator(Key keyToGenerateFrom);
        string SelectKeyMenu();
        void PrettyWrite(object obj, string fileName);
        Key JsonReadAndSearch(string keySelection);
        void GenerateJson();
    }
    public class MusicalKeyService : IMusicalKeyService
    {


        private static readonly JsonSerializerSettings _options
        = new() { NullValueHandling = NullValueHandling.Ignore };
        private static readonly string path = "\\VisualStuidoProjects\\MusicTheoryGenerator2.0\\MusicTheoryGenerator2.0\\Keys.json";

        public string GenerateNoteSequence()
        {
            var select = SelectKeyMenu();
            var foundKey = JsonReadAndSearch(select);

            return RandomNoteMeasureGenerator(foundKey);
        }

        public string GenerateChordProgression()
        {
            var sequence = "";
            var select = SelectKeyMenu();
            var foundKey = JsonReadAndSearch(select);

            return sequence;
        }

        public string RandomNoteMeasureGenerator(Key keyToGenerateFrom)//Do I want to make the arr[4] for sub measure here? or up a level?
        {
            string generatedSequence = "";
            string measure = "";

            string[] keyArr = new string[10]
            {
                keyToGenerateFrom.N1,
                keyToGenerateFrom.N2,
                keyToGenerateFrom.N3,
                keyToGenerateFrom.N4,
                keyToGenerateFrom.N5,
                keyToGenerateFrom.N6,
                keyToGenerateFrom.N7,
                " ", " ", " "
            };

            Random rand = new Random();

            for (var i = 0; i <= 12; i++)
            {
                generatedSequence += measure;
                measure = "";

                for(var k = 0; k <= 4; k++)
                {
                    measure += keyArr[rand.Next(10)];
                }
            }

            return generatedSequence;
        }

        public string SelectKeyMenu()
        {
            Console.WriteLine("Select a key to generate from:");
            Console.WriteLine("		1.) C             8.) C#");
            Console.WriteLine("		2.) D             9.) D#");
            Console.WriteLine("		3.) E             ");
            Console.WriteLine("		4.) F            10.) F#");
            Console.WriteLine("		5.) G            11.) G#");
            Console.WriteLine("		6.) A            12.) A#");
            Console.WriteLine("		7.) B             ");

            try
            {
                int select = int.Parse(Console.ReadLine());
                string sequence = "";
                switch (select)
                {
                    case 1:
                        sequence = "C";
                        break;
                    case 2:
                        sequence = "D";
                        break;
                    case 3:
                        sequence = "E";
                        break;
                    case 4:
                        sequence = "F";
                        break;
                    case 5:
                        sequence = "G";
                        break;
                    case 6:
                        sequence = "A";
                        break;
                    case 7:
                        sequence = "B";
                        break;
                    case 8:
                        sequence = "CS";
                        break;
                    case 9:
                        sequence = "DS";
                        break;
                    case 10:
                        sequence = "FS";
                        break;
                    case 11:
                        sequence = "GS";
                        break;
                    case 12:
                        sequence = "AS";
                        break;
                }

                Console.WriteLine("     1) Major\n" +
                                  "     2) Minor");

                var minMaj = int.Parse(Console.ReadLine());
                switch (minMaj)
                {
                    case 1:
                        sequence += "M";
                        break;
                    case 2:
                        sequence += "m";
                        break;
                }

                return sequence;
            }
            catch(Exception ex)
            {
                Console.WriteLine("\nInvalid Input!\n " + ex.ToString());
                return "";
            }
        }

        public void PrettyWrite(object obj, string fileName)
        {
            var jsonString = JsonConvert.SerializeObject(obj, Formatting.Indented, _options);
            File.WriteAllText(fileName, jsonString);
        }

        public Key JsonReadAndSearch(string keySelection)
        {
            var json = File.ReadAllText(path);
            var jsonKeys = JsonConvert.DeserializeObject<List<Key>>(json);
            var selectedKey = jsonKeys.Where(x => x.key.Equals(keySelection)).FirstOrDefault();
            if (selectedKey is not null)
            {
                return selectedKey;
            }
            return new Key();
        }

        public void GenerateJson()
        {
            var allKeys = new List<Key>();
            //C
            Key CM = new Key("CM", "C", "D", "E", "F", "G", "A", "B"); allKeys.Add(CM);
            Key Cm = new Key("Cm", "C", "D", "D#", "F", "G", "G#", "A#"); allKeys.Add(Cm);
            Key CSM = new Key("CSM", "C#", "D#", "F", "F#", "G#", "A#", "C"); allKeys.Add(CSM);
            Key CSm = new Key("CSm", "C#", "D#", "E", "F#", "G#", "A", "B"); allKeys.Add(CSm);

            //D
            Key DM = new Key("DM", "D", "E", "F#", "G", "A", "B", "C#"); allKeys.Add(DM);
            Key Dm = new Key("Dm", "D", "E", "F", "G", "A", "A#", "C"); allKeys.Add(Dm);
            Key DSM = new Key("DSM", "D#", "F", "G", "G#", "A#", "C", "D"); allKeys.Add(DSM);
            Key DSm = new Key("DSm", "D#", "F", "F#", "G#", "A#", "B", "C#"); allKeys.Add(DSm);

            //E
            Key EM = new Key("EM", "E", "F#", "G#", "A", "B", "C#", "D#"); allKeys.Add(EM);
            Key Em = new Key("Em", "E", "F#", "G", "A", "B", "C", "D"); allKeys.Add(Em);

            //F
            Key FM = new Key("FM", "F", "G", "A", "A#", "C", "D", "E"); allKeys.Add(FM);
            Key Fm = new Key("Fm", "F", "G", "G#", "A#", "C", "C#", "D#"); allKeys.Add(Fm);
            Key FSM = new Key("FSM", "F#", "G#", "A#", "B", "C#", "D#", "F"); allKeys.Add(FSM);
            Key FSm = new Key("FSm", "F#", "G#", "A", "B", "C#", "D", "E"); allKeys.Add(FSm);
            
            //G
            Key GM = new Key("GM", "G", "A", "B", "C", "D", "E", "F#"); allKeys.Add(GM);
            Key Gm = new Key("Gm", "G", "A", "A#", "C", "D", "D#", "F"); allKeys.Add(Gm);
            Key GSM = new Key("GSM", "G#", "A#", "C", "C#", "D#", "F", "G"); allKeys.Add(GSM);
            Key GSm = new Key("GSm", "G#", "A#", "B", "C#", "D#", "E", "F#"); allKeys.Add(GSm);

            //A
            Key AM = new Key("AM", "A", "B", "C#", "D", "E", "F#", "G#"); allKeys.Add(AM);
            Key Am = new Key("Am", "A", "B", "C", "D", "E", "F", "G"); allKeys.Add(Am);
            Key ASM = new Key("ASM", "A#", "C", "D", "D#", "F", "G", "A"); allKeys.Add(ASM);
            Key ASm = new Key("ASm", "A#", "C", "C#", "D#", "F", "F#", "G#"); allKeys.Add(ASm);
            
            //B
            Key BM = new Key("BM", "B", "C#", "D#", "E", "F#", "G#", "A#"); allKeys.Add(BM);
            Key Bm = new Key("Bm", "B", "C#", "D", "E", "F#", "G", "A"); allKeys.Add(Bm);

            PrettyWrite(allKeys, path);
        }
    }
}
