using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Projekt_1dv406.Model.DAL
{
    public class DepartmentDAL : DALBase
    {
        // Hämtar alla avdelningar i databasen från tabellen avdelning
        public static IEnumerable<Department> GetDepartments()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var departments = new List<Department>(10);

                    var cmd = new SqlCommand("appSchema.GetDepartments", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var depIdIndex = reader.GetOrdinal("AvdID");
                        var depIndex = reader.GetOrdinal("Avdelning");

                        while (reader.Read())
                        {
                            departments.Add(new Department
                            {
                                AvdID = reader.GetInt32(depIdIndex),
                                Avdelning = reader.GetString(depIndex), 
                            });
                        }
                    }

                    departments.TrimExcess();
                    return departments;
                }
                catch (Exception)
                {
                    throw new ApplicationException("Ett fel uppstod vid kontakt med databasen.");
                }
            }
        }

        // Hämtar en avdelning i databasen från tabellen avdelning
        public Department GetDepartment(int depId)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.GetDepartment", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AvdID", SqlDbType.Int, 4).Value = depId;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var depIdIndex = reader.GetOrdinal("AvdID");
                            var depIndex = reader.GetOrdinal("Avdelning");

                            return new Department
                            {
                                AvdID = reader.GetInt32(depIdIndex),
                                Avdelning = reader.GetString(depIndex)
                            };
                        }
                    }

                    return null;
                }
                catch (Exception)
                {
                    throw new ApplicationException("Ett fel uppstod vid kontakt med databasen.");
                }
            }
        }
    }
}