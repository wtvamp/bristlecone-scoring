using System.ComponentModel.DataAnnotations.Schema;
using Bristlecone.DataAccessLayer.Common;

namespace Bristlecone.DataAccessLayer.Entities
{
    [Table("Application")]
    public class Application : BaseEntity
    {
        public int ApplicationID { get; set; }

        public string ApplicationName { get; set; }
         
        public string ApplicationType { get; set; }
        
    }
}
