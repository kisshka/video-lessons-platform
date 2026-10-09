using CSharpFunctionalExtensions;
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

        public Title(string value)
        {
            Value = value;
        }

        public static Result<Title, string> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > MAX_LENGTH)
            {
                return "неверный формат заголовка";
            }

            return new Title(value);
        }
    }
}
