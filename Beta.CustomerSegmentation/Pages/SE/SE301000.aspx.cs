using System;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using PX.Web.UI;

public partial class Page_SE301000 : PX.Web.UI.PXPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var pxImg = ControlHelper.FindControl("pxImg", this);
        if (pxImg != null)
        {
            var imgCnt = pxImg as PXImage;
            if (imgCnt != null)
            {
                imgCnt.ImageUrl = "http://localhost/hack2022/(W(1))/Icons/img.png" + $"?id={Guid.NewGuid().ToString()}";
            }

        }

        var pxImgResUlt = ControlHelper.FindControl("pxImgRes", this);
        if (pxImgResUlt != null)
        {
            if (pxImgResUlt is PXImage imgCnt)
            {
                imgCnt.ImageUrl = "http://localhost/hack2022/(W(1))/Icons/imgRes.png" + $"?id={Guid.NewGuid().ToString()}"; ;
            }
        }
    }
}