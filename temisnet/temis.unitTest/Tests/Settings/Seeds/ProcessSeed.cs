using System.Collections.Generic;
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
                ProcessId = 3,
                Status = "Teste"
            };
        }
         public static Process Delete()
        {
            return new Process()
            {
                ProcessId = 4
            };
        }
    }
}