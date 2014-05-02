using Dibware.Template.Presentation.Web.Helpers;
using Dibware.Template.Presentation.Web.Tests.MockData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dibware.Template.Presentation.Web.Tests.HelperTests
{
    [TestClass]
    public class EmailHelperTest
    {
        #region Notes

        // You may need a development SMTP server like:
        //  http://smtp4dev.codeplex.com
        //

        #endregion

        #region SendHtmlEmail

        [TestMethod]
        public void Test_EmailHelper_SendHtmlEmailWithHighPriority_ResultsInNofailureToSend()
        {
            // Arrange
            var toAddress = EmailHelperData.ToAddress;
            var subjectText = EmailHelperData.SubjectText + "- High";
            var bodyText = EmailHelperData.BodyText;
            var priority = EmailHelper.EmailPriority.High;

            // Act
            EmailHelper.SendHtmlEmail(toAddress, subjectText, bodyText, priority);

            // Assert
            // Well we got here without failure so emaiil must have sent.
            // Now need to check inbox!
        }

        [TestMethod]
        public void Test_EmailHelper_SendHtmlEmailWithNormalPriority_ResultsInNofailureToSend()
        {
            // Arrange
            var toAddress = EmailHelperData.ToAddress;
            var subjectText = EmailHelperData.SubjectText + "- Normal";
            var bodyText = EmailHelperData.BodyText;
            var priority = EmailHelper.EmailPriority.Normal;

            // Act
            EmailHelper.SendHtmlEmail(toAddress, subjectText, bodyText, priority);

            // Assert
            // Well we got here without failure so emaiil must have sent.
            // Now need to check inbox!
        }

        [TestMethod]
        public void Test_EmailHelper_SendHtmlEmailWithLowPriority_ResultsInNofailureToSend()
        {
            // Arrange
            var toAddress = EmailHelperData.ToAddress;
            var subjectText = EmailHelperData.SubjectText + "- Low";
            var bodyText = EmailHelperData.BodyText;
            var priority = EmailHelper.EmailPriority.Low;

            // Act
            EmailHelper.SendHtmlEmail(toAddress, subjectText, bodyText, priority);

            // Assert
            // Well we got here without failure so emaiil must have sent.
            // Now need to check inbox!
        }

        #endregion
    }
}