
namespace ProyekAkhir_Teknet.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pasien
    {
        public int Pasien_ID { get; set; }
        public string Nama_Pasien { get; set; }
        public string No_Hp { get; set; }
        public string Gejala_Pasien { get; set; }
        public string Alamat { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
