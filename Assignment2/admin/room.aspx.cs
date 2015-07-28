using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Assignment2.Models;

namespace Assignment2.admin
{
    public partial class room : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //get the room if editing
                if (!String.IsNullOrEmpty(Request.QueryString["RoomID"]))
                {
                    GetRoom();
                }
            }
        }

        protected void GetRoom()
        {
            //populate the existing room for editing
            using (comp2007Entities db = new comp2007Entities())
            {
                Int32 RoomID = Convert.ToInt32(Request.QueryString["RoomID"]);

                Room objC = (from r in db.Rooms
                               where r.RoomID == RoomID
                               select r).FirstOrDefault();

                //populate the form
                ddlRoomSize.Text = objC.Size;
                txtCostPerDay.Text = objC.CostPerDay.ToString();
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            //do insert or update
            using (comp2007Entities db = new comp2007Entities())
            {
                Room objC = new Room();

                if (!String.IsNullOrEmpty(Request.QueryString["RoomID"]))
                {
                    Int32 RoomID = Convert.ToInt32(Request.QueryString["RoomID"]);
                    objC = (from r in db.Rooms
                            where r.RoomID == RoomID
                            select r).FirstOrDefault();
                }

                //populate the room from the input form
                objC.Size = ddlRoomSize.Text;
                objC.CostPerDay = Convert.ToDecimal(txtCostPerDay.Text);
                objC.Availability = "y";

                if (String.IsNullOrEmpty(Request.QueryString["RoomID"]))
                {
                    //add
                    db.Rooms.Add(objC);
                }

                //save and redirect
                db.SaveChanges();
                Response.Redirect("rooms.aspx");
            }
        }
    }
}