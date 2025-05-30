using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace PaymentWorkflow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentTransactionService _transactionService;

        public PaymentController(IPaymentTransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        // Create new payment with "Pending" status
        [HttpPost]
        public IActionResult CreatePayment([FromBody] PaymentRequest paymentRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transaction = _transactionService.CreateTransaction(paymentRequest);
            return Ok(new
            {
                transaction.TransactionId,
                transaction.Status,
                transaction.Message
            });
        }

        // Manually approve transaction
        [HttpPost("approve/{transactionId}")]
        public IActionResult ApprovePayment(Guid transactionId)
        {
            try
            {
                var transaction = _transactionService.ApproveTransaction(transactionId);
                return Ok(new
                {
                    transaction.TransactionId,
                    transaction.Status,
                    transaction.Message
                });
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // Manually decline transaction
        [HttpPost("decline/{transactionId}")]
        public IActionResult DeclinePayment(Guid transactionId)
        {
            try
            {
                var transaction = _transactionService.DeclineTransaction(transactionId);
                return Ok(new
                {
                    transaction.TransactionId,
                    transaction.Status,
                    transaction.Message
                });
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // GET transaction by Id
        [HttpGet("{transactionId}")]
        public IActionResult GetPayment(Guid transactionId)
        {
            try
            {
                var transaction = _transactionService.GetTransaction(transactionId);
                return Ok(new
                {
                    transaction.TransactionId,
                    transaction.Status,
                    transaction.Message,
                    PaymentDetails = transaction.PaymentRequest
                });
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}
