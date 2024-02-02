using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace prjVisaSupplier.Models
{
    [MetadataType(typeof(TVprocessingTimeMetadata))]
    public partial class TVprocessingTime
    {
    }
    internal class TVprocessingTimeMetadata
    {
        [Newtonsoft.Json.JsonIgnore]
        [InverseProperty("FProcessingTime")]
        public virtual ICollection<TVproduct> TVproducts { get; set; } = new List<TVproduct>();
    }
}
