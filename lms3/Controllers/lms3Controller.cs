using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Sql;
using System.Web.Routing;
using lms3.Models;
using static lms3.Models.emp_Registration;
using static lms3.Models.Emp_login_page;
using static lms3.Models.apply_for_leave;
using System.Collections;
using System.Security.Claims;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using Antlr.Runtime.Misc;
using System.Security.Policy;
using System.Web.Helpers;
using System.Configuration;
using System.Web.UI.WebControls;





 



namespace lms3.Controllers
{
    public class lms3Controller : Controller
    {
        
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-201APDA0;Initial Catalog=lms_test2;Integrated Security=True");
        // GET: lms3
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Landing()
        {
            return View();
        }


        public ActionResult register(lms3.Models.emp_Registration emp)
        {




            conn.Open();
            //string v1 = emp.Empid.ToString();
            string v2 = emp.fname.ToString();
            string v3 = emp.dept.ToString();

            string v4 = emp.designation.ToString();
            string v5 = emp.gender.ToString();
            string v6 = emp.username.ToString();

            string v7 = emp.pass.ToString();
            string v8 = emp.user_role.ToString();



            string qry = "insert into emp_Registration (fname,dept,designation,gender,username,pass,user_role) " +
                "values ('" + v2 + "','" + v3 + "','" + v4 + "','" + v5 + "','" + v6 + "','" + v7 + "','" + v8 + "') ";
            SqlCommand cmd1 = new SqlCommand(qry, conn);
            cmd1.ExecuteNonQuery();
            conn.Close();



            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        
        public ActionResult LoginProcess(lms3.Models.Emp_login_page lgn, lms3.Models.emp_Registration emp)
        {





           
            
                    conn.Open();

                    string user = lgn.username;
                    string pass = lgn.pass;

                    string qry = "select *from  emp_Registration where username=@user and pass=@pass";
                    SqlCommand cmd = new SqlCommand(qry, conn);
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", pass);

                    SqlDataReader data = cmd.ExecuteReader();

                    if (data.Read())
                    {
                        emp.fname = data["fname"].ToString();
                        emp.dept = data["dept"].ToString();
                        emp.user_role = data["user_role"].ToString();
                        emp.isvalid = data["isvalid"].ToString();

                        if (emp.user_role != "0")
                        {
                            Session["Employee ID"] = emp.Empid.ToString();
                            Session["UserName"] = emp.username.ToString();

                            return View("Admindashboard", emp);
                        }
                        else
                        {
                            Session["Employee ID"] = emp.Empid.ToString();
                            Session["username"] = emp.username.ToString();

                            return View("dashboard", emp);
                        }
                    }
                    else
                    {
                        conn.Close(); // close the connection before setting TempData
                        TempData["Error Message"] = "Invalid username or password";
                        return View("Landing");
                    }
                
            


        }


        public ActionResult Second(lms3.Models.emp_leave_balance emp)
        {


                conn.Open();

                string user = emp.emp_lb_id.ToString();

                string query = "select * from emp_leave_balance where emp_lb_id  = @user";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", user);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                List<emp_leave_balance> sstaff = new List<emp_leave_balance>();
                foreach (DataRow dr in ds.Tables[0].Rows) 
                {
                    sstaff.Add(new emp_leave_balance
                    {
                        emp_lb_id = Convert.ToInt32(dr["emp_lb_id"]),
                        Casual = Convert.ToString(dr["Casual"]),
                        Earned = Convert.ToString(dr["Earned"]),
                        Medical = Convert.ToString(dr["Medical"]),
                        Maternity = Convert.ToString(dr["Maternity"]),
                        Special = Convert.ToString(dr["Special"]),
                    });
                }

                cmd.ExecuteNonQuery();
                conn.Close();

                return View(sstaff);
            



        }  
        
        public  ActionResult Approve(lms3.Models.apply_for_leave lp)
        {


            conn.Open();
            string v2 = lp.empid;

            string query = "insert  into approvedleave(empid,leave_mst,no_of_days,from_days,To_date,discrip,nam,approved,reject)" +
                "select empid,leave_mst,no_of_days,from_days,To_date,discrip,nam,approved,reject from apply_for_leave where empid='" + v2 + "'" +
                "delete from apply_for_leave where empid = '" + v2 + "' ";

            SqlCommand cmd1 = new SqlCommand(query, conn);


            cmd1.ExecuteNonQuery();

            conn.Close();
            return View();





        }
        public ActionResult Reject(lms3.Models.apply_for_leave lp)
        {
            conn.Open();
            string v2 = lp.empid;
            
            string query = "insert  into Rejectedleave(empid,leave_mst,no_of_days,from_days,To_date,discrip,nam,approved,reject)" +
                "select empid,leave_mst,no_of_days,from_days,To_date,discrip,nam,approved,reject from apply_for_leave where empid='" + v2 + "'" +
                "delete from apply_for_leave where empid = '" + v2 + "' ";

            SqlCommand cmd1 = new SqlCommand(query, conn);


            cmd1.ExecuteNonQuery();

            conn.Close();
            return View();


        }  

      public ActionResult dashboard()
        {

              return View();

        }

        public ActionResult logout()
        {
            Session.Abandon();

            return View("Index");

        }

        public ActionResult Admindashboard(lms3.Models.emp_Registration emp)
        {
            //string v2 = '2'.ToString();

            return View();

        }
        public ActionResult Apply()
        {

            string qwery = "select * from apply_for_leave ";

            conn.Open();
            SqlCommand cmd = new SqlCommand(qwery, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            List<apply_for_leave> sstaff = new List<apply_for_leave>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                sstaff.Add(new apply_for_leave
                {
                    empid = Convert.ToString(dr["empid"]),
                    leave_mst = Convert.ToString(dr["leave_mst"]),
                    no_of_days = Convert.ToString(dr["no_of_days"]),
                    from_days = Convert.ToString(dr["from_days"]),
                    To_date = Convert.ToString(dr["To_date"]),
                    discrip = Convert.ToString(dr["discrip"]),
                    nam = Convert.ToString(dr["nam"]),


                });


            }
            conn.Close();

            return View(sstaff);

        }


        public ActionResult leavepage()
        {
            return View();
        }
        
        public ActionResult leaveapplication(lms3.Models.apply_for_leave la)
        {
            conn.Open();
            //string v1 = emp.Empid.ToString();
            string v2 = la.empid.ToString();
            string v3 = la.leave_mst.ToString();

            string v4 = la.no_of_days.ToString();
            string v5 = la.from_days.ToString();
            string v6 = la.To_date.ToString();

            string v7 = la.discrip.ToString();
            string v8 = la.nam.ToString();



            string qry = "insert into  apply_for_leave(empid,leave_mst,no_of_days,from_days,To_date,discrip,nam) " +
                "values ('" + v2 + "','" + v3 + "','" + v4 + "','" + v5 + "','" + v6 + "','" + v7 + "','" + v8 + "') ";
            
            
            SqlCommand cmd1 = new SqlCommand(qry, conn);

           // string trig= 
            cmd1.ExecuteNonQuery();
            conn.Close();



            return View();
        }




    }
}












