using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Models;
using DataAccessLayer;
using DataAccessLayer.PerfumeRepository;
using NLog;

namespace Services
{
    public class PerfumeService : IPerfumeService
    {
        // private static  readonly ILogger<PerfumeService> _logger;
        private static NLog.Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly IPerfumeRepository  _perfumeRepository;
        private readonly IUtilities _utilities;
       // readonly  string requestId;
       // readonly  string ipAddress;
        public PerfumeService( IPerfumeRepository perfumeRepository, IUtilities utilities )
        {
            
           // logger = _logger;
            perfumeRepository = _perfumeRepository;
            utilities = _utilities;
            

        }




        public async Task<PerfumeResponse> GetAllPerfumes()
        {
            string code = string.Empty;
            string message = string.Empty;
           // string requestId = string.Empty;
           string requestId = _utilities.RandomGuid();
           string ipAddress = _utilities.GetCustomerIP(requestId);
            PerfumeResponse perfumeResponse = new PerfumeResponse();

            try
            {
                _logger.Info($"_requestId=>{requestId}=> getting all perfumes for Client With IpAddress => {ipAddress}");
                perfumeResponse.code = "00";
                perfumeResponse.message = "Successful";
                perfumeResponse.requestId = requestId;
                perfumeResponse.PerfumeModel =   _perfumeRepository.GetAllPerfumes();
            }
            catch(Exception ex)
            {
                _logger.Error($"_requestId=>{requestId}=> getting all perfumes for Client With IpAddress => {ipAddress} failed with Exception=> {ex}");
                perfumeResponse.code = "99";
                perfumeResponse.message = "UnSuccessful";
                perfumeResponse.requestId = requestId;
                perfumeResponse.PerfumeModel = null;
            }
            return perfumeResponse;
        }

        public async Task<PerfumeResponse> GetPerfumeByGender(string gender)
        {
            string code = string.Empty;
            string message = string.Empty;
            string requestId = _utilities.RandomGuid();
            string ipAddress = _utilities.GetCustomerIP(requestId);
            PerfumeResponse perfumeResponse = new PerfumeResponse();

            try
            {
                _logger.Info($"_requestId=>{requestId}=> getting perfumes by gender for Client With IpAddress => {ipAddress}");
                perfumeResponse.code = "00";
                perfumeResponse.message = "Successful";
                perfumeResponse.requestId = requestId;
                perfumeResponse.PerfumeModel = _perfumeRepository.GetPerfumesByGender(gender);
            }
            catch (Exception ex)
            {
                _logger.Error($"_requestId=>{requestId}=> getting perfumes by gender for Client With IpAddress => {ipAddress} failed with Exception=> {ex}");
                perfumeResponse.code = "99";
                perfumeResponse.message = "UnSuccessful";
                perfumeResponse.requestId = requestId;
                perfumeResponse.PerfumeModel = null;
            }
            return perfumeResponse;
        }

        public async Task<PerfumeResponse> SearchPerfumeByCategory(string categoryName)
        {
            string code = string.Empty;
            string message = string.Empty;
            string requestId = _utilities.RandomGuid();
            string ipAddress = _utilities.GetCustomerIP(requestId);
            PerfumeResponse perfumeResponse = new PerfumeResponse();

            try
            {
                _logger.Info($"_requestId=>{requestId}=> getting all perfumes by category for Client With IpAddress => {ipAddress}");
                perfumeResponse.code = "00";
                perfumeResponse.message = "Successful";
                perfumeResponse.requestId = requestId;
                perfumeResponse.PerfumeModel = _perfumeRepository.GetPerfumesByCategory(categoryName);
            }
            catch (Exception ex)
            {
                _logger.Error($"_requestId=>{requestId}=> getting all perfumes by category for Client With IpAddress => {ipAddress} failed with Exception=> {ex}");
                perfumeResponse.code = "99";
                perfumeResponse.message = "UnSuccessful";
                perfumeResponse.requestId = requestId;
                perfumeResponse.PerfumeModel = null;
            }
            return perfumeResponse;
        }

        public async Task<PerfumeResponse> SearchPerfumeByName(string name)
        {
            string code = string.Empty;
            string message = string.Empty;
            string requestId = _utilities.RandomGuid();
            string ipAddress = _utilities.GetCustomerIP(requestId);
            PerfumeResponse perfumeResponse = new PerfumeResponse();

            try
            {
                _logger.Info($"_requestId=>{requestId}=> searching for perfumes for Client With IpAddress => {ipAddress}");
                perfumeResponse.code = "00";
                perfumeResponse.message = "Successful";
                perfumeResponse.requestId = requestId;
                perfumeResponse.PerfumeModel = _perfumeRepository.SearchPerfumes(name);
            }
            catch (Exception ex)
            {
                _logger.Error($"_requestId=>{requestId}=> search service  for Client With IpAddress => {ipAddress} failed with Exception=> {ex}");
                perfumeResponse.code = "99";
                perfumeResponse.message = "UnSuccessful";
                perfumeResponse.requestId = requestId;
                perfumeResponse.PerfumeModel = null;
            }
            return perfumeResponse;
        }
    }
}
