namespace temis.Api.Models.DTO.MemberDto
{
    /// <summary>
    /// Member  Data transfer object 
    /// </summary>
    public class MemberDto
    {
        /// <summary>
        /// Member name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Member Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Member Role
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Member Age
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Member CPF
        /// </summary>
        public string CPF { get; set; }
      
    }
}