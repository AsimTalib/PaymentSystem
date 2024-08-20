
using PaymentApplicationAPI.Domain.Models;
using PaymentApplicationAPI.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApplicationAPI.Domain.Services
{
    public interface IMembershipService
    {
        Task<MemberResultModel> CreateMember(MemberModel member);
        Task<bool> UpdateMemberDetails(MemberModel member);
        Task<bool> UpdateMemberHouseDetails(MemberModel member);
        Task<bool> DeleteMember(MemberModel member);
        Task<MemberResultModel> GetMember(MemberModel member);
        Task<List<MemberModelResponse>> GetAllMembers();
        
    }
}
