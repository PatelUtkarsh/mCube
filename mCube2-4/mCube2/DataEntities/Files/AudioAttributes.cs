using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mCube.DataEntities.Files
{
	public class AudioAttributes
	{
		public int Id { get; set; }
		public int MovieFileId { get; set; }

		public string Format { get; set; }
		public string Codec { get; set; }
		public byte Channels { get; set; }
		public string SamplingRate { get; set; }
		public string Language { get; set; }

		public virtual VideoFile VideoFile { get; set; }
	}
}
