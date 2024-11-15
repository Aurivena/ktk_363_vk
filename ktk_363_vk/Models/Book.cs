using System;

namespace ktk_363_vk.Models;

public class Book
{
    public string Title { get; set; }
    public Author Author { get; set; }= new Author();
    public int YearCreated { get; set; }
    public Genre Genre { get; set; }= new Genre();
    public int CountPages { get; set; }
    public decimal Price { get; set; }
}

public class Genre
{
    public string Name { get; set; }
}

public class Author
{
    public string Name { get; set; }
}