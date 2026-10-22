using CSharpFunctionalExtensions;
using EducationContentService.Domain.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationContentService.Domain.CourseModuleItems
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
        
        // ссылка на элемент урока
        public ItemReference ItemReference { get; private set; } = null!;

        public Position Position { get; private set; } = null!;

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }

    }

}
