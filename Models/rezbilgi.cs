using System.ComponentModel.DataAnnotations;

namespace OtelApp.Models
{
    public class rezbilgi
    {
       //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}")]
        public DateTime Gtarih { get; set; }
      //  [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}")]
        public DateTime Ctarih { get; set; }
        public int kisisayisi { get; set; }
    }
}
