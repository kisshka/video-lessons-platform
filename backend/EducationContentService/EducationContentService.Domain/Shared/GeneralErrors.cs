using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationContentService.Domain.Share
{
    public static class GeneralErrors
    {
        public static ErrorBody InvalidValue(string entity, string fieldName)
            => ErrorBody.Validation(new ErrorMessage($"{entity}.invalid_value", $"Поле {fieldName} имеет неверное значение", fieldName));

        public static ErrorBody NotFound(string entity, string fieldName)
            => ErrorBody.NotFound(new ErrorMessage($"{entity}.not_found", $"Запись {entity} не найдена", fieldName));

        public static ErrorBody ValueIsRequired(string entity, string fieldName)
            => ErrorBody.Validation(new ErrorMessage($"{entity}.value_required", $"Поле {fieldName} обязательно", fieldName));

        public static ErrorBody AlreadyExist(string entity)
            => ErrorBody.Conflict(new ErrorMessage($"{entity}.already.exist", "Запись уже существует", null));

        public static ErrorBody Failure(string? message = null)
            => ErrorBody.Validation(new ErrorMessage("server.failure", message ?? "Серверная ошибка", null));
    }
}
