using System.ComponentModel.DataAnnotations;

namespace TrenBiletApisi.Model
{
    public class Vagon:basic
    {
       
        public int Kapasite { get; set; }
       
        public int DoluKoltukAdeti { get; set; }
    }
}
