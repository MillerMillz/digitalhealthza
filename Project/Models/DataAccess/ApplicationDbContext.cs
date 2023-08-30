using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.DataAccess
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser,IdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ActiveIngrStrength> ActiveIngrStrengths { get; set; }
        public DbSet<AdminModel> adminModels { get; set; }
        public DbSet<PatientAllergy> PatientAllergies { get; set; }//2
        public DbSet<HighestQualification> HighestQualifications { get; set; }//3
        public DbSet<ActiveIngredient> ActiveIngredients { get; set; }
        public DbSet<PrescrLineAlert> PrescrLineAlerts { get; set; } //4
        public DbSet<DispLineAlert> DispLineAlerts { get; set; }//5
        public DbSet<City> Cities { get; set; }
        public DbSet<ConditionDiagnosis> ConditionDiagnoses { get; set; }
        public DbSet<ContraIndication> ContraIndications { get; set; }
        public DbSet<DispenseDetails> DispenseDetails { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DosageForm> DosageForms { get; set; }
        public DbSet<MedActiveIngredient> MedActiveIngredients { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<MedicationTaking> MedicationTakings { get; set; }
        public DbSet<MedInteraction> MedInteractions { get; set; }
        public DbSet<MedPractice> MedPractices { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientCondition> PatientConditions { get; set; }
        public DbSet<Pharmacist> Pharmacists { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionLine> PrescriptionLines { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Surburb> Surburbs { get; set; }
        public DbSet<Strength> Strengths { get; set; }
        public DbSet<LineActiveIngre> LineActiveIngres { get; set; }



    }

}
