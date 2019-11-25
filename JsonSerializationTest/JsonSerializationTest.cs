using JsonSerializationTest;
using NUnit.Framework;
using UsingJSONInCS;

namespace Tests
{
    [TestFixture]
    public class JsonSerializationTest
    {
        private ISerializer jsonSerializer;

        [SetUp]
        public void Setup()
        {
            jsonSerializer = new JsonSerializer();
        }

        [Test]
        public void SerializeEnumValueTest()
        {
            SampleClass sampleEntity = new SampleClass
            {
                Description = "SerializeTest",
                EnumVal = SampleEnum.FirstValue
            };

            string expectedJsonData = "{\"description\":\"SerializeTest\",\"enumVal\":\"FirstValue\"}";
            string actualJsonData = jsonSerializer.Serialize<SampleClass>(sampleEntity);

            Assert.AreEqual(expectedJsonData, actualJsonData);
        }

        [Test]
        public void DeserializeEnumValueTest()
        {
            string jsonData = "{\"description\":\"DeserializeTest\",\"enumVal\":\"SecondValue\"}";

            SampleClass expectedSampleEntity = new SampleClass
            {
                Description = "DeserializeTest",
                EnumVal = SampleEnum.SecondValue
            };

            SampleClass actualSampleEntity = jsonSerializer.Deserialize<SampleClass>(jsonData);

            Assert.AreEqual(expectedSampleEntity.Description, actualSampleEntity.Description);
            Assert.AreEqual(expectedSampleEntity.EnumVal, actualSampleEntity.EnumVal);
        }
    }
}