using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PaymentApplicationAPI.Domain.Models;
using PaymentApplicationAPI.Infrastructure.DataAccessLayer;
using PaymentApplicationAPI.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApplicationAPI.Domain.Services
{
    public class MemberService : IMembershipService
    {
        //Dependency Injections
        private PaymentCollectionDBContext _dbContext;
        private ILogger<MemberService> _logger;
        private const int GenericHouse = 2;
        public MemberService(PaymentCollectionDBContext dbContext, ILogger<MemberService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        private async Task<int> GetGenericHouse()
        {

            var house = await _dbContext.Houses.FirstOrDefaultAsync(x => x.Type == GenericHouse);
            if (house == null)
            {
                var genericHouse = new House
                {
                    DoorNumber = "Generic",
                    Address = "Generic",
                    Postcode = "Generic",
                    City = "Generic",
                    Type = GenericHouse,
                };
                _dbContext.Houses.Add(genericHouse);
                await _dbContext.SaveChangesAsync();
                return genericHouse.Id;
            }
            return house.Id;
        }

        public async Task<MemberResultModel> CreateMember(MemberModel member)
        {
            var result = new MemberResultModel();

            _logger.LogInformation("start creating a new member");
            try
            {
                var houseId = 0;
                if (member.HouseType == GenericHouse)
                {
                    houseId = await GetGenericHouse();
                }
                else
                {
                    //check if the house exists
                    var houseResult = await _dbContext.Houses.Where(x => x.Id == member.HouseId).FirstOrDefaultAsync();

                    //if the house does not exists then create the house ( many members can belong to same house) 
                    if (houseResult == null)
                    {
                        _logger.LogInformation("No house exists for the current member");

                        var houseObject = new House
                        {
                            DoorNumber = member.Number,
                            Address = member.Address,
                            City = member.City,
                            Postcode = member.PostCode
                        };
                        _dbContext.Add(houseObject);
                        await _dbContext.SaveChangesAsync();

                        houseId = houseObject.Id;
                    } else
                    {
                        houseId = houseResult.Id;
                    }
                    

                }

                //assign a member to the house 
                _logger.LogInformation("Start to create a member after House exists");
                var memberObject = new Membership
                {
                    Address = member.Address,
                    HouseId = houseId,
                    PostCode = member.PostCode,
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    PhoneNumber = member.PhoneNumber,
                };
                _dbContext.Add(memberObject);
                await _dbContext.SaveChangesAsync();
                result.Success = true;
                result.Message = "Member has been added successfully";
                _logger.LogInformation(result.Message);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error {ex}", ex);
            }
            return result;
        }


        public async Task<bool> DeleteMember(MemberModel member)
        {
            var memberData =  await _dbContext.Memberships.Where(x => x.Id == member.Id).FirstOrDefaultAsync();
            if(memberData != null)
            {
                _dbContext.Remove(memberData);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<MemberModelResponse>> GetAllMembers()
        {
            var members = await _dbContext.Memberships.ToListAsync();
            var response = members != null ? members.Select(x => new MemberModelResponse
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
                PostCode = x.PostCode,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                HouseId = x.HouseId
            }).ToList() : null;

                return response;
        }

        public Task<MemberResultModel> GetMember(MemberModel member)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateMemberDetails(MemberModel member)
        {
            try
            {
                var person = await _dbContext.Memberships.FirstOrDefaultAsync(x => x.Id == member.Id);
                
                if(person == null)
                {
                    return false;
                }

                person.FirstName = member.FirstName;
                person.LastName = member.LastName;
                person.UpdateBy = member.PhoneNumber;
                person.UpdateAt = DateTime.UtcNow;
                person.CreatedBy = "System";
                person.HouseId = (int)member.HouseId;

                _dbContext.Update(person);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error caught for updating member details " + member.Id);
            }
            return false;

        }
        public async Task<bool> UpdateMemberHouseDetails(MemberModel member)
        {
            
            try
            {
                //this will bring the member and the house - eager loading 
                var person = await _dbContext.Memberships.Include(x=>x.House).FirstOrDefaultAsync(x => x.Id == member.Id);

                if (person == null)
                {
                    return false;
                }

                person.FirstName = member.FirstName;
                person.LastName = member.LastName;
                person.UpdateBy = member.PhoneNumber;
                person.UpdateAt = DateTime.UtcNow;
                person.CreatedBy = "System";
                person.HouseId = (int)member.HouseId;
                if(person.House == null)
                {
                    var house = new House
                    {
                        DoorNumber = member.Number,
                        Address = member.Address,
                        Postcode = member.PostCode,
                        City = member.City
                    };
                    person.House = house;

                }else
                {
                    person.House.DoorNumber = member.Number;
                    person.House.Address = member.Address;
                    person.House.Postcode = member.PostCode;
                    person.House.City = member.City;
                }

                _dbContext.Update(person);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error caught for updating house details " + member.Id);
            }
            return false;
        }

      
    }
}
