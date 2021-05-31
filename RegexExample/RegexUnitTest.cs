using System;
using System.Linq;
using Xunit;
using System.Text.RegularExpressions;

namespace RegexExample
{
    public class RegexUnitTest
    {
        [Theory]
        [InlineData("rmaj@demant.com")]
        [InlineData("rafal.major@gmail.com")]
        public void RegexMailValidationTest(string email)
        {
            var match = Regex.Match(email, @"[a-zA-Z0-9\.]+@[a-zA-Z0-9\.]+\.[a-zA-Z]{2,4}");
            Assert.True(match.Success);
        }

        [Theory]
        [InlineData("rmaj@demant.com")]
        [InlineData("rafal.major@gmail.com")]
        public void MailValidationTest(string email)
        {
            bool result = ValidateMail(email);
            Assert.True(result);
        }

        [Theory]
        [InlineData("rmaj!!!!@demant.com")]
        [InlineData("rafal.major@gmail.commm")]
        public void MailValidationFailedTest(string email)
        {
            bool result = ValidateMail(email);
            Assert.False(result);
        }

        private bool ValidateMail(string email)
        {
            var parts = email.Split('@');

            if (parts.Length != 2) return false;
            
            string[] company = parts[1].Split('.');
            string domain = company.Last();

            if (domain.Length < 2 || domain.Length > 4) return false;

            foreach(char character in parts[0])
            {
                if (((int)character >= ((int)'a') && (int)character <= ((int)'z')) || 
                    ((int)character >= ((int)'A') && (int)character <= ((int)'Z')) || 
                    ((int)character == ((int)'.'))) continue;

                return false;
            }

            foreach(char character in string.Join('.', company.Take(company.Length - 2)))
            {
                if (((int)character >= ((int)'a') && (int)character <= ((int)'z')) || 
                    ((int)character >= ((int)'A') && (int)character <= ((int)'Z')) || 
                    ((int)character == ((int)'.'))) continue;
                return false;
            }

            foreach(char character in domain)
            {
                if (((int)character >= ((int)'a') && (int)character <= ((int)'z')) || 
                    ((int)character >= ((int)'A') && (int)character <= ((int)'Z')) || 
                    ((int)character == ((int)'.'))) continue;
                return false;
            }

            return true;
        }
    }
}
