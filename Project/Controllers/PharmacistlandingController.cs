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
    public class PharmacistlandingController : BaseControllerPharmacist
    {
        private readonly IConditionDiagnosisRepository conditionDiagnosisRepository;
        private readonly IPatientRepository patientRepository;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPharmacistRepository pharmacistRepository;
        private readonly ISurburbRepository surburbRepository;
        private readonly ICityRepository cityRepository;
        private readonly IProvinceRepository provinceRepository;

        public PharmacistlandingController(IConditionDiagnosisRepository _conditionDiagnosisRepository, IPatientRepository _patientRepository, SignInManager<ApplicationUser> _signInManager, UserManager<ApplicationUser> _userManager,IPharmacistRepository pharmacistRepository, ISurburbRepository _surburbRepository, ICityRepository _cityRepository, IProvinceRepository _provinceRepository)
        {
            conditionDiagnosisRepository = _conditionDiagnosisRepository;
            patientRepository = _patientRepository;
            signInManager = _signInManager;
            userManager = _userManager;
            this.pharmacistRepository = pharmacistRepository;
            surburbRepository = _surburbRepository;
            cityRepository = _cityRepository;
            provinceRepository = _provinceRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/PharmacistDashboard/Landing.cshtml");
        }
        [HttpGet]
        public async Task<IActionResult> PatientSearch(Patient patient)
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            Pharmacist pharm = pharmacistRepository.GetPharmacistByUserID(user.Id);
            Patient Temp = new Patient();
            List<Patient> patients = patientRepository.ListPatients().Where(k => k.IDNumber == patient.IDNumber).ToList();
            if (patients.Count == 0)
            {
                NotifyPatientNotFound("ID number not found in the database");
                return View("~/Views/PharmacistDashboard/Landing.cshtml");
            }
            foreach (Patient a in patients)
            {
                if (a.IDNumber == patient.IDNumber)
                {
                    Temp = a;
                    break;
                }
            }
            user.Surname = pharm.PharmacistSurname;
            user.LoginID = pharm.PharmacistID;
            user.PatientID = Temp.PatientID;
            await userManager.UpdateAsync(user);
          
            return RedirectToAction("PatientDetails");
        }
        [HttpGet]
        public async Task<IActionResult> PatientDetails()
        {
            DisplayPatientViewModel model = new DisplayPatientViewModel();
            ApplicationUser user = await userManager.GetUserAsync(User);
            model.Patient = patientRepository.GetPatient(user.PatientID);
            model.Surburb = surburbRepository.GetSurburb(model.Patient.SurburbID);
            model.city = cityRepository.GetCity(model.Surburb.CityID);
            model.Province = provinceRepository.GetProvince(model.city.ProvinceID);
            return View("~/Views/PharmacistDashboard/PatientDetails.cshtml", model);
        }
    }
}
