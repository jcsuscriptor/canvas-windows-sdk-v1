﻿using System.Threading.Tasks;
using Canvas.v1.Managers;
using Canvas.v1.Models;
using Canvas.v1.Wrappers;
using Canvas.v1.Wrappers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Canvas.v1.Test
{
    [TestClass]
    public class BoxSearchManagerTest : BoxResourceManagerTest
    {
        protected BoxSearchManager _searchManager;

        public BoxSearchManagerTest()
        {
            _searchManager = new BoxSearchManager(_config.Object, _service, _converter, _authRepository);
        }

        [TestMethod]
        public async Task SearchKeyword_ValidResponse_ValidResults()
        {
            /*** Arrange ***/
            string responseString = "{\"total_count\":4,\"entries\":[{\"type\":\"file\",\"id\":\"1874102965\",\"sequence_id\":\"0\",\"etag\":\"0\",\"sha1\":\"63a112a4567fb556f5269735102a2f24f2cbea56\",\"name\":\"football.jpg\",\"description\":\"\",\"size\":260271,\"path_collection\":{\"total_count\":1,\"entries\":[{\"type\":\"folder\",\"id\":\"0\",\"sequence_id\":null,\"etag\":null,\"name\":\"All Files\"}]},\"created_at\":\"2012-03-22T18:25:07-07:00\",\"modified_at\":\"2012-10-25T14:40:05-07:00\",\"created_by\":{\"type\":\"user\",\"id\":\"175065494\",\"name\":\"Andrew Luck\",\"login\":\"aluck@colts.com\"},\"modified_by\":{\"type\":\"user\",\"id\":\"175065494\",\"name\":\"Andrew Luck\",\"login\":\"aluck@colts.com\"},\"owned_by\":{\"type\":\"user\",\"id\":\"175065494\",\"name\":\"Andrew Luck\",\"login\":\"aluck@colts.com\"},\"shared_link\":null,\"parent\":{\"type\":\"folder\",\"id\":\"0\",\"sequence_id\":null,\"etag\":null,\"name\":\"All Files\"},\"item_status\":\"active\"}],\"offset\":0,\"limit\":1}";
            _handler.Setup(h => h.ExecuteAsync<BoxCollection<BoxItem>>(It.IsAny<IBoxRequest>()))
                .Returns(Task.FromResult<IBoxResponse<BoxCollection<BoxItem>>>(new BoxResponse<BoxCollection<BoxItem>>()
                {
                    Status = ResponseStatus.Success,
                    ContentString = responseString
                }));

            /*** Act ***/
            BoxCollection<BoxItem> results = await _searchManager.SearchAsync("fakeKeyword", 10);

            /*** Assert ***/
            Assert.AreEqual(4, results.TotalCount);
        }
    }
}