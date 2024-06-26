namespace CadastroNumeros.Models
{
    public class DDD
    {
        public int Id { get; set; }
        public string _DDD {  get; set; }
        public ICollection<Contato> Contatos { get; set; }
        public DDD() { }
        public DDD(string codigoDDD) 
        {
            if (IsValid(codigoDDD))
            {
                _DDD = codigoDDD;
            }
            else
            {
                throw new ArgumentException("Número DDD inválido");
            }
        }

        public static readonly HashSet<string> DDDsValidos = new HashSet<string>
        {
        "11", "12", "13", "14", "15", "16", "17", "18", "19",
        "21", "22", "24", "27", "28", "31", "32", "33", "34", "35", "37", "38", "41", "42", "43", "44", "45", "46",
        "47", "48", "49", "51", "53", "54", "55", "61", "62", "63", "64", "65", "66", "67", "68", "69",
        "71", "73", "74", "75", "77", "79", "81", "82", "83", "84", "85", "86", "87", "88", "89", "91", "92", "93", "94", "95", "96", "97", "98", "99"
        };

        public static bool IsValid(string Codigo)
        {
            return DDDsValidos.Contains(Codigo);
        }
        public string ToString() { return _DDD; }
    }
}
