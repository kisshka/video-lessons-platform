using CSharpFunctionalExtensions;
using EducationContentService.Domain.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationContentService.Domain.ValueObjects
{
    public record Title
    {
        public const int MAX_LENGTH = 200;

        public string Value { get; }

        private Title(string value)
        {
            Value = value;
        }

        public static Result<Title, ErrorBody> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > MAX_LENGTH)
            {
                return GeneralErrors.InvalidValue(nameof(Title), nameof(Value));
            }

            return new Title(value);
        }
    }
}
