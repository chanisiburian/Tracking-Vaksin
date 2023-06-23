using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ProyekAkhir_Teknet.Models
{

public class Register
{

    public int Pasien_ID { get; set; }

    [Required]
    [Display(Name = "Nama Lengkap")]
    public string Nama_Pasien { get; set; }

    [Required]
    [Display(Name = "No Hp")]
    public string No_Hp { get; set; }


    [Required]
    [Display(Name = "Gejala Pasien")]
    public string Gejala_Pasien { get; set; }
 
    
    [Required]
    [Display(Name = "Alamat")]
    public string Alamat { get; set; }


        
    [Required]
    [Display(Name = "Username")]
    public string Username { get; set; }


    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
}