using System.ComponentModel.DataAnnotations;

namespace RazorPagesTestSample.Data
{
     #region snippet1
    public class Message
    {
        public int Id { get; set; }
    
        /// <summary>
        /// Gets or sets the unique identifier for the message.
        /// </summary>
     

        /// <summary>
        /// Gets or sets the text content of the message.
        /// </summary>
        
        [Required]
        [DataType(DataType.Text)]
        [StringLength(250, ErrorMessage = "There's a 250 character limit on messages. Please shorten your message.")]
        public string Text { get; set; }
    }
    #endregion
}
