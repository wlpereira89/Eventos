﻿using System.ComponentModel.DataAnnotations;

namespace Modelo.VM
{
    public class vmEmail
    {
        [Required, Display(Name = "Seu Nome")]
        public string FromName { get; set; }
        [Required, Display(Name = "Seu Email"), EmailAddress]
        public string FromEmail { get; set; }
        [Required, Display(Name = "Mensagem")]
        public string Mensage { get; set; }
    }
}
