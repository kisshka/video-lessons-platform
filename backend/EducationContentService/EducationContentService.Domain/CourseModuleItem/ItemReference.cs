using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationContentService.Domain.CourseModuleItems
{
    public record ItemReference
    {
        public Guid ItemId { get; private set; }
        public ItemType Type { get; private set; }

        private ItemReference(ItemType itemType, Guid itemId)
        {
            Type = itemType;
            ItemId = itemId;
        }
        // Прикрепление урока к модулю
        public static ItemReference ToLesson(Guid lessonId) => new(ItemType.LESSON, lessonId);
        // Прикрепление задачи к модулю
        public static ItemReference ToIssue(Guid issueId) => new(ItemType.ISSUE, issueId);
    }
}
