﻿using System.Threading.Tasks;
using Canvas.v1.Managers;
using Canvas.v1.Models;
using Canvas.v1.Models.Request;
using Canvas.v1.Wrappers;
using Canvas.v1.Wrappers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Canvas.v1.Test
{
    [TestClass]
    public class BoxCommentsManagerTest : BoxResourceManagerTest
    {
        protected BoxCommentsManager _commentsManager;

        public BoxCommentsManagerTest()
        {
            _commentsManager = new BoxCommentsManager(_config.Object, _service, _converter, _authRepository);
        }

        [TestMethod]
        public async Task AddComment_ValidResponse_ValidComment()
        {
            /*** Arrange ***/
            string responseString = "{\"type\":\"comment\",\"id\":\"191969\",\"is_reply_comment\":false,\"message\":\"These tigers are cool!\",\"created_by\":{\"type\":\"user\",\"id\":\"17738362\",\"name\":\"sean rose\",\"login\":\"sean@box.com\"},\"created_at\":\"2012-12-12T11:25:01-08:00\",\"item\":{\"id\":\"5000948880\",\"type\":\"file\"},\"modified_at\":\"2012-12-12T11:25:01-08:00\"}";
            _handler.Setup(h => h.ExecuteAsync<BoxComment>(It.IsAny<IBoxRequest>()))
                .Returns(Task.FromResult<IBoxResponse<BoxComment>>(new BoxResponse<BoxComment>()
                {
                    Status = ResponseStatus.Success,
                    ContentString = responseString
                }));

            /*** Act ***/
            BoxCommentRequest request = new BoxCommentRequest()
            {
                Item = new BoxRequestEntity()
                {
                    Id = "fakeId",
                    Type = BoxType.file
                },
                Message = "fake message"
            };
            BoxComment c = await _commentsManager.AddCommentAsync(request);

            /*** Assert ***/
            Assert.AreEqual("comment", c.Type);
            Assert.AreEqual("191969", c.Id);
            Assert.AreEqual("These tigers are cool!", c.Message);
        }

        [TestMethod]
        public async Task GetCommentInformation_ValidResponse_ValidComment()
        {
            /*** Arrange ***/
            string responseString = "{\"type\":\"comment\",\"id\":\"191969\",\"is_reply_comment\":false,\"message\":\"These tigers are cool!\",\"created_by\":{\"type\":\"user\",\"id\":\"17738362\",\"name\":\"sean rose\",\"login\":\"sean@box.com\"},\"created_at\":\"2012-12-12T11:25:01-08:00\",\"item\":{\"id\":\"5000948880\",\"type\":\"file\"},\"modified_at\":\"2012-12-12T11:25:01-08:00\"}";
            _handler.Setup(h => h.ExecuteAsync<BoxComment>(It.IsAny<IBoxRequest>()))
                .Returns(Task.FromResult<IBoxResponse<BoxComment>>(new BoxResponse<BoxComment>()
                {
                    Status = ResponseStatus.Success,
                    ContentString = responseString
                }));

            /*** Act ***/
            BoxComment c = await _commentsManager.GetInformationAsync("fakeId");

            /*** Assert ***/
            Assert.AreEqual("comment", c.Type);
            Assert.AreEqual("191969", c.Id);
            Assert.AreEqual("These tigers are cool!", c.Message);
        }

        [TestMethod]
        public async Task UpdateComment_ValidResponse_ValidComment()
        {
            /*** Arrange ***/
            string responseString = "{\"type\":\"comment\",\"id\":\"191969\",\"is_reply_comment\":false,\"message\":\"These tigers are cool!\",\"created_by\":{\"type\":\"user\",\"id\":\"17738362\",\"name\":\"sean rose\",\"login\":\"sean@box.com\"},\"created_at\":\"2012-12-12T11:25:01-08:00\",\"item\":{\"id\":\"5000948880\",\"type\":\"file\"},\"modified_at\":\"2012-12-12T11:25:01-08:00\"}";
            _handler.Setup(h => h.ExecuteAsync<BoxComment>(It.IsAny<IBoxRequest>()))
                .Returns(Task.FromResult<IBoxResponse<BoxComment>>(new BoxResponse<BoxComment>()
                {
                    Status = ResponseStatus.Success,
                    ContentString = responseString
                }));

            /*** Act ***/
            BoxCommentRequest request = new BoxCommentRequest()
            {
                Message = "fakeMessage"
            };

            BoxComment c = await _commentsManager.UpdateAsync("fakeId", request);

            /*** Assert ***/
            Assert.AreEqual("comment", c.Type);
            Assert.AreEqual("191969", c.Id);
            Assert.AreEqual("These tigers are cool!", c.Message);
        }

    }
}