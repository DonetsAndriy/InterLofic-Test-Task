using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServe.TAF.Business.WebAPI.RestSharp.Requests.Models
{
    public record BookDto(
            [property: JsonProperty("id")] int Id,
            [property: JsonProperty("title")] string Title,
            [property: JsonProperty("description")] string Description,
            [property: JsonProperty("pageCount")] int PageCount,
            [property: JsonProperty("excerpt")] string Excerpt,
            [property: JsonProperty("publishDate")] DateTime PublishDate
        );
}
