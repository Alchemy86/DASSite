using System;
using System.Collections.Generic;

namespace WebApplication4.App_Code
{
    public class AdvancedMenuBuilder : IAdvancedMenuBuilder
    {

        public string BuildMenuSlider(string id, string label)
        {
            return string.Format(@"<div id='slider_{0}' ClientIDMode='Static' runat='server'></div>
	                    <p class='text-center'><b>{1}</b></p>
	                    <div id='slider4'></div>", id, label);
        }

        public void AttachControllers(List<string> sliders, System.Web.UI.HtmlControls.HtmlGenericControl controller)
        {
            throw new NotImplementedException();
        }
    }
}