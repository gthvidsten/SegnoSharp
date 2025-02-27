﻿using System;
using Un4seen.Bass;
using Whitestone.SegnoSharp.Common.Models;

namespace Whitestone.SegnoSharp.Modules.BassService.Interfaces
{
    public interface IBassWrapper
    {
        void Registration(string email, string key);
        bool Initialize(int device, int frequency, BASSInit flags, IntPtr win);
        bool Uninitialize();
        int CreateMixerStream(int frequency, int noOfChannels, BASSFlag flags);
        int CreateFileStream(string file, long offset, long length, BASSFlag flags);
        bool MixerAddStream(int mixerHandle, int streamHandle, BASSFlag flags);
        bool FreeStream(int handle);
        int BassLoadPlugin(string plugin);
        bool BassUnloadPlugins();
        BASSError GetLastBassError();
        Version GetBassVersion();
        Version GetBassEncVersion();
        Version GetBassEncMp3Version();
        Version GetBassMixerVersion();
        Version GetBassNetVersion();
        bool Play(int handle, bool restart);
        bool MixerPlay(int streamHandle);
        bool Stop(int handle);
        bool SetAttribute(int handle, BASSAttribute attribute, float value);
        bool SlideAttribute(int handle, BASSAttribute attribute, float value, int time);
        Tags GetTagFromFile(string file);
        void StartStreaming(int channel, StreamingSettings settings);
        void StopStreaming();
        void SetStreamingTitle(string title);
    }
}
