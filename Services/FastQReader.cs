using System.Collections.Generic;
using Iondude.Models;
using System.IO;

namespace Iondude.Services
{
    public class FastQReader 
    {        
        public IEnumerable<FastQ> ReadFastQ(string fileName)
        {
            int nLine = -1;
            using (TextReader reader = File.OpenText(fileName))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    nLine++;
                    if(nLine %4 != 0) continue;

                    FastQ read = new FastQ()
                    {
                        Name = line,
                        Seq = reader.ReadLine(),
                        Comment = reader.ReadLine(),
                        Qual = reader.ReadLine()
                    };

                    nLine+=3;

                    yield return read;
                }
            }
        }
    }
}