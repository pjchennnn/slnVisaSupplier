using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace prjVisaSupplier.Models
{
    [MetadataType(typeof(TVorderStatusMetadata))]
    public partial class TVorderStatus
    {
    }
    internal class TVorderStatusMetadata
    {
        [Newtonsoft.Json.JsonIgnore]
        [InverseProperty("FStatus")]
        public virtual ICollection<TVorder> TVorders { get; set; } = new List<TVorder>();
    }
}
