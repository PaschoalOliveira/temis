using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using temis.Core.Interfaces;
using temis.Core.Models;
using temis.data.Data;
using MySql.Data.MySqlClient;

namespace temis.Data.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly MembroContext context;

        public MemberRepository(MembroContext ctx)
        {
            context = ctx;
        }
        private static List<Member> members = new List<Member>();

        public List<Member> FindAll()
        {
            var membros = context.Membros.ToList();
            return membros.OrderBy(u => u.Nome).ToList();
        }

        public Member FindById(long id)
        {
            Member member = context.Membros.Where(p => p.Id == id).FirstOrDefault();
            return member;
        }
        public Member CreateMember(Member member)
        {
            if (member != null)
            {
                context.Database.ExecuteSqlRaw($@"INSERT INTO member_tbl (membername, password, idade, nome, sobrenome)
                                            VALUES (""{member.Username}"", ""{member.Password}"", {member.Idade}, ""{member.Nome}"", ""{member.Sobrenome}"");");
            }

            return context.Membros.Where(p => p.Username == member.Username).FirstOrDefault();
        }

        public Member EditMember(Member member)
        {
            var memberId = new MySqlParameter("@memberId", member.Id);
            var memberIdade = new MySqlParameter("@memberIdade", member.Idade);
            var memberNome = new MySqlParameter("@memberNome", member.Nome);
            var memberPassword = new MySqlParameter("@memberPassword", member.Password);
            var memberSobrenome = new MySqlParameter("@memberSobrenome", member.Sobrenome);
            var memberMembername = new MySqlParameter("@memberMembername", member.Username);

            context.Database.ExecuteSqlRaw(
                "UPDATE member_tbl SET idade = @memberIdade, nome = @memberNome, password = @memberPassword, sobrenome = @memberSobrenome, membername = @memberMembername WHERE id = @memberId", 
                memberIdade, memberNome, memberPassword, memberSobrenome, memberMembername, memberId);

            
            Member memberNew = FindById(member.Id);
            return memberNew;
        }

        public void Delete(long id)
        {
            Member member = FindById(id);
            context.Membros.Remove(member);
            context.SaveChanges();
        }

        public void EditPassword(long id, string password)
        {
            Member memberPassword = new Member() { Id = id };
            memberPassword.Password = password;
        }

        public IEnumerable<Member> PartialEditMember(string membername)
        {

            IEnumerable<Member> member =
            from memberByName in members
            where memberByName.Username == membername
            select memberByName;

            return member;
        }
        public PageResponse<Member> Filter(string name, PageRequest pageRequest)
        {
            IQueryable<Member> query = context.Membros.Where(
                                    i => 
                                    i.Nome.Contains(name) ||
                                    i.Sobrenome.Contains(name) ||
                                    i.Username.Contains(name)
                                   ).OrderBy(u => u.Nome);

            List<Member> filtredMember;
            filtredMember = PaginationRepository<Member>.For(query, pageRequest).ToList();
            return PageResponse<Member>.For(filtredMember, pageRequest, query.Count());
        }

    }
}