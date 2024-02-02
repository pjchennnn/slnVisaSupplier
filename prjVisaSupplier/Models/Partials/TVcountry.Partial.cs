using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace prjVisaSupplier.Models
{
    [MetadataType(typeof(TVcountryMetadata))]
    public partial class TVcountry
    {
    }
    internal class TVcountryMetadata
    {
        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<TVproduct> TVproducts { get; set; } = new List<TVproduct>();
    }
}
