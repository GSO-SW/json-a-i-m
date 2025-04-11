using System.ComponentModel;
using System.Data;
using System.Xml.Linq;

namespace Lieferverwaltung
{
    class Program
    {
        static List<Lieferung> lieferungen = new List<Lieferung>();
        static void Main(string[] args)
        {
            BeispielobjekteAnlegen();
            Console.WriteLine(lieferungen.Count);

            static void FileWriteToJsonFlorianObjekteAuslessen()
            {
                string pfad = "C:\\Users\\lingn\\Desktop\\Schule\\Schule\\Json_Uebung\\json-a-i-m\\Data_Florian.JSON";
                string inhalt = "{\n" +
                   $"  \"anzahl\": {lieferungen.Count},\n" +
                    "  \"lieferungen\": \n   [\n";

                for (int i = 0; i < lieferungen.Count; i++)
                {
                    string speicher;

                    if (lieferungen.Count - i == 1)
                    {
                        speicher =
                       "    {\n" +
                       $"      \"datum\": \"{lieferungen[i].Datum}\",\n" +
                       $"      \"sendungsnummer\": \"{lieferungen[i].Sendungsnummer}\",\n" +
                       $"      \"plz\": {Convert.ToInt32(lieferungen[i].PLZ)}\n" +
                       "     }\n" +
                          "  ]\n" +
                          "}";
                        inhalt += speicher;
                    }
                    else
                    {
                        speicher =
                         "    {\n" +
                         $"      \"datum\": \"{lieferungen[i].Datum}\",\n" +
                         $"      \"sendungsnummer\": \"{lieferungen[i].Sendungsnummer}\",\n" +
                         $"      \"plz\": {Convert.ToInt32(lieferungen[i].PLZ)}\n" +
                         "     },\n";
                        inhalt += speicher;
                    }



                    File.WriteAllText(pfad, inhalt);

                }
            }

            FileWriteToJsonFlorianObjekteAuslessen();



        }

        static void BeispielobjekteAnlegen()
        {
            lieferungen.Add(new Lieferung(
                new DateOnly(2024, 06,22)
                , "HHX05NNW0ZP"
                , "86309"
            ));
            
            lieferungen.Add(new Lieferung(
                new DateOnly(2024, 09, 4)
                , "GSV18EDC4BR"
                , "91139"
            ));
            
            lieferungen.Add(new Lieferung(
                new DateOnly(2023, 04, 8)
                , "CQX55KMY5RW"
                , "07708"
            ));
        }
    }
}
