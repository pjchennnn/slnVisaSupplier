using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace prjVisaSupplier.Models
{
    [MetadataType(typeof(TVvalidityPeriodMetadata))]
    public partial class TVvalidityPeriod
    {
    }
    internal class TVvalidityPeriodMetadata
    {
        [Newtonsoft.Json.JsonIgnore]
        [InverseProperty("FValidityPeriod")]
        public virtual ICollection<TVproduct> TVproducts { get; set; } = new List<TVproduct>();
    }
}
