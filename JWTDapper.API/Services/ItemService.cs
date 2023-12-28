using Dapper;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace JWTDapper.API.Services
{
    public class ItemService
    {
        protected readonly DALContext _context;

        public ItemService()
        {
            _context = new DALContext();

        }

        public async Task<IEnumerable<Item>> GetItemsForUserAsync(int userId)
        {
            string query = "SELECT * FROM Items WHERE UserId = @UserId";
            using (var connection = _context.CreateConnection())
            {
                var items = await connection.QueryAsync<Item>(query,
                    new { UserId = userId }
                );
                return items;
            }
        }
    }
}
