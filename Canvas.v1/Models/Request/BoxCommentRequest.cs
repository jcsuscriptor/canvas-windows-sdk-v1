﻿using Newtonsoft.Json;

namespace Canvas.v1.Models.Request
{
    /// <summary>
    /// A request class for making comment requests
    /// </summary>
    public class BoxCommentRequest
    {
        /// <summary>
        /// The item that this comment will be placed on.
        /// </summary>
        [JsonProperty(PropertyName = "item")]
        public BoxRequestEntity Item { get; set; }

        /// <summary>
        /// The message
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

    }
}
