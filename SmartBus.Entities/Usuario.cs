using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartBus.Entities
{
    public class Usuario : BaseEntity
    {
        public virtual string Email { get; set; }

        [JsonIgnore]
        public virtual string Contraseña { get; set; }
    }
}
