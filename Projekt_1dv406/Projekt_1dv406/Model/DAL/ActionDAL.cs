using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Projekt_1dv406.Model.DAL
{
    public class ActionDAL : DALBase
    {
        // Hämtar alla åtgärder i databasen
        public static IEnumerable<Action> GetActionList()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var actions = new List<Action>(100);

                    var cmd = new SqlCommand("appSchema.GetActionList", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var actionIdIndex = reader.GetOrdinal("ÅtgID");
                        var errorCaseIndex = reader.GetOrdinal("FelanmID");
                        var depIndex = reader.GetOrdinal("AvdID");
                        var startDateIndex = reader.GetOrdinal("StartDatum");
                        var endDateIndex = reader.GetOrdinal("SlutDatum");
                           
                        while (reader.Read())
                        {
                            actions.Add(new Action
                            {
                                ÅtgID = reader.GetInt32(actionIdIndex),
                                FelanmID = reader.GetInt32(errorCaseIndex),
                                AvdID = reader.GetInt32(depIndex),
                                StartDatum = reader.GetDateTime(startDateIndex),
                                SlutDatum = reader.GetDateTime(endDateIndex)
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

        // Hämtar en åtgärd i databasen
        public Action GetAction(int actionId)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.GetAction", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ÅtgID", SqlDbType.Int, 4).Value = actionId;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var actionIdIndex = reader.GetOrdinal("ÅtgID");
                            var errorCaseIndex = reader.GetOrdinal("FelanmID");
                            var depIndex = reader.GetOrdinal("AvdID");
                            var startDateIndex = reader.GetOrdinal("StartDatum");
                            var endDateIndex = reader.GetOrdinal("SlutDatum");

                            return new Action
                            {
                                ÅtgID = reader.GetInt32(actionIdIndex),
                                FelanmID = reader.GetInt32(errorCaseIndex),
                                AvdID = reader.GetInt32(depIndex),
                                StartDatum = reader.GetDateTime(startDateIndex),
                                SlutDatum = reader.GetDateTime(endDateIndex)
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

        // Uppdaterar en åtgärd i databasen
        public static void UpdateAction(Action action)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.UpdateAction", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ÅtgID", SqlDbType.Int, 4).Value = action.ÅtgID;
                    cmd.Parameters.Add("@FelanmID", SqlDbType.Int, 4).Value = action.FelanmID;
                    cmd.Parameters.Add("@AvdID", SqlDbType.Int, 4).Value = action.AvdID;
                    cmd.Parameters.Add("@StartDatum", SqlDbType.DateTime, 8).Value = action.StartDatum;
                    cmd.Parameters.Add("@SlutDatum", SqlDbType.DateTime, 8).Value = action.SlutDatum;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new ApplicationException("Ett fel uppstod vid uppdateringen.");
                }
            }
        }

        // Tar bort en åtgärd i databasen
        public static void DeleteAction(int actionId)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.DeleteAction", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ÅtgID", SqlDbType.Int, 4).Value = actionId;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new ApplicationException("Ett fel uppstod vid borttag av åtgärd.");
                }
            }
        }
    }
}