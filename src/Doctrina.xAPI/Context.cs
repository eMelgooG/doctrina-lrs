﻿using Doctrina.xAPI.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Doctrina.xAPI
{
    //[JsonConverter(typeof(ContextConverter))]
    [JsonObject]
    public class Context
    {
        [JsonProperty("registration", 
            NullValueHandling = NullValueHandling.Ignore,
            Required = Required.DisallowNull)]
        public Guid? Registration { get; set; }

        /// <summary>
        /// Instructor that the Statement relates to, if not included as the Actor of the Statement.
        /// </summary>
        [JsonProperty("instructor", 
            NullValueHandling = NullValueHandling.Ignore,
            Required = Required.DisallowNull),
            JsonConverter(typeof(AgentJsonConverter))]
        public Agent Instructor { get; set; }

        /// <summary>
        /// Instructor that the Statement relates to, if not included as the Actor of the Statement.
        /// </summary>
        [JsonProperty("team", 
            NullValueHandling = NullValueHandling.Ignore,
            Required = Required.DisallowNull),
            JsonConverter(typeof(AgentJsonConverter))]
        public Group Team { get; set; }

        /// <summary>
        /// A map of the types of learning activity context that this Statement is related to. Valid context types are: parent, "grouping", "category" and "other".
        /// </summary>
        [JsonProperty("contextActivities",
            NullValueHandling = NullValueHandling.Ignore,
            Required = Required.DisallowNull)]
        public ContextActivities ContextActivities { get; set; }

        /// <summary>
        /// Revision of the learning activity associated with this Statement. Format is free.
        /// The "revision" property MUST only be used if the Statement's Object is an Activity.
        /// </summary>
        [JsonProperty("revision",
            NullValueHandling = NullValueHandling.Ignore,
            Required = Required.DisallowNull)]
        public string Revision { get; set; }

        /// <summary>
        /// Platform used in the experience of this learning activity.
        /// The "platform" property MUST only be used if the Statement's Object is an Activity.
        /// </summary>
        [JsonProperty("platform",
            NullValueHandling = NullValueHandling.Ignore,
            Required = Required.DisallowNull)]
        public string Platform { get; set; }

        
        private string _language;
        /// <summary>
        /// Code representing the language in which the experience being recorded in this Statement (mainly) occurred in, if applicable and known.
        /// </summary>
        [JsonProperty("language",
            NullValueHandling = NullValueHandling.Ignore,
            Required = Required.DisallowNull)]
        public string Language
        {
            get { return _language; }
            set {
                CultureInfo.GetCultureInfo(value);
                _language = value;
            }
        }


        /// <summary>
        /// Another Statement to be considered as context for this Statement.
        /// </summary>
        [JsonProperty("statement",
            NullValueHandling = NullValueHandling.Ignore,
            Required = Required.DisallowNull)]
        public StatementRef Statement { get; set; }

        [JsonProperty("extensions",
            NullValueHandling = NullValueHandling.Ignore,
            Required = Required.Default)]
        public Extensions Extensions { get; set; }

        public override bool Equals(object obj)
        {
            var context = obj as Context;
            return context != null &&
                   EqualityComparer<Guid?>.Default.Equals(Registration, context.Registration) &&
                   EqualityComparer<Agent>.Default.Equals(Instructor, context.Instructor) &&
                   EqualityComparer<Group>.Default.Equals(Team, context.Team) &&
                   EqualityComparer<ContextActivities>.Default.Equals(ContextActivities, context.ContextActivities) &&
                   Revision == context.Revision &&
                   Platform == context.Platform &&
                   Language == context.Language &&
                   EqualityComparer<StatementRef>.Default.Equals(Statement, context.Statement) &&
                   EqualityComparer<Extensions>.Default.Equals(Extensions, context.Extensions);
        }

        public override int GetHashCode()
        {
            var hashCode = 2045218665;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid?>.Default.GetHashCode(Registration);
            hashCode = hashCode * -1521134295 + EqualityComparer<Agent>.Default.GetHashCode(Instructor);
            hashCode = hashCode * -1521134295 + EqualityComparer<Group>.Default.GetHashCode(Team);
            hashCode = hashCode * -1521134295 + EqualityComparer<ContextActivities>.Default.GetHashCode(ContextActivities);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Revision);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Platform);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Language);
            hashCode = hashCode * -1521134295 + EqualityComparer<StatementRef>.Default.GetHashCode(Statement);
            hashCode = hashCode * -1521134295 + EqualityComparer<Extensions>.Default.GetHashCode(Extensions);
            return hashCode;
        }

        public static bool operator ==(Context context1, Context context2)
        {
            return EqualityComparer<Context>.Default.Equals(context1, context2);
        }

        public static bool operator !=(Context context1, Context context2)
        {
            return !(context1 == context2);
        }
    }
}