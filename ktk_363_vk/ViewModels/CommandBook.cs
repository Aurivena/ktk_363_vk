using System;
using System.Linq;
using Avalonia.Controls.Primitives;
using ktk_363_vk.Models;

namespace ktk_363_vk.ViewModels;

public class CommandBook : ICommandBook
{
    private BookViewModel _viewModel { get; }
    private Popup _popup { get; }

    public CommandBook(BookViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public void RemoveBook()
    {
        if (_viewModel.SelectedBook != null)
        {
            _viewModel.Books.Remove(_viewModel.SelectedBook);
        }
    }

    public void AppendBook()
    {
        if (!validate(_viewModel.NewBook.YearCreated, _viewModel.NewBook.CountPages,_viewModel.NewBook.Price, out string errorMessage))
        {
            Console.WriteLine(errorMessage);
            return;
        }

        var newBook = new Book
        {
            Title = _viewModel.NewBook.Title,
            Author = new Author { Name = _viewModel.NewBook.Author.Name },
            YearCreated = _viewModel.NewBook.YearCreated,
            Genre = new Genre() { Name = _viewModel.NewBook.Genre.Name },
            CountPages = _viewModel.NewBook.CountPages,
            Price = _viewModel.NewBook.Price
        };
        _viewModel.Books.Add(newBook);
        _viewModel.NewBook = new Book();
        _viewModel.SelectedBook = null;
        _viewModel.OnPropertyChanged(nameof(_viewModel.NewBook));
        _viewModel.OnPropertyChanged(nameof(_viewModel.SelectedBook));
        return;
    }

    public bool UpdateBook(Book updatedBook)
    {
        if (updatedBook == null || string.IsNullOrEmpty(updatedBook.Title))
        {
            Console.WriteLine("Обновление невозможно: передана некорректная книга.");
            return false;
        }

        var bookInCollection = _viewModel.Books.FirstOrDefault(b => b.Title == updatedBook.Title);
        if (bookInCollection != null)
        {

            if (!validate(_viewModel.NewBook.YearCreated,_viewModel.NewBook.CountPages, _viewModel.NewBook.Price, out string errorMessage))
            {
                Console.WriteLine(errorMessage);
                return false;
            }
            
            var newBook = new Book
            {
                Title = _viewModel.NewBook.Title,
                Author = new Author { Name = _viewModel.NewBook.Author.Name },
                YearCreated = _viewModel.NewBook.YearCreated,
                Genre = new Genre() { Name = _viewModel.NewBook.Genre.Name },
                CountPages = _viewModel.NewBook.CountPages,
                Price = _viewModel.NewBook.Price
            };
            _viewModel.Books.Add(newBook);
            _viewModel.Books.Remove(updatedBook);
            
            _viewModel.OnPropertyChanged(nameof(_viewModel.Books));
            _viewModel.OnPropertyChanged(nameof(bookInCollection));
            _viewModel.OnPropertyChanged(nameof(_viewModel.SelectedBook));

            Console.WriteLine("Книга успешно обновлена!");
            return true;
        }

        return false;
    }

    private bool validate(int year, int pages, decimal price, out string errorMessage)
    {
        if (year<= 0 || year > DateTime.Now.Year)
        {
            errorMessage = "Ошибка: Некорректный год создания!";
            return false;
        }
        
        if (pages <= 0)
        {
            errorMessage = "Ошибка: Некорректная цена!";
            return false;
        }

        if (price <= 0)
        {
            errorMessage = "Ошибка: Некорректная цена!";
            return false;
        }
        errorMessage = string.Empty;
        return true;
    }
}