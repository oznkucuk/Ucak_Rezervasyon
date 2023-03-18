namespace UcakRezervasyonSistemi
{
    class Ucak
    {
        public Koltuk Koltuk { get; set; }
        public Ucak(string ad, string passNo)
        {
            Koltuk = new Koltuk(ad, passNo);
        }
    }
}
