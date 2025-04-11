namespace Lieferverwaltung
{
    class Program
    {
        static List<Lieferung> lieferungen = new List<Lieferung>();
        static void Main(string[] args)
        {
            BeispielobjekteAnlegen();
            Console.WriteLine(lieferungen.Count);

            WriteToJSON();
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

        static void WriteToJSON()
        {
            string data = "{\n" +
                "\t\"anzahl\": " + lieferungen.Count + ",\n" +
                "\t\"lieferungen\": ";

            if (lieferungen.Count > 0)
            {
                data += "[\n";

                Lieferung lastItem = lieferungen[lieferungen.Count - 1];

                foreach (Lieferung l in lieferungen)
                {
                    data += "\t\t{\n" +
                        "\t\t\t\"datum\": \"" + l.Datum.ToString() + "\",\n" +
                        "\t\t\t\"sendungsnummer\": \"" + l.Sendungsnummer + "\",\n" +
                        "\t\t\t\"plz\": " + Convert.ToInt32(l.PLZ) + "\n" +
                        "\t\t}";

                    if (l != lastItem)
                    {
                        data += ",";
                    }

                    data += "\n";
                }

                data += "\t]\n";
            }

            data += "}";

            File.WriteAllText("lukas_data.json", data);
        }
    }
}
