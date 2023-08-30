using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.Repositories;
using Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models.ViewModels;
using Microsoft.AspNetCore.Identity;


namespace Project.Controllers
{
    public class PrescriptionController : BaseControllerDoctor
    {
        private readonly IMedicationTakingRepository medicationTakingRepository;
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

        public PrescriptionController(IMedicationTakingRepository medicationTakingRepository,IDoctorRepository doctorRepository,IPrescrLineAlertRepository prescrLineAlertRepository,IMedInteractionRepository medInteractionRepository,IMedicalHistoryRepository medicalHistoryRepository,IConditionDiagnosisRepository conditionDiagnosisRepository,IPatientAllergyRepository patientAllergyRepository,SignInManager<ApplicationUser> _signInManager,IPatientConditionRepository _patientConditionRepository,IContraIndicationRepository contraIndicationRepository, IActiveIngrStrengthRepository _AISIDRepository,UserManager<ApplicationUser> _userManager, IPrescriptionRepository _prescriptionRep,ILineActiveIngreRepository _lineActiveIngreRepository,IMedicationRepository _medRep,IMedActiveIngredientRepository _medActIngrRep,IActiveIngredientRepository _AIRep,IActiveIngrStrengthRepository _AISRep, IstrengthRepository _strengthRep,IPrescriptionLineRepository _prescriptionLineRepository)
        {
            this.medicationTakingRepository = medicationTakingRepository;
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
        [HttpGet]
        public async Task<IActionResult> ListPrescriptions()
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            List<Prescription> model = prescriptionRep.ListPrescriptions().Where(p => p.PatientID == user.PatientID).ToList();
            List<DisplayPrescriptionViewModel> ViewModel = new List<DisplayPrescriptionViewModel>();
            for (int i = 0; i < model.Count; i++)
            {
                ViewModel.Add(new DisplayPrescriptionViewModel() { Prescription = model[i], Doctor = doctorRepository.GetDoctor(model[i].DoctorID) });
            }
            return View("~/Views/DoctorsDashboard/ListPrescriptions.cshtml", ViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> ListPrescriptionsForPharm()
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            List<Prescription> model = prescriptionRep.ListPrescriptions().Where(p => p.PatientID == user.PatientID).ToList();
            List<DisplayPrescriptionViewModel> ViewModel = new List<DisplayPrescriptionViewModel>();
            for (int i = 0; i < model.Count; i++)
            {
                ViewModel.Add(new DisplayPrescriptionViewModel() { Prescription=model[i],Doctor=doctorRepository.GetDoctor(model[i].DoctorID)});
            }
            return View("~/Views/PharmacistDashboard/ListPrescriptions.cshtml", ViewModel);
        }
        [HttpGet]
        public IActionResult ListPrescriptionMedication(int id)
        {
            List<PrescriptionLine> theLines = prescriptionLineRepository.ListPrescriptionLines().Where(z => z.PrescriptionID == id).ToList();
            List<MedicationViewModel> Model = new List<MedicationViewModel>();
            MedicationViewModel medication;
            UnitMedicationViewModel unitMedication;
            List<MedActiveIngredient> newLine = new List<MedActiveIngredient>();
            Medication medication1;
            ActiveIngrStrength activeIngrStrength = new ActiveIngrStrength();Strength strength = new Strength();
            for (int i = 0; i < theLines.Count; i++)
            {
                medication = new MedicationViewModel();
                medication.ActiveIngredients = new List<UnitMedicationViewModel>();
                medication1 = medRep.GetMedication(theLines[i].MedID);
                medication.MedicationID = medication1.ID;
                medication.MedicationName = medication1.MedicationName;
                medication.Instruction = theLines[i].Instruction;
                medication.repeats = theLines[i].Repeats;
                medication.Qty = theLines[i].Quantity;
                medication.repeatsLeft = theLines[i].RepeatsLeft;
                newLine = medActIngrRep.ListMedActiveIngredients().Where(z => z.MedID == theLines[i].MedID).ToList();
                for (int j = 0; j < newLine.Count; j++)
                {
                    unitMedication = new UnitMedicationViewModel();
                    activeIngrStrength = AISRep.GetAIStrength(newLine[j].AISID);
                    unitMedication.ActiveIngredient = AIRep.GetActiveIngredient(activeIngrStrength.ActiveIngrID);
                    unitMedication.Strength =  strengthRep.GetStrength(activeIngrStrength.StrengthID);
                    medication.ActiveIngredients.Add(unitMedication);
                }
                Model.Add(medication);
            }
            return View("~/Views/DoctorsDashboard/ListPrescriptionMeds.cshtml", Model);
        }
        [HttpGet]
        public IActionResult ListPrescriptionMedicationForPharm(int id)
        {
            List<PrescrLineAlert> alerts = prescrLineAlertRepository.ListAlerts().Where(z => z.PrescriptionID == id).ToList();
            PrescrLineAlert alert = new PrescrLineAlert();
            foreach (var item in alerts)
            {
                if(item.PrescriptionID==id)
                {
                    alert = item;
                    Notify(alert.Alert, "Caution", NotificationType.warning);
                    break;
                }
            };
            
            List<PrescriptionLine> theLines = prescriptionLineRepository.ListPrescriptionLines().Where(z => z.PrescriptionID == id).ToList();
            List<MedicationViewModel> Model = new List<MedicationViewModel>();
            MedicationViewModel medication;
            UnitMedicationViewModel unitMedication;
            List<MedActiveIngredient> newLine = new List<MedActiveIngredient>();
            Medication medication1;
            ActiveIngrStrength activeIngrStrength = new ActiveIngrStrength(); Strength strength = new Strength();
            for (int i = 0; i < theLines.Count; i++)
            {
                medication = new MedicationViewModel();
                medication.ActiveIngredients = new List<UnitMedicationViewModel>();
                medication1 = medRep.GetMedication(theLines[i].MedID);
                medication.MedicationID = medication1.ID;
                medication.MedicationName = medication1.MedicationName;
                medication.Instruction = theLines[i].Instruction;
                medication.LineID = theLines[i].ID;
                medication.repeats = theLines[i].Repeats;
                medication.Qty = theLines[i].Quantity;
                medication.repeatsLeft = theLines[i].RepeatsLeft;
                newLine = medActIngrRep.ListMedActiveIngredients().Where(z => z.MedID == theLines[i].MedID).ToList();
                for (int j = 0; j < newLine.Count; j++)
                {
                    unitMedication = new UnitMedicationViewModel();
                    activeIngrStrength = AISRep.GetAIStrength(newLine[j].AISID);
                    unitMedication.ActiveIngredient = AIRep.GetActiveIngredient(activeIngrStrength.ActiveIngrID);
                    unitMedication.Strength = strengthRep.GetStrength(activeIngrStrength.StrengthID);
                    medication.ActiveIngredients.Add(unitMedication);
                }
                Model.Add(medication);
            }
            return View("~/Views/PharmacistDashboard/ListPrescriptionMeds.cshtml", Model);
        }
        [HttpGet]
         public IActionResult AddPrescription(AddPrescriptionViewModel model)
        {
            List<Medication> Meds = medRep.ListMedications().OrderBy(z=>z.MedicationName).ToList();
            ViewBag.Medication = Meds;
            
            return View("~/Views/DoctorsDashboard/AddPrescription.cshtml",model);
        }
        [HttpPost]
        public IActionResult CancelPrescription(int id)
        {
            Prescription prescription=  prescriptionRep.GetPrescription(id);
            prescriptionRep.DeletePrescription(prescription);
            List<PrescriptionLine> lines = prescriptionLineRepository.ListPrescriptionLines().Where(z=> z.PrescriptionID==id).ToList();
            prescriptionLineRepository.DeletePrescriptionLineInBulk(lines);
            return RedirectToAction("ListPrescriptions");
        }
        [HttpGet]
        public IActionResult MedicationFiller(AddPrescriptionViewModel model)
        {
            MedicationViewModel viewModel = new MedicationViewModel() { ActiveIngredients=new List<UnitMedicationViewModel>()};
            viewModel.MedicationName = medRep.GetMedication(model.Current.MedicationID).MedicationName;
            viewModel.MedicationID = model.Current.MedicationID;
            viewModel.repeats = model.Current.repeats;
            viewModel.Qty = model.Current.Qty;
            viewModel.Instruction = model.Current.Instruction;
            
            if(model.Medications==null)
            {
                model.Medications = new List<MedicationViewModel>();
            }
         
         
                model.Medications.Add(viewModel);

            List<Medication> Meds = medRep.ListMedications().OrderBy(z=>z.MedicationName).ToList();
            ViewBag.Medication = Meds;
            model.Current = new MedicationViewModel();

            return View("~/Views/DoctorsDashboard/AddPrescription.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPrescriptionPost(AddPrescriptionViewModel model)
        {
            try
            {

                PrescriptionLine prescriptionLine;
                List<PrescriptionLine> prescriptionLines = new List<PrescriptionLine>();
                ApplicationUser user = await userManager.GetUserAsync(User);
                Prescription Submint = new Prescription() { Status = "ACTIVE", DoctorID = user.LoginID, PatientID = user.PatientID, Date = DateTime.Now };
                //Check contra-indication
                List<PatientCondition> patientConditions = patientConditionRepository.ListPatientConditions().Where(z=>z.PatientID==user.PatientID).ToList();
                List<MedicalHistory> medicalHistories = medicalHistoryRepository.ListMedicalHistories().Where(z => z.PatientID == user.PatientID).ToList();
                List<PatientAllergy> allergies = patientAllergyRepository.ListePatientAllergies().Where(z => z.PatientID == user.PatientID).ToList();
                List<MedicationTaking> medicationTakings = medicationTakingRepository.ListMedicationTakings().Where(z => z.PatientID == user.PatientID).ToList();
                List<MedActiveIngredient> medActiveIngredients;
                List<MedActiveIngredient> medActiveIngredients1;
                List<MedInteraction> medInteractions = medInteractionRepository.ListMedInteractions();
                ActiveIngrStrength activeIngrStrength;
                ActiveIngrStrength activeIngrStrength1;
                
                List<string> errors = new List<string>();
                string error = "";

                for (int i = 0; i < model.Medications.Count; i++)
                {
                    //Checking for medication already taking
                    foreach (MedicationTaking item in medicationTakings)
                        {

                            if (item.MedID == model.Medications[i].MedicationID)
                            {
                                error =  "Patient is already taking"+ model.Medications[i].MedicationName+ ",";
                                errors.Add(error);      
                            }
                        }
                    medActiveIngredients = medActIngrRep.ListMedActiveIngredients().Where(z => z.MedID == model.Medications[i].MedicationID).ToList();
                    for (int j = 0; j < medActiveIngredients.Count; j++)
                    {
                        activeIngrStrength = aISIDRepository.GetAIStrength(medActiveIngredients[j].AISID);
                        //checking for patient allergy 
                        foreach (PatientAllergy item in allergies)
                        {
                            if (item.ActiveIngredientID == activeIngrStrength.ActiveIngrID)
                            {
                                error =  "Patient has an allergy on " + AIRep.GetActiveIngredient(item.ActiveIngredientID).ActiveIngredientName + ",";
                                 errors.Add(error);
                            }
                        }
                        //Checking for contra-indication in patient conditions
                        for (int r = 0; r < patientConditions.Count; r++)
                        {
                            foreach (var item in contraIndicationRepository.ListContraIndication())
                            {
                                if (item.ConditionID == patientConditions[r].ConditionID && activeIngrStrength.ActiveIngrID==item.ActiveIngredientID)
                                {
                                    error = "Patient with condition " + conditionDiagnosisRepository.GetConditionDiagnosis(patientConditions[r].ConditionID).DiagnosisName + "can not take medication containing "+AIRep.GetActiveIngredient(activeIngrStrength.ActiveIngrID) +",";
                                    errors.Add(error);
                                }
                            }
                        }
                        //Checking for contra-indication in patient medical history
                        for (int r = 0; r < medicalHistories.Count; r++)
                        {
                            foreach (var item in contraIndicationRepository.ListContraIndication())
                            {
                                if (item.ConditionID == medicalHistories[r].ConditionID && activeIngrStrength.ActiveIngrID == item.ActiveIngredientID)
                                {
                                    error = "Patient with condition " + conditionDiagnosisRepository.GetConditionDiagnosis(medicalHistories[r].ConditionID).DiagnosisName + "can not take medication containing " + AIRep.GetActiveIngredient(activeIngrStrength.ActiveIngrID) + ",";
                                    errors.Add(error);
                                }
                            }
                        }
                        for (int s = 0; s < medInteractions.Count; s++)
                        {
                            if(medInteractions[s].ActiveIngredient1ID==activeIngrStrength.ActiveIngrID)
                            {
                                //checking for medication interaction on presription
                                for (int p = 0; p < model.Medications.Count; p++)
                                {
                                    medActiveIngredients1 = medActIngrRep.ListMedActiveIngredients().Where(z => z.MedID == model.Medications[p].MedicationID).ToList();
                                    for (int q = 0; q < medActiveIngredients1.Count; q++)
                                    {
                                        activeIngrStrength1 = aISIDRepository.GetAIStrength(medActiveIngredients1[q].AISID);
                                        if (medInteractions[s].ActiveIngredient2ID == activeIngrStrength1.ActiveIngrID)
                                        {
                                            error =  "Medication "+model.Medications[i].MedicationName+" should not be taken with madication "+model.Medications[p].MedicationName+",";
                                             errors.Add(error);
                                    }
                                    }
                                }
                                //checking for medication interaction on medication already taking
                                foreach (MedicationTaking item in medicationTakings)
                                {
                                    medActiveIngredients1 = medActIngrRep.ListMedActiveIngredients().Where(z => z.MedID == item.MedID).ToList();
                                    for (int q = 0; q < medActiveIngredients1.Count; q++)
                                    {
                                        activeIngrStrength1 = aISIDRepository.GetAIStrength(medActiveIngredients1[q].AISID);
                                        if (medInteractions[s].ActiveIngredient2ID == activeIngrStrength1.ActiveIngrID)
                                        {
                                            error = "Medication " + model.Medications[i].MedicationName + " should not be taken with madication " + medRep.GetMedication(item.MedID).MedicationName + ",";
                                            errors.Add(error);
                                        }
                                    }
                                }
                            }
                        }



                        }
                   
                }
            if (errors.Count > 0) {
            error = "";
            foreach (string item in errors)
            {
                error = error +item +"\n";
            }
                    model.alert = error;
            Notify(error, "Caution", NotificationType.warning);
                return View("~/Views/DoctorsDashboard/Reason.cshtml", model);
            }
            
            Prescription prescription = prescriptionRep.AddPrescription(Submint);
               
                for (int i = 0; i < model.Medications.Count; i++)
                {
                    prescriptionLine = new PrescriptionLine();
                    prescriptionLine.Instruction = model.Medications[i].Instruction;
                    prescriptionLine.PrescriptionID = prescription.ID;
                    prescriptionLine.MedID = model.Medications[i].MedicationID;
                    prescriptionLine.Repeats = model.Medications[i].repeats;
                    prescriptionLine.RepeatsLeft = model.Medications[i].repeats;
                    prescriptionLine.Quantity = model.Medications[i].Qty;
                   prescriptionLineRepository.AddPrescriptionLine(prescriptionLine);
                  

                }

            Notify(" saved successfully");
        }
            catch (Exception ex)
            {
                
            }
            return RedirectToAction("ListPrescriptions");
        }
        [HttpPost]
        public async Task<IActionResult> AddPrescriptionAfterAlert(AddPrescriptionViewModel model)
        {
            try
            {

                PrescriptionLine prescriptionLine;
            List<PrescriptionLine> prescriptionLines = new List<PrescriptionLine>();
            ApplicationUser user = await userManager.GetUserAsync(User);
            Prescription Submint = new Prescription() { Status = "ACTIVE", DoctorID = user.LoginID, PatientID = user.PatientID, Date = DateTime.Now };
                //Check contra-indication
               

            Prescription prescription = prescriptionRep.AddPrescription(Submint);
            PrescrLineAlert alert = new PrescrLineAlert() {PrescriptionID=prescription.ID,Reason=model.reason,Alert=model.alert};
                prescrLineAlertRepository.AddAlert(alert);
            for (int i = 0; i < model.Medications.Count; i++)
            {
                prescriptionLine = new PrescriptionLine();
                prescriptionLine.Instruction = model.Medications[i].Instruction;
                prescriptionLine.PrescriptionID = prescription.ID;
                prescriptionLine.MedID = model.Medications[i].MedicationID;
                prescriptionLine.Repeats = model.Medications[i].repeats;
                    prescriptionLine.RepeatsLeft = model.Medications[i].repeats;
                    prescriptionLine.Quantity = model.Medications[i].Qty;
                    prescriptionLine = prescriptionLineRepository.AddPrescriptionLine(prescriptionLine);


            }

            Notify(" saved successfully");
        }
            catch (Exception ex)
            {

            }
            return RedirectToAction("ListPrescriptions");
        }


        [HttpGet]
        public IActionResult AddMedToPrescription(AddPrescriptionViewModel model)
        {
            Medication medication = medRep.GetMedication(model.Current.MedicationID);
            model.Current.MedicationName = medication.MedicationName;
            model.Current.MedicationID = medication.ID;
            model.Current.ActiveIngredients = new List<UnitMedicationViewModel>();
            List<MedActiveIngredient> MedIngres = medActIngrRep.ListMedActiveIngredients().Where(z => z.MedID == model.Current.MedicationID).ToList();
            List<ActiveIngredient> ingredients = new List<ActiveIngredient>();
            List<ActiveIngrStrength> activeIngrStrengths;
            ActiveIngredient activeIngredient = new ActiveIngredient();
            List<StrengthViewModel> Temp = new List<StrengthViewModel>(); int count = 0;
            StrengthViewModel strength;
            //foreach (MedActiveIngredient MAI in MedIngres)
            //{

            //    activeIngredient = AIRep.GetActiveIngredient(MAI.ActiveIngredientID);
            //    activeIngrStrengths = AISRep.ListAIStrengths().Where(z => z.ActiveIngrID == activeIngredient.ID).ToList();
            //    ingredients.Add(activeIngredient);
            //    strength = new StrengthViewModel() { ActiveIngredient = activeIngredient, Strengths = new List<Strength>() };
            //    model.Current.ActiveIngredients.Add(new UnitMedicationViewModel() { ActiveIngredient = activeIngredient, Strength = new Strength() }); ;
            //    Temp.Add(strength);
            //    foreach (ActiveIngrStrength AIS in activeIngrStrengths)
            //    {


            //        Temp[count].Strengths.Add(strengthRep.GetStrength(AIS.StrengthID));

            //    }
            //    count++;
            //}
           
            ViewBag.ActiveIngredients = ingredients;
            ViewBag.Strengths = Temp;
            return View("~/Views/DoctorsDashboard/AddMedToPrescription.cshtml", model);
        }

    }
}
