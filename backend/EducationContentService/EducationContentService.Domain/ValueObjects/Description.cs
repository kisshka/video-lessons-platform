using CSharpFunctionalExtensions;
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

        public Description(string value)
        {
            Value = value;
        }

        public static Result<Description, string> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > MAX_LENGTH)
            {
                return "неверный формат описания";
            }

            return new Description(value);
        }
    }
}
