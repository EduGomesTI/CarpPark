using CarPark.Dominio.Shared.Entities;

namespace CarPark.Dominio.Shared.Interfaces
{
    public interface IRepository<T> where T : class
    {        
        void Cadastrar(T entity);
        void Alterar(T entity);
        void Excluir(int id);
    }
}