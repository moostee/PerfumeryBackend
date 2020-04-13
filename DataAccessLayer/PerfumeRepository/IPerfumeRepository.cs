using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.PerfumeRepository
{
    public interface IPerfumeRepository
    {
        Task<List<PerfumeModel>> GetAllPerfumes();
        Task<List<PerfumeModel>> GetPerfumesByCategory(string category);
        Task<List<PerfumeModel>> GetPerfumesByGender(string gender);
        Task<List<PerfumeModel>> SearchPerfumes(string name);

    }
}
