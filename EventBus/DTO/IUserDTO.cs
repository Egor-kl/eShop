﻿namespace EventBus.DTO
{
    public interface IUserDTO
    {
        /// <summary>
        /// DTO for profile Id
        /// </summary>
        public int ProfileId { get; set; }

        /// <summary>
        /// DTO for user Id
        /// </summary>
        public int UserId { get; set; }
    }
}