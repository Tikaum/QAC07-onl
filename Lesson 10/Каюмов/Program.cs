namespace Linq2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product> {
            new Product { Id = 1, Name = "C# in Depth", Category = "Books", Price = 45.5m, QuantityInStock = 5, Rating = 4.8 },
            new Product { Id = 2, Name = "Smartphone", Category = "Electronics", Price = 699.99m, QuantityInStock = 0, Rating = 4.3 },
            new Product { Id = 3, Name = "T-shirt", Category = "Clothes", Price = 19.99m, QuantityInStock = 20, Rating = 4.1 },
            new Product { Id = 4, Name = "Laptop", Category = "Electronics", Price = 1200m, QuantityInStock = 7, Rating = 4.7 },
            new Product { Id = 5, Name = "Blender", Category = "Electronics", Price = 85m, QuantityInStock = 12, Rating = 4.0 },
            new Product { Id = 6, Name = "Novel", Category = "Books", Price = 15m, QuantityInStock = 0, Rating = 4.6 },
            new Product { Id = 7, Name = "Jeans", Category = "Clothes", Price = 49.99m, QuantityInStock = 15, Rating = 3.8 },
            new Product { Id = 8, Name = "Monitor", Category = "Electronics", Price = 250m, QuantityInStock = 3, Rating = 4.4 },
            new Product { Id = 9, Name = "Sneakers", Category = "Clothes", Price = 89.99m, QuantityInStock = 10, Rating = 4.2 },
            new Product { Id = 10, Name = "Dictionary", Category = "Books", Price = 29.99m, QuantityInStock = 8, Rating = 4.9 }};

            //1) Получите список всех товаров категории "Books", у которых есть остаток на складе.
            var ExistBooks = products.Where(b => b.Category == "Books" && b.IsAvailable);

            //2)Получите имена всех товаров, у которых рейтинг выше 4.5.
            var NameGoodsWithRatingUp4i5 = products.Where(b => b.Rating > 4.5).Select(b => b.Name);

            //3) Отсортируйте все товары по цене по убыванию.
            var GoodsDescPrice = products.OrderByDescending(b => b.Price);

            //4) Получите среднюю цену всех товаров категории "Electronics".
            var AveragePriceOfElectronics = products.Where(b => b.Category == "Electronics").Average(b => b.Price);

            //5) Выведите первый товар, у которого нет остатков на складе.
            var FirstEndedGoods = products.Where(b => !b.IsAvailable).First();

            //6) Проверьте, есть ли хоть один товар, у которого рейтинг меньше 4.0.
            var IsExistGoodsWithRatingLower4i0 = products.Any(b => b.Rating < 4.0);

            //7) Создайте список анонимных объектов: Name, Price, InStock, где InStock — это "Yes" или "No" в зависимости от наличия товара на складе.
            var AnonGoods = products.Select(p => new {
                Name = p.Name,
                Price = p.Price,
                InStock = p.IsAvailable ? "Yes" : "No"})
                .ToList();

            //8) Группируйте все товары по категории и для каждой группы выведите:
            //    -название категории,
            //    -количество товаров,
            //    -среднюю цену товаров в категории.
            var CategoryOfGoods = products.GroupBy(good => good.Category)
                .Select(categoryInfo => new {
                CategoryName = categoryInfo.Key,
                CategoryCount = categoryInfo.Count(),
                CategoryAveragePrice = categoryInfo.Select(p => p.Price).Average()});

            //9) Получите список всех уникальных категорий, отсортированных по алфавиту
            var UniqCategoryNames = products.Select(a => a.Category).Distinct().OrderBy(c => c);

            //10) Найдите 3 самых дорогих товара из всех доступных(в наличии) и выведите их названия и цену.
            var ThreeMostExpensiveGoods = products.Where(g => g.IsAvailable)
                .OrderByDescending(g => g.Price)
                .Take(3).Select(g => new {
                Name = g.Name,
                Price = g.Price});




           

            



        }
    }

}
