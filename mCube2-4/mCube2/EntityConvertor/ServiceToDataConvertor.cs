using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SE = mCube.Service.Entites;
using DE = mCube.DataEntities;

namespace mCube.Service.EntityConvertor
{
	public static class ServiceToDataConvertor
	{
		public static DE.Files.VideoFile ConvertVideoFile(SE.VideoFileAttributes serviceFileAttributes)
		{
			var dataFileAttribute = new DE.Files.VideoFile();

			dataFileAttribute.AudioAttributes = new List<DE.Files.AudioAttributes>();
			dataFileAttribute.VideoAttributes = new List<DE.Files.VideoAttributes>();

			dataFileAttribute.AudioCount = serviceFileAttributes.AudioCount;
			dataFileAttribute.Duration = serviceFileAttributes.Duration;
			dataFileAttribute.Extension = serviceFileAttributes.Extension;
			dataFileAttribute.FileName = serviceFileAttributes.FileName;
			dataFileAttribute.Format = serviceFileAttributes.Format;
			dataFileAttribute.OpenSubtitlesHash = serviceFileAttributes.OpenSubtitlesHash;
			dataFileAttribute.OverallBitrate = serviceFileAttributes.OverallBitrate;
			dataFileAttribute.VideoCount = serviceFileAttributes.VideoCount;

			foreach (var audioAttributese in serviceFileAttributes.AudioAttributes)
			{
				dataFileAttribute.AudioAttributes.Add(ConvertAudioAttributes(audioAttributese));
			}

			foreach (var videoAttributese in serviceFileAttributes.VideoAttributes)
			{
				dataFileAttribute.VideoAttributes.Add(ConvertVideoAttributes(videoAttributese));
			}

			return dataFileAttribute;
		}

		private static DE.Files.VideoAttributes ConvertVideoAttributes(SE.VideoAttribute videoAttribute)
		{
			var dataVideoAttribute = new DE.Files.VideoAttributes();

			dataVideoAttribute.BitRate = videoAttribute.BitRate;
			dataVideoAttribute.CodecId = videoAttribute.CodecId;
			dataVideoAttribute.Format = videoAttribute.Format;
			dataVideoAttribute.Fps = videoAttribute.Fps;
			dataVideoAttribute.Height = videoAttribute.Height;
			dataVideoAttribute.Widht = videoAttribute.Widht;

			return dataVideoAttribute;
		}

		private static DE.Files.AudioAttributes ConvertAudioAttributes(SE.AudioAttribute audioAttributese)
		{
			var dataAudioAttributes = new DE.Files.AudioAttributes();

			dataAudioAttributes.Channels = audioAttributese.Channels;
			dataAudioAttributes.Codec = audioAttributese.Codec;
			dataAudioAttributes.Format = audioAttributese.Format;
			dataAudioAttributes.Language = audioAttributese.Language;
			dataAudioAttributes.SamplingRate = audioAttributese.SamplingRate;

			return dataAudioAttributes;
		}
	}
}
