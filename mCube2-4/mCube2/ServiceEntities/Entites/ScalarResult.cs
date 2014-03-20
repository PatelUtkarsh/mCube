using System.Runtime.Serialization;

namespace mCube.Service.Entites
{
	[DataContract]
	public class ScalarResult
	{
		[DataMember]
		public bool OperationSucceeded { get; set; }
		[DataMember]
		public string Message { get; set; }
	}
}