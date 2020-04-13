using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace Services
{
    public interface IPerfumeService
    {
        Task<PerfumeResponse> GetAllPerfumes();
        Task<PerfumeResponse> SearchPerfumeByCategory(string categoryName);
        Task<PerfumeResponse> SearchPerfumeByName(string name);
        Task<PerfumeResponse> GetPerfumeByGender(string gender);

       
    }
}
