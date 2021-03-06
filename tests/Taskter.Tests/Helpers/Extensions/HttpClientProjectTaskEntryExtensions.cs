﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Taskter.Api.Contracts;
using Taskter.Core.Entities;

namespace Taskter.Tests.Helpers.Extensions
{
    public static class HttpClientProjectTaskEntryExtensions
    {
        public static async Task PostNewTimeEntry(this HttpClient client, ProjectTaskEntry model)
        {
            var insertModel = new ProjectTaskEntryInsertDTO()
            {
                UserId = model.UserId,
                ProjectTaskId = model.ProjectTaskId,
                DurationInMin = model.DurationInMin,
                Day = model.Date.Day,
                Month = model.Date.Month,
                Year = model.Date.Year,
                Note = model.Note
            };
            var response = await client.PostAsJsonAsync("api/entries", insertModel);
            response.EnsureSuccessStatusCode();
        }
        public static async Task<List<ProjectTaskEntryDTO>> GetProjectTaskEntriesByDate(this HttpClient client, int year, int month, int day)
        {
            var response = await client.GetAsync($"/api/users/current/entries/{year}/{month}/{day}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<ProjectTaskEntryDTO>>(jsonResponse).ToList();
            return result;
        }
        public static async Task<ProjectTaskEntryUpdateDTO> GetProjectTaskEntriesByIdAsync(this HttpClient client, int id)
        {
            var response = await client.GetAsync($"/api/users/current/entries/{id}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ProjectTaskEntryUpdateDTO>(jsonResponse);
            return result;
        }
        public static async  Task<HttpResponseMessage> UpdateTaskEntry(this HttpClient client, ProjectTaskEntryUpdateDTO entry)
        {
            var payload = JsonConvert.SerializeObject(entry);
            var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("/api/users/current/entries", httpContent);
            response.EnsureSuccessStatusCode();
            return response;
        }
    }
}
