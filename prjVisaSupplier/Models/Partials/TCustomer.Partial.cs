using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace prjVisaSupplier.Models
{
    [MetadataType(typeof(TCustomerMetadata))]
    public partial class TCustomer
    {
    }
    internal class TCustomerMetadata
    {
        [Newtonsoft.Json.JsonIgnore]
        [InverseProperty("FCustomer")]
        public virtual ICollection<TVorder> TVorders { get; set; } = new List<TVorder>();
    }
}