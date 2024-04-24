namespace ProgressAcademy.Domain.Models
{
    /// <summary>
    /// Represents a question-answer pair interface.
    /// </summary>
    public interface IQuestionAnswer
    {
        /// <summary>
        /// The question.
        /// </summary>
        string Question { get; set; }

        /// <summary>
        /// The answer to the question.
        /// </summary>
        List<string> Answers { get; set; }
    }
}