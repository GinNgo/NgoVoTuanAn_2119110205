using Cau1.DepartmentDALL;
using Cau1.EmloyeeDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.EmloyeeDALL
{
    public class EmployeeDAL:DBConnection
    {
        public List<EmployeeBEL> ReadEmployee()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            //SqlCommand cmd = new SqlCommand("select*from Employee", conn);
            //lấy dl = procedure
            SqlCommand cmd = new SqlCommand("SelectAllEmployee", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader reader = cmd.ExecuteReader();

            List<EmployeeBEL> lstemp = new List<EmployeeBEL>();
            DepartmentDAL dep = new DepartmentDAL();
            while (reader.Read())
            {
                EmployeeBEL emp = new EmployeeBEL();

                emp.IdEmployee = reader["IdEmployee"].ToString();
                emp.Name = reader["Name"].ToString();
                emp.DateBirth = (DateTime)reader["DateBirth"];
                int flag = (int)reader["Gender"];
                if (flag == 1)
                {
                    emp.Gender = true;
                }
                else
                {
                    emp.Gender = false;

                }
                
                emp.PlaceBirth = reader["PlaceBirth"].ToString();
                emp.Department = dep.ReadDepartment(reader["IdDepartment"].ToString());
                
                lstemp.Add(emp);
            }
            conn.Close();
            return lstemp;
        }
        public void EditEmployee(EmployeeBEL emp)
        {
            SqlConnection conn = CreateConnection();
            try { 
            conn.Open();
                //SqlCommand cmd = new SqlCommand("update Employee set Name = @Name,DateBirth = @DateBirth,Gender = @Gender,PlaceBirth = @PlaceBirth,IdDepartment = @IdDepartment where IdEmployee =@IdEmployee", conn);
                //cmd.Parameters.Add(new SqlParameter("@IdEmployee", emp.IdEmployee));
                //cmd.Parameters.Add(new SqlParameter("@Name", emp.Name));
                //cmd.Parameters.Add(new SqlParameter("@DateBirth", emp.DateBirth));
                //cmd.Parameters.Add(new SqlParameter("@Gender", emp.Gender));
                //cmd.Parameters.Add(new SqlParameter("@PlaceBirth", emp.PlaceBirth));
                //cmd.Parameters.Add(new SqlParameter("@IdDepartment", emp.Department.IdDepartment));
                SqlCommand cmd = new SqlCommand("UpdateEmployee", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add("@IdEmployee", SqlDbType.NVarChar).Value = emp.IdEmployee;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = emp.Name;
                cmd.Parameters.Add("@DateBirth", SqlDbType.Date).Value = emp.DateBirth;
                cmd.Parameters.Add("@Gender", SqlDbType.Int).Value = emp.Gender;
                cmd.Parameters.Add("@PlaceBirth", SqlDbType.NVarChar).Value = emp.PlaceBirth;
                cmd.Parameters.Add("@IdDepartment", SqlDbType.VarChar).Value = emp.Department.IdDepartment;
                cmd.ExecuteNonQuery();
            conn.Close();
            Console.WriteLine("Sua thanh cong !!!");

        }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                conn.Close();
            }
        }
        public void DeleteEmployee(EmployeeBEL emp)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                conn.Open();
                //SqlCommand cmd = new SqlCommand("delete from Employee where IdEmployee =@IdEmployee", conn);
                //cmd.Parameters.Add(new SqlParameter("@IdEmployee", emp.IdEmployee));
                SqlCommand cmd = new SqlCommand("DeleteEmployee", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add("@IdEmployee", SqlDbType.NVarChar).Value = emp.IdEmployee;
                cmd.ExecuteNonQuery();
            conn.Close();
            Console.WriteLine("Xoa thanh cong !!!");
        }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                conn.Close();
            }
        }
        public void NewEmployee(EmployeeBEL emp)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                conn.Open();
            //SqlCommand cmd = new SqlCommand("insert into Employee values(@IdEmployee, @Name,@DateBirth,@Gender, @PlaceBirth, @IdDepartment  )", conn);
            //cmd.Parameters.Add(new SqlParameter("@IdEmployee", emp.IdEmployee));
            //cmd.Parameters.Add(new SqlParameter("@Name", emp.Name));
            //cmd.Parameters.Add(new SqlParameter("@DateBirth", emp.DateBirth));
            //cmd.Parameters.Add(new SqlParameter("@Gender", emp.Gender));
            //cmd.Parameters.Add(new SqlParameter("@PlaceBirth", emp.PlaceBirth));
            //cmd.Parameters.Add(new SqlParameter("@IdDepartment", emp.Department.IdDepartment));
            SqlCommand cmd = new SqlCommand("InsertEmployee", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add("@IdEmployee", SqlDbType.NVarChar).Value = emp.IdEmployee;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = emp.Name;
            cmd.Parameters.Add("@DateBirth", SqlDbType.Date).Value = emp.DateBirth;
            cmd.Parameters.Add("@Gender", SqlDbType.Int ).Value = emp.Gender;
            cmd.Parameters.Add("@PlaceBirth", SqlDbType.NVarChar).Value = emp.PlaceBirth;
            cmd.Parameters.Add("@IdDepartment", SqlDbType.VarChar).Value = emp.Department.IdDepartment;
            cmd.ExecuteNonQuery();
            conn.Close();
                Console.WriteLine("Them thanh cong !!!");


            }
            catch (Exception e)
            {
              
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                conn.Close();
            }
        }
    }
}
