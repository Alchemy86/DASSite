using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LunchboxWebControls
{
    [ToolboxData("<{0}:LunchboxGridView runat=server></{0}:LunchboxGridView>")]
    //[ToolboxBitmap(typeof(LunchboxGridView), "LunchboxWebControls.GridView.bmp")]
    public class LunchboxGridView : GridView
    {
        /// <summary>
        /// Holds the Sort Direction
        /// </summary>
        private new SortDirection SortDirection
        {
            get 
            {
                if (ViewState["SortDirection"] == null)
                {
                    ViewState["SortDirection"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["SortDirection"];
            }
            set { ViewState["SortDirection"] = value; }
        }
            
        /// <summary>
        /// Order by Specified Column
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="property"></param>
        public void Order<T>(IQueryable<T> source, string property)
        {
            ApplyOrder(source, property);
        }

            
        void ApplyOrder<T>(IQueryable<T> source, string property)
        {
            SortDirection = SortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending;
            var methodName = "";
            switch (SortDirection)
            {
                case SortDirection.Ascending:
                    methodName = "OrderBy";
                    break;
                case SortDirection.Descending:
                    methodName = "OrderByDescending";
                    break;
            }

            var props = property.Split('.');
            Type[] type = {typeof(T)};
            var arg = Expression.Parameter(type[0], "x");
            Expression expr = arg;
            foreach (var pi in props.Select(prop => type[0].GetProperty(prop)))
            {
                if (pi != null)
                {
                                    expr = Expression.Property(expr, pi);
                type[0] = pi.PropertyType;
                    
                }
            }
            var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type[0]);
            var lambda = Expression.Lambda(delegateType, expr, arg);

            var result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type[0])
                    .Invoke(null, new object[] { source, lambda });
            DataSource = ((IOrderedQueryable<T>)result).ToList();
            DataBind();
        } 
    }
}
