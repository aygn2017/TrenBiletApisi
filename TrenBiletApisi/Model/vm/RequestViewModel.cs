namespace TrenBiletApisi.Model.vm
{
    public class RequestViewModel
    {
        public  Tren Tren { get; set; }

        public int RezervasyonYapilacakKisiSayisi { get; set; }

        public  bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
    }
}
