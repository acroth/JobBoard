using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardFinal.Data//.Metadata
{
    public class OpenPositionMetadata
    {
        public int OpenPositionID { get; set; }
        public int PositionID { get; set; }
        public int LocationID { get; set; }

    }
    [MetadataType(typeof(OpenPositionMetadata))]
    public partial class OpenPosition { }
}
