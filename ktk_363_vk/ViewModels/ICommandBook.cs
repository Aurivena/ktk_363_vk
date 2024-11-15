using ktk_363_vk.Models;

namespace ktk_363_vk.ViewModels;

public interface ICommandBook
{
    public void RemoveBook();
    public void AppendBook();
    public bool UpdateBook(Book updatedBook);
}