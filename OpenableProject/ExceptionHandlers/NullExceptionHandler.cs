using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace OpenableProject.ExceptionHandlers;

public class NullExceptionHandler(IProblemDetailsService problemDetailsService) 
    : ExceptionHandler<NullReferenceException>(StatusCodes.Status400BadRequest, nameof(NullReferenceException), problemDetailsService);