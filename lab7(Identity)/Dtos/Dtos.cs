namespace lab7_Identity_.Dtos;

public record LoginDto(string UserName, string Password);
public record RegisterDto(string UserName, string Password, string Email, DateTime DOB);