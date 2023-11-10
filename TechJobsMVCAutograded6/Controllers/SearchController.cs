using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVCAutograded6.Data;
using TechJobsMVCAutograded6.Models;

namespace TechJobsMVCAutograded6.Controllers;

public class SearchController : Controller
{
    List<Job> jobs = new List<Job>();

    // GET: /<controller>/
    public IActionResult Index()
    {
        ViewBag.columns = ListController.ColumnChoices;
        ViewBag.jobs = jobs;
        return View(jobs);
    }

    // TODO #3 - Create an action method to process a search request and render the updated search views.
    [HttpPost]
    public IActionResult Results(string searchType, string searchTerm)
    {
        ViewBag.title = $"Search Results for {searchTerm}";

        if (string.IsNullOrEmpty(searchTerm) && (searchType == "all"))
        {
            jobs = JobData.FindAll();

        }else
        {

            jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
        }
        ViewBag.columns = ListController.ColumnChoices;
        ViewBag.jobs = jobs;

        return View("Index");

    }

}
       
        


