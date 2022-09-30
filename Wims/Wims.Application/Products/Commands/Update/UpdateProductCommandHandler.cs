using ErrorOr;
using MapsterMapper;
using MediatR;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Application.Products.Common;
using Wims.Domain.Common.Errors;
using Wims.Domain.DTOs;
using Wims.Domain.Entities;

namespace Wims.Application.Products.Commands.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ErrorOr<ProductResult>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository; 
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<ProductResult>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_productRepository.GetProductById(command.Id) is not Product product)
            {
                return Errors.Product.NotFound;
            }

            if (_productRepository.GetProductByName(command.Name) is not null)
            {
                return Errors.Product.DuplicateProduct;
            }

            if (_categoryRepository.GetCategoryByName(command.CategoryName) is null)
            {
                return Errors.Category.NotFound;
            }

            var category = _categoryRepository.GetCategoryByName(command.CategoryName);
                
            product.Name = string.IsNullOrEmpty(command.Name) ? product.Name : command.Name;
            product.Description = string.IsNullOrEmpty(command.Description) ? product.Description : command.Description;
            product.SellingPrice = (product.SellingPrice == command.SellingPrice) ? product.SellingPrice : command.SellingPrice;
            product.CostPrice = (product.CostPrice == command.CostPrice) ? product.CostPrice : command.CostPrice;
            product.QtyInStock = (product.QtyInStock == command.QtyInStock) ? product.QtyInStock : command.QtyInStock;
            product.Category = (product.Category == category) ? product.Category : category;          

            try
            {
                var productDTO = _mapper.Map<ProductDTO>(product);
                _productRepository.Update(product);
                return new ProductResult(productDTO, "Updated");
            }
            catch (Exception)
            {
                return Errors.Product.Conflict;
            }
        }
    }
}
