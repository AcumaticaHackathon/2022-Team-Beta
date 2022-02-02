using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Objects.FS;
using PX.Data;
using PX.Objects.CR;

namespace Beta.Segmentation
{
	public class CREmailActivityMaintExtension : PXGraphExtension<CREmailActivityMaint>
    {
        public static bool IsActive() => true;

        public PXAction<CRSMEmail> AddToTaxCase;
        [PXButton(CommitChanges = true, Category = "Actions")]
        [PXUIField(DisplayName = "Add To Tax Case")]
        protected virtual void addToTaxCase()
        {
            CRSMEmail email = Base.Message.Current;
            if (email is null) return;

            //CRCase taxCase = 
            //if (taxCase != null)
            //{
            //    Base.CurrentMessage.SetValueExt<CRSMEmail.refNoteID>(email, taxCase.NoteID);
            //    email = Base.CurrentMessage.Update(email);
            //    ListField_PriceType.Base.Actions.PressSave();
            //}
        }
    }
}
