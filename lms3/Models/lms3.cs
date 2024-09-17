using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace lms3.Models
{
    public class emp_Registration
    {
        public int Empid { get; set; }
        public string fname { get; set; }
        public string dept { get; set; }
        public string designation { get; set; }
        public string gender { get; set; }
        public string username { get; set; }
        public string pass { get; set; }
        public string user_role { get; set; }
        public string isvalid { get; set; }


    }
    public class leave_master
    {
        public string leave_id { get; set; }
        public string leave_name { get; set; }
    }
    public class emp_leave_balance
    {
        public int emp_lb_id { get; set; }
        public string Casual { get; set; }
        public string Earned { get; set; }
        public string Medical { get; set; }
        public string Maternity { get; set; }
        public string Special { get; set; }
        public string username { get; set; }

    }
    public class Dept_master
    {
        public string dept_id { get; set; }
        public string dept_name { get; set; }
    }
    public class dsg_names
    {
        public string dsg_id { get; set; }
        public string dsg_name { get; set; }

    }
    public class admin_lgn_page
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public class leave_status
    {
        public string STATUSS { get; set; }

    }
    public class Emp_login_page
    {
        public string username { get; set; }
        public string pass { get; set; }
    }
    public class change_password
    {
        public string crt_pass { get; set; }
        public string new_pass { get; set; }
        public string cnm_pass { get; set; }
    }
    public class apply_for_leave
    {
        public string empid { get; set; }
        public string leave_mst { get; set; }
        public string no_of_days { get; set; }
        public string from_days { get; set; }
        public string To_date { get; set; }
        public string discrip { get; set; }
        public string nam { get; set; }
        public string approved { get; set; }
        public string reject { get; set; }
    }

    public class approvedleave
    {
        public string empid { get; set; }
        public string leave_mst { get; set; }
        public string no_of_days { get; set; }
        public string from_days { get; set; }
        public string To_date { get; set; }
        public string discrip { get; set; }
        public string nam { get; set; }
        public string approved { get; set; }
        public string reject { get; set; }
    }
    public class Rejectedleave
    {
        public string empid { get; set; }
        public string leave_mst { get; set; }
        public string no_of_days { get; set; }
        public DateTime from_days { get; set; }
        public DateTime To_date { get; set; }
        public string discrip { get; set; }
        public string nam { get; set; }
        public string approved { get; set; }

        public string reject { get; set; }
    }

    public class leave_history
    {
        public string leave_mst { get; set; }
        public string from_date { get; set; }
        public string To_date { get; set; }
        public string discrip { get; set; }
        public string post_date { get; set; }
        public string Admin_remark { get; set; }
        public int AStat { get; set; }
    }
    public class admin_dash
    {
        public string total_regis_emp { get; set; }
        public string total_leave { get; set; }
        public string total_apprd_leave { get; set; }
        public string new_leave_app { get; set; }
    }
    public class new_leave_application
    {
        public string username { get; set; }
        public string leave_mst { get; set; }
        public string pending_date { get; set; }
        public string stat { get; set; }
        public string take_action { get; set; }
    }
    public class admin_hpages
    {
        public string ADMIN_HOME_PAGE { get; set; }
    }
    public class leave_management
    {
        public string all_leaves { get; set; }
        public string pending_leaves { get; set; }
        public string approved_leave { get; set; }
        public string Rejected_leave { get; set; }
    }
    public class pass_recovery
    {
        public string empid { get; set; }
        public string emailid { get; set; }
    }
    public class emp_hpage
    {
        public string EMP_Homepage { get; set; }
    }
    public class employee_dashb
    {
        public string total_leave { get; set; }
        public string leave_balance { get; set; }
        public string leave_approved { get; set; }
        public string eleave_rejected { get; set; }
        public string leave_pending { get; set; }
    }
}