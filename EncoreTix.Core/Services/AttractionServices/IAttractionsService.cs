using EncoreTix.Core.Model.AttractionServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncoreTix.Core.Services.AttractionService
{
    public interface IAttractionsService
    {
        Task<AttractionListResponse> GetAttractionListAsync(string keyword);
        Task<AttractionDetailResponse> GetAttractionDetailAsync(string attractionId);
    }
}
