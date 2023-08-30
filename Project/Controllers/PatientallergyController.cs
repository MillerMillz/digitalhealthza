using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class PatientallergyController : BaseControllerDoctor
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IPatientRepository patientRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IActiveIngredientRepository activeIngredientRepository;
        private readonly IPatientAllergyRepository patientAllergyRepository;

        public PatientallergyController(SignInManager<ApplicationUser> _signInManager,IPatientRepository _patientRepository, UserManager<ApplicationUser> _userManager,IActiveIngredientRepository _activeIngredientRepository,IPatientAllergyRepository _patientAllergyRepository)
        {
            signInManager = _signInManager;
            patientRepository = _patientRepository;
            userManager = _userManager;
            activeIngredientRepository = _activeIngredientRepository;
            patientAllergyRepository = _patientAllergyRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ListAllergies()
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            List<PatientAllergy> patientAllergies = patientAllergyRepository.ListePatientAllergies().Where(Z => Z.PatientID == user.PatientID).ToList();
            List<ActiveIngredient> model = new List<ActiveIngredient>();
            foreach  (PatientAllergy allergy in patientAllergies)
            {
                model.Add(activeIngredientRepository.GetActiveIngredient(allergy.ActiveIngredientID));
            }
            return View("~/Views/DoctorsDashboard/ListAllergies.cshtml", model);
        }
        [HttpGet]
        public async Task<IActionResult> ListAllergiesForPharm()
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            List<PatientAllergy> patientAllergies = patientAllergyRepository.ListePatientAllergies().Where(Z => Z.PatientID == user.PatientID).ToList();
            List<ActiveIngredient> model = new List<ActiveIngredient>();
            foreach (PatientAllergy allergy in patientAllergies)
            {
                model.Add(activeIngredientRepository.GetActiveIngredient(allergy.ActiveIngredientID));
            }
            return View("~/Views/PharmacistDashboard/ListAllergies.cshtml", model);
        }
        [HttpGet]
        public IActionResult AddPatientAllergies()
        {
            AllergyViewModel model = new AllergyViewModel()
            {
                states = activeIngredientRepository.ListActiveIngredients()
            };
            return View("~/Views/DoctorsDashboard/Allergies.cshtml",model);
        }
        [HttpPost]
        public async Task<IActionResult> AddPatientAllergies(AllergyViewModel model)
        {
            try
            {

                List<PatientAllergy> patientAllergies = new List<PatientAllergy>();
                PatientAllergy patientAllergy;
                ApplicationUser user = await userManager.GetUserAsync(User);
                Patient patient = patientRepository.GetPatient(user.PatientID);
                if (model.Selection != null)
                {
                    foreach (int item in model.Selection)
                    {
                        patientAllergy = new PatientAllergy()
                        {
                            ActiveIngredientID = item,
                            PatientID = user.PatientID
                        };
                        patientAllergies.Add(patientAllergy);
                    }
                }
                patientAllergyRepository.AddPatientAllergyInBulk(patientAllergies);
                patient.IsNew = "No";
                patientRepository.UpdatePatient(patient);

                Notify("Medical History Added Successfully", "Medical History", NotificationType.success);

            }
            catch (Exception)
            {

            }
        
            return RedirectToAction("PatientDetails", "Drlanding");

           
        }
        [HttpGet]
        public IActionResult AddPatientAllergies2()
        {
            AllergyViewModel model = new AllergyViewModel() ;
           
            ViewBag.ActiveIngredients = activeIngredientRepository.ListActiveIngredients().OrderBy(z=>z.ActiveIngredientName);
            return View("~/Views/DoctorsDashboard/AddAllergies.cshtml",model);
        }
        [HttpGet]
        public IActionResult AllergyFiller(AllergyViewModel model)
        {
            ViewBag.ActiveIngredients = activeIngredientRepository.ListActiveIngredients().OrderBy(z => z.ActiveIngredientName);
            if (model.states == null)
            {
                model.states = new List<ActiveIngredient>();
            }
            ActiveIngredient activeIngredient = new ActiveIngredient();
            activeIngredient = activeIngredientRepository.GetActiveIngredient(model.ID);
            model.states.Add(activeIngredient);
            return View("~/Views/DoctorsDashboard/AddAllergies.cshtml", model);
        }
        [HttpPost]
        public async Task<IActionResult> AddPatientAllergies2(AllergyViewModel model)
        {
            List<PatientAllergy> patientAllergies = new List<PatientAllergy>();
            PatientAllergy patientAllergy;
            ApplicationUser user = await userManager.GetUserAsync(User);
            if (model.states != null)
            {
                foreach (ActiveIngredient item in model.states)
                {
                    patientAllergy = new PatientAllergy()
                    {
                        ActiveIngredientID = item.ID,
                        PatientID = user.PatientID
                    };
                    patientAllergies.Add(patientAllergy);
                }
            }
            patientAllergyRepository.AddPatientAllergyInBulk(patientAllergies);
            return RedirectToAction("ListAllergies");
        }
    }
}
