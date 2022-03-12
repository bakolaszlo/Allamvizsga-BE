#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataManager.Data;
using DataManager.Model;

namespace DataManager.Controllers
{
    [Route("api/data")]
    public class PerformancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PerformancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Data
        [HttpGet]
        public IEnumerable<Performance> Index()
        {
            return _context.Performances.ToList();
        }

        // GET: Data/Details/5
        [Route("/details/{id}")]
        [HttpGet]
        public Performance Details(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var performance = _context.Performances
                .FirstOrDefault(m => m.Id == id);
            if (performance == null)
            {
                return null;
            }

            return performance;
        }

        // GET: Performances/Create
        [HttpPost]
        public Performance Create([FromForm] Performance performance)
        {
            _context.Add(performance);
            _context.SaveChanges();
            return _context.Performances.FirstOrDefault(m => m.Id == performance.Id);
        }


        // GET: Performances/Edit/5
        [HttpPut]
        public Performance Edit([FromForm] Performance performance)
        {
            if (performance.Id == null)
            {
                return null;
            }

            var performanceToUpdate = _context.Performances.Find(performance.Id);
            if (performanceToUpdate == null)
            {
                return null;
            }
            _context.Performances.Update(performance);
            _context.SaveChanges();
            return performance;
        }

        
        // GET: Performances/Delete/5
        [HttpDelete]
        public Performance Delete(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var performance = _context.Performances
                .FirstOrDefault(m => m.Id == id);
            if (performance == null)
            {
                return null;
            }

            return performance;
        }

    }
}
