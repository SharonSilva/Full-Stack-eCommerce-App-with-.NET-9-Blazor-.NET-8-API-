using eCommerceApp.Application.DTOs.Product;

namespace eCommerceApp.Application.DTOs.Category;

public class UpdateCategory : CategoryBase
{
    public Guid Id { get; set; }
}