using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace prjVisaSupplier.Models
{
    [MetadataType(typeof(TVlengthOfStayMetadata))]
    public partial class TVlengthOfStay
    {
    }
    internal class TVlengthOfStayMetadata
    {
        [Newtonsoft.Json.JsonIgnore]
        [InverseProperty("FLengthOfStay")]
        public virtual ICollection<TVproduct> TVproducts { get; set; } = new List<TVproduct>();
    }
}
