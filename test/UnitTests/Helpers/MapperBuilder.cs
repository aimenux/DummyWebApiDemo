using AutoMapper;

namespace UnitTests.Helpers;

public class MapperBuilder
{
    private readonly List<Profile> _profiles = [];

    public MapperBuilder WithProfile<T>() where T : Profile, new()
    {
        _profiles.Add(new T());
        return this;
    }

    public IMapper Build()
    {
        var mapperConfiguration = new MapperConfiguration(x => x.AddProfiles(_profiles));
        mapperConfiguration.AssertConfigurationIsValid();
        return mapperConfiguration.CreateMapper();
    }
}