using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace webapp1
{
  public partial class addstock : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
      Label1.Text = Session["Dist_name"].ToString();
      for (int i = 1; i <= TotalNumberAdded; i++)
      {
        AddControls(i + 1);
      }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
      TotalNumberAdded++;
      AddControls(TotalNumberAdded);

    }
    int z = 1;
    private void AddControls(int controlNumber)
    {
      z++;
      TextBox tb1 = new TextBox();
      TextBox tb2 = new TextBox();

      tb1.ID = "tbmodel" + z.ToString();
      tb2.ID = "tbstock" + z.ToString();

      tb1.CssClass = "form-control";
      tb2.CssClass = "form-control";

      tb1.Attributes.Add("placeholder", "Enter Model No.");
      tb2.Attributes.Add("placeholder", "Enter no. of batteries");

      HtmlGenericControl d = new HtmlGenericControl("div");
      HtmlGenericControl d1 = new HtmlGenericControl("div");
      HtmlGenericControl d2 = new HtmlGenericControl("div");

      d1.Attributes.Add("class", "col-3");
      d2.Attributes.Add("class", "col-2");
      d.Attributes.Add("class", "row");

      d1.Controls.Add(tb1);
      d2.Controls.Add(tb2);

      d.Controls.Add(d1);
      d.Controls.Add(d2);

      paneladd.Controls.Add(d);
    }
    protected int TotalNumberAdded
    {
      get { return (int)(ViewState["TotalNumberAdded"] ?? 0); }
      set { ViewState["TotalNumberAdded"] = value; }
    }

    protected void Btnadd_Click(object sender, EventArgs e)
    {
      for (int a = 1; a <= z; a++)
      {

        con.Open();
        TextBox tb11 = paneladd.FindControl("tbmodel" + a.ToString()) as TextBox;
        TextBox tb22 = paneladd.FindControl("tbstock" + a.ToString()) as TextBox;

        string s = "select * from stock where Dist_No=@p1 and Model_No=@p2";
        SqlCommand cmd = new SqlCommand(s, con);
        cmd.Parameters.AddWithValue("@p1", Session["Dist_no"].ToString());
        cmd.Parameters.AddWithValue("@p2", tb11.Text);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        if (dt.Rows.Count > 0)
        {
          con.Open();
          TextBox tb1 = paneladd.FindControl("tbmodel" + a.ToString()) as TextBox;
          TextBox tb2 = paneladd.FindControl("tbstock" + a.ToString()) as TextBox;

          string s1 = "UPDATE stock SET stock=stock+@p1 WHERE Dist_No=@p2 AND Model_No=@p3";
          SqlCommand cmd1 = new SqlCommand(s1, con);

          cmd1.Parameters.AddWithValue("@p2", Session["Dist_no"].ToString());
          cmd1.Parameters.AddWithValue("@p3", tb1.Text);
          cmd1.Parameters.AddWithValue("@p1", int.Parse(tb2.Text));
          cmd1.ExecuteNonQuery();
          con.Close();
          lbladded.Text = "New Stock updated.";
        }

        else
        {
          con.Open();
          TextBox tb1 = paneladd.FindControl("tbmodel" + a.ToString()) as TextBox;
          TextBox tb2 = paneladd.FindControl("tbstock" + a.ToString()) as TextBox;

          string ss = "select * from Battery where Model_No=@p7";
          SqlCommand cmds = new SqlCommand(ss, con);
          cmds.Parameters.AddWithValue("@p7", tb1.Text);
          SqlDataReader rdr = cmds.ExecuteReader();
          string Company = String.Empty;
          string Product_Name = String.Empty;

          while (rdr.Read())
          {
            Company = rdr["Company"].ToString();
            Product_Name = rdr["Product_Name"].ToString();
          }
          rdr.Close();

          string s1 = "insert into stock (Dist_No, Company, Product_Name, Model_No, stock) values (@p1,@p2,@p3,@p4,@p5)";
          SqlCommand cmd1 = new SqlCommand(s1, con);

          cmd1.Parameters.AddWithValue("@p1", Session["Dist_no"].ToString());
          cmd1.Parameters.AddWithValue("@p2", Company);
          cmd1.Parameters.AddWithValue("@p3", Product_Name);
          cmd1.Parameters.AddWithValue("@p4", tb1.Text);
          cmd1.Parameters.AddWithValue("@p5", int.Parse(tb2.Text));
          cmd1.ExecuteNonQuery();
          con.Close();
          lbladded.Text = "New Stock added.";
        }
      }
      Response.Redirect("addstock.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
      Response.Redirect("login.aspx");
    }
  }
}
