namespace ClassTemplates;

// Template variables:
// $time$ => The current DateTime
// $username$ => The user that is logged in the computer

using Microsoft.Extensions.Logging;

/// <summary>
/// Purpose: 
/// Created By: $username$
/// Created On: $time$
/// </summary>
public class ComplexClassTemplate
{
    private readonly ILogger<ComplexClassTemplate> _logger;

    public ComplexClassTemplate(ILogger<ComplexClassTemplate> logger)
    {
        _logger = logger;
    }
}
