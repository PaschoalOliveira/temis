using System;
using System.Collections.Generic;
using temis.Api.Models.DTO;
using temis.Api.Models.ViewModel;
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
                    Veredict = "teste"
                }
            };
            return PageResponse<Judgment>.For(content, pReq, 1);
        }

        public static Judgment GetById()
        {
            return new Judgment(){
                Veredict = "veredict"
            };
        }
        public  static Judgment Delete()
        {
            return new Judgment(){
                Veredict = "1234"
            };
        }
        public static Judgment Post()
        {
            return new Judgment(){
                Veredict = "complete"
            };
        }
        public static JudgmentViewModel PostViewModel()
        {
            return new JudgmentViewModel(){
                Veredict = "complete"
            };
        }

        public static Judgment Put()
        {
            return new Judgment(){
                Veredict = "abcd"
            };
        }

        public static JudgmentDto PutDto()
        {
            return new JudgmentDto(){
                Veredict = "abcd"
            };
        }
    }
}