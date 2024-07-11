using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServe.TAF.Business.WebAPI.RestSharp.Requests.Models
{
    public record ActivityDto(
            [property: JsonProperty("id")] int Id,
            [property: JsonProperty("title")] string Title,
            [property: JsonProperty("dueDate")] DateTime DueDate
        );
}
