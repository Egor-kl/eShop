namespace EventBus.DTO
{
    public interface IProfileDTO
    {
        /// <summary>
        ///     User identifier.
        /// </summary>
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
    }
}