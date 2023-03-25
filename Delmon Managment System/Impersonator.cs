using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Principal;

namespace Delmon_Managment_System
{
    public static class Impersonator
    {
       
            [DllImport("advapi32.dll", SetLastError = true)]
            private static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword,
                int dwLogonType, int dwLogonProvider, out IntPtr phToken);

            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool CloseHandle(IntPtr hHandle);

            private static WindowsImpersonationContext impersonationContext;

            public static bool Impersonate(string username, string domain, string password)
            {
                IntPtr token;
                if (LogonUser(username, domain, password, 2, 0, out token))
                {
                    WindowsIdentity identity = new WindowsIdentity(token);
                    impersonationContext = identity.Impersonate();
                    CloseHandle(token);
                    return true;
                }
                return false;
            }

            public static void StopImpersonation()
            {
                impersonationContext?.Undo();
            }

        }

    }

