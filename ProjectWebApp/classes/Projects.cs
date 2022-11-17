using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProjectWebApp.classes
{
    public class Projects
    {
        SqlConnection conn = Connections.GetConeection();
        public static List<Projects> prList = new List<Projects>();
        public string ProjectCode { get; set; }
        private string _projectName;
        public string ProjectName
        {
            get { return _projectName; }
            set
            {
                if (value.Trim().Length < 3)
                {
                    throw new Exception($"Project name ({value}) should at least be 3 characters long");
                }
                _projectName = value;
            }
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public double Duration { get; }
        public double EstimatedCost { get; set; }
        public Employee Emp { get; } = new Employee();
        public Projects()
        {

        }
        public Projects(string theCode, string theName, DateTime sDate, DateTime eDate)
        {
            ProjectCode = theCode;
            ProjectName = theName;
            StartDate = sDate;
            EndDate = eDate;
            if (StartDate > EndDate)
            {
                throw new Exception($"Start date ({StartDate}) cannot be after the end date ({EndDate})");
            }
            Duration = (EndDate - StartDate).TotalDays;
            Emp = new Employee();
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="rate"></param>
        public void calcEstimatedCost(double rate)
        {
            EstimatedCost = (rate * Duration) * 8;
        }
        public override string ToString()
        {
            //Code: PR123  Name: SISONKE 14 days, EC: R22 400.00
            return $"Code: {ProjectCode} Name: {ProjectName} {Duration} days, EC: {EstimatedCost:c}";
        }
        /*implement an indexer that will return a project 
		 * with a specific code*/
        public Projects this[string code]
        {
            get
            {
                return prList.Find(x => x.ProjectCode.Equals(code));
            }
        }
        //return a prject with the highest estimated cost

        public Projects HighestEstCost()
        {
            string strSelect = $"SELECT * FROM tblProject WHERE EstimatedCost = (SELECT MAX(EstimatedCost) FROM tblProject)";
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(strSelect, conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProjectCode = (string)reader[0];
                            ProjectName = (string)reader["PrName"];
                            StartDate = (DateTime)reader["StartDate"];
                            EndDate = (DateTime)reader[3];
                            EstimatedCost = Convert.ToDouble(reader[5]);

                        }
                    }
                }
            }

            return new Projects(ProjectCode, ProjectName, StartDate, EndDate);

            //return prList.Aggregate((p1, p2) =>
            //p1.EstimatedCost > p2.EstimatedCost ? p1 : p2);

        }
        public void DeleteProject(string code)
        {
            string strInsert = $"Delete from tblProject where Code = '{code}';";
            SqlCommand cmdInsert = new SqlCommand(strInsert, conn);

            conn.Open();
            cmdInsert.ExecuteNonQuery();
            conn.Close();
        }
        public void AddProject()
        {
            string strInsert = $"INSERT INTO tblProject VALUES('{ProjectCode}','{ProjectName}','{StartDate.ToShortDateString()}','{EndDate.ToShortDateString()}',{Duration},{EstimatedCost}, {Emp.EmployeeNum})";
            SqlCommand cmdInsert = new SqlCommand(strInsert, conn);

            conn.Open();
            cmdInsert.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateProject(string code)
        {
            string strInsert = $@"UPDATE tblProject Set 
            Code = '{ProjectCode}',
            PrName = '{ProjectName}',
            StartDate = '{StartDate.ToShortDateString()}',
            EndDate = '{EndDate.ToShortDateString()}',
            Duration = {Duration},
            EstimatedCost = {EstimatedCost},
            Employee = {Emp.EmployeeNum}
            where Code = '{code}'";
            SqlCommand cmdInsert = new SqlCommand(strInsert, conn);

            conn.Open();
            cmdInsert.ExecuteNonQuery();
            conn.Close();
        }
        public List<Projects> AllProjects()
        {
            string strSelect = $"SELECT * FROM tblProject";
            SqlCommand cmdSelect = new SqlCommand(strSelect, conn);
            DataTable myTable = new DataTable();
            DataRow myRow;
            SqlDataAdapter myAdapter = new SqlDataAdapter(cmdSelect);
            List<Projects> _list = new List<Projects>();

            conn.Open();
            myAdapter.Fill(myTable);

            if (myTable.Rows.Count > 0)
            {
                for (int i = 0; i < myTable.Rows.Count; i++)
                {
                    myRow = myTable.Rows[i];
                    ProjectCode = (string)myRow[0];
                    ProjectName = (string)myRow["PrName"];
                    StartDate = (DateTime)myRow["StartDate"];
                    EndDate = (DateTime)myRow[3];

                    _list.Add(new Projects(ProjectCode, ProjectName, StartDate, EndDate));
                }
            }


            conn.Close();
            return _list;
        }

        public List<Projects> empProjects(int emnum)
        {
            string strSelect = $"SELECT * FROM tblProject where Employee = {emnum}";
            SqlCommand cmdSelect = new SqlCommand(strSelect, conn);
            DataTable myTable = new DataTable();
            DataRow myRow;
            SqlDataAdapter myAdapter = new SqlDataAdapter(cmdSelect);
            List<Projects> _list = new List<Projects>();

            conn.Open();
            myAdapter.Fill(myTable);

            if (myTable.Rows.Count > 0)
            {
                for (int i = 0; i < myTable.Rows.Count; i++)
                {
                    myRow = myTable.Rows[i];
                    ProjectCode = (string)myRow[0];
                    ProjectName = (string)myRow["PrName"];
                    StartDate = (DateTime)myRow["StartDate"];
                    EndDate = (DateTime)myRow[3];

                    _list.Add(new Projects(ProjectCode, ProjectName, StartDate, EndDate));
                }
            }


            conn.Close();
            return _list;
        }
        public void GetProjects(string code)
        {
            string strSelect = $"SELECT * FROM tblProject where Code = '{code}'";
            SqlCommand cmdSelect = new SqlCommand(strSelect, conn);
            DataTable myTable = new DataTable();
            DataRow myRow;
            SqlDataAdapter myAdapter = new SqlDataAdapter(cmdSelect);
            List<Projects> _list = new List<Projects>();

            conn.Open();
            myAdapter.Fill(myTable);

            if (myTable.Rows.Count > 0)
            {
                for (int i = 0; i < myTable.Rows.Count; i++)
                {
                    myRow = myTable.Rows[i];
                    ProjectCode = (string)myRow[0];
                    ProjectName = (string)myRow["PrName"];
                    StartDate = (DateTime)myRow["StartDate"];
                    EndDate = (DateTime)myRow[3];

                    
                }
            }

            conn.Close();
           
        }
    }
}
