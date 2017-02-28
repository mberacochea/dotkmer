namespace Iondude.Models
{
    public class FastQ
    {
        public FastQ()
        {
            this.Name = "";
            this.Comment = "";
            this.Seq = "";
            this.Qual = "";
        }
        
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Seq { get; set; }
        public string Qual { get; set; }
    }
}