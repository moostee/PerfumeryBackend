using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using System.Data.SqlClient;


namespace DataAccessLayer.PerfumeRepository
{
    public class PerfumeRepository: IPerfumeRepository
    {
       private readonly IConfiguration Config;
       // private static IDbConnection con = Config.GetConnectionString("PerfumeryDB");


        public PerfumeRepository(IConfiguration configuration)
        {
           
            Config = configuration;
        }


        public async Task<List<PerfumeModel>> GetAllPerfumes()
        {
            List<PerfumeModel> perfumeModel = new List<PerfumeModel>();
            try
            {

                using (IDbConnection con = new SqlConnection(Config.GetConnectionString("PerfumeryDB")))
                {
                    DynamicParameters parameter = new DynamicParameters();
                    string selectQuery = "SELECT * FROM [DB_A57633_perfumery].[dbo].[Perfumery_Perfumes]";
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    var result = await con.QueryAsync<PerfumeModel>(selectQuery);
                    foreach (var item in result.ToList())
                    {
                        perfumeModel.Add(new PerfumeModel()
                        {
                            name = item.name,
                            make = item.make,
                            description = item.description,
                            picture = item.picture,
                            gender= item.gender,
                            quantity= item.quantity,
                            subTotal= item.subTotal
                        });
        

                    }
                }
            }
            catch(Exception ex)
            {

            }


            return perfumeModel;
        }

        public async Task<List<PerfumeModel>> GetPerfumesByCategory(string category)
        {
            List<PerfumeModel> perfumeModel = new List<PerfumeModel>();
            try
            {

            }
            catch (Exception ex)
            {

            }


            return perfumeModel;
        }


        public async Task<List<PerfumeModel>> GetPerfumesByGender(string gender)
        {
            List<PerfumeModel> perfumeModel = new List<PerfumeModel>();
            try
            {

            }
            catch (Exception ex)
            {

            }


            return perfumeModel;
        }

        public async Task<List<PerfumeModel>> SearchPerfumes(string name)
        {
            List<PerfumeModel> perfumeModel = new List<PerfumeModel>();
            try
            {

            }
            catch (Exception ex)
            {

            }


            return perfumeModel;
        }
    }
}
