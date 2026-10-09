using EducationContentService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationContentService.Domain.Module
{
    public sealed class CourseModule
    {
        public CourseModule(Guid? id, Title title, Description description)
        {
            Id = id ?? Guid.NewGuid();
            Title = title;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;
            DeletedAt = null;
        }

        public Guid Id { get; }

        public Title Title { get; private set; }

        public Description Description { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }

        public DateTime? DeletedAt { get; private set; }
    }
}
