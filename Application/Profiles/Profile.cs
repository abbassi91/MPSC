using System.Collections.Generic;
using Domain;
using Newtonsoft.Json;

namespace Application.Profiles
{
    public class Profile
    {
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string Image { get; set; }
        public string Id { get; set; }

        [JsonProperty("Collaborateur")]
        public bool IsCollaborateur { get; set; }

    }
}