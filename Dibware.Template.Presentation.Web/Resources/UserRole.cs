using System;

namespace Dibware.Template.Presentation.Web.Resources
{
    [Flags]
    public enum UserRole
    {
        None = 0,
        UnknownUser = 1,
        MainUser = 2,
        SuperUser = 4,
        AdministratorUser = 8,
        AllNonAdmin = (MainUser | SuperUser),
        AllAuthorised = (MainUser | SuperUser | AdministratorUser),
        All = (UnknownUser | MainUser | SuperUser | AdministratorUser)
    }
}