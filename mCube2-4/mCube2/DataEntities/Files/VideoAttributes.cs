using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mCube.DataEntities.Files
{
	public class VideoAttributes
	{
		public int Id { get; set; }
		public int MovieFileId { get; set; }

		public string CodecId { get; set; }
		public string Format { get; set; }
		public ushort BitRate { get; set; } // in Kbps
		public ushort Height { get; set; }
		public ushort Widht { get; set; }
		public float Fps { get; set; }

		public virtual VideoFile VideoFile { get; set; }
	}
}
