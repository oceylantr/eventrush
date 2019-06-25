using System;
using Newtonsoft.Json;

namespace eventrush{

    public class Event{

        public Event(){
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
            Description = "default desc";
        }

        [JsonProperty]
        public Guid Id {get; private set;}

        [JsonProperty]
        public DateTime CreationDate {get; private set;}

        [JsonProperty]
        public string Description {get; private set;}

    }

}