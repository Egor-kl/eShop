namespace Identity.DTO
{
    public class TokenDTO
    {
        /// <summary>
        ///     Account Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     User name.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     User role.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        ///     Authentication token.
        /// </summary>
        public string Token { get; set; }
    }
}