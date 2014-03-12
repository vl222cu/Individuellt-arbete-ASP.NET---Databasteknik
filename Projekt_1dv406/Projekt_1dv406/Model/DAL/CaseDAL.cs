using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Projekt_1dv406.Model.DAL
{
    public class CaseDAL : DALBase
    {
        // Hämtar alla felanmälningar i databasen
        public static IEnumerable<Case> GetCases()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var actions = new List<Case>(20);

                    var cmd = new SqlCommand("appSchema.GetCases", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var errorCaseIdIndex = reader.GetOrdinal("FelanmID");
                        var CaseTopicIndex = reader.GetOrdinal("Ämne");
                        var DateIndex = reader.GetOrdinal("Datum");

                        while (reader.Read())
                        {
                            actions.Add(new Case
                            {
                                FelanmID = reader.GetInt32(errorCaseIdIndex),
                                Ämne = reader.GetString(CaseTopicIndex),
                                Datum = reader.GetDateTime(DateIndex)
                            });
                        }
                    }

                    actions.TrimExcess();
                    return actions;
                }
                catch (Exception)
                {
                    throw new ApplicationException("Ett fel uppstod vid kontakt med databasen.");
                }
            }
        }

        // Hämtar vald felanmälan i databasen
        public Case GetCase(int errorCaseId)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.GetCase", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FelanmID", SqlDbType.Int, 4).Value = errorCaseId;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var errorCaseIdIndex = reader.GetOrdinal("FelanmID");
                            var topicIndex = reader.GetOrdinal("Ämne");
                            var caseIndex = reader.GetOrdinal("Felanmälan");
                            var dateIndex = reader.GetOrdinal("Datum");

                            return new Case
                            {
                                FelanmID = reader.GetInt32(errorCaseIdIndex),
                                Ämne = reader.GetString(topicIndex),
                                Felanmälan = reader.GetString(caseIndex),
                                Datum = reader.GetDateTime(dateIndex)
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

        // Skapar ny felanmälan i databasen
        public void InsertCase(Case errorCase)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.InsertCase", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Ämne", SqlDbType.VarChar, 50).Value = errorCase.Ämne;
                    cmd.Parameters.Add("@Felanmälan", SqlDbType.VarChar, 500).Value = errorCase.Felanmälan;
                    cmd.Parameters.Add("@Datum", SqlDbType.DateTime, 8).Value = errorCase.Datum;
                    cmd.Parameters.Add("@FelanmID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    errorCase.FelanmID = (int)cmd.Parameters["@FelanmID"].Value;
                }
                catch (Exception)
                {
                    throw new ApplicationException("Ett fel uppstod vid kontakt med databasen.");
                }
            }
        }

        // Uppdaterar en felanmälan i databasen
        public static void UpdateCase(Case errorCase)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.UpdateCase", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Ämne", SqlDbType.VarChar, 50).Value = errorCase.Ämne;
                    cmd.Parameters.Add("@Felanmälan", SqlDbType.VarChar, 500).Value = errorCase.Felanmälan;
                    cmd.Parameters.Add("@Datum", SqlDbType.DateTime, 8).Value = errorCase.Datum;
                    cmd.Parameters.Add("@FelanmID", SqlDbType.Int, 4).Value = errorCase.FelanmID;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new ApplicationException("Ett fel uppstod vid uppdateringen.");
                }
            }
        }

        // Tar bort en felanmälan i databasen
        public static void DeleteCase(int felanmId)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.DeleteCase", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FelanmID", SqlDbType.Int, 4).Value = felanmId;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new ApplicationException("Ett fel uppstod vid borttag av felanmälan.");
                }
            }
        }
    }
}