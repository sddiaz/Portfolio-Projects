using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Testing
{
    public partial class _Default : Page
    {
        string UserData;
        string UserCode; 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void GetCode_Click(object sender, EventArgs e)
        {
             if (pasteBox.Text == String.Empty)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You need to enter something to generate a code.')", true);
            }
             else
            {

            }
        }
    }
}