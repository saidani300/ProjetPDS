﻿using Microsoft.AspNetCore.Mvc;
using ProductMicroService.Models;
using ProductMicroService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProductMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productRepository.GetProducts();
        }
        [HttpPost]
        public void Post([FromBody] Product product)
        {

            _productRepository.InsertProduct(product);

        }
    }
}
