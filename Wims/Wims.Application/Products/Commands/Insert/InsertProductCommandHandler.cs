using ErrorOr;
using MapsterMapper;
using MediatR;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Application.Products.Common;
using Wims.Domain.Common.Errors;
using Wims.Domain.DTOs;
using Wims.Domain.Entities;

namespace Wims.Application.Products.Commands.Insert
{
    public class InsertProductCommandHandler : IRequestHandler<InsertProductCommand, ErrorOr<ProductResult>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public InsertProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<ProductResult>> Handle(InsertProductCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_productRepository.GetProductByName(command.Name) is not null)
            {
                return Errors.Product.DuplicateProduct;
            }

            if (_categoryRepository.GetCategoryByName(command.CategoryName) is null)
            {
                return Errors.Category.NotFound;
            }

            var category = _categoryRepository.GetCategoryByName(command.CategoryName);

            var product = new Product
            {
                Name = command.Name,
                Description = command.Description,
                SellingPrice = command.SellingPrice,
                CostPrice = command.CostPrice,
                QtyInStock = command.QtyInStock,
                MinThreshold = command.MinThreshold,
                Category = category
            };

            try
            {
                var productDTO = _mapper.Map<ProductDTO>(product);

                _productRepository.Add(product);
                return new ProductResult(productDTO, "Inserted");
            }
            catch (Exception)
            {

                return Errors.Product.Conflict;
            }
        }
    }
}
