using System;
using Iondude.Services;

namespace Iondude
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FastQReader fastQreader = new FastQReader();
            Kmer kmerService = new Kmer(int.Parse(args[0]));

            foreach (var read in fastQreader.ReadFastQ(args[1])) 
            {
                // count contexts
                kmerService.CountContexts(read);
            }

            Console.WriteLine("Context count ended, enter a kmer to get the count.");
            Console.WriteLine("Write 'exit' to close it");            
            
            // pseudo repl
            while (true)
            {
                string query = Console.ReadLine();

                if (query == "exit")
                {
                    Console.WriteLine("bye");
                    break;
                }

                Console.WriteLine($"Count: {kmerService.Count(query)}");
            }
        }
    }
}