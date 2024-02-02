using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace prjVisaSupplier.Models
{
    [MetadataType(typeof(TCcompanyInfoMetadata))]
    public partial class TCcompanyInfo
    {
    }
    internal class TCcompanyInfoMetadata
    {
        [Newtonsoft.Json.JsonIgnore]
        [InverseProperty("FSupplier")]
        public virtual ICollection<TVproduct> TVproducts { get; set; } = new List<TVproduct>();
    }
}
