﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebVella.ERP.Api.Models
{
	public class MultiSelectField : Field
	{
        [JsonProperty(PropertyName = "fieldType")]
        public static FieldType FieldType { get { return FieldType.MultiSelectField; } }

        [JsonProperty(PropertyName = "defaultValue")]
        public IEnumerable<string> DefaultValue { get; set; }

        [JsonProperty(PropertyName = "options")]
        public IDictionary<string, string> Options { get; set; }

        public MultiSelectField()
        {
        }

        public MultiSelectField(Field field) : base(field)
        {
        }

        public MultiSelectField(InputField field) : base(field)
        {
            foreach (var property in field.GetProperties())
            {
                switch (property.Key.ToLower())
                {
                    case "defaultvalue":
                        DefaultValue = (IEnumerable<string>)property.Value;
                        break;
                    case "options":
                        Options = (IDictionary<string, string>)property.Value;
                        break;
                }
            }
        }
    }

	public class MultiSelectFieldMeta : MultiSelectField, IFieldMeta
    {
        [JsonProperty(PropertyName = "entityId")]
        public Guid EntityId { get; set; }

        [JsonProperty(PropertyName = "entityName")]
        public string EntityName { get; set; }

        [JsonProperty(PropertyName = "parentFieldName")]
        public string ParentFieldName { get; set; }

        public MultiSelectFieldMeta(Guid entityId, string entityName, MultiSelectField field, string parentFieldName = null) : base(field)
        {
            EntityId = entityId;
			EntityName = entityName;
			DefaultValue = field.DefaultValue;
			Options = field.Options;
            ParentFieldName = parentFieldName;
        }
	}
}