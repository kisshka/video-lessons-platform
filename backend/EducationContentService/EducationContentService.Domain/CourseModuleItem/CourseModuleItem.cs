using CSharpFunctionalExtensions;
using EducationContentService.Domain.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationContentService.Domain.CourseModuleItem
{
    public sealed class CourseModuleItem
    {
        private CourseModuleItem()
        {  
        }

        public CourseModuleItem(Guid? id, Guid courseModuleId, ItemReference itemReference, Position position)
        {
            Id = id ?? Guid.NewGuid();
            CourseModuleId = courseModuleId;
            ItemReference = itemReference;
            Position = position;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }

        public Guid CourseModuleId { get; private set; }

        public ItemReference ItemReference { get; private set; } = null!;

        public Position Position { get; private set; } = null!;

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }

    }

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

        private Position First(ItemType item, decimal value) => new (item, INITIAL_STEP);

        public static Result<Position, string> Beetwen(Position before, Position after)
        {
            if (before.Type != after.Type)
            {
                return "Невозможно создать позицию между элементами разных типов";
            }

            if(before.Value >= after.Value)
            {
                return "Позиция до больше, чем позиция после";
            }

            return new Position(before.Type, (before.Value + after.Value) / 2);
        }

        public static Position After(Position position)
            => new(position.Type, position.Value + INITIAL_STEP);

    }


    public record ItemReference
    {
        public Guid ItemId { get; private set; }
        public ItemType Type { get; private set; }

        private ItemReference(ItemType itemType, Guid itemId)
        {
            Type = itemType;
            ItemId = itemId;
        }

        public static ItemReference ToLesson(Guid lessonId) => new (ItemType.LESSON, lessonId);

        public static ItemReference ToIssue(Guid issueId) => new(ItemType.ISSUE, issueId);
    }

    public enum ItemType
    {
        LESSON,
        ISSUE
    }

}
