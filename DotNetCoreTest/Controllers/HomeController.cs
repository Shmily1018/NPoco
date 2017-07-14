using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NPoco;

namespace DotNetCoreTest.Controllers
{
    public class MyDb : Database
    {
        public MyDb(string connectionString, DatabaseType databaseType, DbProviderFactory provider) : base(connectionString, databaseType, provider)
        {
        }

        public override void OnExecutingCommand(DbCommand cmd)
        {
            File.WriteAllText("log.txt", FormatCommand(cmd));
        }
    }

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
