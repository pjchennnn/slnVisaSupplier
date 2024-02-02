using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace prjVisaSupplier.Models
{
    [MetadataType(typeof(TCouponListMetadata))]
    public partial class TCouponList
    {
    }
    internal class TCouponListMetadata
    {
        [Newtonsoft.Json.JsonIgnore]
        [InverseProperty("FCoupon")]
        public virtual ICollection<TVorder> TVorders { get; set; } = new List<TVorder>();
    }
}
