using Microsoft.AspNetCore.Mvc;
using PaymentApplicationAPI.API.Models;
using PaymentApplicationAPI.Domain.Models;
using PaymentApplicationAPI.Domain.Services;



//See who has paid membership ( which years unpaid)
//see who is a member 
//add members to household 
//update existing members to different addresses 


namespace PaymentApplicationAPI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembershipController : ControllerBase
    {
        private IMembershipService _membershipService;
        
        public MembershipController(IMembershipService membershipService)
        {
            _membershipService = membershipService;
            
        }

        [HttpPost]
        public async Task<IActionResult> PostMember([FromBody] MemberDetails member)
        {
            var MemberModel = new MemberModel
            {
                FirstName = member.FirstName,
                LastName = member.LastName,
                PhoneNumber = member.PhoneNumber,
                Number = member.Number,
                Address = member.Address,
                City = member.City,
                PostCode = member.PostCode,
                HouseId = member.HouseId,
                HouseType = member.HouseType
            };

            var memberSignUp = await _membershipService.CreateMember(MemberModel);
            return Ok(memberSignUp);
        }

        [HttpPut]
        public async Task<IActionResult> PostMemberDetailsUpdate([FromBody] MemberDetails member)
        {
            var MemberModel = new MemberModel
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                PhoneNumber = member.PhoneNumber,
                Number = member.Number,
                Address = member.Address,
                City = member.City,
                PostCode = member.PostCode,
                HouseId = member.HouseId,
                HouseType = member.HouseType
            };

            var memberUpdate = await _membershipService.UpdateMemberDetails(MemberModel);
            return Ok(memberUpdate);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            var members = await _membershipService.GetAllMembers();
            return Ok(members);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMember([FromBody] MemberModel member)
        {
            var memberData = await _membershipService.DeleteMember(member);
            return Ok(memberData);
        }
        [HttpPut("/House")]
        public async Task<IActionResult> UpdateHouseDetails([FromBody] MemberModel member)
        {
            var memberData = await _membershipService.UpdateMemberHouseDetails(member);
            return Ok(memberData);
        }
    }
}

