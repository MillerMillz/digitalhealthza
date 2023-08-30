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
    public class MedtakingController : Controller
    {
        private readonly IMedicationTakingRepository medicationTakingRepository;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMedicationRepository medicationRepository;

        public MedtakingController(IMedicationTakingRepository _medicationTakingRepository, SignInManager<ApplicationUser> _signInManager, UserManager<ApplicationUser> _userManager, IMedicationRepository _medicationRepository)
        {
            medicationTakingRepository = _medicationTakingRepository;
            signInManager = _signInManager;
            userManager = _userManager;
            medicationRepository = _medicationRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddMedication()
        {
            Try model = new Try();
            ViewBag.Medication = medicationRepository.ListMedications().OrderBy(z => z.MedicationName).ToList();
            return View("~/Views/DoctorsDashboard/MedsTakin.cshtml",model);
        }
        [HttpGet]
        public IActionResult MedicationFiller(Try model)
        {
            ViewBag.Medication = medicationRepository.ListMedications().OrderBy(z => z.MedicationName).ToList();
            if (model.states==null)
            {
                model.states = new List<Medication>();
                model.Dates = new List<DateTime>();
            }
            
            Medication medication = new Medication() ;
            medication = medicationRepository.GetMedication(model.ID);
            model.states.Add(medication);
            model.Dates.Add(DateTime.Now);
            return View("~/Views/DoctorsDashboard/MedsTakin.cshtml",model);
        }
        [HttpPost]
        public async Task<IActionResult> AddMedication(Try model)
        {
            List<MedicationTaking> medicationTakings = new List<MedicationTaking>();
            MedicationTaking medication;
            ApplicationUser user = await userManager.GetUserAsync(User);
            if (model.states != null)
            {
                int i = 0;
                foreach (Medication item in model.states)
                {
                    medication = new MedicationTaking()
                    {
                        MedID = item.ID,
                        PatientID = user.PatientID,
                        Date=model.Dates[i]
                    };
                    medicationTakings.Add(medication);
                    i++;
                }
            }
            medicationTakingRepository.AddMedicationTakingInBulk(medicationTakings);
            return RedirectToAction("AddPatientAllergies", "Patientallergy");
        }
    }
}
