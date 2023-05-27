namespace HLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read in commandline args for infile1 name, infile2 name and output filename
            // they can be in any order
            var infile1 = args[0];
            var infile2 = args[1];
            var outfile = args[2];

            var file1 = File.ReadAllText(infile1);
            var file2 = File.ReadAllText(infile2);

            // delete even numbered lines from file1
            var lines = file1.Split('\n');
            var oddLines = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (i % 2 == 0)
                {
                    // remove any crlf if its there
                    var line = lines[i].Replace("\r", "");
                    oddLines.Add(line);
                }
            }

            // delete odd numbered lines from file2
            lines = file2.Split('\n');
            var evenLines = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (i % 2 == 1)
                {
                    // remove any crlf if its there
                    var line = lines[i].Replace("\r", "");
                    evenLines.Add(line);
                }

            }

            // combine the two files
            var combined = new List<string>();
            for (int i = 0; i < oddLines.Count; i++)
            {
                combined.Add(oddLines[i]);
                combined.Add(evenLines[i]);
            }
            // write the combined file to disk
            File.WriteAllLines(outfile, combined);


        }
    }
}