using SoftServe.TAF.Business.WebAPI.RestSharp.Requests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServe.TAF.Business.WebAPI.RestSharp.Requests.Endpoints
{
    public class AuthorEndpoint : Endpoint
    {
        public override string GetRoute() => "api/v1/Authors";

        public async Task<AuthorDto> GetAuthor(int id) =>
            await RequestAsync<AuthorDto>(Method.Get, $"{id}");

        public async Task<AuthorDto> PostAuthor(int id, string firstName, string lastName) =>
            await RequestAsync<AuthorDto>(Method.Post, new AuthorDto(id, firstName, lastName));

        public async Task<AuthorDto> PutAuthor(int id, string firstName, string lastName) =>
            await RequestAsync<AuthorDto>(Method.Put, new AuthorDto(id, firstName, lastName));

        public async Task<RestResponse> DeleteAuthor(int id) =>
            await RequestAsync(Method.Delete, $"{id}");
    }
}
