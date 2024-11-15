using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using ktk_363_vk.Models;

namespace ktk_363_vk.ViewModels;

public class BookViewModel: INotifyPropertyChanged
{
    public ObservableCollection<Book> Books { get; set; }
    public Book? SelectedBook { get; set; }
    
    public Book NewBook { get; set; }
    
    private CommandBook _commandBook;
    
    private Book _selectedBookPopup;
    public Book SelectedBookPopup
    {
        get => _selectedBookPopup;
        set
        {
            if (_selectedBookPopup != value)
            {
                _selectedBookPopup = value;
                OnPropertyChanged();
            }
        }
    }
    
    public Popup Popup;
    
        
    private bool _isPopupForAppendVisible;
    public bool IsPopupForAppendVisible
    {
        get => _isPopupForAppendVisible;
        set
        {
            if (_isPopupForAppendVisible != value)
            {
                _isPopupForAppendVisible = value;
                OnPropertyChanged();
            }
        }
    }

    private bool _isPopupForUpdateVisible;
    public bool IsPopupForUpdateVisible
    {
        get => _isPopupForUpdateVisible;
        set
        {
            if (_isPopupForUpdateVisible != value)
            {
                _isPopupForUpdateVisible = value;
                OnPropertyChanged();
            }
        }
    }

    
    public  BookViewModel()
    {
        Books = new ObservableCollection<Book>()
        {
            new Book
            {
                Title = "Book 1", Author = new Author{Name="Author 1"}, YearCreated = 2000, Genre = new Genre {Name="jar"}, CountPages = 100,
                Price = 9.99m
            },
            new Book
            {
                Title = "Book 2", Author = new Author{Name="Author 2"}, YearCreated = 2010, Genre = new Genre {Name="123"}, CountPages = 200,
                Price = 12.99m
            },
        };
        NewBook = new Book
        {
            Author = new Author(),
            Genre = new Genre(),
            Title = string.Empty,
            YearCreated = 0,
            CountPages = 0,
            Price = 0
        };
        
        Popup = new Popup(this);
        
        _commandBook = new CommandBook(this);
    }

    public void RemoveBook()
    {
        _commandBook.RemoveBook();
    }

    public void AppendBook()
    {
        _commandBook.AppendBook();
    }

    public void ShowPopupForAppend()
    {
        Popup.ShowPopupAppend();
    }

    public void ClosePopup()
    {
        Popup.ClosePopup();
    }

    public void ShowPopupForUpdate()
    {
        if (SelectedBook != null)
        {
            Popup.ShowPopupUpdate();            
        }
    }
    
    public void UpdateBook()
    {
        if (SelectedBook != null)
        {
            bool success = _commandBook.UpdateBook(SelectedBook);
            
            if (success)
            {
                Console.WriteLine( "Книга успешно обновлена!");
                ClosePopup();
            }
            else
            {
                Console.WriteLine("Ошибка при обновлении книги.");
            }
        }
    }

    
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null!)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}