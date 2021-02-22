using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProcessPayment.Dtos;
using ProcessPayment.Models;
using ProcessPayment.Services.Interfaces;

namespace ProcessPayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentStateRepository _paymentStateRepository;
        private readonly IExpensivePaymentGateway _expensivePaymentGateway;
        private readonly ICheapPaymentGateway _cheapPaymentGateway;
        private readonly IMapper _mapper;

        public PaymentController(
            IPaymentRepository paymentRepository,
            IPaymentStateRepository paymentStateRepository,
            IExpensivePaymentGateway expensivePaymentGateway,
            ICheapPaymentGateway cheapPaymentGateway,
            IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _paymentStateRepository = paymentStateRepository;
            _expensivePaymentGateway = expensivePaymentGateway;
            _cheapPaymentGateway = cheapPaymentGateway;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddPayment(PaymentDto paymentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if ((paymentDto.ExpirationDate - DateTime.Today) <= TimeSpan.Zero)
                return BadRequest("Payment duration has expired");

            var payment = _mapper.Map<Payment>(paymentDto);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetPayments()
        {
            var payments = _paymentRepository.FindAll();

            return Ok();
        }
    }
}