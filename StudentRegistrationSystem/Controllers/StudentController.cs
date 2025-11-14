
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using StudentRegistrationSystem.Models;

namespace StudentRegistrationSystem.Controllers
{
    public class StudentController : Controller
    {
        //string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;


        public ActionResult Index()
        {
            var students = GetAllStudents();
            return View(students);
        }

        // ✅ Fetch All Students
        public List<StudentModel> GetAllStudents()
        {
            List<StudentModel> list = new List<StudentModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM StudentReg";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    list.Add(new StudentModel
                    {
                        StudentId = Convert.ToInt32(rdr["StudentId"]),
                        FullName = rdr["FullName"].ToString(),
                        Email = rdr["Email"].ToString(),
                        MobileNo = rdr["MobileNo"].ToString(),
                        Gender = rdr["Gender"].ToString(),
                        PanNo = rdr["PanNo"].ToString(),
                        AadharNo = rdr["AadharNo"].ToString(),
                        PassportNo = rdr["PassportNo"].ToString(),
                        VoterId = rdr["VoterId"].ToString(),
                        DrivingNo = rdr["DrivingNo"].ToString()
                    });
                }
            }
            return list;
        }

        // ✅ Create New Student
        [HttpPost]
        public JsonResult CreateNew(StudentModel model)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO StudentReg 
                                    (FullName, Email, MobileNo, Gender, PanNo, AadharNo, PassportNo, VoterId, DrivingNo)
                                    VALUES (@FullName, @Email, @MobileNo, @Gender, @PanNo, @AadharNo, @PassportNo, @VoterId, @DrivingNo)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@FullName", model.FullName);
                    cmd.Parameters.AddWithValue("@Email", model.Email);
                    cmd.Parameters.AddWithValue("@MobileNo", model.MobileNo);
                    cmd.Parameters.AddWithValue("@Gender", model.Gender);
                    cmd.Parameters.AddWithValue("@PanNo", model.PanNo);
                    cmd.Parameters.AddWithValue("@AadharNo", model.AadharNo);
                    cmd.Parameters.AddWithValue("@PassportNo", model.PassportNo);
                    cmd.Parameters.AddWithValue("@VoterId", model.VoterId);
                    cmd.Parameters.AddWithValue("@DrivingNo", model.DrivingNo);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // ✅ Update Student
        [HttpPost]
        public JsonResult Update(StudentModel model)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"UPDATE StudentReg SET 
                                    FullName=@FullName, Email=@Email, MobileNo=@MobileNo, Gender=@Gender, 
                                    PanNo=@PanNo, AadharNo=@AadharNo, PassportNo=@PassportNo, VoterId=@VoterId, DrivingNo=@DrivingNo
                                    WHERE StudentId=@StudentId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@StudentId", model.StudentId);
                    cmd.Parameters.AddWithValue("@FullName", model.FullName);
                    cmd.Parameters.AddWithValue("@Email", model.Email);
                    cmd.Parameters.AddWithValue("@MobileNo", model.MobileNo);
                    cmd.Parameters.AddWithValue("@Gender", model.Gender);
                    cmd.Parameters.AddWithValue("@PanNo", model.PanNo);
                    cmd.Parameters.AddWithValue("@AadharNo", model.AadharNo);
                    cmd.Parameters.AddWithValue("@PassportNo", model.PassportNo);
                    cmd.Parameters.AddWithValue("@VoterId", model.VoterId);
                    cmd.Parameters.AddWithValue("@DrivingNo", model.DrivingNo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // ✅ Delete Student
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM StudentReg WHERE StudentId=@StudentId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@StudentId", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
