using Application;
using Application.Interfaces;
using Application.Models.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Rest.Controllers;

public class UserController(ISecurityService securityService, IUserService userService) : ControllerBase
{
    public const string ControllerRoute = "api/" + nameof(UserController) + "/";
    public const string UpdateRoute = ControllerRoute + nameof(UpdateUserEmail);
    public const string DeleteRoute = ControllerRoute + nameof(DeleteUser);
    
    [HttpPut]
    [Route(UpdateRoute)]
    public ActionResult<UpdateUserResponseDto> UpdateUserEmail([FromBody] UpdateUserDto request)
    {

        if (request.UserId.Length == 0)
        {
            return BadRequest(ErrorMessages.GetMessage(ErrorCode.ErrorUserId));
        }

        try
        {
            var jwtClaims = securityService.VerifyJwtOrThrow(request.Jwt);
            if (jwtClaims == null)
            {
                return NotFound("User not found");
            }

            if (request.Email.Length == 0)
            {
                return BadRequest("Email is required");
            }

            var result = userService.UpdateUser(request);
            return Ok(result);

        }
        catch (ApplicationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpDelete]
    [Route(DeleteRoute)]
    public ActionResult DeleteUser([FromBody] string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            return BadRequest("UserId is required");
        }

        try
        {
            userService.DeleteUser(userId);
            return Ok(new { Message = "User deleted successfully" });
        }
        catch (ApplicationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}