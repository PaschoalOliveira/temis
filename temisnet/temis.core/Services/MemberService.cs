using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
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
            Member memberNew = _repository.CreateMember(member);
            return memberNew;
        }

        public Member EditMember(Member member)
        {
            Member editedMember = _repository.EditMember(member);
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

        public string GenerateToken(Member member)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(api.Settings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, member.Cpf.ToString()),
                    new Claim(ClaimTypes.Role, member.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }

    
}
