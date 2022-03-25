using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Travel.Application.Common.Mappings
{
    /// <summary>
    /// The preceding code is an interface for applying mappings from the assembly. You will 
    /// notice that there is a Profile type that is being passed here from AutoMapper.
    /// Profile is a configuration that will do the mapping for you based on naming conventions.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
