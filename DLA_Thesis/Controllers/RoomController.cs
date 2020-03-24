using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using DLA_Thesis.Data.Model;
using DLA_Thesis.Data.Model.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DLA_Thesis.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository roomRepository;
        private readonly ITeacherRepository teacherRepo;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IStudentRepository studentRepo;

        public RoomController(IRoomRepository roomRepository,  ITeacherRepository teacherRepo, IHostingEnvironment hostingEnvironment, IStudentRepository studentRepo)
        {
            this.roomRepository = roomRepository;
            this.teacherRepo = teacherRepo;
            this.hostingEnvironment = hostingEnvironment;
            this.studentRepo = studentRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(Room room)
        {
            if (roomRepository.FindRoom(a => a.RoomNumber == room.RoomNumber) != null)
                return View("Index");

            roomRepository.Create(room);
            return View("Index");
        }



    }
}