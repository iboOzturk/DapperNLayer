using Dapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.DTOs;

namespace DataAccessLayer.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductDal
    {       

        public async Task<List<Product>> GetOldestProductsAsync()
        {
            string query = "SELECT * FROM Products WHERE CreateDate <= DATEADD(MONTH, -1, GETDATE());";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<Product>(query);
                return values.ToList();
            }
        }

        public async Task<List<ProductWithCategoryDto>> GetProductWithCategoryAsync()
        {
            string query = @"SELECT p.ProductId, p.name , p.description,
                            p.CreateDate, c.name , c.categoryId AS categoryId
                            FROM Products p INNER JOIN Categories c ON p.categoryId = c.categoryId";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ProductWithCategoryDto, Category, ProductWithCategoryDto>(
                    query,
                    (product, category) =>
                    {
                        product.Category = category;
                        return product;
                    },
                    splitOn: "name"
                );

                return values.ToList();
            }
        }
    }
}
