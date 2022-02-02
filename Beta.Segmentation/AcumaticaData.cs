using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Beta.Segmentation
{
    [Serializable]
    [PXCacheName("AcumaticaData")]
    public class AcumaticaData : IBqlTable
    {
        #region X
        [PXDBDecimal(IsKey = true)]
        [PXUIField(DisplayName = "X")]
        public virtual Decimal? X { get; set; }
        public abstract class x : PX.Data.BQL.BqlDecimal.Field<x> { }
        #endregion

        #region Y
        [PXDBDecimal(IsKey = true)]
        [PXUIField(DisplayName = "Y")]
        public virtual Decimal? Y { get; set; }
        public abstract class y : PX.Data.BQL.BqlDecimal.Field<y> { }
        #endregion

        #region Z
        [PXDBDecimal(IsKey = true)]
        [PXUIField(DisplayName = "Z")]
        public virtual Decimal? Z { get; set; }
        public abstract class z : PX.Data.BQL.BqlDecimal.Field<z> { }
        #endregion

        #region Z
        [PXDBDecimal(IsKey = true)]
        [PXUIField(DisplayName = "W")]
        public virtual Decimal? W { get; set; }
        public abstract class w : PX.Data.BQL.BqlDecimal.Field<w> { }
        #endregion
    }
}
