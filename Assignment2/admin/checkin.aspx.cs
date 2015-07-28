using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

using Assignment2.Models;

namespace Assignment2.admin
{
    public partial class checkin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //get the room if editing
                if (!String.IsNullOrEmpty(Request.QueryString["RoomID"]))
                {
                    CheckIn();
                }
            }
        }

        protected void CheckIn()
        {
            //populate the existing room for editing
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
                objC.Size = objC.Size;
                objC.CostPerDay = objC.CostPerDay;
                objC.Availability = objC.Availability;

                //set availability to no
                if (objC.Availability == "y")
                {
                    objC.Availability = "n";

                    if (String.IsNullOrEmpty(Request.QueryString["RoomID"]))
                    {
                        //add
                        db.Rooms.Add(objC);
                    }
                    //save 
                    db.SaveChanges();
                }
                //room not currently available
                else
                {
                    //redirect
                    Response.Redirect("rooms.aspx");
                }
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

                Booking objD = new Booking();

                //populate the booking entry from the input form and room info
                objD.RoomID = objC.RoomID;
                objD.LastName = txtLastName.Text;
                objD.FirstName = txtFirstName.Text;
                objD.DaysStaying = Convert.ToInt32(txtDaysStaying.Text);
                objD.BookDate = DateTime.Today;

                //Decimal TotalCost = objC.CostPerDay * objD.DaysStaying;

                    //add
                    db.Bookings.Add(objD);

                //save and redirect
                db.SaveChanges();
                Response.Redirect("bookings.aspx");
            }
        }
    }
}