using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net.Http.Headers;
using Xceed.Wpf.Toolkit;
using ForumWPF.Model;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        HttpClient client;

        [TestInitialize]
        public void TestsInit()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:47503");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

        [TestMethod]
        public void testGetForums()
        {
            Logger.filePath = @"C:\Users\WIN8\Desktop\logger.txt";
            HttpResponseMessage response = client.GetAsync("api/forum/getForums").Result;

            string logms = response.IsSuccessStatusCode.ToString();

            Logger.filePath = @"C:\Users\WIN8\Desktop\logger.txt";
            Logger.log(logms);

            if (response.IsSuccessStatusCode)
            {
                var forums = response.Content.ReadAsAsync<IEnumerable<Forum>>().Result;
                foreach (Forum f in forums)
                {
                    Logger.log(f.header);
                }

                Logger.log("TestGetForums-Success");
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void testRegister()
        {
            int ForumId = 1;
            string email = "tzaveyHaNinja@gmail.com", gender = "Female", username = "ShaqilO'neil", password = "MasterSplinter";
            DateTime dob = DateTime.Now;
            HttpResponseMessage response = client.GetAsync("api/forum/register/" + ForumId + "/" + email + "/" + dob.Year + "-" + dob.Month + "-" + dob.Day + "/" + gender + "/" + username + "/" + password).Result;
           

            if (response.IsSuccessStatusCode)
            {
                var ans = response.Content.ReadAsAsync<int>().Result;
                
                Logger.log(ans.ToString());
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);

        }

        /*[TestMethod]
        public void testRegister()
        {

            HttpResponseMessage response = client.GetAsync("api/forum/registerUser").Result;
            
            string logms = response.IsSuccessStatusCode.ToString();
            
            Logger.filePath = @"C:\Users\WIN8\Desktop\logger.txt";
            Logger.log(logms);

            if (response.IsSuccessStatusCode)
            {
                var forums = response.Content.ReadAsAsync<int>().Result;
                //foreach (Forum f in forums)
                //{
                //    Console.WriteLine(f.header);
                //}
                Logger.filePath = @"C:\Users\WIN8\Desktop\logger.txt";
                Logger.log("TestGetForums-Success2");
                Assert.IsTrue(true);
            }
        }*/

        /*[TestMethod]
        public void testGetPosts()
        {
            int forumId = 0;
            int subForumId = 0;
            HttpResponseMessage response = client.GetAsync("api/forum/getPosts/" + forumId + "/" + subForumId).Result;
            if (response.IsSuccessStatusCode)
            {
                var posts = response.Content.ReadAsAsync<IEnumerable<Post>>().Result;
                foreach (Post f in posts)
                {
                    Console.WriteLine(f.title);
                }
                Assert.IsTrue(true);
            }
        }*/

        /*

        UserHandler uh = UserHandler.Instance;
        ForumHandler fh = ForumHandler.Instance();
        //User Tests
        [TestMethod]
        public void TestRegister()
        {
            //Arrange
            string password = "BenTheKing123", email = "bentheking@gmail.com", gender = "Female", userName = "THEBEST";
            DateTime birth = DateTime.Now;
            //Act
            int ans = uh.RegisterUser(email, userName, password, gender, birth, 1);
            //Assert
            Assert.AreEqual(ans, Constants.SUCCESS);
        }
        [TestMethod]
        public void TestSignIn()
        {
            //Arrange
            fh.getAllForums();
            fh.GetSubForums(1);
            uh.SignOutUser("bentheking@gmail.com");
            string password = "BenTheKing123", email = "bentheking@gmail.com";
            //Act
            int ans = uh.SignInUser(email, password);
            //Assert
            Assert.AreEqual(ans, Constants.SUCCESS);
        }

        //Forum Tests
        [TestMethod]
        public void TestsGetAllForums()
        {
            //Act
            int ans = fh.getAllForums();
            //Assert
            Assert.AreEqual(ans, Constants.SUCCESS);
        }
        [TestMethod]
        public void TestGetSubForums()
        {
            //Arrange
            int forumID = 1;
            //Act
            int ans = fh.GetSubForums(forumID);
            //Assert
            Assert.AreEqual(ans, Constants.SUCCESS);
        }
        [TestMethod]
        public void TestGetThreads()
        {
            //Arrange
            int subForumID = 1;
            //Act
            int ans = fh.GetThreads(subForumID);
            //Assert
            Assert.AreEqual(ans, Constants.SUCCESS);
        }
        [TestMethod]
        public void TestGetReplies()
        {
            //Arrange
            int threadId = 1;
            //Act
            int ans = fh.GetReplies(threadId);
            //Assert
            Assert.AreEqual(ans, Constants.SUCCESS);
        }


        [TestMethod]
        public void TestAddSubForum()
        {
            string subForumName = "Rebelde Way";
            int forumID = 1;
            int ans = fh.AddSubForum(subForumName);
            Assert.AreEqual(ans, Constants.SUCCESS);
        }*/
    }
}
