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
    public class ConditionController : BaseControllerDoctor
    {
        private readonly IMedicalHistoryRepository medicalHistoryRepository;
        private readonly IPatientConditionRepository patientConditionRepository;
        private readonly IConditionDiagnosisRepository conditionDiagnosisRepository;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public ConditionController(IMedicalHistoryRepository _medicalHistoryRepository,IPatientConditionRepository _patientConditionRepository,IConditionDiagnosisRepository _conditionDiagnosisRepository,SignInManager<ApplicationUser> _signInManager,UserManager<ApplicationUser> _userManager)
        {
            medicalHistoryRepository = _medicalHistoryRepository;
            patientConditionRepository = _patientConditionRepository;
            conditionDiagnosisRepository = _conditionDiagnosisRepository;
            signInManager = _signInManager;
            userManager = _userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ListConditions()
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            List<PatientCondition> patientConditions = patientConditionRepository.ListPatientConditions().Where(z => z.PatientID == user.PatientID).ToList();
            List<ConditionDiagnosis> model = new List<ConditionDiagnosis>();
            foreach (PatientCondition item in patientConditions)
            {
                model.Add(conditionDiagnosisRepository.GetConditionDiagnosis(item.ConditionID));
            }
            return View("~/Views/DoctorsDashboard/ListConditions.cshtml",model);
        }
        [HttpGet]
        public async Task<IActionResult> ListConditionsForPharm()
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            List<PatientCondition> patientConditions = patientConditionRepository.ListPatientConditions().Where(z => z.PatientID == user.PatientID).ToList();
            List<ConditionDiagnosis> model = new List<ConditionDiagnosis>();
            foreach (PatientCondition item in patientConditions)
            {
                model.Add(conditionDiagnosisRepository.GetConditionDiagnosis(item.ConditionID));
            }
            return View("~/Views/PharmacistDashboard/ListConditions.cshtml", model);
        }
        [HttpGet]
        public IActionResult AddCondition()
        {
            ViewBag.Conditions = conditionDiagnosisRepository.ListConditionDiagnoses().OrderBy(z => z.DiagnosisName);
            AddConditionViewModel model = new AddConditionViewModel();
            return View("~/Views/DoctorsDashboard/MedHistory.cshtml",model);
        }
        [HttpGet]
        public IActionResult ConditionFiller(AddConditionViewModel model)
        {
            ViewBag.Conditions = conditionDiagnosisRepository.ListConditionDiagnoses().OrderBy(z => z.DiagnosisName);
            if (model.conditions == null)
            {
                model.conditions = new List<UnitCondition>();
            }
            ConditionDiagnosis condition = new ConditionDiagnosis();
            condition = conditionDiagnosisRepository.GetConditionDiagnosis(model.ID);
            model.conditions.Add(new UnitCondition() { Condition =condition,Date=DateTime.Today});
            return View("~/Views/DoctorsDashboard/MedHistory.cshtml", model);
        }
        [HttpPost]
        public async Task<IActionResult> AddCondition(AddConditionViewModel model)
        {
            try
            {
                ApplicationUser user = await userManager.GetUserAsync(User);
                List<MedicalHistory> patientConditions = new List<MedicalHistory>();
                MedicalHistory condition;
                if (model.conditions != null)
                {
                    for (int i = 0; i < model.conditions.Count; i++)
                    {
                        condition = new MedicalHistory()
                        {
                            PatientID = user.PatientID,
                            ConditionID = model.conditions[i].Condition.ID,
                            Date = model.conditions[i].Date

                        };
                        patientConditions.Add(condition);
                    }
                }
                medicalHistoryRepository.AddMedicalHistoryInBulk(patientConditions);
             
                return RedirectToAction("AddMedication", "Medtaking");
            }
            catch(Exception)
            {

            }
            return View("~/Views/DoctorsDashboard/MedHistory.cshtml");
          
        }
        [HttpGet]
        public IActionResult ConditionFiller2(AddConditionViewModel model)
        {
            ViewBag.Conditions = conditionDiagnosisRepository.ListConditionDiagnoses().OrderBy(z => z.DiagnosisName);
            if (model.conditions == null)
            {
                model.conditions = new List<UnitCondition>();
            }
            ConditionDiagnosis condition = new ConditionDiagnosis();
            condition = conditionDiagnosisRepository.GetConditionDiagnosis(model.ID);
            model.conditions.Add(new UnitCondition() { Condition = condition, Date = DateTime.Today });
            return View("~/Views/DoctorsDashboard/AddConditions.cshtml", model);
        }
        public IActionResult AddCondition2()
        {
            ViewBag.Conditions = conditionDiagnosisRepository.ListConditionDiagnoses().OrderBy(z => z.DiagnosisName);
            AddConditionViewModel model = new AddConditionViewModel();
            return View("~/Views/DoctorsDashboard/AddConditions.cshtml", model);
        }
    
        [HttpPost]
        public async Task<IActionResult> AddCondition2(AddConditionViewModel model)
        {

            try
           {
            ApplicationUser user = await userManager.GetUserAsync(User);
            List<PatientCondition> patientConditions = new List<PatientCondition>();
            PatientCondition condition;
            if (model.conditions != null)
            {
                for (int i = 0; i < model.conditions.Count; i++)
                {
                    condition = new PatientCondition()
                    {
                        PatientID = user.PatientID,
                        ConditionID = model.conditions[i].Condition.ID,
                        
                    };
                    patientConditions.Add(condition);
                }
            }
            patientConditionRepository.AddPatientConditionInBulk(patientConditions);
                NotifyCondition(" saved successfully");
                return RedirectToAction("ListConditions");
            }
            catch (Exception)
            {

            }
            ViewBag.Conditions = conditionDiagnosisRepository.ListConditionDiagnoses().OrderBy(z => z.DiagnosisName);
            return View("~/Views/DoctorsDashboard/AddConditions.cshtml",model);
        }
    }

}
