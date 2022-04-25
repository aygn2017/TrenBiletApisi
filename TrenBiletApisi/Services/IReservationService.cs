using TrenBiletApisi.Model.vm;

namespace TrenBiletApisi.Services
{
    public interface IReservationService
    {
        public ResponseViewModel Reservation(RequestViewModel request);
    }
}
