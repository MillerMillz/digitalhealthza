using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IAdminRepository
    {
        AdminViewModel Add(AdminViewModel changes);
        IEnumerable<AdminViewModel> GetAll();


        //Doctor
        IEnumerable<Doctor> GetAllDoctor(); 
        //AdminModel GetDoctor(object regionalLiasonId);
        Doctor AddDoctor(Doctor doctor);
        Doctor GetDoctorEdit(int id);
        Doctor EditDoctor(Doctor doctor);
        Doctor DeleteDoctor(int id);
        Doctor GetDoctors(int id);
        Doctor ViewDoctor(int id);

        //Pharmasist
        IEnumerable<Pharmacist> GetAllPharmacist();
        Pharmacist AddPharmacist(Pharmacist pharmacist);
        Pharmacist GetPharmacistEdit(int id);
        Pharmacist EditPharmacist(Pharmacist pharmacist);
        Pharmacist DeletePharmacist(int id);
        Pharmacist GetPharmacists(int id);
        Pharmacist ViewPharmacist(int id);

        //Pracice

        IEnumerable<MedPractice > GetAllPractice();
        MedPractice DeletePractice(int id);
        MedPractice AddPractice(MedPractice practice);
        MedPractice EditPractice(MedPractice practice);
        MedPractice GetPracticeEdit(int id);
        MedPractice GetPractice(int id);
        MedPractice ViewPractice(int id);

        //Pharmmacy
        IEnumerable<Pharmacy> GetAllPharmacy();
        Pharmacy DeletePharmacy(int id);
        Pharmacy AddPharmacy(Pharmacy pharmacy);
        Pharmacy EditPharmacy(Pharmacy pharmacy);
        Pharmacy GetPharmacyEdit(int id);
        Pharmacy GetPharmacy(int id);
        Pharmacy ViewPharmacy(int id);


        //Medication
        IEnumerable<Medication> GetAllMedication();
        Medication AddMedication(Medication medication);
        Medication GetMedicationEdit(int id);
        Medication EditMedication(Medication medication);
        Medication DeleteMedication(int id);
        Medication GetMedications(int id);
        Medication ViewMedication(int id);

        //Active Ingredients
        IEnumerable<ActiveIngredient> GetAllActiveIngredient();
        ActiveIngredient DeleteActiveIngredient(int id);
        ActiveIngredient AddActiveIngredient(ActiveIngredient ingredient);
        ActiveIngredient EditActiveIngredient(ActiveIngredient ingredient);
        ActiveIngredient GetActiveIngredientEdit(int id);
        ActiveIngredient GetActiveIngredient(int id);
        ActiveIngredient ViewActiveIngredient(int id);

        //Condition
        IEnumerable<ConditionDiagnosis> GetAllCondition();
        ConditionDiagnosis DeleteCondition(int id);
        ConditionDiagnosis AddCondition(ConditionDiagnosis condition);
        ConditionDiagnosis EditCondition(ConditionDiagnosis condition);
        ConditionDiagnosis GetConditionEdit(int id);
        ConditionDiagnosis GetCondition(int id);
        ConditionDiagnosis ViewCondition(int id);


    }
}
