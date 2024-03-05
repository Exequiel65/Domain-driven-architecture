using AutoMapper;
using Packgroup.Ecommerce.Aplication.DTO;
using Packgroup.Ecommerce.Aplication.Interface.Infraestructure;
using Packgroup.Ecommerce.Aplication.Interface.Persistence;
using Packgroup.Ecommerce.Aplication.Interface.UserCases;
using Packgroup.Ecommerce.Application.Validator;
using Packgroup.Ecommerce.Domain.Events;
using Packgroup.Ecommerce.Transversal.Common;

namespace Packgroup.Ecommerce.Aplication.UseCases.Discount
{
    public class DiscountApplication : IDiscountApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly DiscountDTOValidator _discountDTOValidator;
        private readonly IEventBus _eventBus;

        public DiscountApplication(IUnitOfWork unitOfWork, IMapper mapper, DiscountDTOValidator discountDTOValidator, IEventBus eventBus)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _discountDTOValidator = discountDTOValidator;
            _eventBus = eventBus;
        }

        public async Task<Response<bool>> Create(DiscountDto discountDto, CancellationToken cancellationToken = default)
        {
            var response = new Response<bool>();
            try
            {
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
                }

            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> Delete(int id, CancellationToken cancellationToken = default)
        {
            var response = new Response<bool>();
            try
            {
                await _unitOfWork.Discounts.DeleteAsync(id.ToString());
                response.Data = await _unitOfWork.Save(cancellationToken) > 0;
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<DiscountDto>> Get(int id, CancellationToken cancellationToken = default)
        {
            var response = new Response<DiscountDto>();
            try
            {
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

            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<List<DiscountDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var response = new Response<List<DiscountDto>>();
            try
            {
                var discount = await _unitOfWork.Discounts.GetAllAsync(cancellationToken);
                response.Data = _mapper.Map<List<DiscountDto>>(discount);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                    return response;
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> Update(DiscountDto discountDto, CancellationToken cancellationToken = default)
        {
            var response = new Response<bool>();
            try
            {
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

            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
