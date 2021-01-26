using System.Collections.Generic;
using System.Linq;
using CarPark.Dominio.PessoaFisicaContext.Entities;
using CarPark.Dominio.PessoaFisicaContext.Queries;
using CarPark.Dominio.Repositories;
using CarPark.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace CarPark.Infra.Repositories
{
    public class PessoaFisicaRepository : IPessoaFisicaRepository
    {
        private readonly DataContext _context;

        public PessoaFisicaRepository(DataContext context)
        {
            _context = context;
        }

        public void Alterar(PessoaFisica entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Cadastrar(PessoaFisica entity)
        {
            _context.PessoasFisicas.Add(entity);
            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        public PessoaFisica GetCPF(string cpf)
        {
            return _context.PessoasFisicas
                .AsNoTracking()
                .Where(PessoaFisicaQueries.GetCPF(cpf))
                .Include(e => e.Emails)
                .Include(t => t.Telefones)
                .Include(n => n.Endereco)
                .FirstOrDefault();
        }

        public PessoaFisica GetNome(string nome)
        {
            return _context.PessoasFisicas
                .AsNoTracking()
                .Where(PessoaFisicaQueries.GetNome(nome))
                .Include(e => e.Emails)
                .Include(t => t.Telefones)
                .Include(n => n.Endereco)
                .FirstOrDefault();
        }

        public PessoaFisica GetRG(string rg)
        {
            return _context.PessoasFisicas
                .AsNoTracking()
                .Where(PessoaFisicaQueries.GetRG(rg))
                .Include(e => e.Emails)
                .Include(t => t.Telefones)
                .Include(n => n.Endereco)
                .FirstOrDefault();
        }
    }
}