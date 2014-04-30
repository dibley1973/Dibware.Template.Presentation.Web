using Dibware.Template.Core.Domain.Contracts.Services;
using Dibware.Template.Core.Domain.Entities.Security;
using Dibware.Template.Presentation.Web.Tests.MockData;
using Moq;
using System.Collections.Generic;

namespace Dibware.Template.Presentation.Web.Tests.Helpers
{
    public static class MockServiceHelper
    {
        /// <summary>
        /// Gets a lookup service mock.
        /// </summary>
        /// <returns></returns>
        public static Mock<ILookupService> GetLookupServiceMock()
        {
            // Mock all password strength rules array
            List<PasswordStrengthRule> allRulesList =
                new List<PasswordStrengthRule>()
            { 
                new PasswordStrengthRule
                {
                    Id = PasswordStrengthRuleData.Rule1.Id,
                    Sequence = PasswordStrengthRuleData.Rule2.Sequence,
                    Description = PasswordStrengthRuleData.Rule1.Description,
                    Notes = PasswordStrengthRuleData.Rule1.Notes,
                    RegularExpression = PasswordStrengthRuleData.Rule1.RegularExpression
                },
                new PasswordStrengthRule
                {
                    Id = PasswordStrengthRuleData.Rule2.Id,
                    Sequence = PasswordStrengthRuleData.Rule2.Sequence,
                    Description = PasswordStrengthRuleData.Rule2.Description,
                    Notes = PasswordStrengthRuleData.Rule2.Notes,
                    RegularExpression = PasswordStrengthRuleData.Rule2.RegularExpression
                },
                new PasswordStrengthRule
                {
                    Id = PasswordStrengthRuleData.Rule3.Id,
                    Sequence = PasswordStrengthRuleData.Rule3.Sequence,
                    Description = PasswordStrengthRuleData.Rule3.Description,
                    Notes = PasswordStrengthRuleData.Rule3.Notes,
                    RegularExpression = PasswordStrengthRuleData.Rule3.RegularExpression
                },
                new PasswordStrengthRule
                {
                    Id = PasswordStrengthRuleData.Rule4.Id,
                    Sequence = PasswordStrengthRuleData.Rule4.Sequence,
                    Description = PasswordStrengthRuleData.Rule4.Description,
                    Notes = PasswordStrengthRuleData.Rule4.Notes,
                    RegularExpression = PasswordStrengthRuleData.Rule4.RegularExpression
                },
                new PasswordStrengthRule
                {
                    Id = PasswordStrengthRuleData.Rule5.Id,
                    Sequence = PasswordStrengthRuleData.Rule5.Sequence,
                    Description = PasswordStrengthRuleData.Rule5.Description,
                    Notes = PasswordStrengthRuleData.Rule5.Notes,
                    RegularExpression = PasswordStrengthRuleData.Rule5.RegularExpression
                },
                new PasswordStrengthRule
                {
                    Id = PasswordStrengthRuleData.Rule6.Id,
                    Sequence = PasswordStrengthRuleData.Rule6.Sequence,
                    Description = PasswordStrengthRuleData.Rule6.Description,
                    Notes = PasswordStrengthRuleData.Rule6.Notes,
                    RegularExpression = PasswordStrengthRuleData.Rule5.RegularExpression
                },
                new PasswordStrengthRule
                {
                    Id = PasswordStrengthRuleData.Rule7.Id,
                    Sequence = PasswordStrengthRuleData.Rule7.Sequence,
                    Description = PasswordStrengthRuleData.Rule7.Description,
                    Notes = PasswordStrengthRuleData.Rule7.Notes,
                    RegularExpression = PasswordStrengthRuleData.Rule7.RegularExpression
                }
            };

            Mock<ILookupService> lookupServiceMock = new Mock<ILookupService>();
            lookupServiceMock
                .Setup(s => s.FindAll<PasswordStrengthRule>())
                .Returns(allRulesList);
            return lookupServiceMock;
        }
    }
}
