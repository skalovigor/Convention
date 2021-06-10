using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace Convention.BLL.Infrastructure.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException() : base("Validation failed.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}