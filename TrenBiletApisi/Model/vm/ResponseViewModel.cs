using System.Collections.Generic;

namespace TrenBiletApisi.Model.vm
{
    public class ResponseViewModel
    {
        public bool RezervasyonYapılır { get; set; }
        public List<YerleşimAyrinti> YerleşmeAyrinti { get; set; }
    }

    public  class YerleşimAyrinti
    {

        public string VagonAdi { get; set; }
        public int KisiSayisi { get; set; }
    }
}
