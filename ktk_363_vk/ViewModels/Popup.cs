using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ktk_363_vk.Models;

namespace ktk_363_vk.ViewModels;

public class Popup:IPopup

{
    private readonly BookViewModel _viewModel;
    
    public Popup(BookViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public void ShowPopupAppend()
    {
        _viewModel.IsPopupForAppendVisible = true;
        _viewModel.IsPopupForUpdateVisible = false;
    }

    public void ShowPopupUpdate()
    {
        if (_viewModel.SelectedBook != null)
        {
            _viewModel.NewBook = new Book
            {
                Title = _viewModel.SelectedBook.Title,
                Author = new Author { Name = _viewModel.SelectedBook.Author.Name },
                YearCreated = _viewModel.SelectedBook.YearCreated,
                Genre = new Genre { Name = _viewModel.SelectedBook.Genre.Name },
                CountPages = _viewModel.SelectedBook.CountPages,
                Price = _viewModel.SelectedBook.Price
            };
        }
        
        _viewModel.IsPopupForAppendVisible = false;
        _viewModel.IsPopupForUpdateVisible = true;
        _viewModel.OnPropertyChanged(nameof(_viewModel.NewBook));
    }

    public void ClosePopup()
    {
        _viewModel.IsPopupForAppendVisible = false;
        _viewModel.IsPopupForUpdateVisible = false;
            _viewModel.NewBook = new Book();
            _viewModel.SelectedBook = null;
            _viewModel.OnPropertyChanged(nameof( _viewModel.NewBook));
            _viewModel.OnPropertyChanged(nameof(_viewModel.SelectedBook));
    }
}