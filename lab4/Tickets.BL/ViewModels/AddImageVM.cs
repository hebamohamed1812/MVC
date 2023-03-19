using Microsoft.AspNetCore.Http;

namespace Tickets.Models.ViewModels;

public record AddImageVM(int Id, IFormFile? Image);
