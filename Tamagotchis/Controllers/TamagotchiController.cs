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
            Tama.Time();
            Tama.CheckForDead();
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
            List<Tama> allTama = Tama.GetAll();
            tamagotchi.Feed();
            Tama.CheckForDead();
            return tamagotchi.IsDead() ? Index() : View("Details", tamagotchi);
        }

        [HttpPost("/tamagotchi/{id}/sleep")]
        public ActionResult CreateSleep(int id)
        {
            Tama tamagotchi = Tama.Find(id);
            List<Tama> allTama = Tama.GetAll();
            tamagotchi.MakeSleep();
            Tama.CheckForDead();
            return tamagotchi.IsDead() ? Index() : View("Details", tamagotchi);
        }

        [HttpPost("/tamagotchi/{id}/play")]
        public ActionResult CreateAttention(int id)
        {
            Tama tamagotchi = Tama.Find(id);
            List<Tama> allTama = Tama.GetAll();
            tamagotchi.Play();
            Tama.CheckForDead();
            return tamagotchi.IsDead() ? Index() : View("Details", tamagotchi);
        }

        [HttpPost("/time")]
        public ActionResult AddTime()
        {
            Tama.Time();
            Tama.CheckForDead();
            List<Tama> allTama = Tama.GetAll();
            return View("Index", allTama);
        }

        [HttpPost("/delete")]
        public ActionResult Delete()
        {
            Tama.ClearAll();
            List<Tama> allTama = Tama.GetAll();
            return View("Index", allTama);
        }
    }
}
