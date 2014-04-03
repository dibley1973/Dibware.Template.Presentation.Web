using Dibware.Template.Core.Domain.Contracts.Services;
using System.IO;
using System.Xml.Serialization;

namespace Dibware.Template.Core.Application.Services
{
    public class DeepCopyCloneService : ICloneService
    {
        /// <summary>
        /// Clones the specified instance using a MemoryStream
        /// to provide a deep copy.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        public T Clone<T>(T instance) where T : class
        {
            var serializer = new XmlSerializer(typeof(T));
            var stream = new MemoryStream();
            serializer.Serialize(stream, instance);
            stream.Seek(0, SeekOrigin.Begin);
            return serializer.Deserialize(stream) as T;
        }
    }
}