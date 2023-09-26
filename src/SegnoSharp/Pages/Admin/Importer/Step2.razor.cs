﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Whitestone.SegnoSharp.Models.States;
using Whitestone.SegnoSharp.Common.Extensions;

namespace Whitestone.SegnoSharp.Pages.Admin.Importer
{
    public partial class Step2
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private ImportState ImporterState { get; set; }

        private string ErrorMessage { get; set; }

        protected override void OnInitialized()
        {
            if (ImporterState.SelectedFiles != null &&
                ImporterState.SelectedFiles.Any())
            {
                base.OnInitialized();
                return;
            }

            if (ImporterState.SelectedFolder?.Parent == null)
            {
                ErrorMessage = "No folder selected.";
                base.OnInitialized();
                return;
            }

            string[] extensions = { ".wma", ".mp3", ".flac" };
            List<FileInfo> files = ImporterState.SelectedFolder.EnumerateFiles("*",
                    ImporterState.ImportSubfolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
                .Where(f => extensions.Contains(f.Extension))
                .ToList();

            if (files.Count > 100)
            {
                ErrorMessage = "More than 100 files in selected folder. Please select a folder with fewer files.";
                base.OnInitialized();
                return;
            }

            ImporterState.SelectedFiles = files.Select(f => new SelectedFile
            {
                File = f,
                Filename = f.FullName.TrimStart(ImporterState.SelectedFolder.FullName).TrimStart('\\')
            }).ToArray();

            base.OnInitialized();
        }

        private void OnNextClick()
        {
            NavigationManager.NavigateTo("/admin/import/step-3");
        }

        private void OnBackClick()
        {
            NavigationManager.NavigateTo("/admin/import");
        }

        private void OnAllImportChange(ChangeEventArgs e)
        {
            if (e.Value == null)
            {
                return;
            }

            foreach (SelectedFile file in ImporterState.SelectedFiles)
            {
                file.Import = (bool)e.Value;
            }
        }
        private void OnAllImportPublicChange(ChangeEventArgs e)
        {
            if (e.Value == null)
            {
                return;
            }

            foreach (SelectedFile file in ImporterState.SelectedFiles)
            {
                file.ImportToPublicLibrary = (bool)e.Value;
            }
        }
        private void OnAllImportPlaylistChange(ChangeEventArgs e)
        {
            if (e.Value == null)
            {
                return;
            }

            foreach (SelectedFile file in ImporterState.SelectedFiles)
            {
                file.ImportToPlaylist = (bool)e.Value;
            }
        }
    }
}
