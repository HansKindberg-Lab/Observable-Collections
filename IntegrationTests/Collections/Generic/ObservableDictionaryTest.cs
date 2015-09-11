using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HansKindberg.IntegrationTests.Collections.Generic
{
	[TestClass]
	public class ObservableDictionaryTest
	{
		#region Methods

		private static T Deserialize<T>(string serializedInstance)
		{
			var serializedInstanceBytes = Convert.FromBase64String(serializedInstance);

			using(var memoryStream = new MemoryStream(serializedInstanceBytes, 0, serializedInstanceBytes.Length))
			{
				memoryStream.Write(serializedInstanceBytes, 0, serializedInstanceBytes.Length);
				memoryStream.Position = 0;
				return (T) new BinaryFormatter().Deserialize(memoryStream);
			}
		}

		[TestMethod]
		public void ObservableDictionary_ShouldBeSerializable()
		{
			const string key = "Key";
			const string value = "Value";

			var dictionary = new Dictionary<string, string> {{key, value}};

			var deserializedDictionary = Deserialize<Dictionary<string, string>>(Serialize(dictionary));

			Assert.AreEqual(1, dictionary.Count);
			Assert.AreEqual(1, deserializedDictionary.Count);
			Assert.IsTrue(dictionary.ContainsKey(key));
			Assert.IsTrue(deserializedDictionary.ContainsKey(key));
			Assert.AreEqual(value, dictionary[key]);
			Assert.AreEqual(value, deserializedDictionary[key]);

			var observableDictionary = new Dictionary<string, string> {{key, value}};

			var deserializedObservableDictionary = Deserialize<Dictionary<string, string>>(Serialize(observableDictionary));

			Assert.AreEqual(1, observableDictionary.Count);
			Assert.AreEqual(1, deserializedObservableDictionary.Count);
			Assert.IsTrue(observableDictionary.ContainsKey(key));
			Assert.IsTrue(deserializedObservableDictionary.ContainsKey(key));
			Assert.AreEqual(value, observableDictionary[key]);
			Assert.AreEqual(value, deserializedObservableDictionary[key]);
		}

		private static string Serialize(object instance)
		{
			using(var memoryStream = new MemoryStream())
			{
				new BinaryFormatter().Serialize(memoryStream, instance);

				return Convert.ToBase64String(memoryStream.ToArray());
			}
		}

		#endregion
	}
}