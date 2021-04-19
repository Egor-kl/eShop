﻿namespace Email.Common.Settings
{
    /// <summary>
    /// Settings for email sender
    /// </summary>
    public class MailSettings
    {
        /// <summary>
        /// Server.
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// Port.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }
    }
}