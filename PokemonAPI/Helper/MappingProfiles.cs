﻿using AutoMapper;
using PokemonAPI.DTO;
using PokemonAPI.Models;

namespace PokemonAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDTO>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}
