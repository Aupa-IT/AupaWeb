using System;
using System.ComponentModel.DataAnnotations;

namespace AupaWeb.Models
{
    public class UserBasicObject
    {
        private String aba01;  //user_id
        private String aba02;  //user_name
        private String aba03;  //password
        private String aba04;  //email
        private String aba05;  //create_date
        private String aba06;  //last_login _date
        private String aba07;  //Role
        private bool showhide;

        [Required(ErrorMessage = "Required.")]
        public string Aba01 { get => aba01; set => aba01 = value; }
        public string Aba02 { get => aba02; set => aba02 = value; }
        [Required(ErrorMessage = "Required.")]
        public string Aba03 { get => aba03; set => aba03 = value; }
        public string Aba04 { get => aba04; set => aba04 = value; }
        public string Aba05 { get => aba05; set => aba05 = value; }
        public string Aba06 { get => aba06; set => aba06 = value; }
        public string Aba07 { get => aba07; set => aba07 = value; }
        public bool Showhide { get => showhide; set => showhide = value; }
    }
}