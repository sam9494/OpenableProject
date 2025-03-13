using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OpenableProject.Exceptions;

namespace OpenableProject.ExceptionHandlers;

public class OrderNotFoundExceptionHandler(IProblemDetailsService problemDetailsService)
    : ExceptionHandler<OrderNotFoundException>(OrderNotFoundException.StatusCode, OrderNotFoundException.Title, problemDetailsService);
