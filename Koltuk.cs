namespace UcakRezervasyonSistemi
{
    class Koltuk
    {
        public string KoltukAdi { get; set; }
        public Yolcu Yolcu { get; set; }
        public Koltuk(string ad, string passNo)
        {
            Yolcu = new Yolcu(ad, passNo);
        }
    }
}
