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
            return membros.OrderBy(u => u.Name).ToList();
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
                context.Database.ExecuteSqlRaw($@"INSERT INTO member (name, age, role, lastName)
                                            VALUES (""{member.Name}"", ""{member.Age}"", {member.Role}, ""{member.LastName}"");");
            }

            return context.Membros.Where(p => p.Name == member.Name).FirstOrDefault();
        }

        public Member EditMember(Member member)
        {
            var memberId = new MySqlParameter("@memberId", member.Id);
            var memberIdade = new MySqlParameter("@memberAge", member.Age);
            var memberNome = new MySqlParameter("@memberName", member.Name);
            var memberSobrenome = new MySqlParameter("@memberLastName", member.LastName);
            var memberMembername = new MySqlParameter("@memberRole", member.Role);

            context.Database.ExecuteSqlRaw(
                "UPDATE member SET idade = @memberAge, name = @memberName, lastName = @memberLastName, memberName = @memberName WHERE id = @memberId", 
                memberIdade, memberNome, memberSobrenome, memberMembername, memberId);

            
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
           // memberPassword.Password = password;
        }

        public IEnumerable<Member> PartialEditMember(string membername)
        {

            IEnumerable<Member> member =
            from memberByName in members
            where memberByName.Name == membername
            select memberByName;

            return member;
        }
        public PageResponse<Member> Filter(string name, PageRequest pageRequest)
        {
            IQueryable<Member> query = context.Membros.Where(
                                    i => 
                                    i.Name.Contains(name) ||
                                    i.LastName.Contains(name) 
                                   ).OrderBy(u => u.Name);

            List<Member> filtredMember;
            filtredMember = PaginationRepository<Member>.For(query, pageRequest).ToList();
            return PageResponse<Member>.For(filtredMember, pageRequest, query.Count());
        }

    }
}