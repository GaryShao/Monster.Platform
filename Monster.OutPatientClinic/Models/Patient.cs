using System;

namespace Monster.OutPatientClinic.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public DateTime ConsultingTime { get; set; }
        public string Symptom { get; set; }
        public string Prescription { get; set; }
    }
}
