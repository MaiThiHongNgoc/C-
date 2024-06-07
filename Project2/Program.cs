using Project2;

class Program
{
    public static void Main(string[] args)
    {
        IProductRepository productRepository = new ProductService();
        Menu(productRepository);
    }
    static void Menu(IProductRepository productRepository)
    {
        while (true)
        {
            Console.WriteLine("Product Management");
            Console.WriteLine("1. List All Products");
            Console.WriteLine("2. Create a new Product");
            Console.WriteLine("3. Read the new Product");
            Console.WriteLine("4. Update the new Product");
            Console.WriteLine("5. Delete the new Product");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Select an option: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ListAllProduct(productRepository);
                    break;
                case "2":
                    CreateProduct(productRepository);
                    break;
                case "3":
                    ReadProduct(productRepository);
                    break;
                case "4":
                    UpdateProduct(productRepository);
                    break;
                case "5":
                    DeleteProduct(productRepository);
                    break;
                case "6":
                    return;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Psl try again");
                    break;
            }


        }
    }
    static void ListAllProduct(IProductRepository productRepository)
    {
        List<Product> products = productRepository.GetAll();
        foreach (var product in products)
        {
            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Description: {product.Description}");

        }
    }
    static void CreateProduct(IProductRepository productRepository)
    {
        Console.WriteLine("Enter product name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter product price: ");
        decimal price = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Enter product description: ");
        string description = Console.ReadLine();
        Product newProduct = new Product
        {
            Name = name,
            Price = price,
            Description = description
        };
        productRepository.Create(newProduct);
        Console.WriteLine("Product created successfully!");
    }

    static void ReadProduct(IProductRepository productRepository)
    {
        Console.WriteLine("Enter product ID: ");
        int id = int.Parse(Console.ReadLine());
        Product product = productRepository.Read(id);
        if (product != null)
        {
            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Description: {product.Description}");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    static void UpdateProduct(IProductRepository productRepository)
    {
        Console.WriteLine("Enter product ID to update: ");
        int id = int.Parse(Console.ReadLine());
        Product existingProduct = productRepository.Read(id);
        if (existingProduct != null)
        {
            Console.WriteLine("Enter new product name (leave blank to keep current): ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter new product price (leave blank to keep current): ");
            string priceInput = Console.ReadLine();
            Console.WriteLine("Enter new product description (leave blank to keep current): ");
            string description = Console.ReadLine();

            if (!string.IsNullOrEmpty(name)) existingProduct.Name = name;
            if (!string.IsNullOrEmpty(priceInput)) existingProduct.Price = decimal.Parse(priceInput);
            if (!string.IsNullOrEmpty(description)) existingProduct.Description = description;

            productRepository.Update(existingProduct);
            Console.WriteLine("Product updated successfully!");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }

    }

    static void DeleteProduct(IProductRepository productRepository)
    {
        Console.WriteLine("Enter product ID to delete: ");
        int id = int.Parse(Console.ReadLine());
        productRepository.Delete(id);
        Console.WriteLine("Product deleted successfully!");
    }
}