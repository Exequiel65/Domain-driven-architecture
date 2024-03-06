using AutoMapper;
using Packgroup.Ecommerce.Aplication.DTO;
using Packgroup.Ecommerce.Aplication.Interface.Infraestructure;
using Packgroup.Ecommerce.Aplication.Interface.Persistence;
using Packgroup.Ecommerce.Aplication.Interface.UserCases;
using Packgroup.Ecommerce.Application.Validator;
using Packgroup.Ecommerce.Domain.Events;
using Packgroup.Ecommerce.Transversal.Common;
using System.Text.Json;

namespace Packgroup.Ecommerce.Aplication.UseCases.Discount
{
    public class DiscountApplication : IDiscountApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly DiscountDTOValidator _discountDTOValidator;
        private readonly IEventBus _eventBus;
        private readonly IAppLogger<DiscountApplication> _logger;
        private readonly INotification _notification;

        public DiscountApplication(IUnitOfWork unitOfWork, IMapper mapper, DiscountDTOValidator discountDTOValidator, IEventBus eventBus, IAppLogger<DiscountApplication> logger, INotification notification)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _discountDTOValidator = discountDTOValidator;
            _eventBus = eventBus;
            _logger = logger;
            _notification = notification;
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Response<bool>> Create(DiscountDto discountDto, CancellationToken cancellationToken = default)
        {
            var response = new Response<bool>();

            var validation = await _discountDTOValidator.ValidateAsync(discountDto, cancellationToken);
            if (!validation.IsValid)
            {
                response.Message = "Errores de validación";
                response.Errors = validation.Errors;
                return response;
            }

            var discount = _mapper.Map<Domain.Entities.Discount>(discountDto);
            await _unitOfWork.Discounts.InsertAsync(discount);
            response.Data = await _unitOfWork.Save(cancellationToken) > 0;

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Registro Exitoso!!";

                // Publicamos el evento
                var discountCreatedEvent = _mapper.Map<DiscountCreatedEvent>(discount);
                _eventBus.Publish<DiscountCreatedEvent>(discountCreatedEvent);
                await _notification.SendMailAsync(response.Message, JsonSerializer.Serialize(discount), cancellationToken);
            }



            return response;
        }

        public async Task<Response<bool>> Delete(int id, CancellationToken cancellationToken = default)
        {
            var response = new Response<bool>();

            await _unitOfWork.Discounts.DeleteAsync(id.ToString());
            response.Data = await _unitOfWork.Save(cancellationToken) > 0;
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Eliminación Exitosa!!";
            }


            return response;
        }

        public async Task<Response<DiscountDto>> Get(int id, CancellationToken cancellationToken = default)
        {
            var response = new Response<DiscountDto>();

            var discount = await _unitOfWork.Discounts.GetAsync(id, cancellationToken);
            if (discount is null)
            {
                response.IsSuccess = true;
                response.Message = "Descuento no existe....";
                return response;
            }

            response.Data = _mapper.Map<DiscountDto>(discount);
            response.IsSuccess = true;
            response.Message = "Consulta exitosa";


            return response;
        }

        public async Task<Response<List<DiscountDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var response = new Response<List<DiscountDto>>();

            var discount = await _unitOfWork.Discounts.GetAllAsync(cancellationToken);
            response.Data = _mapper.Map<List<DiscountDto>>(discount);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta exitosa";
                return response;
            }

            return response;
        }

        public async Task<ResponsePagination<IEnumerable<DiscountDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<DiscountDto>>();

            var count = await _unitOfWork.Discounts.CountAsync();
            var discounts = await _unitOfWork.Discounts.GetAllWithPaginationAsync(pageNumber, pageSize);
            response.Data = _mapper.Map<IEnumerable<DiscountDto>>(discounts);

            if (response.Data != null)
            {
                response.PageNumber = pageNumber;
                response.TotalPage = (int)Math.Ceiling(count / (double)pageSize);
                response.TotalCount = count;
                response.IsSuccess = true;
                response.Message = "Consulta Paginada Exitosa!!";

            }
            return response;
        }

        public async Task<Response<bool>> Update(DiscountDto discountDto, CancellationToken cancellationToken = default)
        {
            var response = new Response<bool>();

            var validation = await _discountDTOValidator.ValidateAsync(discountDto, cancellationToken);
            if (!validation.IsValid)
            {
                response.Message = "Errores de validación";
                response.Errors = validation.Errors;
                return response;
            }

            var discount = _mapper.Map<Domain.Entities.Discount>(discountDto);
            await _unitOfWork.Discounts.UpdateAsync(discount);
            response.Data = await _unitOfWork.Save(cancellationToken) > 0;

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Actualizacion Exitosa!!";
            }


            return response;
        }
    }
}
