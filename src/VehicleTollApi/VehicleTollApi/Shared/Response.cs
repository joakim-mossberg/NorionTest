using FluentValidation.Results;
using System.Collections.ObjectModel;

namespace VehicleTollApi.Shared;

public class Response
{
    private readonly IList<ValidationFailure> _errorMessages;

    public Response(IList<ValidationFailure> errors = null!)
    {
        _errorMessages = errors ?? new List<ValidationFailure>();
    }

    public bool IsValidResponse => !_errorMessages.Any();

    public IReadOnlyCollection<ValidationFailure> Errors => new ReadOnlyCollection<ValidationFailure>(_errorMessages);
}

public class Response<TModel> : Response
    where TModel : class
{

    public Response(TModel model, IList<ValidationFailure> errors = null!)
        : base(errors)
    {
        Result = model;
    }

    public TModel Result { get; }
}