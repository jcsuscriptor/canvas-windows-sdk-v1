﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Canvas.v1.Models.Request
{
    /// <summary>
    /// An object representing the request to create a shared link
    /// </summary>
    public class BoxSharedLinkRequest
    {
        /// <summary>
        /// The level of access required for this shared link. Can be open, company, collaborators
        /// </summary>
        [JsonProperty(PropertyName = "access")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BoxSharedLinkAccessType? Access { get; set; }

        /// <summary>
        /// The day that this link should be disabled at. Timestamps are rounded off to the given day.
        /// </summary>
        [JsonProperty(PropertyName = "unshared_at")]
        public DateTime? UnsharedAt { get; set; }

        /// <summary>
        /// The set of permissions that apply to this link
        /// </summary>
        [JsonProperty(PropertyName = "permissions")]
        public BoxPermissionsRequest Permissions { get; set; }
    }
}

