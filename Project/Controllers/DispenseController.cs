using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Models.Repositories;
using Project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class DispenseController : BaseControllerPharmacist
    {

        private readonly IMedicationTakingRepository medicationTakingRepository;
        private readonly IDispenseDetailsRepository dispenseDetailsRepository;
        private readonly IPharmacistRepository pharmacistRepository;
        private readonly IDoctorRepository doctorRepository;
        private readonly IPrescrLineAlertRepository prescrLineAlertRepository;
        private readonly IMedInteractionRepository medInteractionRepository;
        private readonly IMedicalHistoryRepository medicalHistoryRepository;
        private readonly IConditionDiagnosisRepository conditionDiagnosisRepository;
        private readonly IPatientAllergyRepository patientAllergyRepository;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IPatientConditionRepository patientConditionRepository;
        private readonly IContraIndicationRepository contraIndicationRepository;
        private readonly IActiveIngrStrengthRepository aISIDRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPrescriptionRepository prescriptionRep;
        private readonly ILineActiveIngreRepository lineActiveIngreRepository;
        private readonly IMedicationRepository medRep;
        private readonly IMedActiveIngredientRepository medActIngrRep;
        private readonly IstrengthRepository strengthRep;
        private readonly IPrescriptionLineRepository prescriptionLineRepository;

        public IActiveIngredientRepository AIRep { get; }
        public IActiveIngrStrengthRepository AISRep { get; }

        public DispenseController(IMedicationTakingRepository medicationTakingRepository,IDispenseDetailsRepository dispenseDetailsRepository, IPharmacistRepository pharmacistRepository,IDoctorRepository doctorRepository, IPrescrLineAlertRepository prescrLineAlertRepository, IMedInteractionRepository medInteractionRepository, IMedicalHistoryRepository medicalHistoryRepository, IConditionDiagnosisRepository conditionDiagnosisRepository, IPatientAllergyRepository patientAllergyRepository, SignInManager<ApplicationUser> _signInManager, IPatientConditionRepository _patientConditionRepository, IContraIndicationRepository contraIndicationRepository, IActiveIngrStrengthRepository _AISIDRepository, UserManager<ApplicationUser> _userManager, IPrescriptionRepository _prescriptionRep, ILineActiveIngreRepository _lineActiveIngreRepository, IMedicationRepository _medRep, IMedActiveIngredientRepository _medActIngrRep, IActiveIngredientRepository _AIRep, IActiveIngrStrengthRepository _AISRep, IstrengthRepository _strengthRep, IPrescriptionLineRepository _prescriptionLineRepository)
        {
            this.medicationTakingRepository = medicationTakingRepository;
            this.dispenseDetailsRepository = dispenseDetailsRepository;
            this.pharmacistRepository = pharmacistRepository;
            this.doctorRepository = doctorRepository;
            this.prescrLineAlertRepository = prescrLineAlertRepository;
            this.medInteractionRepository = medInteractionRepository;
            this.medicalHistoryRepository = medicalHistoryRepository;
            this.conditionDiagnosisRepository = conditionDiagnosisRepository;
            this.patientAllergyRepository = patientAllergyRepository;
            signInManager = _signInManager;
            patientConditionRepository = _patientConditionRepository;
            this.contraIndicationRepository = contraIndicationRepository;
            aISIDRepository = _AISIDRepository;
            userManager = _userManager;
            prescriptionRep = _prescriptionRep;
            lineActiveIngreRepository = _lineActiveIngreRepository;
            medRep = _medRep;
            medActIngrRep = _medActIngrRep;
            AIRep = _AIRep;
            AISRep = _AISRep;
            strengthRep = _strengthRep;
            prescriptionLineRepository = _prescriptionLineRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SubmitAfterAlert(AddPrescriptionViewModel model)
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            Pharmacist pharmacist = pharmacistRepository.GetPharmacist(user.LoginID);
            List<MedicationViewModel> viewModels = model.Medications.Where(z => z.Dispense == true).ToList();
            PrescriptionLine prescriptionLine = new PrescriptionLine();
            List<DispenseDetails> details = new List<DispenseDetails>();
            List<PrescriptionLine> update = new List<PrescriptionLine>();
            for (int i = 0; i < viewModels.Count; i++)
            {
                prescriptionLine = prescriptionLineRepository.GetPrescriptionLine(viewModels[i].LineID);
                prescriptionLine.RepeatsLeft = prescriptionLine.RepeatsLeft - 1;
                update.Add(prescriptionLine);
                details.Add(new DispenseDetails() { Date=DateTime.Now,LineID=prescriptionLine.ID,PharmacistID=pharmacist.PharmacistID,PharmacyID=pharmacist.PharmacyID});
            }
            dispenseDetailsRepository.AddDispenseDetailsInBulk(details);
            prescriptionLineRepository.UpdatePrescriptionLineInBulk(update);
            
            Notify("Dispensed Successfully", "Success", NotificationType.success);
            return RedirectToAction("ListPrescriptionsForPharm", "Prescription");
        }
        [HttpPost]
        public async Task<IActionResult> Submit(List<MedicationViewModel> models)
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            Pharmacist pharmacist = pharmacistRepository.GetPharmacist(user.LoginID);
            List<MedicationViewModel> viewModels = models.Where(z => z.Dispense == true).ToList();
            //check start
            List<PatientAllergy> allergies = patientAllergyRepository.ListePatientAllergies().Where(z => z.PatientID == user.PatientID).ToList();
            List<MedicationTaking> medicationTakings = medicationTakingRepository.ListMedicationTakings().Where(z => z.PatientID == user.PatientID).ToList();
            List<MedActiveIngredient> medActiveIngredients;
            List<MedActiveIngredient> medActiveIngredients1;
            List<MedInteraction> medInteractions = medInteractionRepository.ListMedInteractions();
            ActiveIngrStrength activeIngrStrength;
            ActiveIngrStrength activeIngrStrength1;

            List<string> errors = new List<string>();
            string error = "";

            for (int i = 0; i < viewModels.Count; i++)
            {

                foreach (MedicationTaking item in medicationTakings)
                {

                    if (item.MedID == viewModels[i].MedicationID)
                    {
                        error = "Patient is already taking" + viewModels[i].MedicationName + ",";
                        errors.Add(error);
                    }
                }
                medActiveIngredients = medActIngrRep.ListMedActiveIngredients().Where(z => z.MedID == viewModels[i].MedicationID).ToList();
                for (int j = 0; j < medActiveIngredients.Count; j++)
                {
                    activeIngrStrength = aISIDRepository.GetAIStrength(medActiveIngredients[j].AISID);
                    foreach (PatientAllergy item in allergies)
                    {
                        if (item.ActiveIngredientID == activeIngrStrength.ActiveIngrID)
                        {
                            error = "Patient has an allergy on " + AIRep.GetActiveIngredient(item.ActiveIngredientID).ActiveIngredientName + ",";
                            errors.Add(error);
                        }
                    }
                    for (int s = 0; s < medInteractions.Count; s++)
                    {
                        if (medInteractions[s].ActiveIngredient1ID == activeIngrStrength.ActiveIngrID)
                        {
                            for (int p = 0; p < viewModels.Count; p++)
                            {
                                medActiveIngredients1 = medActIngrRep.ListMedActiveIngredients().Where(z => z.MedID ==viewModels[p].MedicationID).ToList();
                                for (int q = 0; q < medActiveIngredients1.Count; q++)
                                {
                                    activeIngrStrength1 = aISIDRepository.GetAIStrength(medActiveIngredients1[q].AISID);
                                    if (medInteractions[s].ActiveIngredient2ID == activeIngrStrength1.ActiveIngrID)
                                    {
                                        error = "Medication " +viewModels[i].MedicationName + " should not be taken with madication " + viewModels[p].MedicationName + ",";
                                        errors.Add(error);
                                    }
                                }
                            }
                            foreach (MedicationTaking item in medicationTakings)
                            {
                                medActiveIngredients1 = medActIngrRep.ListMedActiveIngredients().Where(z => z.MedID == item.MedID).ToList();
                                for (int q = 0; q < medActiveIngredients1.Count; q++)
                                {
                                    activeIngrStrength1 = aISIDRepository.GetAIStrength(medActiveIngredients1[q].AISID);
                                    if (medInteractions[s].ActiveIngredient2ID == activeIngrStrength1.ActiveIngrID)
                                    {
                                        error = "Medication " + viewModels[i].MedicationName + " should not be taken with madication " + medRep.GetMedication(item.MedID).MedicationName + ",";
                                        errors.Add(error);
                                    }
                                }
                            }
                        }
                    }



                }

            }
            if (errors.Count > 0)
            {
                AddPrescriptionViewModel model = new AddPrescriptionViewModel() { Medications= models};
                error = "";
                foreach (string item in errors)
                {
                    error = error + item + "\n";
                }
                model.alert = error;
                Notify(error, "Caution", NotificationType.warning);
                PrescriptionLine colec = prescriptionLineRepository.GetPrescriptionLine(models[1].LineID);
                PrescrLineAlert prescrLineAlert = new PrescrLineAlert();
                IEnumerable<PrescrLineAlert> lines = prescrLineAlertRepository.ListAlerts().Where(p => p.PrescriptionID == colec.PrescriptionID);
                foreach(var i in lines)
                {
                    if(i.PrescriptionID==colec.PrescriptionID)
                    {
                        prescrLineAlert = i;
                        break; }
                }
                model.Drreason = prescrLineAlert.Reason;
                return View("~/Views/PharmacistDashboard/Reason.cshtml", model);
            }
            PrescriptionLine prescriptionLine;
            List<DispenseDetails> details = new List<DispenseDetails>();
            List<PrescriptionLine> update = new List<PrescriptionLine>();
            for (int i = 0; i < viewModels.Count; i++)
            {
                prescriptionLine = prescriptionLineRepository.GetPrescriptionLine(viewModels[i].LineID);
                prescriptionLine.RepeatsLeft = prescriptionLine.RepeatsLeft - 1;
                update.Add(prescriptionLine);
                details.Add(new DispenseDetails() { Date = DateTime.Now, LineID = prescriptionLine.ID, PharmacistID = pharmacist.PharmacistID, PharmacyID = pharmacist.PharmacyID });
            }
            dispenseDetailsRepository.AddDispenseDetailsInBulk(details);
            prescriptionLineRepository.UpdatePrescriptionLineInBulk(update);

            Notify("Dispensed Successfully", "Success", NotificationType.success);
            return RedirectToAction("ListPrescriptionsForPharm", "Prescription");
        }
    }
}
