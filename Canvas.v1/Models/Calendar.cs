﻿using Newtonsoft.Json;

namespace Canvas.v1.Models
{
    /// <summary>
    /// An events calendar for a Canvas entity
    /// </summary>
    public class Calendar
    {
        /// <summary>
        /// URL for the calendar in iCalender (ICS) format.
        /// </summary>
        [JsonProperty(PropertyName = "ics")]
        public string Ics { get; set; }
    }
}