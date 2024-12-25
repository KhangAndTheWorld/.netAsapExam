using AutoMapper;
using FinalTestDotNet.Models;

namespace Thi.MappingProfile
{
    public class ReportTableMapping : Profile
    {
        public ReportTableMapping()
        {
            CreateMap<RentalDetails, ReportTableMapping>();
        }
    }
}