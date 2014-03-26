using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Projekt_1dv406.Model.DAL

{   // Klass mot tabellen Åtgärd med CRUD-funktionalitet
    public class ActionDAL : DALBase
    {
        // Hämtar lista med åtgärder i databasen
        public static IEnumerable<Action> GetActionList()
        {
            // Skapar anslutningsobjekt
            using (var conn = CreateConnection())
            {
                try
                {
                    var actions = new List<Action>(100);

                    // Skapar SQLCommand-objekt för att kunna exekvera den lagrade proceduren
                    var cmd = new SqlCommand("appSchema.GetActionList", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    // Skapar SqlDataReader-objekt och returnerar en referens till objektet
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

                    // Trimmar listobjektet efter antalet element
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
            // Skapar anslutningsobjekt
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar SQLCommand-objekt för att kunna exekvera den lagrade proceduren
                    var cmd = new SqlCommand("appSchema.GetAction", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ÅtgID", SqlDbType.Int, 4).Value = actionId;

                    conn.Open();

                    // Skapar SqlDataReader-objekt och returnerar en referens till objektet
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Tar reda på indexet för varje kolumn
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

        // Hämtar alla åtgärder i databasen
        public List<Action> GetActionByCaseId(int caseId)
        {
            // Skapar anslutningsobjekt
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar SQLCommand-objekt för att kunna exekvera den lagrade proceduren
                    var cmd = new SqlCommand("appSchema.GetActionByCaseId", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FelanmID", SqlDbType.Int, 4).Value = caseId;

                    List<Action> actions = new List<Action>(100);

                    conn.Open();

                    // Skapar SqlDataReader-objekt och returnerar en referens till objektet
                    using (var reader = cmd.ExecuteReader())
                    {
                        var errorCaseIndex = reader.GetOrdinal("FelanmID");
                        var actionIndex = reader.GetOrdinal("ÅtgID");
                        var depIndex = reader.GetOrdinal("AvdID");
                        var startDateIndex = reader.GetOrdinal("StartDatum");
                        var endDateIndex = reader.GetOrdinal("SlutDatum");

                        while (reader.Read())
                        {
                            actions.Add(new Action
                            {
                                FelanmID = reader.GetInt32(errorCaseIndex),
                                ÅtgID = reader.GetInt32(actionIndex),
                                AvdID = reader.GetInt32(depIndex),
                                StartDatum = reader.GetDateTime(startDateIndex),
                                SlutDatum = reader.GetDateTime(endDateIndex)
                            });
                        }
                    }

                    // Trimmar listobjektet efter antalet element
                    actions.TrimExcess();

                    return actions;
                }
                catch (Exception)
                {
                    throw new ApplicationException("Ett fel uppstod vid kontakt med databasen.");
                }
            }
        }

        // Skapar en åtgärd i databasen
        public static void InsertAction(Action actionCase)
        {
            // Skapar anslutningsobjekt
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar SQLCommand-objekt för att kunna exekvera den lagrade proceduren
                    var cmd = new SqlCommand("appSchema.InsertAction", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FelanmID", SqlDbType.Int, 4).Value = actionCase.FelanmID;
                    cmd.Parameters.Add("@AvdID", SqlDbType.Int, 4).Value = actionCase.AvdID;
                    cmd.Parameters.Add("@StartDatum", SqlDbType.DateTime, 8).Value = actionCase.StartDatum;
                    cmd.Parameters.Add("@SlutDatum", SqlDbType.DateTime, 8).Value = actionCase.SlutDatum;

                    conn.Open();

                    // Metod för exekvering av lagrad procedur som inte returnerar 
                    // några poster
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new ApplicationException("Ett fel uppstod vid uppdateringen.");
                }
            }
        }


        // Uppdaterar en åtgärd i databasen
        public static void UpdateAction(Action action)
        {
            // Skapar anslutningsobjekt
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar SQLCommand-objekt för att kunna exekvera den lagrade proceduren
                    var cmd = new SqlCommand("appSchema.UpdateAction", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FelanmID", SqlDbType.Int, 4).Value = action.FelanmID;
                    cmd.Parameters.Add("@ÅtgID", SqlDbType.Int, 4).Value = action.ÅtgID;
                    cmd.Parameters.Add("@AvdID", SqlDbType.Int, 4).Value = action.AvdID;
                    cmd.Parameters.Add("@StartDatum", SqlDbType.DateTime, 8).Value = action.StartDatum;
                    cmd.Parameters.Add("@SlutDatum", SqlDbType.DateTime, 8).Value = action.SlutDatum;

                    conn.Open();

                    // Metod för exekvering av lagrad procedur som inte returnerar 
                    // några poster
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new ApplicationException("Ett fel uppstod vid uppdateringen.");
                }
            }
        }

        // Tar bort en åtgärd i databasen
        public static void DeleteAction(int ÅtgId)
        {
            // Skapar anslutningsobjekt
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar SQLCommand-objekt för att kunna exekvera den lagrade proceduren
                    var cmd = new SqlCommand("appSchema.DeleteAction", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ÅtgID", SqlDbType.Int, 4).Value = ÅtgId;

                    conn.Open();

                    // Metod för exekvering av lagrad procedur som inte returnerar 
                    // några poster
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