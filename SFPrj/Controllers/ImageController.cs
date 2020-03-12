using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using System.Collections.Generic;
using Entities.DataTransferObjects;
using System;
using Entities.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SFPrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ImageController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}