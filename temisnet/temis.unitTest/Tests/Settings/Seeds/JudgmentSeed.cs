using System;
using System.Collections.Generic;
using temis.Core.Models;

namespace temis.unitTest.Tests.Settings.Seeds
{
    public class JudgmentSeed
    {
        public static PageResponse<Judgment> Get()
        {
            PageRequest pReq = PageRequest.Of(1,3);
            List<Judgment> content = new List<Judgment>(){
                new Judgment(){
                    JudgmentInstanceId = 1,
                    JudgingInstance = new JudgingInstance(){},
                    ProcessId = 1,
                    Process = new Process(){},
                    JudgmentDate = new DateTime(2021, 1, 1),
                    Veredict = "teste"
            }};
            return PageResponse<Judgment>.For(content, pReq, 1);
        }

        public static Judgment GetById()
        {
            return new Judgment(){
                JudgmentInstanceId = 2,
                JudgingInstance = new JudgingInstance(){},
                ProcessId = 4,
                Process = new Process(){},
                JudgmentDate = new DateTime(2019, 5, 1),
                Veredict = "veredict"
            };
        }
        public  static Judgment Delete()
        {
            return new Judgment(){
                JudgmentInstanceId = 3,
                JudgingInstance = new JudgingInstance(){},
                ProcessId = 5,
                Process = new Process(){},
                JudgmentDate = new DateTime(2018, 12, 1),
                Veredict = "1234"
            };
        }
    }
}