using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using fantastic.Controllers;
using fantastic.Models;
using fantastic.Models.ManageViewModels;
using fantastic.Services;
using fantastic.Data;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace SportTest
{
    [TestClass]
    public class UnitTest1
    {
        static ILoggerFactory loggerFactory = new LoggerFactory()
            .AddConsole()
            .AddDebug();
        ILogger logger = loggerFactory.CreateLogger<UnitTest1>();
        private ApplicationDbContext _context;
        public UnitTest1(ApplicationDbContext context)
        {
            _context = context;
        }

        //public void TestMethod1()
        //{
        //}

        [TestMethod]
        public void IndexShowsSomething()
        {
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            //var password = "hallo";
            //userManager = await UserManager.CreateAsync(userStore.Object, password);
            var controller = new HomeController(null, null, null);
            var result = controller.Index();
            logger.LogDebug("here's the result:");
            logger.LogDebug(result.ToString());
            Assert.IsNotNull(result);
            //var connection = new SqliteConnection("DataSource=:memory:");
            //connection.Open();
            //try
            //{
            //    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            //        .UseSqlite(connection)
            //        .Options;

            //    using (var context = new ApplicationDbContext(options))
            //    {
            //        context.Database.EnsureCreated();
            //    }
            //}
            //finally
            //{
            //    connection.Close();
            //}
        }
    }
}
