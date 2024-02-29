using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Packgroup.Ecommerce.Aplication.DTO;
using Packgroup.Ecommerce.Aplication.Interface;
using Packgroup.Ecommerce.Domain.Interface;
using Packgroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;

namespace Packgroup.Ecommerce.Aplication.Main
{
    public class CategoriesApplication : ICategoriesApplication
    {
        private readonly ICategoriesDomain _categoriesDomain;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;

        public CategoriesApplication(ICategoriesDomain categoriesDomain, IMapper mapper, IDistributedCache cache)
        {
            _categoriesDomain = categoriesDomain;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Response<IEnumerable<CategoriesDto>>> GetAll()
        {
            var response = new Response<IEnumerable<CategoriesDto>>();
            var cacheKey = "categoriesList";

            try
            {
                var redisCategories = await _cache.GetAsync(cacheKey);
                if (redisCategories != null)
                {
                    response.Data = JsonSerializer.Deserialize<IEnumerable<CategoriesDto>>(redisCategories);
                } else
                {
                    var categories = await _categoriesDomain.GetAll();
                    response.Data = _mapper.Map<IEnumerable<CategoriesDto>>(categories);
                    if (response.Data != null)
                    {
                        var serializedCategories = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(response.Data));
                        var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddHours(8))
                            .SetSlidingExpiration(TimeSpan.FromMinutes(60));

                        await _cache.SetAsync(cacheKey, serializedCategories, options);
                    }
                }

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!";
                }

            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
