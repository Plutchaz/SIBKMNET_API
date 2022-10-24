using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNETMvc_WebApp.Models
{
    public class Province
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        
        //create instanceObject Class
        public Region Region { get; set; }
        [ForeignKey("Region")]
        public int RegionId { get; set; }
    }
}
