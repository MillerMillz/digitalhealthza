using Microsoft.AspNetCore.Authorization;
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
    public class Admin : BaseControllerAdmin
    {

        private readonly IAdminRepository admin;
        private readonly IMedActiveIngredientRepository medActiveIngredientRepository;

        public Admin(IAdminRepository adm,IMedActiveIngredientRepository _medActiveIngredientRepository)
        {
            admin = adm;
            medActiveIngredientRepository = _medActiveIngredientRepository;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        //Doctor
        public ViewResult GetDoctor()
        {
            var model = admin.GetAllDoctor();
            return View("GetDoctorEdit", model);
        }

        [HttpPost]
        public ViewResult Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                Doctor newDoctor = admin.AddDoctor(doctor);

            }
            return View();
        }
        public IActionResult AddDoctor()
        {
            return View("~/Views/Admin/addDoctor.cshtml");
        }

        [HttpPost]
        public RedirectToActionResult AddDoctor(Doctor doctor)
        {
            try
            {
                Doctor newDoctor = admin.AddDoctor(doctor);
                //try save data into database
                NotifyDoctor(" saved successfully");
            }
            catch (Exception)
            {

            }

            return RedirectToAction("GetAllDoctor");
        }
        [HttpGet]
        public ViewResult GetAllDoctor()
        {
            IEnumerable<Doctor> model = admin.GetAllDoctor();
            return View("GetAllDoctor", model);
        }
        [HttpGet]

        public ViewResult GetDoctorEdit(int id)
        {
            Doctor d = admin.GetDoctorEdit(id);
            return View(d);
        }
        [HttpPost]
        public RedirectToActionResult EditDoctor(Doctor doctor)
        {

            try
            {
                admin.EditDoctor(doctor);
                //try save data into database
                NotifyDoctor(" Updated successfully");
            }
            catch (Exception)
            {

            }
            return RedirectToAction("getalldoctor");
        }
        public RedirectToActionResult DeleteDoctor(int id)
        {

            try
            {
                admin.DeleteDoctor(id);
                //try save data into database
                NotifyDoctor(" Deleted successfully");
            }
            catch (Exception)
            {

            }
            return RedirectToAction("getalldoctor");
        }
        public ViewResult ViewDoctor(int id)
        {
            var model = admin.ViewDoctor(id);
            return View("ViewDoctor", model);
        }


        //Pharmacist


        public ViewResult GetPharmacist()
        {
            var model = admin.GetAllPharmacist();
            return View("GetPharmacistEdit", model);
        }

        [HttpPost]
        public ViewResult Create(Pharmacist pharmacist)
        {
            if (ModelState.IsValid)
            {
                Pharmacist newPharmacist = admin.AddPharmacist(pharmacist);

            }
            return View();
        }
        public IActionResult AddPharmacist()
        {
            return View("~/Views/Admin/addPharmacist.cshtml");
        }
        [HttpPost]
        public RedirectToActionResult AddPharmacist(Pharmacist pharmacist)
        {
            try
            {
                Pharmacist newPharmacistr = admin.AddPharmacist(pharmacist);
                //try save data into database
                NotifyPharmacist(" saved successfully");
            }
            catch (Exception)
            {

            }

            return RedirectToAction("GetAllPharmacist");
        }
        [HttpGet]
        public ViewResult GetAllPharmacist()
        {
            IEnumerable<Pharmacist> model = admin.GetAllPharmacist();
            return View("GetAllPharmacist", model);
        }
        [HttpGet]

        public ViewResult GetPharmacistEdit(int id)
        {
            Pharmacist p = admin.GetPharmacistEdit(id);
            return View(p);
        }
        [HttpPost]
        public RedirectToActionResult EditPharmacist(Pharmacist pharmacist)
        {

            try
            {
                admin.EditPharmacist(pharmacist);
                //try save data into database
                NotifyPharmacist(" Updated successfully");
            }
            catch (Exception)
            {

            }
            return RedirectToAction("getallpharmacist");
        }
        public RedirectToActionResult DeletePharmacist(int id)
        {

            try
            {
                admin.DeletePharmacist(id);
                //try save data into database
                NotifyPharmacist(" Deleted successfully");
            }
            catch (Exception)
            {

            }
            return RedirectToAction("getallpharmacist");
        }
        public ViewResult ViewPharmacist(int id)
        {
            var model = admin.ViewPharmacist(id);
            return View("ViewPharmacist", model);
        }



        //Practice
        public ViewResult GetPractice()
        {
            var model = admin.GetAllPractice();
            return View("GetPractice", model);
        }


        [HttpPost]
        public ViewResult Create(MedPractice practice)
        {
            if (ModelState.IsValid)
            {
                MedPractice newMedPractice = admin.AddPractice(practice);


            }
            return View();
        }



        [HttpGet]
        public ViewResult AddPractice()
        {
            return View("~/Views/Admin/addPractice.cshtml");
        }

        [HttpPost]
        public RedirectToActionResult AddPractice(MedPractice practice)
        {


            try
            {
                MedPractice newMedPractice = admin.AddPractice(practice);
                //try save data into database
                NotifyPractice(" saved successfully");
            }
            catch (Exception)
            {

            }
            return RedirectToAction("GetAllPractice");
        }
        [HttpGet]
        public ViewResult GetAllPractice()
        {
            var model = admin.GetAllPractice();
            return View("GetAllPractice", model);
        }
        [HttpGet]
        public ViewResult GetPracticeeEdit(int id)
        {
            MedPractice m = admin.GetPracticeEdit(id);
            return View(m);
        }
        [HttpPost]
        public RedirectToActionResult EditPractice(MedPractice practice)
        {
            try
            {

                admin.EditPractice(practice);
                //try save data into database
                NotifyPractice(" Updated successfully");
            }
            catch (Exception)
            {

            }

            return RedirectToAction("getallpractice");
        }
        public RedirectToActionResult DeletePractice(int id)
        {


            try
            {

                admin.DeletePractice(id);
                //try save data into database
                //Notify("Creche Deleted successfully");
            }
            catch (Exception)
            {

            }
            return RedirectToAction("getallpractice");
        }
        [HttpGet]
        public ViewResult ViewPractice(int id)
        {
            var model = admin.ViewPractice(id);
            return View("ViewPractice", model);
        }







        //Pharmacy
        public ViewResult GetPharmacy()
        {
            var model = admin.GetAllPharmacy();
            return View("GetPharmacy", model);
        }


        [HttpPost]
        public ViewResult Create(Pharmacy pharmacy)
        {
            if (ModelState.IsValid)
            {
                Pharmacy newPharmacy = admin.AddPharmacy(pharmacy);


            }
            return View();
        }



        [HttpGet]
        public ViewResult AddPharmacy()
        {
            return View("~/Views/Admin/addPractice.cshtml");
        }

        [HttpPost]
        public RedirectToActionResult AddPharmacy(Pharmacy pharmacy)
        {


            try
            {
                Pharmacy newPharmacy = admin.AddPharmacy(pharmacy);
                //try save data into database
                NotifyPharmacy(" saved successfully");
            }
            catch (Exception)
            {

            }
            return RedirectToAction("GetAllPharmacy");
        }
        [HttpGet]
        public ViewResult GetAllPharmacy()
        {
            var model = admin.GetAllPharmacy();
            return View("GetAllPharmacy", model);
        }
        [HttpGet]
        public ViewResult GetPharmacyEdit(int id)
        {
            Pharmacy p = admin.GetPharmacyEdit(id);
            return View(p);
        }
        [HttpPost]
        public RedirectToActionResult EditPharmacy(Pharmacy pharmacy)
        {
            try
            {

                admin.EditPharmacy(pharmacy);
                //try save data into database
                NotifyPharmacy(" Updated successfully");
            }
            catch (Exception)
            {

            }

            return RedirectToAction("getallpharmacy");
        }
        public RedirectToActionResult DeletePharmacy(int id)
        {


            try
            {

                admin.DeletePharmacy(id);
                //try save data into database
                NotifyPharmacy(" Deleted successfully");
            }
            catch (Exception)
            {

            }
            return RedirectToAction("getallpharmacy");
        }

        public ViewResult ViewPharmacy(int id)
        {
            var model = admin.ViewPharmacy(id);
            return View("ViewPharmacy", model);
        }



        //Active Ingredient 
        public ViewResult GetActiveIngredient()
        {
            var model = admin.GetAllActiveIngredient();
            return View("GetActiveIngredient", model);
        }


        [HttpPost]
        public ViewResult Create(ActiveIngredient ingredient)
        {
            if (ModelState.IsValid)
            {
                ActiveIngredient newActiveIngredient = admin.AddActiveIngredient(ingredient);

            }
            return View();
        }


        [HttpGet]
        public IActionResult AddActiveIngredient()
        {
            return View("~/Views/Admin/addActiveIngredient.cshtml");
        }

        [HttpPost]
        public RedirectToActionResult AddActiveIngredient(ActiveIngredient ingredient)
        {


            try
            {
                ActiveIngredient newActiveIngredient = admin.AddActiveIngredient(ingredient);
                //try save data into database
                Notify("saved successfully");
            }
            catch (Exception)
            {

            }
            return RedirectToAction("GetAllActiveIngredient");
        }



        [HttpGet]
        public ViewResult GetAllActiveIngredient()
        {
            var model = admin.GetAllActiveIngredient();
            return View("GetAllActiveIngredient", model);
        }
        [HttpGet]
        public ViewResult GetActiveIngredientEdit(int id)
        {
            ActiveIngredient a = admin.GetActiveIngredientEdit(id);
            return View(a);
        }

        [HttpPost]
        public RedirectToActionResult EditActiveIngredient(ActiveIngredient ingredient)
        {
            try
            {

                admin.EditActiveIngredient(ingredient);
                //try save data into database
                Notify("Updated successfully");
            }
            catch (Exception)
            {

            }

            return RedirectToAction("getallactiveingredient");
        }
        public RedirectToActionResult DeleteActiveIngredient(int id)
        {


            try
            {

                admin.DeleteActiveIngredient(id);
                //try save data into database
                Notify(" Deleted successfully");
            }
            catch (Exception)
            {

            }
            return RedirectToAction("getallactiveingredient");
        }


       


        public ViewResult ViewActiveIngredient(int id)
        {
            var model = admin.ViewActiveIngredient(id);
            return View("ViewActiveIngredient", model);
        }



        //Condition
        public ViewResult GetCondition()
        {
            var model = admin.GetAllCondition();
            return View("GetConditionEdit", model);
        }


        [HttpPost]
        public ViewResult Create(ConditionDiagnosis condition)
        {
            if (ModelState.IsValid)
            {
                ConditionDiagnosis newConditionDiagnosis = admin.AddCondition(condition);


            }
            return View();
        }



        public IActionResult AddCondition()
        {
            return View("~/Views/Admin/addCondition.cshtml");
        }

        [HttpPost]
        [AllowAnonymous]
        public RedirectToActionResult AddCondition(ConditionDiagnosis condition)
        {


            try
            {
                ConditionDiagnosis newConditionDiagnosis = admin.AddCondition(condition);
                //try save data into database
                NotifyCondition(" saved successfully");
            }
            catch (Exception)
            {

            }
            return RedirectToAction("GetAllCondition");
        }

        [HttpGet]
        public ViewResult GetAllCondition()
        {
            var model = admin.GetAllCondition();
            return View("GetAllCondition", model);
        }

        [HttpGet]
        public ViewResult GetConditionEdit(int id)
        {
            ConditionDiagnosis c = admin.GetConditionEdit(id);
            return View(c);
        }

        [HttpPost]
        public RedirectToActionResult EditCondition(ConditionDiagnosis condition)
        {
            try
            {

                admin.EditCondition(condition);
                //try save data into database
                NotifyCondition(" Updated successfully");
            }
            catch (Exception)
            {

            }

            return RedirectToAction("getallcondition");
        }

        public RedirectToActionResult DeleteCondition(int id)
        {


            try
            {

                admin.DeleteCondition(id);
                //try save data into database
                NotifyCondition(" Deleted successfully");
            }
            catch (Exception)
            {

            }
            return RedirectToAction("getallcondition");
        }


        public ViewResult ViewCondition(int id)
        {
            var model = admin.GetCondition(id);
            return View("ViewCondition", model);
        }



        //Medication
        public ViewResult GetMedication()
        {
            var model = admin.GetAllMedication();
            return View("GetMedication", model);
        }


        [HttpPost]
        public ViewResult Create(Medication medication)
        {
            if (ModelState.IsValid)
            {
                Medication newMedication = admin.AddMedication(medication);


            }
            return View();
        }
        [HttpGet]
        public IActionResult ActiveIngredientFilter(MedActive model)
        {
            ViewBag.ActiveIngredients = admin.GetAllActiveIngredient();
            if (model.ActiveIngredients == null)
            {
                model.ActiveIngredients = new List<ActiveIngredient>();

            }
            ActiveIngredient active = new ActiveIngredient();
            active = admin.GetActiveIngredient(model.ID);
            model.ActiveIngredients.Add(active);
            return View("~/Views/Admin/addMedication.cshtml", model );

        }

       


        [HttpGet]
        public ViewResult AddMedication()
        {
            MedActive model = new MedActive()
            {
                ActiveIngredients = new List<ActiveIngredient>()
            };

            ViewBag.ActiveIngredients = admin.GetAllActiveIngredient();
            return View("~/Views/Admin/addMedication.cshtml",model);
        }




        [HttpPost]
        public RedirectToActionResult AddMedication(MedActive model)
        {


            try
            {
                Medication newMedication = admin.AddMedication(model.Medication);
                List<MedActiveIngredient> ingredients = new List<MedActiveIngredient>();
                foreach (ActiveIngredient item in model.ActiveIngredients)
                {
                    //ingredients.Add(new MedActiveIngredient() {ActiveIngredientID=item.ID,MedID=model.Medication.ID });
                }
                medActiveIngredientRepository.AddMedActiveIngredientInBulk(ingredients); ;
                
                //try save data into database
                NotifyMedication(" saved successfully");
            }
            catch (Exception)
            {

            }
            return RedirectToAction("GetAllMedication");
        }
        [HttpGet]
        public ViewResult GetAllMedication()
        {
            List<Medication> medications = admin.GetAllMedication().ToList();
            List<MedActiveIngredient> medActives;
            List<ActiveIngredient> activeIngredients;
            List<MedActive> model = new List<MedActive>();
            for (int i = 0; i < medications.Count; i++) 
            { activeIngredients = new List<ActiveIngredient>();
                 medActives = medActiveIngredientRepository.ListMedActiveIngredients().Where(z => z.MedID == medications[i].ID).ToList();
                for (int j = 0; j < medActives.Count; j++)
                {
                  //  activeIngredients.Add(admin.GetActiveIngredient(medActives[j].ActiveIngredientID));
                }
                model.Add(new MedActive() { Medication = medications[i], ActiveIngredients = activeIngredients });
            }
            return View("GetAllMedication", model);
        }

        [HttpGet]
        public ViewResult GetMedicationEdit(int id)
        {
            Medication m = admin.GetMedicationEdit(id);
            return View(m);
        }
        [HttpPost]
        public RedirectToActionResult EditMedication(Medication medication)
        {
            try
            {

                admin.EditMedication(medication);
                //try save data into database
                NotifyMedication(" Updated successfully");
            }
            catch (Exception)
            {

            }

            return RedirectToAction("getallmedication");
        }
        public RedirectToActionResult DeleteMedication(int id)
        {


            try
            {

                admin.DeleteMedication(id);
                //try save data into database
                Notify(" Deleted successfully");
            }
            catch (Exception)
            {

            }
            return RedirectToAction("getallmedication");
        }

        [HttpGet]
        public ViewResult GetMedication(int id)
        {
            var model = admin.GetMedications(id);
            return View("ViewMedication", model);
        }


    }
}
