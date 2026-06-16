using AutoMapper;
using Core.DTOs;
using Core.Entities;

namespace GymManagementSystem.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AttendenceRecord, AttendenceRecordToReturnDTO>()
                .ForMember(a => a.MemberName, a => a.MapFrom(a => a.Member.FullName));
            ///////////////////////////////////////////////////////////////////////////////////
            CreateMap<Branch, BranchToReturnDTO>();
            ///////////////////////////////////////////////////////////////////////////////////
            CreateMap<FitnessClass, FitnessClassToReturnDTO>();
            ///////////////////////////////////////////////////////////////////////////////////
            CreateMap<MembershipPlan,MembershipPlanToReturnDTO>();
            ///////////////////////////////////////////////////////////////////////////////////
            CreateMap<MembershipSubscription, MembershipSubscriptionToReturnDTO>()
                .ForMember(m => m.MemberName, m => m.MapFrom(m => m.Member.FullName))
                .ForMember(m => m.PlanName, m => m.MapFrom(m => m.MembershipPlan.PlanName));
            ///////////////////////////////////////////////////////////////////////////////////
            CreateMap<Member, MemberToReturnDTO>()
                .ForMember(m => m.TrainerName, m => m.MapFrom(m => m.Trainer.FullName));
            ///////////////////////////////////////////////////////////////////////////////////
            CreateMap<Payment, PaymentToReturnDTO>();
            ///////////////////////////////////////////////////////////////////////////////////
            CreateMap<Review, ReviewToReturnDTO>()
                .ForMember(r => r.MemberName, r => r.MapFrom(r => r.Member.FullName))
                .ForMember(r => r.TrainerName, r => r.MapFrom(r => r.Trainer.FullName));
            ///////////////////////////////////////////////////////////////////////////////////
            CreateMap<Trainer, TrainerToReturnDTO>();
        }
    }
}
