using System;

namespace EventBus.Events
{
    /// <summary>
    /// Profile register event
    /// </summary>
    public interface IRegisterProfile
    {
        /// <summary>
        /// User id
        /// </summary>
        public int UserId { get; set; }
        
        /// <summary>
        /// Username user
        /// </summary>
        public string UserName { get; set; }
        
        /// <summary>
        /// Date, when user register
        /// </summary>
        public string CreationDate { get; set; }
    }
}