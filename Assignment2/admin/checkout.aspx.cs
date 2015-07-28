using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Assignment2.Models;

namespace Assignment2.admin
{
    public partial class checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //get the room if editing
                if (!String.IsNullOrEmpty(Request.QueryString["RoomID"]))
                {
                    CheckOut();
                }
            }
        }

        protected void CheckOut()
        {
            //get selected room number
            Int32 RoomID = Convert.ToInt32(Request.QueryString["RoomID"]);

            using (comp2007Entities db = new comp2007Entities())
            {
                //get selected room
                Room objC = (from r in db.Rooms
                             where r.RoomID == RoomID
                             select r).FirstOrDefault();

                //populate the room
                objC.Size = objC.Size;
                objC.CostPerDay = objC.CostPerDay;
                objC.Availability = objC.Availability;

                //set room to available
                if (objC.Availability == "n")
                {
                    objC.Availability = "y";

                    if (String.IsNullOrEmpty(Request.QueryString["RoomID"]))
                    {
                        //add
                        db.Rooms.Add(objC);

                        //save and redirect
                        db.SaveChanges();
                    }
                }
                else
                {
                    //a customer is already checked into this room
                    Response.Redirect("rooms.aspx");
                }

                Booking objD = (from b in db.Bookings
                             where b.RoomID == RoomID
                             select b).FirstOrDefault();

                //remove customer's entry from the bookings db
                db.Bookings.Remove(objD);

                db.SaveChanges();

                //Redirect
                Response.Redirect("bookings.aspx");
            }
        }





    }
}