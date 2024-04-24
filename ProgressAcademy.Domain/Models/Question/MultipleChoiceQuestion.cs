using System.Collections.Generic;

namespace ProgressAcademy.Domain.Models
{
    /// <summary>
    /// Represents a multiple-choice question.
    /// </summary>
    public class MultipleChoiceQuestion : IQuestionAnswer
    {
        /// <summary>
        /// The question text.
        /// </summary>
        public string? Question { get; set; }

        /// <summary>
        /// The list of options for the question.
        /// </summary>
        public List<string>? Options { get; set; }

        /// <summary>
        /// The selected answer for the question.
        /// </summary>
        public List<string>? Answers { get; set; }
    }
}
