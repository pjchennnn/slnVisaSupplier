using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace prjVisaSupplier.Models
{
    [MetadataType(typeof(TVproductMetadata))]
    public partial class TVproduct
    {
    }
    internal class TVproductMetadata
    {
        [Newtonsoft.Json.JsonIgnore]
        [InverseProperty("FProduct")]
        public virtual ICollection<TVorder> TVorders { get; set; } = new List<TVorder>();

        [Newtonsoft.Json.JsonIgnore]
        [InverseProperty("FProduct")]
        public virtual ICollection<TVproductFormsRequired> TVproductFormsRequireds { get; set; } = new List<TVproductFormsRequired>();
    }
}
