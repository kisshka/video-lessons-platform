using CSharpFunctionalExtensions;
using EducationContentService.Domain.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationContentService.Domain.ValueObjects
{
    public record Description
    {
        public const int MAX_LENGTH = 5000;

        public string Value { get; }

        private Description(string value)
        {
            Value = value;
        }

        public static Result<Description, ErrorBody> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > MAX_LENGTH)
            {
                return GeneralErrors.InvalidValue(nameof(Description), nameof(Value));
            }

            return new Description(value);
        }
    }
}
