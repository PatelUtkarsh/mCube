using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace mCube.Service.Entites
{
	[DataContract]
	public class VideoFileAttributes : MediaFileAttributes
	{
		public VideoFileAttributes()
		{
			VideoAttributes = new List<VideoAttribute>();
			AudioAttributes = new List<AudioAttribute>();
		}

		[DataMember]
		public IList<VideoAttribute> VideoAttributes { get; private set; }
		[DataMember]
		public IList<AudioAttribute> AudioAttributes { get; private set; }
		[DataMember]
		public string Format { get; set; }
		[DataMember]
		public byte AudioCount { get; set; }
		[DataMember]
		public byte VideoCount { get; set; }
		[DataMember]
		public TimeSpan Duration { get; set; }
		[DataMember]
		public ushort OverallBitrate { get; set; } // in Kbps
		[DataMember]
		public string OpenSubtitlesHash { get; set; }

	}
}
