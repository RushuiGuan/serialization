using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Albatross.Serialization.Json {
	/// <summary>
	/// Reduced footprint serialization option used by applications only where sender and receiver are both created internally.
	/// * default
	///		* camel case
	///		* ignore when writing default
	/// * alternate
	///		* proper case
	///		* ignore when writing default
	/// </summary>
	public class ReducedFootprintJsonSettings : IJsonSettings {
		public JsonSerializerOptions Value { get; private set; }
		public ReducedFootprintJsonSettings() {
			Value = new JsonSerializerOptions {
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
			};
		}
		readonly static Lazy<ReducedFootprintJsonSettings> lazy = new Lazy<ReducedFootprintJsonSettings>();
		public static IJsonSettings Instance => lazy.Value;
	}
}