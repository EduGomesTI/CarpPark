using System.Linq;
using CarPark.Dominio.PessoaJuridicaContext.Entities;
using CarPark.Dominio.PessoaJuridicaContext.Queries;
using CarPark.Dominio.Repositories;
using CarPark.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace CarPark.Infra.Repositories
{
    public class PessoaJuridicaRepository : IPessoaJuridicaRepository
    {
        private readonly DataContext _context;

        public PessoaJuridicaRepository(DataContext context)
        {
            _context = context;
        }

        public void Alterar(PessoaJuridica entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Cadastrar(PessoaJuridica entity)
        {
            _context.PessoasJuridicas.Add(entity);
            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        public PessoaJuridica GetCNPJ(string cnpj)
        {
            return _context.PessoasJuridicas
                .AsNoTracking()
                .Where(PessoaJuridicaQueries.GetCNPJ(cnpj))
                .Include(e => e.Emails)
                .Include(t => t.Telefones)
                .Include(n => n.Endereco)
                .FirstOrDefault();

        }

        public PessoaJuridica GetNomeFantasia(string nomeFantasia)
        {
            return _context.PessoasJuridicas
                .AsNoTracking()
                .Where(PessoaJuridicaQueries.GetNomeFantasia(nomeFantasia))
                .Include(e => e.Emails)
                .Include(t => t.Telefones)
                .Include(n => n.Endereco)
                .FirstOrDefault();
        }

        public PessoaJuridica GetRazaoSocial(string razaoSocial)
        {
            return _context.PessoasJuridicas
                .AsNoTracking()
                .Where(PessoaJuridicaQueries.GetRazaoSocial(razaoSocial))
                .Include(e => e.Emails)
                .Include(t => t.Telefones)
                .Include(n => n.Endereco)
                .FirstOrDefault();
        }        
    }
}