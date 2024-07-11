using SoftServe.TAF.Business.WebAPI.RestSharp.Requests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServe.TAF.Business.WebAPI.RestSharp.Requests.Endpoints
{
    public class ActivityEndpoint : Endpoint
    {
        public override string GetRoute() => "api/v1/Activities";

        public async Task<List<ActivityDto>> GetAllActivities() =>
            await RequestAsync<List<ActivityDto>>(Method.Get, "");

        public async Task<ActivityDto> PostActivity(int id, string title, DateTime dueDate) =>
            await RequestAsync<ActivityDto>(Method.Post, new ActivityDto(id, title, dueDate));

        public async Task<ActivityDto> PutActivity(int id, string title, DateTime dueDate) =>
            await RequestAsync<ActivityDto>(Method.Put, new ActivityDto(id, title, dueDate));

        public async Task<RestResponse> DeleteActivity(int id) =>
            await RequestAsync(Method.Delete, $"{id}");
    }
}
