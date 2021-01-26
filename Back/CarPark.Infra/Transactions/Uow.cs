using CarPark.Infra.Data;

namespace CarPark.Infra.Transactions
{
    public class Uow : IUow
    {
        private readonly DataContext _context;

        public Uow(DataContext datacontext)
        {
            _context = datacontext;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            ///Nada.
        }
    }
}