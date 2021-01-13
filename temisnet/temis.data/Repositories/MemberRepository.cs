using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using temis.Core.Interfaces;
using temis.Core.Models;
using temis.data.Data;
using MySql.Data.MySqlClient;
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

        public PageResponse<PessoaFisica> Filter(string name, PageRequest pageRequest)
        {
            IQueryable<PessoaFisica> query = _context.Pessoas.Where(
                                    i =>
                                    i.Name.Contains(name) ||
                                    i.LastName.Contains(name)
                                   ).OrderBy(u => u.Name);

            List<PessoaFisica> filtredPessoaFisica;
            filtredPessoaFisica = PaginationRepository<PessoaFisica>.For(query, pageRequest).ToList();
            return PageResponse<PessoaFisica>.For(filtredPessoaFisica, pageRequest, query.Count());
        }
    }
}