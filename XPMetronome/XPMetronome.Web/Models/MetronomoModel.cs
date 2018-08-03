using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XPMetronome.Web.Models
{
    public class MetronomoModel
    {
        public string TipoCompasso { get; set; }

        public int Bpm { get; set; }

        [Required(ErrorMessage ="Digite quantos compassos deseja repetir.")]
        public int QtdCompassosRepetir { get; set; }

        [Required(ErrorMessage ="Digite quantos compassos deseja aumentar a velocidade.")]
        public int QtdCompassosEvoluir { get; set; }

        [Required(ErrorMessage ="Digite quantidade de bpm a ser acelerado.")]
        public int IncrementoBpm { get; set; }
    }
}