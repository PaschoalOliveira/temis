using System.Collections.Generic;
using System.Linq;
using temis.Core.Interfaces;
using temis.Core.Models;
using temis.data.Data;
using Solutis.Services;

namespace temis.Data.Repositories
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(TemisContext context) : base(context) { }

        private static List<Member> members = new List<Member>();

        public Member Validate(string cpf, string password)
        {

            var users = this.FindAll().ToList();
            string passwordGenerate = GenerateToken.GenerateMD5(password);
            var user = users.Where(
                    x =>
                         x.Cpf == cpf &&
                         x.Password == passwordGenerate
                         ).FirstOrDefault();
            return user;
        }

        public void EditPassword(long id, string password)
        {
            Member memberPassword = new Member() { Id = id };
        }

        public PageResponse<Member> Filter(string name, PageRequest pageRequest)
        {
            IQueryable<Member> query = _context.Members.Where(
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