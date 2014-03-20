using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using mCube.DataEntities.MetaData;

namespace mCube.DataEntities.Files
{
	public class VideoFile
	{

		public int Id { get; set; }


		public string Format { get; set; }
		public byte AudioCount { get; set; }
		public byte VideoCount { get; set; }
		public long DurationInTicks { get; set; }
		public ushort OverallBitrate { get; set; }
		public string OpenSubtitlesHash { get; set; }
		public string Extension { get; set; }
		public string FileName { get; set; }
		public float FileSize { get; set; }
		[NotMapped]
		public TimeSpan Duration
		{
			get
			{
				return new TimeSpan(DurationInTicks);
			}
			set
			{
				DurationInTicks = value.Ticks;
			}
		}

		public virtual ICollection<VideoAttributes> VideoAttributes { get; set; }

		public virtual ICollection<AudioAttributes> AudioAttributes { get; set; }

		
	}
}
