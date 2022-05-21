using System;

namespace SSU.Coins.Entities
{
    public class Coin
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public int? Price { get; set; }

        public string Description { get; set; }

        public int IdCountry { get; set; }

        public int IdMaterial { get; set; }

        public int IdUser { get; set; }

        public byte[] Picture { get; set; }

        public bool IsSalling { get; set; }
    }
}
