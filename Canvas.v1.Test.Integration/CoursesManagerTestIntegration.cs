﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Canvas.v1.Config;
using Canvas.v1.Models;
using Canvas.v1.Models.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Canvas.v1.Test.Integration
{
    [TestClass]
    public class CoursesManagerTestIntegration : ResourceManagerTestIntegration
    {
        [TestMethod]
        public async Task GetAllAccountsManageableByUser()
        {
            var courses = await _client.CoursesManager.GetAll();
        }
    }
}