using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationContentService.Domain.Share
{
    public record ErrorBody
    {
        public IReadOnlyList<ErrorMessage> Messages { get; } = [];

        private ErrorBody( IEnumerable<ErrorMessage> messages, ErrorType type)
        {
            Messages = messages.ToArray();
            Type = type;
        }

        //public string Code { get;}
        //public string Message { get;}
        public ErrorType Type { get;}
        //public string? InvalidField { get;}
    
    public static ErrorBody Validation(params IEnumerable<ErrorMessage> messages) =>
            new (messages, ErrorType.VALIDATION);

    public static ErrorBody NotFound(params IEnumerable<ErrorMessage> messages) =>
        new(messages, ErrorType.NOT_FOUND);

    public static ErrorBody Failure(params IEnumerable<ErrorMessage> messages) =>
        new(messages, ErrorType.FAILURE);

    public static ErrorBody Conflict(params IEnumerable<ErrorMessage> messages) =>
        new(messages, ErrorType.CONFLICT);

    public static ErrorBody Authentication(params IEnumerable<ErrorMessage> messages) =>
        new(messages, ErrorType.AUTHENTICATION);

    public static ErrorBody Authorization(params IEnumerable<ErrorMessage> messages) =>
        new(messages, ErrorType.AUTHORIZATION);
    }

    public enum ErrorType
    {
        VALIDATION,
        NOT_FOUND,
        FAILURE,
        CONFLICT,
        AUTHENTICATION,
        AUTHORIZATION
    }

    public record ErrorMessage(string Code, string Message, string? InvalidField);

}
