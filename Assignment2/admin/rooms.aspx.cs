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
    public partial class rooms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SortColumn"] = "RoomID";
                Session["SortDirection"] = "ASC";
                GetRooms();
            }
        }

        protected void GetRooms()
        {
            using (comp2007Entities db = new comp2007Entities())
            {
                String SortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                var Rooms = from r in db.Rooms
                              select new { r.RoomID, r.Size, r.CostPerDay, r.Availability };

                grdRooms.DataSource = Rooms.AsQueryable().OrderBy(SortString).ToList();
                grdRooms.DataBind();
            }
        }

        protected void grdRooms_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //get selected room number
            Int32 RoomID = Convert.ToInt32(grdRooms.DataKeys[e.RowIndex].Values["RoomID"]);

            using (comp2007Entities db = new comp2007Entities())
            {
                //get selected room
                Room objC = (from r in db.Rooms
                               where r.RoomID == RoomID
                               select r).FirstOrDefault();

                //delete
                db.Rooms.Remove(objC);
                db.SaveChanges();

                //refresh grid
                GetRooms();
            }
        }

        protected void grdRooms_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set the new page #
            grdRooms.PageIndex = e.NewPageIndex;
            GetRooms();
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set new page size
            grdRooms.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            GetRooms();
        }

        protected void grdRooms_Sorting(object sender, GridViewSortEventArgs e)
        {
            //get the column to sort by
            Session["SortColumn"] = e.SortExpression;

            //reload the grid
            GetRooms();

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

        protected void grdRooms_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    Image SortImage = new Image();

                    for (int i = 0; i <= grdRooms.Columns.Count - 1; i++)
                    {
                        if (grdRooms.Columns[i].SortExpression == Session["SortColumn"].ToString())
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