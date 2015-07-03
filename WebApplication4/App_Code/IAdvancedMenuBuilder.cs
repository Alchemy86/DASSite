using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;

namespace WebApplication4.App_Code
{
    public interface IAdvancedMenuBuilder
    {
        string BuildMenuSlider(string id, string label);
        void AttachControllers(List<string> sliders, HtmlGenericControl controller);
    }
}
