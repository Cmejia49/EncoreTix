using EncoreTix.Core.Model.AttractionDetailsManagemen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncoreTix.Core.Management
{
    public interface IAttractionDetailManagement
    {
        Task<AttractionDetailManagementResponse> GetAttractionDetails(string attractionId);
    }
}
