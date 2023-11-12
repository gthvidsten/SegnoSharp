﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Whitestone.SegnoSharp.Database;
using Whitestone.SegnoSharp.Database.Models;

namespace Whitestone.SegnoSharp.Pages.Admin.AlbumEditor
{
    public partial class Persons : IDisposable
    {
        [Inject] private IDbContextFactory<SegnoSharpDbContext> DbFactory { get; set; }
        [Inject] private IJSRuntime JsRuntime { get; set; }

        private SegnoSharpDbContext DbContext { get; set; }

        private string SearchQuery { get; set; }
        private List<Person> PersonResults { get; set; } = new();

        private Timer _searchTimer;

        protected override async Task OnInitializedAsync()
        {
            DbContext = await DbFactory.CreateDbContextAsync();
        }

        private async Task SaveChanges()
        {
            await DbContext.SaveChangesAsync();
        }

        private async Task DiscardChanges()
        {
            DbContext.ChangeTracker.Clear();

            string query = SearchQuery.Trim();

            PersonResults = await DbContext.Persons
                .Where(p => EF.Functions.Like(p.LastName, "%" + query + "%") || EF.Functions.Like(p.FirstName, "%" + query + "%"))
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .ThenBy(p => p.Version)
                .ToListAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                DbContext?.Dispose();
            }
        }

        private async Task OnBeforeInternalNavigation(LocationChangingContext context)
        {
            if (DbContext.ChangeTracker.HasChanges())
            {
                var confirmed = await JsRuntime.InvokeAsync<bool>("confirm", "You have unsaved changes. Are you sure you want to leve this page?");
                if (!confirmed)
                {
                    context.PreventNavigation();
                }
            }
        }

        private void StartSearchTimer()
        {
            DisposeSearchTimer();
            _searchTimer = new Timer(300);
            _searchTimer.Elapsed += SearchTimerElapsedTickAsync;
            _searchTimer.Enabled = true;
            _searchTimer.Start();
        }

        private void DisposeSearchTimer()
        {
            if (_searchTimer == null)
            {
                return;
            }

            _searchTimer.Enabled = false;
            _searchTimer.Elapsed -= SearchTimerElapsedTickAsync;
            _searchTimer.Dispose();
            _searchTimer = null;
        }

        private async void SearchTimerElapsedTickAsync(object sender, ElapsedEventArgs e)
        {
            DisposeSearchTimer();

            string query = SearchQuery.Trim();

            if (query.Length <= 0)
            {
                PersonResults = new List<Person>();
                return;
            }

            PersonResults = await DbContext.Persons
                .Where(p => EF.Functions.Like(p.LastName, "%" + query + "%") || EF.Functions.Like(p.FirstName, "%" + query + "%"))
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .ThenBy(p => p.Version)
                .ToListAsync();

            _ = InvokeAsync(StateHasChanged);
        }

        private async Task RemovePerson(Person person)
        {
            var confirmed = await JsRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to delete {person.FirstName} {person.LastName} (ID: {person.Id})?");
            if (!confirmed)
            {
                return;
            }

            PersonResults.Remove(person);
            DbContext.Persons.Remove(person);

            foreach (Person existingPerson in PersonResults.Where(existingPerson => existingPerson.FirstName == person.FirstName &&
                                                                                    existingPerson.LastName == person.LastName &&
                                                                                    existingPerson.Version > person.Version))
            {
                existingPerson.Version = (ushort)(existingPerson.Version - 1);
            }
        }
    }
}
