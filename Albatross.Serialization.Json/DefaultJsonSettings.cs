using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Albatross.Serialization.Json {
	/// <summary>
	/// Default json serialization option used by webapi and http clients
	///  * default
	///		* camel case property name
	///		* ignore when writing null
	/// </summary>
	public class DefaultJsonSettings : IJsonSettings {
		public JsonSerializerOptions Value { get; private set; }
		public DefaultJsonSettings() {
			Value = new JsonSerializerOptions {
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
			};
		}
		readonly static Lazy<DefaultJsonSettings> lazy = new Lazy<DefaultJsonSettings>();
		public static IJsonSettings Instance => lazy.Value;
	}
}