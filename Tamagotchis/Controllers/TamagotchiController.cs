using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Tamagotchis.Models;

namespace Tamagotchis.Controllers
{
    public class TamagotchiController : Controller
    {
        [HttpGet("/tamagotchi")]
        public ActionResult Index()
        {
          List<Tama> allTama = Tama.GetAll();
            return View(allTama);
        }

        [HttpGet("/tamagotchi/new")]
        public ActionResult CreateForm()
        {
            return View();
        }

        [HttpPost("/tamagotchi")]
        public ActionResult Create()
        {
            Tama newTama = new Tama(Request.Form["name"]);
            List<Tama> allTama = Tama.GetAll();
            return View("Index", allTama);
        }

        [HttpGet("/tamagotchi/{id}")]
        public ActionResult Details(int id)
        {
            Tama tamagotchi = Tama.Find(id);
            return View(tamagotchi);
        }

        [HttpPost("/tamagotchi/{id}/feed")]
        public ActionResult CreateFeed(int id)
        {
            Tama tamagotchi = Tama.Find(id);
            tamagotchi.Feed();
            return View("Details", tamagotchi);
        }

        [HttpPost("/tamagotchi/{id}/sleep")]
        public ActionResult CreateSleep(int id)
        {
          Tama tamagotchi = Tama.Find(id);
          tamagotchi.MakeSleep();
          return View("Details", tamagotchi);
        }

        [HttpPost("/tamagotchi/{id}/play")]
        public ActionResult CreateAttention(int id)
        {
          Tama tamagotchi = Tama.Find(id);
          tamagotchi.Play();
          return View("Details", tamagotchi);
        }

        [HttpPost("/time")]
        public ActionResult AddTime()
        {
          Tama.Time();
          Tama.ClearDeadTama();
          List<Tama> allTama = Tama.GetAll();
          return View("Index", allTama);
        }
    }
}
