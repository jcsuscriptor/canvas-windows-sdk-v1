﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Canvas.v1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Canvas.v1.Test.Integration.Managers
{
    [TestClass]
    public class AccountsManagerTestIntegration : ResourceManagerTestIntegration
    {

        [TestMethod]
        public async Task GetAllAccountsManageableByUser()
        {
            var accounts = await _client.AccountsManager.GetAll();
            Console.Out.WriteLine(string.Join("\n", accounts));
        }

        [TestMethod]
        public async Task GetAccountById()
        {
            var account = await _client.AccountsManager.Get(AccountId);
            Console.Out.WriteLine(account);
        }

        [TestMethod]
        public async Task GetCoursesById()
        {
            var courses = await _client.AccountsManager.GetCourses(AccountId);
            Console.Out.WriteLine(string.Join("\n", courses));
        }

        [TestMethod]
        public async Task GetCoursesById_SpecificStates()
        {
            var courses = await _client.AccountsManager.GetCourses(AccountId, state: CourseWorkflowState.Completed );
            Console.Out.WriteLine(string.Join("\n", courses));
        }

        [TestMethod]
        public async Task GetUsers()
        {
            var courses = await _client.AccountsManager.GetUsers(AccountId);
            Console.Out.WriteLine(string.Join("\n", courses));
        }

        [TestMethod]
        [Ignore]
        // This can cause long delays and/or timeouts (504) on large accounts.
        public async Task GetUsers_SearchByLoginId()
        {
            var courses = await _client.AccountsManager.GetUsers(AccountId, itemsPerPage: 3, searchTerm: "jhoerr");
            Console.Out.WriteLine(string.Join("\n", courses));
        }

        [TestMethod]
        public async Task GetCoursesById_SpecificUser()
        {
            var courses = await _client.AccountsManager.GetCourses(AccountId, byTeachers: new long[] { 5639813 });
            Console.Out.WriteLine(string.Join("\n", courses));
        }
    }
}