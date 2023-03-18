namespace UcakRezervasyonSistemi
{
    class Yolcu
    {
        public string AdSoyad { get; set; }
        public string PasaportNo { get; set; }
        public Yolcu(string adSoyad, string pasaportNo)
        {
            AdSoyad = adSoyad;
            PasaportNo = pasaportNo;
        }
    }
}
