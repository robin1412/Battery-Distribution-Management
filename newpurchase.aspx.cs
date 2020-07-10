using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;

namespace webapp1
{
  public partial class newpurchase : System.Web.UI.Page
  {
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
      DisName.Text = Session["Dist_name"].ToString();
      for (int i = 1; i <= TotalNumberAdded; i++)
      {
        AddControls(i + 1);
      }
    }
    int z = 1;
    protected void Button1_Click(object sender, EventArgs e)
    {
      TotalNumberAdded++;
      AddControls(TotalNumberAdded);
    }
    private void AddControls(int controlNumber)
    {
      z++;
      TextBox tb1 = new TextBox();
      TextBox tb2 = new TextBox();
      TextBox tb3 = new TextBox();
      TextBox tb4 = new TextBox();
      tb1.ID = "TextBoxmo" + z.ToString();
      tb2.ID = "TextBoxwa" + z.ToString();
      tb3.ID = "TextBoxno" + z.ToString();
      tb4.ID = "TextBoxpr" + z.ToString();
      tb1.CssClass = "form-control";
      tb2.CssClass = "form-control";
      tb3.CssClass = "form-control";
      tb4.CssClass = "form-control";
      tb1.Attributes.Add("placeholder", "Enter Model No.");
      tb1.AutoPostBack = true;
      tb1.TextChanged += TextBoxmo_TextChanged;

      tb2.Attributes.Add("placeholder", "Enter months");
      tb3.Attributes.Add("placeholder", "Enter no. of batteries");
      tb4.Attributes.Add("placeholder", "Enter price");

      
      

      HtmlGenericControl d = new HtmlGenericControl("div");
      HtmlGenericControl d1 = new HtmlGenericControl("div");
      HtmlGenericControl d2 = new HtmlGenericControl("div");
      HtmlGenericControl d3 = new HtmlGenericControl("div");
      HtmlGenericControl d4 = new HtmlGenericControl("div");
      d1.Attributes.Add("class", "col-3");
      d2.Attributes.Add("class", "col-2");
      d3.Attributes.Add("class", "col-2");
      d4.Attributes.Add("class", "col-2");
      d.Attributes.Add("class", "row");

      d1.Controls.Add(tb1);
      d2.Controls.Add(tb2);
      d3.Controls.Add(tb3);
      d4.Controls.Add(tb4);

      d.Controls.Add(d1);
      d.Controls.Add(d2);
      d.Controls.Add(d3);
      d.Controls.Add(d4);

      paneladd.Controls.Add(d);
    }
    protected int TotalNumberAdded
    {
      get { return (int)(ViewState["TotalNumberAdded"] ?? 0); }
      set { ViewState["TotalNumberAdded"] = value; }
    }
    //SELECT Company, SUM(stock) AS Sum FROM stock  GROUP BY Company WHERE Dist_No=@dist

    protected void Button2_Click(object sender, EventArgs e)
    {
      for(int a = 1; a <= z; a++)
      {
        con.Open();
        TextBox tb1 = paneladd.FindControl("TextBoxmo"+a.ToString()) as TextBox;
        TextBox tb2 = paneladd.FindControl("TextBoxwa"+a.ToString()) as TextBox;
        TextBox tb3 = paneladd.FindControl("TextBoxno"+a.ToString()) as TextBox;
        TextBox tb4 = paneladd.FindControl("TextBoxpr"+a.ToString()) as TextBox;

        string ss = "select * from Battery where Model_No=@p7";
        SqlCommand cmds = new SqlCommand(ss, con);
        cmds.Parameters.AddWithValue("@p7", tb1.Text);
        SqlDataReader rdr = cmds.ExecuteReader();
        string Company = String.Empty;
        string Product_Name = String.Empty;
        string Category = String.Empty;
        string Capacity = String.Empty;
        string Price = String.Empty;
        string Warrenty = String.Empty;
        while (rdr.Read())
        {
          Company = rdr["Company"].ToString();
          Product_Name = rdr["Product_Name"].ToString();
          Category = rdr["Category"].ToString();
          Capacity = rdr["Capacity"].ToString();
          Price = rdr["Price"].ToString();
          Warrenty = rdr["Warrenty"].ToString();
        }
        rdr.Close();

        string s1 = "insert into PurchaseHistory (Dist_No,Dist_name,User_No,User_Name,Company_Name,Product_Name,Model_No,Category,Capacity,Warranty,Price,Number_Of_Batteries,Date) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13)";
        SqlCommand cmd1 = new SqlCommand(s1, con);

        cmd1.Parameters.AddWithValue("@p1", Session["Dist_no"].ToString());
        cmd1.Parameters.AddWithValue("@p2", Session["Dist_name"].ToString());
        cmd1.Parameters.AddWithValue("@p3", TBcno.Text);
        cmd1.Parameters.AddWithValue("@p4", TBcna.Text);
        cmd1.Parameters.AddWithValue("@p5", Company);
        cmd1.Parameters.AddWithValue("@p6", Product_Name);
        cmd1.Parameters.AddWithValue("@p7", tb1.Text);
        cmd1.Parameters.AddWithValue("@p8", Category);
        cmd1.Parameters.AddWithValue("@p9", Capacity);
        cmd1.Parameters.AddWithValue("@p10", tb2.Text);
        cmd1.Parameters.AddWithValue("@p11", tb4.Text);
        cmd1.Parameters.AddWithValue("@p12", tb3.Text);
        cmd1.Parameters.AddWithValue("@p13", Convert.ToDateTime(TBdate.Text));
        cmd1.ExecuteNonQuery();

        string stk = "UPDATE stock SET stock=stock-@stk WHERE Dist_No=@dist AND Model_No=@mdl";
        SqlCommand cmdstk = new SqlCommand(stk, con);
        cmdstk.Parameters.AddWithValue("@dist", Session["Dist_no"].ToString());
        cmdstk.Parameters.AddWithValue("@mdl", tb1.Text);
        cmdstk.Parameters.AddWithValue("@stk", tb3.Text);
        cmdstk.ExecuteNonQuery();
        con.Close();
      }
      lbladded.Text = "New Purchase Information Added.";
      Application["CustomerName"] = TBcna.Text;
      Application["CustomerNo"] = TBcno.Text;
      Response.Redirect("invoice.aspx");
    }

    protected void TBcno_TextChanged(object sender, EventArgs e)
    {

      TextBox textBox = sender as TextBox;
      String idi = textBox.Text;
      con.Open();
      string s = "select * from User_login where User_no=@p7";
      SqlCommand cmds = new SqlCommand(s, con);
      cmds.Parameters.AddWithValue("@p7", textBox.Text);
      SqlDataReader rdr = cmds.ExecuteReader();
      string Username = String.Empty;
      while (rdr.Read())
      {
        Username = rdr["Username"].ToString();
      }
      rdr.Close();
      TextBox tb2 = paneladd.FindControl("TBcna") as TextBox;
      tb2.Text = Username;

    }

    protected void TextBoxmo_TextChanged(object sender, EventArgs e)
    {

      TextBox textBox = sender as TextBox;
      String idi = textBox.ID;
      String indexx = idi.Substring(9);
      con.Open();
      string s = "select * from Battery where Model_No=@p7";
      SqlCommand cmds = new SqlCommand(s, con);
      cmds.Parameters.AddWithValue("@p7", textBox.Text);
      SqlDataReader rdr = cmds.ExecuteReader();
      string Price = String.Empty;
      string Warrenty = String.Empty;
      while (rdr.Read())
      {
        Price = rdr["Price"].ToString();
        Warrenty = rdr["Warrenty"].ToString();
      }
      rdr.Close();
      TextBox tb2 = paneladd.FindControl("TextBoxwa" + indexx) as TextBox;
      TextBox tb4 = paneladd.FindControl("TextBoxpr" + indexx) as TextBox;
      tb2.Text = Warrenty;
      tb4.Text = Price;
    }


    protected void Button3_Click(object sender, EventArgs e)
    {
      Response.Redirect("login.aspx");
    }
  }
}
