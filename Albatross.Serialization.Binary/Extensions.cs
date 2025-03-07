using MessagePack;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Albatross.Serialization.Binary {
	public static class Extensions {
		public static async IAsyncEnumerable<Record> ReadArrayAsync<Record>(this Stream stream, MessagePackSerializerOptions options, [EnumeratorCancellation] CancellationToken cancellationToken) {
			var reader = new MessagePackStreamReader(stream);
			for (var value = await reader.ReadAsync(cancellationToken); value != null; value = await reader.ReadAsync(cancellationToken)) {
				var msg = MessagePackSerializer.Deserialize<Record>(value.Value, options);
				yield return msg;
			}
		}

	}
}
