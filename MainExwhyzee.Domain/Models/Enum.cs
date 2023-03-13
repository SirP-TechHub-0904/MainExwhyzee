using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MainExwhyzee.Domain.Models
{
    public class Enum
    {
        public enum AccontStatus
        {

            [Description("NONE")]
            NONE = 0,
            [Description("Active")]
            Active = 2,
            [Description("Pending")]
            Pending = 3,
            [Description("Suspended")]
            Suspended = 4,
            [Description("Expired")]
            Expired = 5

        }
        public enum TypeOfAccount
        {

            [Description("NONE")]
            NONE = 0,
            [Description("Hosting")]
            Hosting = 2,
            [Description("Domain")]
            Domain = 3,
            [Description("Website")]
            Website = 4,
            [Description("SSL")]
            SSL = 5,
        }
        public enum PagePosition
        {
            [Description("None")]
            None = 0,

            [Description("Top")]
            Top = 2,

            [Description("Menu")]
            Menu = 3,
            [Description("Footer")]
            Footer = 4,
        }
        public enum NotificationStatus
        {
            [Description("NotDefind")]
            NotDefind = 0,
            [Description("Sent")]
            Sent = 1,

            [Description("NotSent")]
            NotSent = 2,


        }
        public enum NotificationType
        {
            [Description("NotDefind")]
            NotDefind = 0,
            [Description("SMS")]
            SMS = 1,

            [Description("Email")]
            Email = 2


        }
    }
}