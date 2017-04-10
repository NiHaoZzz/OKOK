using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace 级联.UI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string str = "server=.;database=JG;uid=sa;pwd=123456";
                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter ok = new SqlDataAdapter("select * from kp", conn);
                    ok.Fill(dt);
                    DropDownList1.DataSource = dt;
                    DropDownList1.DataTextField = "CS";
                    DropDownList1.DataValueField = "SH";
                    DropDownList1.DataBind();
                }
            }
           
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string a = DropDownList1.SelectedItem.Value;
            string str = "server=.;database=JG;uid=sa;pwd=123456";
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("select * from shi where SHo=@SHo", conn);
                cmd.Parameters.AddWithValue("@SHo",a);
                SqlDataAdapter ok = new SqlDataAdapter(cmd);
                ok.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataTextField = "SName";
                DropDownList2.DataValueField = "SH";
                DropDownList2.DataBind();
            }
           

        }
    }
}