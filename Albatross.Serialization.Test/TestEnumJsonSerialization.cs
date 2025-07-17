using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace Albatross.Serialization.Test {
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum TestEnum {
		[JsonStringEnumMemberName("1st")]
		First,

		[JsonStringEnumMemberName("2nd")]
		Second,

		[JsonStringEnumMemberName("3rd")]
		Third
	}

	public class TestEnumJsonSerialization {
		[Theory]
		[InlineData(TestEnum.First, "\"1st\"")]
		public void Test(TestEnum value, string expected) {
			var text = JsonSerializer.Serialize(value);
			Assert.Equal(expected, text);
		}
	}
}