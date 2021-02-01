using DulkyBook.Data;
using DulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DulkyBook.Controllers
{
    public class DictionaryController : Controller
    {
        private readonly DulkyBookDbContext _entity;
        public DictionaryController(DulkyBookDbContext entity)
        {
            _entity = entity;
        }

        public IActionResult Index()
        {
            var response = _entity.Dictionary.Select(d => new RoundModel()
            {
                Round = d.Round.ToString(),
                Flag = d.Flag
            }).Distinct().OrderBy(x => Convert.ToInt32(x.Round)).ToList();

            return View(response);
        }

        public IActionResult GetRound(int round, string flag)
        {
            var response = new List<DictionaryModel>();
            if (flag != null && flag.Equals("s"))
            {
                response = _entity.Dictionary.Where(d => d.Round == round && d.Flag.Equals("s")).Select(d => new DictionaryModel
                {
                    Id = d.Id,
                    English = d.English,
                    Serbian = d.Serbian,
                    Round = d.Round
                }).OrderBy(x => Guid.NewGuid()).ToList();
            }
            else if (flag != null && flag.Equals("w"))
            {
                response = _entity.Dictionary.Where(d => d.Round == round && d.Flag.Equals("w")).Select(d => new DictionaryModel
                {
                    Id = d.Id,
                    English = d.English,
                    Serbian = d.Serbian,
                    Round = d.Round
                }).OrderBy(x => Guid.NewGuid()).ToList();
            }
            else
            {
                response = _entity.Dictionary.Where(d => d.Round == round && d.Flag == null).Select(d => new DictionaryModel
                {
                    Id = d.Id,
                    English = d.English,
                    Serbian = d.Serbian,
                    Round = d.Round
                }).OrderBy(x => Guid.NewGuid()).ToList();
            }
            
            return Json(response);
        }
    }
}
