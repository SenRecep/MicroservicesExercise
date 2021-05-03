using System;
using System.Collections.Generic;
using System.Text;

using FreeCourse.Shared.ServicesLib.Dtos;

using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Shared.ServicesLib.ControllerBases
{
    public class CustomBaseController:ControllerBase
    {
        public IActionResult CreateIActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
