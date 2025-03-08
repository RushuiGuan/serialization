using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Albatross.Serialization.Json {
	/// <summary>
	/// Formatted json serialization option used by print outs
	/// </summary>
	public class FormattedJsonSettings : IJsonSettings {
		public JsonSerializerOptions Value { get; private set; }
		public FormattedJsonSettings() {
			Value = new JsonSerializerOptions {
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
				WriteIndented = true,
			};
		}
		readonly static Lazy<FormattedJsonSettings> lazy = new Lazy<FormattedJsonSettings>();
		public static IJsonSettings Instance => lazy.Value;
	}
}