﻿using Newtonsoft.Json;
using System;

namespace WebVella.ERP.Api.Models
{
    public class CurrencyField : Field
    {
        [JsonProperty(PropertyName = "fieldType")]
        public static FieldType FieldType { get { return FieldType.CurrencyField; } }

        [JsonProperty(PropertyName = "defaultValue")]
        public decimal? DefaultValue { get; set; }

        [JsonProperty(PropertyName = "minValue")]
        public decimal? MinValue { get; set; }

        [JsonProperty(PropertyName = "maxValue")]
        public decimal? MaxValue { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public CurrencyTypes Currency { get; set; }

        public CurrencyField()
        {
        }

        public CurrencyField(Field field) : base(field)
        {
        }

        public CurrencyField(InputField field) : base(field)
        {
            foreach (var property in field.GetProperties())
            {
                switch (property.Key.ToLower())
                {
                    case "defaultvalue":
                        DefaultValue = (decimal?)property.Value;
                        break;
                    case "minvalue":
                        MinValue = (decimal?)property.Value;
                        break;
                    case "maxvalue":
                        MaxValue = (decimal?)property.Value;
                        break;
                    case "currency":
                        Currency = (CurrencyTypes)property.Value;
                        break;
                }
            }
        }

    }

    public class CurrencyFieldMeta : CurrencyField, IFieldMeta
    {
        [JsonProperty(PropertyName = "entityId")]
        public Guid EntityId { get; set; }

        [JsonProperty(PropertyName = "entityName")]
        public string EntityName { get; set; }

        [JsonProperty(PropertyName = "parentFieldName")]
        public string ParentFieldName { get; set; }

        public CurrencyFieldMeta(Guid entityId, string entityName, CurrencyField field, string parentFieldName = null) : base(field)
        {
            EntityId = entityId;
			EntityName = entityName;
			DefaultValue = field.DefaultValue;
			MinValue = field.MinValue;
			MaxValue = field.MaxValue;
			Currency = field.Currency;
            ParentFieldName = parentFieldName;
        }
	}
}