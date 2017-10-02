using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_OnlineCourse.Models;
using MVC_OnlineCourse.Models.MSSQL;

namespace MVC_OnlineCourse.Controllers
{
    public class StudentController : Controller
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentController(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }


        // GET: Student
        [HttpGet]
        public ActionResult Index()
        {
            return View(_studentRepository.GetList());
        }

        [HttpGet]
        public ActionResult StudentForm()
        {


            return View(new Student());
        }

        [HttpGet]
        public ActionResult Edit(int studentID)
        {
            var _student = _studentRepository.SingleRecord(s => s.ID == studentID);
            return View("StudentForm", _student);
        }

        [HttpGet]
        public ActionResult Delete(int studentID)
        {
            var _student = _studentRepository.SingleRecord(s => s.ID == studentID);
            _studentRepository.Delete(_student);
            _studentRepository.Save();
            return RedirectToAction("Index","Student");
        }
        [HttpPost]
        public ActionResult Save(Student _student)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = _student;

                return View("StudentForm", viewModel);
            }

            if (_student.ID == 0)
            {
                _studentRepository.Add(_student);
            }
            else
            {
                _studentRepository.Edit(_student);
            }
            
            _studentRepository.Save();
            return RedirectToAction("Index","Student");
        }
    }
}