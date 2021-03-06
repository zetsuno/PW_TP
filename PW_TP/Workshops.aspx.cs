﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PW_TP.App_Classes;
using PW_TP.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text;

namespace PW_TP
{
    public partial class Workshops : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {

            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected int populate_DDL()
        {
            int val;
            SqlConnection con = GetSqlCon.GetCon();
            SqlDataAdapter com = new SqlDataAdapter("GetWorkshopNamesByRegion", con);
            com.SelectCommand.CommandType = CommandType.StoredProcedure;
            com.SelectCommand.Parameters.AddWithValue("@param1", DdlRegiao.SelectedValue);
            DataSet ds1 = new DataSet();
            if (com != null)
            { com.Fill(ds1); }
            con.Open();
            DdlOficinas.DataSource = ds1;
            DdlOficinas.DataTextField = "WorkshopName";
            DdlOficinas.DataValueField = "WorkshopName";
            DdlOficinas.DataBind();
            con.Close();

            val = Badges.CountWorkshopsInRegion(DdlRegiao.SelectedValue);
            if(val == -1) { Response.Redirect("~/Error.aspx"); }
            return val;
        }

        protected void DdlRegiao_SelectedIndexChanged(object sender, EventArgs e)
        {
            int result;

            if (DdlRegiao.SelectedValue != "0")
            {

                if (DescOficina.Visible == true) { DescOficina.Visible = false; }
                result = populate_DDL();
                if (result == 0)
                {
                    DdlOficinas.Items.Insert(0, new ListItem("Não existem Oficinas na Região", "0"));
                    if (DdlOficinas.Enabled == true) { DdlOficinas.Enabled = false; }
                }
                else
                {
                    DdlOficinas.Items.Insert(0, new ListItem("-- Selecione --", "0"));
                    DdlOficinas.Enabled = true;
                }
            }
            else if (DdlOficinas.Enabled == true && DescOficina.Visible == true) { DdlOficinas.Enabled = false; DescOficina.Visible = false; }
            else { DdlOficinas.Enabled = false; }
        }

        protected void GetWorkshopDetails(string workshopname)
        {
            
            SqlConnection con = GetSqlCon.GetCon();
            SqlDataAdapter com = new SqlDataAdapter("GetWorkshopDetails", con);
            com.SelectCommand.CommandType = CommandType.StoredProcedure;
            com.SelectCommand.Parameters.AddWithValue("@param1", workshopname);
            DataTable dtWorkshops = new DataTable();
            com.Fill(dtWorkshops);
            DescOficina.DataSource = dtWorkshops;
            DescOficina.DataBind();

            //rating
            double rating = Commissions.GetAvgRating(Users.GetWorkshopId(workshopname));
            Label ratinglb = DescOficina.FindControl("ratinglabel") as Label;
            if(rating == -1) { ratinglb.Text = "Sem Avaliação"; }
            else { ratinglb.Text = rating.ToString() + "/5" + "&#9733"; }

        }

        protected void DdlOficinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetWorkshopDetails(DdlOficinas.SelectedValue);
            DescOficina.Visible = true;

        }

        protected void SearchWorkshop_OnClick(object sender, EventArgs e)
        {
            if(txtSearchWorkshop.Value.Length <= 0) { DivTxtEmpty.Visible = true; return; }
            int exists = Users.CheckIfWorkshopExist(txtSearchWorkshop.Value);
            if (exists == -1) { Response.Redirect("~/Error.aspx"); }
            if (exists == 1)
            {
                if (DivErrorMsg.Visible == true) { DivErrorMsg.Visible = false; }
                if (DivTxtEmpty.Visible == true) { DivTxtEmpty.Visible = false; }
                GetWorkshopDetails(txtSearchWorkshop.Value);
                DescOficina.Visible = true;
            }
            else
            {
                if (DivTxtEmpty.Visible == true) { DivTxtEmpty.Visible = false; }
                if (DescOficina.Visible == true) { DescOficina.Visible = false; }
                DivErrorMsg.Visible = true;
            }

        }
    }
}