using BankApplicationIIS.Services.Interfaces;
using BankApplicationIIS.Services.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace BankApplicationIIS.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        #region Deposit
        [HttpPost("deposit")]
        public async Task<IActionResult> DepositAsync([FromBody] TransactionRequestModel request)
        {
            if (request.Amount <= 0)
            {
                return BadRequest("Please enter an amount greater than 0");
            }

            else if (!ModelState.IsValid)
            {
                return BadRequest("Invalid deposit request model");
            }

            try
            {
                var response = await _accountService.DepositAsync(request);

                if (response == null) return BadRequest("Deposit failed: No acconut found.");

                if (!response.Succeeded)
                {
                    return BadRequest("Server could not process your deposit.");
                }

                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }
        #endregion

        #region Withdrawal
        [HttpPost("withdrawal")]
        public async Task<IActionResult> WithdrawalAsync([FromBody] TransactionRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid withdrawal request model");
            }

            try
            {
                var response = await _accountService.WithdrawalAsync(request);

                if (response == null) return BadRequest("Withdrawal failed: No acconut found.");

                if (!response.Succeeded)
                {
                    return BadRequest("Server could not process your withdrawal.");
                }

                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }
        #endregion

        #region Close Account
        [HttpPost("close-account")]
        public async Task<IActionResult> AccountCloseAsync([FromBody] AccountCloseRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid AccountCloseRequest model");
            }

            try
            {
                var response = await _accountService.AccountCloseAsync(request);

                if (response == null) return BadRequest("Account closure failed: No account found.");

                if (!response.Succeeded)
                {
                    return BadRequest("Server could not process your account closure.");
                }

                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }
        #endregion

        #region Open Account
        [HttpPost("open-account")]
        public async Task<IActionResult> AccountCreateAsync([FromBody] AccountCreateRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid AccountCreateRequest model");
            }

            try
            {
                var response = await _accountService.AccountCreateAsync(request);

                if (response == null) return BadRequest("Account creation failed.");

                if (!response.Succeeded)
                {
                    return BadRequest("Server could not process your account creation.");
                }

                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }
        #endregion
    }
}
