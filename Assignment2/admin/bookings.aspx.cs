using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Assignment2.Models;
using System.Linq.Dynamic;

namespace Assignment2.admin
{
    public partial class bookings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SortColumn"] = "RoomID";
                Session["SortDirection"] = "ASC";
                GetBookings();
            }
        }

        //show booking list
        protected void GetBookings()
        {
            using (comp2007Entities db = new comp2007Entities())
            {
                String SortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                var Bookings = from b in db.Bookings
                            select new { b.BookingID, b.RoomID, b.LastName, b.FirstName, b.DaysStaying, b.BookDate };

                grdBookings.DataSource = Bookings.AsQueryable().OrderBy(SortString).ToList();
                grdBookings.DataBind();
            }
        }



        protected void grdBookings_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set the new page #
            grdBookings.PageIndex = e.NewPageIndex;
            GetBookings();
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set new page size
            grdBookings.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            GetBookings();
        }

        protected void grdBookings_Sorting(object sender, GridViewSortEventArgs e)
        {
            //get the column to sort by
            Session["SortColumn"] = e.SortExpression;

            //reload the grid
            GetBookings();

            //toggle the direction
            if (Session["SortDirection"].ToString() == "ASC")
            {
                Session["SortDirection"] = "DESC";
            }
            else
            {
                Session["SortDirection"] = "ASC";
            }
        }

        protected void grdBookings_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    Image SortImage = new Image();

                    for (int i = 0; i <= grdBookings.Columns.Count - 1; i++)
                    {
                        if (grdBookings.Columns[i].SortExpression == Session["SortColumn"].ToString())
                        {
                            if (Session["SortDirection"].ToString() == "DESC")
                            {
                                SortImage.ImageUrl = "images/desc.jpg";
                                SortImage.AlternateText = "Sort Descending";
                            }
                            else
                            {
                                SortImage.ImageUrl = "images/asc.jpg";
                                SortImage.AlternateText = "Sort Ascending";
                            }

                            e.Row.Cells[i].Controls.Add(SortImage);

                        }
                    }
                }

            }
        }
    }
}