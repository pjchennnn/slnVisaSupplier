using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace prjVisaSupplier.Models
{
    [MetadataType(typeof(TVformPathMetadata))]
    public partial class TVformPath
    {
    }
    internal class TVformPathMetadata
    {
        [Newtonsoft.Json.JsonIgnore]
        [InverseProperty("FForm")]
        public virtual ICollection<TVproductFormsRequired> TVproductFormsRequireds { get; set; } = new List<TVproductFormsRequired>();
    }
}
