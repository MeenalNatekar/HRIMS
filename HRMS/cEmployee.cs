using System;
using System.Data;
using System.Data.SqlClient;
        public static DataTable GetEmpList()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EmpID");
            dt.Columns.Add("EmployeeCode");
            dt.Columns.Add("DepartmentType");
            dt.Columns.Add("Designation");
            dt.Columns.Add("Firstname");
            dt.Columns.Add("WorkEmail");
            dt.Columns.Add("DOJ");
            List<SqlParameter> a = new List<SqlParameter>();
            oDB.CallSPROC("uspEmployeeData", a, dt);
            return dt;
        }
        public static DataTable GetEmpBirthDay()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("DOB");
            List<SqlParameter> a = new List<SqlParameter>();
            oDB.CallSPROC("uspGetDOB", a, dt);
            return dt;
        }
        public static DataTable GetProject(int LoginUserID)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProjectName");
            dt.Columns.Add("sDescription");
            List<SqlParameter> a = new List<SqlParameter>();
            a.Add(new SqlParameter("@LoginUserID", SqlDbType.Int));
            a[a.Count-1].Value=LoginUserID;
            oDB.CallSPROC("uspGetAssignedProject", a, dt);
            return dt;
        }
        public static DataTable GetNewJoinee()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("EmployeeCode");
            dt.Columns.Add("DepartmentType");
            List<SqlParameter> a = new List<SqlParameter>();
            oDB.CallSPROC("uspGetNewJoinee", a, dt);
            return dt;
        }
        public static DataTable GetNews()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("sHeadLine");
            dt.Columns.Add("sDescription");
            List<SqlParameter> a = new List<SqlParameter>();
            oDB.CallSPROC("uspGetLatestNews", a, dt);
            return dt;
        }