namespace ProgressAcademy.Domain.ReadModels
{
    /// <summary>
    /// Represents a simplified version of a mentee.
    /// </summary>
    public class SimplifiedMentee
    {
        /// <summary>
        /// Gets or sets the ID of the mentee.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the full name of the mentee.
        /// </summary>
        public string? FullName { get; set; }
    }
}
