﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace Project
{
    public partial class ModifyCourses : System.Web.UI.Page
    {
        BlackboardSvc.Blackboard pxy = new BlackboardSvc.Blackboard();
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            int profID = int.Parse(id);
            gvCourses.DataSource = pxy.ProfessorCourses(profID);
            gvCourses.DataBind();
        }

        protected void gvCourses_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = Request.QueryString["id"];
            int profID = int.Parse(id);

            gvCourses.EditIndex = e.NewEditIndex;

            gvCourses.DataSource = pxy.ProfessorCourses(profID);
            gvCourses.DataBind();
        }

        protected void gvCourses_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            Label label;
            TextBox txtbox;

            label = (Label)gvCourses.Rows[rowIndex].FindControl("lblCourseID");
            int id = int.Parse(label.Text);

            txtbox = (TextBox)gvCourses.Rows[rowIndex].FindControl("txtCourseName");
            string courseName = txtbox.Text;

            txtbox = (TextBox)gvCourses.Rows[rowIndex].FindControl("txtCourseDescription");
            string description = txtbox.Text;

            txtbox = (TextBox)gvCourses.Rows[rowIndex].FindControl("txtCredit");
            int credit = int.Parse(txtbox.Text);

            txtbox = (TextBox)gvCourses.Rows[rowIndex].FindControl("txtCourseSectionNum");
            int number = int.Parse(txtbox.Text);

            txtbox = (TextBox)gvCourses.Rows[rowIndex].FindControl("txtCourseDay");
            string day = txtbox.Text;

            pxy.UpdateCourses(id, courseName, description, credit);
            
        }
    }
}