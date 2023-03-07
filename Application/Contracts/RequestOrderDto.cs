using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace Application.Contracts
{

    [SwaggerSchema("Requested order")]
    public class RequestOrderDto
    {
        [SwaggerSchema("Menu (e.g.: morning or evening)")]
        public string Menu { get; set; }

        [SwaggerSchema("List of integer with dishes identifiers (e.g.: 1 ,2 ,3)")]
        public List<int> Dishes { get; set; }

    }
}
