namespace ProductsAttributesRestApi.Models.Dtos;

public class UserResponse
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public required string Phone { get; set; }
}
