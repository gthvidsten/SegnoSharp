﻿using Whitestone.SegnoSharp.Common.Models;

namespace Whitestone.SegnoSharp.BassService.Models
{
    internal class TrackExt : Track
    {
        internal int ChannelHandle { get; set; }

        internal TrackExt(Track track)
        {
            Album = track.Album;
            Artist = track.Artist;
            Title = track.Title;
            File = track.File;
        }
    }
}
