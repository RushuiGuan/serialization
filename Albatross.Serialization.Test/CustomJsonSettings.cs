using System;
using System.Text.Json.Serialization;
using System.Text.Json;
using Albatross.Serialization.Json;

namespace Albatross.Serialization.Test {
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum SecurityTypeText {
		Undefined  = -1,
		Equity = 1,
		FixedIncome = 2
	}

	public enum SecurityTypeInt {
		Undefined = -1,
		Equity = 1,
		FixedIncome = 2
	}
	public class CustomJsonSettings : IJsonSettings {
		public JsonSerializerOptions Value { get; private set; }
		public CustomJsonSettings() {
			Value = new JsonSerializerOptions {
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
				Converters = {
					new StringEnumConverterWithFallback<SecurityTypeText>(SecurityTypeText.Undefined),
				}
			};
		}
		readonly static Lazy<CustomJsonSettings> lazy = new Lazy<CustomJsonSettings>();
		public static IJsonSettings Instance => lazy.Value;
	}
}