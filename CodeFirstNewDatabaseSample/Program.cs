// See https://aka.ms/new-console-template for more information
using CodeFirstNewDatabaseSample;

// Link ref: https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/workflows/new-database

using (var db = new BloggingContext())
{
    // Create and save a new Blog
    //Console.Write("Enter a name for a new Blog: ");
    //var name = Console.ReadLine();

    //var blog = new Blog { Name = name };
    //db.Blogs.Add(blog);
    //db.SaveChanges();

    // Display all Blogs from the database
    var query = from b in db.Blogs
                orderby b.Name
                select b;

    Console.WriteLine("All blogs in the database:");
    foreach (var item in query)
    {
        Console.WriteLine(item.Name);
    }

    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}