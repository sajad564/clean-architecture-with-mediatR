using System;
using System.Collections.Generic;
using AutoMapper;

namespace book.Application.common.AutoMapper
{
    public static class Mapping
{
    private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
    {
        var config = new MapperConfiguration(cfg => {
            // This line ensures that internal properties are also mapped over.
            cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddMyProfiles() ; 
        });
        var mapper = config.CreateMapper();
        return mapper;
    });

    public static IMapper Mapper => Lazy.Value;
}

public static class AllProfiles 
{
    public static IMapperConfigurationExpression  AddMyProfiles(this IMapperConfigurationExpression conf)
    {
        conf.AddProfile<BookProfile>() ; 
        conf.AddProfile<FileProfile>() ; 
        conf.AddProfile<CommentProfile>() ; 
        conf.AddProfile<UserProfile>() ; 
        conf.AddProfile<PhotoProfile>() ;
        conf.AddProfile<OrderProfile>() ; 
        return conf ; 
        // Additional mappings here...
    }
}
}