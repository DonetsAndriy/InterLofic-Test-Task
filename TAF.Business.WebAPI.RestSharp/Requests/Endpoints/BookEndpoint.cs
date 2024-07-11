using SoftServe.TAF.Business.WebAPI.RestSharp.Requests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServe.TAF.Business.WebAPI.RestSharp.Requests.Endpoints
{
    public class BookEndpoint : Endpoint
    {
        public override string GetRoute() => "api/v1/Books";

        public async Task<BookDto> GetBook(int id) =>
            await RequestAsync<BookDto>(Method.Get, $"{id}");

        public async Task<BookDto> PostBook(int id, string title, string description, int pageCount, string excerpt, DateTime publishDate) =>
            await RequestAsync<BookDto>(Method.Post, new BookDto(id, title, description, pageCount, excerpt, publishDate));

        public async Task<BookDto> PutBook(int id, string title, string description, int pageCount, string excerpt, DateTime publishDate) =>
            await RequestAsync<BookDto>(Method.Put, $"{id}", new BookDto(id, title, description, pageCount, excerpt, publishDate));

        public async Task<RestResponse> DeleteBook(int id) =>
            await RequestAsync(Method.Delete, $"{id}");
    }
}
