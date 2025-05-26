using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class Horario_Medico
    {
        public int IdHorarioMedico { get; set; }
        public string Dia {  get; set; }
        public  bool hora_0 { get; set; }
        public  bool hora_1 { get; set; }
        public  bool hora_2 { get; set; }
        public  bool hora_3 { get; set; }
        public  bool hora_4 { get; set; }
        public  bool hora_5 { get; set; }
        public  bool hora_6 { get; set; }
        public  bool hora_7 { get; set; }
        public  bool hora_8 { get; set; }
        public  bool hora_9 { get; set; }
        public  bool hora_10 { get; set; }
        public  bool hora_11 { get; set; }
        public  bool hora_12 { get; set; }
        public  bool hora_13 { get; set; }
        public  bool hora_14 { get; set; }
        public  bool hora_15 { get; set; }
        public  bool hora_16 { get; set; }
        public  bool hora_17 { get; set; }
        public  bool hora_18 { get; set; }
        public  bool hora_19 { get; set; }
        public  bool hora_20 { get; set; }
        public  bool hora_21 { get; set; }
        public  bool hora_22 { get; set; }
        public  bool hora_23 { get; set; }

        public int IdMedico { get; set; }

        public Horario_Medico() { }

        public Horario_Medico (string dia, int idMedico)
        {
            this.Dia = dia;
            this.IdMedico = idMedico;
        }
    }
}
