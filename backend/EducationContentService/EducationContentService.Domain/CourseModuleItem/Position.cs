using CSharpFunctionalExtensions;
using EducationContentService.Domain.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationContentService.Domain.CourseModuleItems
{
    public record Position
    {
        public Position(ItemType item, decimal value)
        {
            Type = item;
            Value = value;
        }

        public const decimal INITIAL_STEP = 1000;
        public decimal Value { get; private set; }

        public ItemType Type { get; private set; }

        private Position First(ItemType item, decimal value) => new(item, INITIAL_STEP);

        public static Result<Position, ErrorBody> Beetwen(Position before, Position after)
        {
            if (before.Type != after.Type)
            {
                return ErrorBody.Validation( new ErrorMessage("position.item.type", "Невозможно создать позицию между элементами разных типов", "position") );
            }

            if (before.Value >= after.Value)
            {
                return ErrorBody.Validation( new ErrorMessage("position.item", "Позиция до больше, чем позиция после", "position") );
            }

            return new Position(before.Type, (before.Value + after.Value) / 2);
        }

        public static Position After(Position position)
            => new(position.Type, position.Value + INITIAL_STEP);

    }
}
