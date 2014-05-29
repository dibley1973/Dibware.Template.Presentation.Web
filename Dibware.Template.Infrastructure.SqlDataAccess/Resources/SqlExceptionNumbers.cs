
namespace Dibware.Template.Infrastructure.SqlDataAccess.Resources
{
    public enum SqlExceptionNumbers : int
    {
        UserNameAlreadyExists = 50001,
        EmailAddressAlreadyExists = 50002,
        MembershipHasAlreadyConfirmed = 50003,
        UsernameDoesNotExist = 50004,

        /* Terms */
        NoCurrentTermfoundInSystem = 50005,
        TermDoesNotExistInSystem = 50006,
        CannotDeleteTermThatIsActive = 50007,
        CannotUpdateTermThatIsActive = 50008,

        /* Password reset token */
        PasswordResetTokenDoesNotExist = 50009,
        PasswordResetTokenExistsInMultiple = 50010,
        PasswordResetTokenExpired = 50011
    }
}