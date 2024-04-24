namespace ProgressAcademy.Domain.Models
{
    /// <summary>
    /// Represents a free-form question.
    /// </summary>
    public class FreeFormQuestion : IQuestionAnswer
    {
        /// <summary>
        /// The question text.
        /// </summary>
        public string? Question { get; set; }

        /// <summary>
        /// The answer to the question.
        /// </summary>
        public List<string>? Answers { get; set; }
    }
}