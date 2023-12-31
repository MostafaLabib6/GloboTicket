﻿using GloboTicket.Application.Models;
using MediatR;

namespace GloboTicket.Application.Features.Event.Commands.Update;

public class UpdateEventCommand : IRequest
{
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public string? Artist { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public Guid CategoryId { get; set; }
}
