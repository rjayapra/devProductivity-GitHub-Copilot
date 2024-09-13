using System.ComponentModel.DataAnnotations;
using Xunit;

namespace RazorPagesTestSample.Data.Tests
{
    public class MessageTest
    {
        [Fact]
        public void Message_Id_ShouldGetAndSetId()
        {
            // Arrange
            var message = new Message();
            var expectedId = 1;

            // Act
            message.Id = expectedId;

            // Assert
            Assert.Equal(expectedId, message.Id);
        }

        [Fact]
        public void Message_Text_ShouldGetAndSetText()
        {
            // Arrange
            var message = new Message();
            var expectedText = "Hello, World!";

            // Act
            message.Text = expectedText;

            // Assert
            Assert.Equal(expectedText, message.Text);
        }

        [Fact]
        public void Message_Text_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var property = typeof(Message).GetProperty(nameof(Message.Text));

            // Act
            var attribute = property.GetCustomAttributes(typeof(RequiredAttribute), false);

            // Assert
            Assert.NotEmpty(attribute);
        }

        [Fact]
        public void Message_Text_ShouldHaveStringLengthAttribute()
        {
            // Arrange
            var property = typeof(Message).GetProperty(nameof(Message.Text));

            // Act
            var attribute = property.GetCustomAttributes(typeof(StringLengthAttribute), false).FirstOrDefault() as StringLengthAttribute;

            // Assert
            Assert.NotNull(attribute);
            Assert.Equal(250, attribute.MaximumLength);
        }

        [Fact]
        public void Message_Text_ShouldHaveDataTypeAttribute()
        {
            // Arrange
            var property = typeof(Message).GetProperty(nameof(Message.Text));

            // Act
            var attribute = property.GetCustomAttributes(typeof(DataTypeAttribute), false).FirstOrDefault() as DataTypeAttribute;

            // Assert
            Assert.NotNull(attribute);
            Assert.Equal(DataType.Text, attribute.DataType);
        }
        
        [Fact]
                public void Message_Text_ShouldAllowTextWithLength200()
                {
                    // Arrange
                    var message = new Message();
                    var text = new string('a', 200);

                    // Act
                    message.Text = text;

                    // Assert
                    Assert.Equal(text, message.Text);
                }

                [Fact]
                public void Message_Text_ShouldAllowTextWithLength250()
                {
                    // Arrange
                    var message = new Message();
                    var text = new string('a', 250);

                    // Act
                    message.Text = text;

                    // Assert
                    Assert.Equal(text, message.Text);
                }

                [Fact]
                public void Message_Text_ShouldNotAllowTextWithLength300()
                {
                    // Arrange
                    var message = new Message();
                    var text = new string('a', 300);

                    // Act & Assert
                    var exception = Assert.Throws<ValidationException>(() => Validator.ValidateObject(message, new ValidationContext(message), true));
                    Assert.Contains("There's a 250 character limit on messages. Please shorten your message.", exception.Message);
                }
        
    }
}

