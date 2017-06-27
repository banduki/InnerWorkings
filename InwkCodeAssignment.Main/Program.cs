using System;
using System.IO;

namespace InnerWorkingsCodeAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessJob(1);
            ProcessJob(2);
            ProcessJob(3);

            Console.ReadKey();
        }

        static void ProcessJob(int jobNumber)
        {
            var inputFile = $"Jobs\\Job {jobNumber}.txt";
            var outputFile = $"Jobs\\Invoice for job {jobNumber}.txt";

            Console.WriteLine($"Job {jobNumber}:");

            var properties = new JobReader(inputFile).LoadProperties();
            var output = new JobCalculator(properties).Output;
            Console.WriteLine(output + "\n\n");

            File.WriteAllLines(outputFile, output.Split('\n'));
            Console.Write($"Wrote output to {outputFile}\n\n");
        }
    }
}