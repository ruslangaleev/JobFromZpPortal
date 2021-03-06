﻿using Job.Data.Models;
using Job.Services.Clients.Interfaces;
using Job.Services.ResourceModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Job.Services.Clients.Logic
{
    public class ZpClient : IZpClient
    {
        private static readonly HttpClient _client = new HttpClient();

        public ZpClient(IConfiguration configuration)
        {
            var baseUri = configuration["BaseUriZp"];
            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = new Uri(baseUri);
            }
        }

        public Task<IEnumerable<Rubric>> GetRubrics()
        {
            throw new NotImplementedException();
        }

        public async Task<VacancyInfo> GetVacancies(int limit = 100, int offset = 0)
        {
            var uri = $"/v1/vacancies?limit={limit}&offset={offset}";
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<VacancyInfo>(json);
            }

            var test = await response.Content.ReadAsStringAsync();

            return null;
        }
    }
}
