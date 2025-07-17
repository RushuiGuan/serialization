using Albatross.Serialization.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace Albatross.Serialization.Test {
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum HisEnum {
		A,
		B
	}
	public class Test {
		public SecurityTypeText TextType { get; set; }
		public SecurityTypeInt IntType { get; set; }
	}

	public class TestJsonConverter {
		[Fact]
		public void Test() {
			JsonSerializer.Deserialize<HisEnum>("\"A\"");

		}

		[Fact]
		public void TestEnumUnknownTextValueDeserialization() {
			var text = "{\"textType\":\"xxx\"}";
			var obj = System.Text.Json.JsonSerializer.Deserialize<Test>(text, CustomJsonSettings.Instance.Value);
			Assert.Equal(SecurityTypeText.Undefined, obj?.TextType);
		}

		[Fact]
		public void TestEnumUnknownValueValueDeserialization() {
			var text = "{\"intType\": 99}";
			var obj = JsonSerializer.Deserialize<Test>(text, CustomJsonSettings.Instance.Value);
			Assert.Equal(99, (int)obj.IntType);
		}

		[Fact]
		public void TestEnumValueSerialization() {
			var test = new Test { TextType = SecurityTypeText.Equity };
			var actual = System.Text.Json.JsonSerializer.Serialize<Test>(test, DefaultJsonSettings.Instance.Value);
			var expected = System.Text.Json.JsonSerializer.Serialize<Test>(test, CustomJsonSettings.Instance.Value);
			Assert.Equal(expected, actual);
		}
	}
}