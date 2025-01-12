using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.dto
{
    public class ExampleDto
    {
        public int Id { get; set; } // Идентификатор
        public string Name { get; set; } // Название
        public List<string> Tags { get; set; } // Список тегов
    }
}
