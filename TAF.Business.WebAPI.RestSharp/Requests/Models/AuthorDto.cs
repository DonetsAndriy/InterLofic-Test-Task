using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServe.TAF.Business.WebAPI.RestSharp.Requests.Models
{
    public record AuthorDto(
        [property: JsonProperty("id")] int Id,
        [property: JsonProperty("firstName")] string FirstName,
        [property: JsonProperty("lastName")] string LastName
    );
}
