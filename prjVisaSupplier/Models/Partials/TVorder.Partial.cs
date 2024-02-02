using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace prjVisaSupplier.Models
{
    [MetadataType(typeof(TVorderMetadata))]
    public partial class TVorder
    {
    }
    internal class TVorderMetadata
    {
        [Newtonsoft.Json.JsonIgnore]
        [InverseProperty("FOrder")]
        public virtual ICollection<TVtravelerInfo> TVtravelerInfos { get; set; } = new List<TVtravelerInfo>();
    }
}
