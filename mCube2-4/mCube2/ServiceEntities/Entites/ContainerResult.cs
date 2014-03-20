using System.Runtime.Serialization;

namespace mCube.Service.Entites
{
	[DataContract]
	public class ContainerResult <T> :ScalarResult
	{
		[DataMember]
		public T Result { get; set; }
	}
}
