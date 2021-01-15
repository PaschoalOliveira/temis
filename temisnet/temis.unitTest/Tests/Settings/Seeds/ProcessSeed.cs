using System.Collections.Generic;
using temis.api.Requests;
using temis.Api.Controllers.Models.Requests;
using temis.Api.Models.DTO;
using temis.Core.Models;

namespace temis.unitTest.Tests.Settings.Seeds
{
    public class ProcessSeed
    {
         public static PageResponse<Process> Get()
        {

            return new PageResponse<Process>()
            {
               Content = new List<Process>()
               {
                   new Process()
                   {
                     Number = "2020"
                   }
               }
            };
        }

         public static Process Post()
        {
            return new Process()
            {
                Number = "2021"
            };
        }
        public static Process Patch()
        {
            return new Process()
            {
                Id = 0,
            };
        }
         public static Process Delete()
        {
            return new Process()
            {
                Id = 4
            };
        }

    }
}