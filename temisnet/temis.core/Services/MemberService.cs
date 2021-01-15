using System;
using System.Collections.Generic;
using temis.Core.Interfaces;
using temis.Core.Models;
using temis.Core.Services.Interfaces;

namespace temis.Core.Services.Service
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _repository;

        public MemberService(IMemberRepository repository)
        {
            _repository = repository;
        }
        public Member CreateMember(Member member)
        {
            Member memberNew = _repository.Create(member);
            return memberNew;
        }

        public Member EditMember(Member member)
        {
            Member editedMember = _repository.Update(member);
            return editedMember;
        }

        public List<Member> FindAll()
        {
            List<Member> list = new List<Member>();
            list = _repository.FindAll();
            return list;
        }

        public Member FindById(long id)
        {
            Member member = _repository.FindById(id);
            return member;
        }

        public Member Validate(string cpf, string password)
        {
            Member member = _repository.Validate(cpf,password);
            return member;
        }

        public void EditPassword(long id, string password)
        {
            Member member = _repository.FindById(id);
            if(member == null)
            {
                throw new NullReferenceException("Usuário não cadastrado!");
            }
            _repository.EditPassword(member.Id, password);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public PageResponse<Member> Filter(string name, PageRequest pageRequest)
        {
            return _repository.Filter(name, pageRequest);
        }

       
    }

    
}
