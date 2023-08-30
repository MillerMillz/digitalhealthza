using Microsoft.AspNetCore.Mvc;
using Project.Models.DataAccess;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public class AdminRepository: IAdminRepository
    {
        private readonly ApplicationDbContext context;

        public AdminRepository(ApplicationDbContext cxt)
        {
            context = cxt;
        }


        //Doctor
        public Doctor AddDoctor(Doctor doctor)
        {
            context.Doctors.Add(doctor);
            context.SaveChanges();
            return doctor;
        }


        public IEnumerable<Doctor> GetAllDoctor()
        {
            return context.Doctors;
        }
        public Doctor GetDoctor(int id)
        {
            return context.Doctors.Find(id);

        }
        public Doctor GetDoctorEdit(int id)
        {
            return context.Doctors.Find(id);
        }



        public Doctor EditDoctor(Doctor doctor)
        {
            var doctors = context.Doctors.Attach(doctor);
            doctors.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return doctor;
        }

        public Doctor DeleteDoctor(int id)
        {
            Doctor doctor = context.Doctors.Find(id);
            if (doctor != null)
            {
                context.Doctors.Remove(doctor);
                context.SaveChanges();
            }
            return doctor;
        }

        public Doctor GetDoctors(int id)
        {
            return context.Doctors.Find(id);

        }
        public Doctor ViewDoctor(int id)
        {
            return context.Doctors.Find(id);

        }


        //Pharmacist
        public Pharmacist AddPharmacist(Pharmacist pharmacist)
        {
            context.Pharmacists.Add(pharmacist);
            context.SaveChanges();
            return pharmacist;
        }


        public IEnumerable<Pharmacist> GetAllPharmacist()
        {
            return context.Pharmacists;
        }
        public Pharmacist GetPharmacist(int id)
        {
            return context.Pharmacists.Find(id);

        }
        public Pharmacist GetPharmacistEdit(int id)
        {
            return context.Pharmacists.Find(id);
        }



        public Pharmacist EditPharmacist(Pharmacist pharmacist)
        {
            var pharmacists = context.Pharmacists.Attach(pharmacist);
            pharmacists.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return pharmacist;
        }

        public Pharmacist DeletePharmacist(int id)
        {
            Pharmacist pharmacist = context.Pharmacists.Find(id);
            if (pharmacist != null)
            {
                context.Pharmacists.Remove(pharmacist);
                context.SaveChanges();
            }
            return pharmacist;
        }

        public Pharmacist GetPharmacists(int id)
        {
            return context.Pharmacists.Find(id);

        }
        public Pharmacist ViewPharmacist(int id)
        {
            return context.Pharmacists.Find(id);

        }

        //Practice

        public MedPractice AddPractice(MedPractice practice)
        {
            context.MedPractices.Add(practice);
            context.SaveChanges();
            return practice;
        }
        public MedPractice DeletePractice(int id)
        {
            MedPractice practice = context.MedPractices.Find(id);
            if (practice != null)
            {
                context.MedPractices.Remove(practice);
                context.SaveChanges();
            }
            return practice;
        }


        public IEnumerable<MedPractice> GetAllPractice()
        {
            return context.MedPractices;
        }

        public MedPractice EditPractice(MedPractice practice)
        {
            var practices = context.MedPractices.Attach(practice);
            practices.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return practice;
        }

        public MedPractice GetPracticeEdit(int id)
        {
            return context.MedPractices.Find(id);

        }
        public MedPractice GetPractice(int id)
        {
            return context.MedPractices.Find(id);

        }

        public MedPractice ViewPractice(int id)
        {
            return context.MedPractices.Find(id);

        }


        //Pharmacy


        public Pharmacy AddPharmacy(Pharmacy pharmacy)
        {
            context.Pharmacies.Add(pharmacy);
            context.SaveChanges();
            return pharmacy;
        }
        public Pharmacy DeletePharmacy(int id)
        {
            Pharmacy pharmacy = context.Pharmacies.Find(id);
            if (pharmacy != null)
            {
                context.Pharmacies.Remove(pharmacy);
                context.SaveChanges();
            }
            return pharmacy;
        }


        public IEnumerable<Pharmacy> GetAllPharmacy()
        {
            return context.Pharmacies;
        }

        public Pharmacy EditPharmacy(Pharmacy pharmacy)
        {
            var pharmacies = context.Pharmacies.Attach(pharmacy);
            pharmacies.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return pharmacy;
        }

        public Pharmacy GetPharmacyEdit(int id)
        {
            return context.Pharmacies.Find(id);

        }
        public Pharmacy GetPharmacy(int id)
        {
            return context.Pharmacies.Find(id);

        }

        public Pharmacy ViewPharmacy(int id)
        {
            return context.Pharmacies.Find(id);

        }


        //Condition
        public ConditionDiagnosis AddCondition(ConditionDiagnosis condition)
        {
            context.ConditionDiagnoses.Add(condition);
            context.SaveChanges();
            return condition;
        }
        public ConditionDiagnosis DeleteCondition(int id)
        {
            ConditionDiagnosis condition = context.ConditionDiagnoses.Find(id);
            if (condition != null)
            {
                context.ConditionDiagnoses.Remove(condition);
                context.SaveChanges();
            }
            return condition;
        }


        public IEnumerable<ConditionDiagnosis> GetAllCondition()
        {
            return context.ConditionDiagnoses;
        }

        public ConditionDiagnosis EditCondition(ConditionDiagnosis condition)
        {
            var conditions = context.ConditionDiagnoses.Attach(condition);
            conditions.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return condition;
        }

        public ConditionDiagnosis GetConditionEdit(int id)
        {
            return context.ConditionDiagnoses.Find(id);

        }
        public ConditionDiagnosis ViewCondition(int id)
        {
            return context.ConditionDiagnoses.Find(id);

        }

        public ConditionDiagnosis GetCondition(int id)
        {
            return context.ConditionDiagnoses.Find(id);

        }



        //Active Ingredients
        public ActiveIngredient AddActiveIngredient(ActiveIngredient ingredient)
        {
            context.ActiveIngredients.Add(ingredient);
            context.SaveChanges();
            return ingredient;
        }


        public ActiveIngredient DeleteActiveIngredient(int id)
        {
            ActiveIngredient ingredient = context.ActiveIngredients.Find(id);
            if (ingredient != null)
            {
                context.ActiveIngredients.Remove(ingredient );
                context.SaveChanges();
            }
            return ingredient;
        }


        public IEnumerable<ActiveIngredient> GetAllActiveIngredient()
        {
            return context.ActiveIngredients;
        }

        public ActiveIngredient EditActiveIngredient(ActiveIngredient ingredient)
        {
            var ingredients = context.ActiveIngredients.Attach(ingredient );
            ingredients.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return ingredient ;
        }

        public ActiveIngredient GetActiveIngredientEdit(int id)
        {
            return context.ActiveIngredients.Find(id);

        }

        public ActiveIngredient GetActiveIngredient(int id)
        {

            return context.ActiveIngredients.Find(id);

        }

        public ActiveIngredient ViewActiveIngredient(int id)
        {

            return context.ActiveIngredients.Find(id);

        }




        //Medication
        public Medication  AddMedication(Medication medication)
        {
            context.Medications.Add(medication);
            context.SaveChanges();
            return medication;
        }
        public Medication DeleteMedication(int id)
        {
            Medication medication = context.Medications.Find(id);
            if (medication != null)
            {
                context.Medications.Remove(medication);
                context.SaveChanges();
            }
            return medication;
        }


        public IEnumerable<Medication > GetAllMedication()
        {
            return context.Medications;
        }

        public Medication EditMedication(Medication medication)
        {
            var medications = context.Medications.Attach(medication);
            medications.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return medication;
        }

        public Medication GetMedicationEdit(int id)
        {
            return context.Medications.Find(id);

        }
        public Medication GetMedications(int id)
        {
            return context.Medications.Find(id);

        }
        public Medication ViewMedication(int id)
        {
            return context.Medications.Find(id);

        }





        public AdminViewModel Add(AdminViewModel changes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AdminViewModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
