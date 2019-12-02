using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dojeopardy.Models;

namespace dojeopardy.Controllers
{
    public class HomeController : Controller
    {
        public List<Pet> Pets { get; set; }

        public HomeController()
        {
            Pets = MakePets();
        }
        //GENERAL LINQOLIGY?
            //QUESTION: What LINQ command would I use to get a single item matching some provided criteria if it exsists, or null if it doesn't. 
            //ANSWER: first or default

            //QEUSTION: What do linq queries return? 
            //ANSWER: IEnumerable

            //QUESTION: What is the "=>" and what is it used for (Maybe definition of lambda?)
            //ANSWER: Lambda


        [HttpGet("")]
        public IActionResult Result()
        {

            return View("Result", this.Pets);
        }







        //PREDICT THE OUTPUT
        [HttpGet("predict/1")]
        public IActionResult Predict1()
        {
            var somePet = Pets.FirstOrDefault(p=>p.Type=="Cat");
            return RedirectToAction("Result");
        }

        [HttpGet("predict/2")]
        public IActionResult Predict2()
        {
            var somePets = Pets.Where(p=>p.Type=="Cat").OrderBy(p=>p.TimesUsedInDemos).ToList();
            return RedirectToAction("Result");
        }


        [HttpGet("predict/3")]
        public IActionResult Predict3()
        {
            var somePets = Pets.Select(p=>p.Name).ToList();
            return RedirectToAction("Result");
        }








        //SWAT THE BUG


        [HttpGet("buggy/1")]
        public IActionResult Buggy1()
        {
            // List<Pet> somePets = Pets.Where(p=>p.Name=="Rover");
            return RedirectToAction("Result");
        }


        [HttpGet("buggy/2")]
        public IActionResult Buggy2()
        {
            // List<Pet> somePets = Pets.Select(p=>p.Name).ToList();
            return RedirectToAction("Result");
        }


        [HttpGet("buggy/3")]
        public IActionResult Buggy3()
        {
            //IEnumerable<Pet> somePet = Pets.Where(p=>p.Name=="Nick Furry" && p.Type=="Cat"); 
            return RedirectToAction("Result");
        }





        
        //WRITE THAT QUERY

        public IActionResult writeIt1()
        {
            //get all pets who have been demo-ed more than 10 times
            IEnumerable<Pet> lowercasePets = Pets.Where(p=>p.TimesUsedInDemos>10);
            return RedirectToAction("Result");
        }

        public IActionResult writeIt2()
        {
            //get one pet that is named Rover and is a dog

            return RedirectToAction("Result");
        }

        public IActionResult writeIt3()
        {
            //get pets with e in their name, ordered by how many times they've been demo-ed

            return RedirectToAction("Result");
        }





        public static List<Pet> MakePets()
        {
            List<Pet> allPets = new List<Pet>();
            Pet pet1 = new Pet("Nick Furry", "Cat", 42);
            Pet pet2 = new Pet("Rover", "Cat", 3);
            Pet pet3 = new Pet("Rover", "Dog", 12);
            Pet pet4 = new Pet("Fluffy", "Turtle", 16);
            Pet pet5 = new Pet("Tweety", "Bird", 0);
            Pet pet6 = new Pet("Peeve", "Dog", 2);
            Pet pet7 = new Pet("Captain Reginald", "Fish", 6);
            Pet pet8 = new Pet("Fantasia", "Rat", 7);
            Pet pet9 = new Pet("Ink Eyes", "Rat", 7);
            Pet pet10 = new Pet("Leela", "Dog", 29);
            allPets.Add(pet1);
            allPets.Add(pet2);
            allPets.Add(pet3);
            allPets.Add(pet4);
            allPets.Add(pet5);
            allPets.Add(pet6);
            allPets.Add(pet7);
            allPets.Add(pet8);
            allPets.Add(pet9);
            allPets.Add(pet10);
            return allPets;
        }
    }
}
