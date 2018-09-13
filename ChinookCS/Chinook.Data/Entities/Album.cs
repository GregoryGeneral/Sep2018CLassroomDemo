using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Data.Entities
{
    [Table("Albums")]
    public class Album
    {
        
        [Key] public int AlbumID { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(160, ErrorMessage = "Title is limited to 120 char")]
        public string Title { get; set; }
        public int ArtistID { get; set; }
        public int ReleaseYear { get; set; }
        [StringLength(50, ErrorMessage = "Release Label is limited to 50 char")]
        public string ReleaseLabel { get; set; }


        //navigational properties
        public virtual Artist Artist { get; set; }
        //public virtual ICollection<Track> Tracks { get; set; }

    }
}
