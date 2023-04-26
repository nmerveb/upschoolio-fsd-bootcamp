using AutoMapper;
using UpSchool.Domain.Dtos;
using UpSchool.Domain.Entities;

namespace UpSchool.WepApi.AutoMapper.Profiles
{
    public class AccountProfile:Profile
    {
        public AccountProfile()
        {
            //Map islemi sirasinda donusturulecek objede eksik olan kisimlar icin atama ayarlarini ForMember ile yapabiliriz.
            CreateMap<AccountEditDto, Account>()
                .ForMember(dest => dest.LastModifiedOn, opt => opt.MapFrom(x => DateTimeOffset.Now));

            CreateMap<Account, AccountDto>();
        }
    }
}
