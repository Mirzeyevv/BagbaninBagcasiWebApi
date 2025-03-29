using AutoMapper;
using BusinessLayer.DTOs.ProductDTOs;
using BusinessLayer.ExternalServices.Abstractions;
using BusinessLayer.Services.Abstractions;
using DAL.SqlServer.Repositories.Abstractions;
using Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;
    private readonly IMapper _mapper;
    private readonly IFileUploadService _fileUploadService;
    IWebHostEnvironment _webHostEnvironment;


    public ProductService(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IMapper mapper, IFileUploadService fileUploadService, IWebHostEnvironment webHostEnvironment)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
        _mapper = mapper;
        _fileUploadService = fileUploadService;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task CreateProductAsync(ProductPostDTO productPostDTO)
    {
        Product product = _mapper.Map<Product>(productPostDTO);
        product.CreatedAt = DateTime.UtcNow.AddHours(4);
        product.ImageUrl = await _fileUploadService.SaveFileAsync(productPostDTO.ImageUrl,_webHostEnvironment.WebRootPath, new[] {".jpg",".jpeg",".png",".webp",".gif"});
        await _productWriteRepository.CreateAsync(product);
        var result = await _productWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Product not created");
        }
    }

    public async Task DeleteProductAsync(Guid id)
    {
        if (!await _productReadRepository.IsExist(id)) throw new Exception("Product not found");
        Product product = await _productReadRepository.GetByIdAsync(id) ?? throw new Exception("Product not found");
        _productWriteRepository.Delete(product);

        var result = await _productWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Product not created");
        }

        _fileUploadService.DeleteFile(product.ImageUrl, _webHostEnvironment.WebRootPath);
    }

    public async Task<ICollection<ProductGetDTO>> GetAllActiveProductAsync()
    {
        ICollection<Product> products = await _productReadRepository.GetAllByCondition(c => !c.IsDeleted).ToListAsync();
        return _mapper.Map<ICollection<ProductGetDTO>>(products);
    }

    public async Task<ICollection<ProductGetDTO>> GetAllSoftDeletedProduct()
    {
        ICollection<Product> products = await _productReadRepository.GetAllByCondition(c => c.IsDeleted).ToListAsync();
        return _mapper.Map<ICollection<ProductGetDTO>>(products);
    }

    public async Task<ProductGetDTO> GetByIdProductAsync(Guid id)
    {
        if (!await _productReadRepository.IsExist(id)) throw new Exception("Product not found");
        Product product = await _productReadRepository.GetByIdAsync(id) ?? throw new Exception("Product not found");
        return _mapper.Map<ProductGetDTO>(product);
    }

    public async Task RestoreProductAsync(Guid id)
    {
        if (!await _productReadRepository.IsExist(id)) throw new Exception("Product not found");
        Product product = await _productReadRepository.GetOneByCondition(c => c.Id == id && c.IsDeleted, false) ?? throw new Exception("Product not found");
        product.IsDeleted = false;
        product.DeletedAt = null;
        _productWriteRepository.Update(product);

        var result = await _productWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Product not created");
        }
    }

    public async Task SoftDeleteProductAsync(Guid id)
    {
        if (!await _productReadRepository.IsExist(id)) throw new Exception("Product not found");
        Product product = await _productReadRepository.GetOneByCondition(c => c.Id == id && !c.IsDeleted, false) ?? throw new Exception("Product not found");
        product.IsDeleted = true;
        product.DeletedAt = DateTime.UtcNow.AddHours(4);
        _productWriteRepository.Update(product);

        var result = await _productWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Product not created");
        }
    }

    public async Task UpdateProductAsync(ProductPutDTO productPutDTO)
    {
        Product product = _mapper.Map<Product>(productPutDTO);
        product.LastModifiedAt = DateTime.UtcNow.AddHours(4);
        _productWriteRepository.Update(product);

        var result = await _productWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Product not created");
        }
    }
}
