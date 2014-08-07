﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Canvas.v1.Models.Request
{
    /// <summary>
    /// The set of permissions that apply to this link
    /// </summary>
    public class BoxPermissionsRequest
    {
        /// <summary>
        /// Whether this link allows downloads. Can only be used with Open and Company
        /// </summary>
        [JsonProperty(PropertyName = "can_download")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BoxPermissionType? Download { get; set; }
        
        /// <summary>
        /// Whether this link allows previews. Can only be used with Open and Company
        /// </summary>
        [JsonProperty(PropertyName = "can_preview")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BoxPermissionType? Preview { get; set; }
    }

    /// <summary>
    /// The available permissions for the request
    /// </summary>
    public enum BoxPermissionType
    {
        Open,
        Company
    }
}
