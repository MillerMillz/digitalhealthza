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
    public class DrlandingController : BaseControllerDoctor
    {
        private readonly IConditionDiagnosisRepository conditionDiagnosisRepository;
        private readonly IPatientRepository patientRepository;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDoctorRepository doctorRepository;
        private readonly ISurburbRepository surburbRepository;
        private readonly ICityRepository cityRepository;
        private readonly IProvinceRepository provinceRepository;

        public DrlandingController(IConditionDiagnosisRepository _conditionDiagnosisRepository,IPatientRepository _patientRepository,SignInManager<ApplicationUser> _signInManager,UserManager<ApplicationUser> _userManager,IDoctorRepository _doctorRepository,ISurburbRepository _surburbRepository,ICityRepository _cityRepository,IProvinceRepository _provinceRepository)
        {
            conditionDiagnosisRepository = _conditionDiagnosisRepository;
            patientRepository = _patientRepository;
            signInManager = _signInManager;
            userManager = _userManager;
            doctorRepository = _doctorRepository;
            surburbRepository = _surburbRepository;
            cityRepository = _cityRepository;
            provinceRepository = _provinceRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/DoctorsDashboard/Landing.cshtml");
        }
        [HttpGet]
        public async Task<IActionResult> PatientSearch(Patient patient)
        {
            ApplicationUser user = await userManager.GetUserAsync(User);
            Doctor doc = doctorRepository.GetDoctorByUserId(user.Id);
            Patient Temp = new Patient();
            List<Patient> patients = patientRepository.ListPatients().Where(k => k.IDNumber == patient.IDNumber).ToList();
            if(patients.Count==0)
            {
                NotifyPatientNotFound("ID number not found in the database");
                return View("~/Views/DoctorsDashboard/Landing.cshtml");
            }
            foreach(Patient a in patients)
            {
                if(a.IDNumber==patient.IDNumber)
                {
                    Temp = a;
                    break;
                }
            }
            user.Surname = doc.DoctorSurname;
            user.LoginID = doc.DoctorID;
            user.PatientID = Temp.PatientID;
            await userManager.UpdateAsync(user);
            if (Temp.IsNew=="YES")
            {

                Notify("Please Enter medical history", "New Patient Alert", NotificationType.info);
                return RedirectToAction("AddCondition","Condition"); }
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
            return View("~/Views/DoctorsDashboard/PatientDetails.cshtml",model);
        }
    }
}
