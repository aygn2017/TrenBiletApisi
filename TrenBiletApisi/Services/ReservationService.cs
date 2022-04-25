using System;
using System.Collections.Generic;
using TrenBiletApisi.Model.vm;
namespace TrenBiletApisi.Services
{
    public class ReservationService : IReservationService
    {
        public ResponseViewModel Reservation(RequestViewModel request)
        {
            if (request.KisilerFarkliVagonlaraYerlestirilebilir==true)
            {
                List<YerleşimAyrinti> yerleşimPlani = new List<YerleşimAyrinti>();
                var kisi = request.RezervasyonYapilacakKisiSayisi;
                foreach (var item in request.Tren.vagonlar)
                {
                    var mevcutYüzde = Math.Ceiling((double)item.DoluKoltukAdeti / item.Kapasite * 100);
                    var maxDoluKoltuk = (double)70 * item.Kapasite / 100;
                    var maxkullanici = Math.Floor((double)maxDoluKoltuk - item.DoluKoltukAdeti);
                    if (maxkullanici < 0)
                        continue;

                    else if(kisi- maxkullanici <= 0)
                    {
                        yerleşimPlani.Add(new YerleşimAyrinti { KisiSayisi = kisi,VagonAdi = item.Ad });
                        ResponseViewModel response = new ResponseViewModel
                        { RezervasyonYapılır = true, YerleşmeAyrinti = yerleşimPlani };
                        return response;

                    }
                     else
                    {
                        yerleşimPlani.Add(new YerleşimAyrinti { KisiSayisi = (int)maxkullanici,VagonAdi=item.Ad });
                        kisi -= (int)maxkullanici;
                    }
                }
                if (kisi <= 0)
                    return new ResponseViewModel { RezervasyonYapılır = true, YerleşmeAyrinti = yerleşimPlani };
                else
                    return new ResponseViewModel { RezervasyonYapılır = false, YerleşmeAyrinti = new List<YerleşimAyrinti>() };
            }
            else
            {
                foreach (var item in request.Tren.vagonlar)
                {
                    var yuzdeliksonuc = (float)(item.DoluKoltukAdeti +
                    request.RezervasyonYapilacakKisiSayisi) / (item.Kapasite) * 100;
                    if(yuzdeliksonuc<70)
                    {
                        List<YerleşimAyrinti> yerleşims = new() { new YerleşimAyrinti { KisiSayisi = request.RezervasyonYapilacakKisiSayisi, VagonAdi = item.Ad } };
                        ResponseViewModel resp=new() { RezervasyonYapılır=true,YerleşmeAyrinti=yerleşims };
                        return resp;
                    }
                }
                return new ResponseViewModel { RezervasyonYapılır = false, YerleşmeAyrinti = new List<YerleşimAyrinti>() };
            }
        }
    }
}
