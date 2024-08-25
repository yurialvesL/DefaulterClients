using AutoMapper;
using DefaulterClients.Application.DTOs.Request.User;
using DefaulterClients.Application.DTOs.Result.Auth;
using DefaulterClients.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DefaulterClients.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly ILogger<AuthController> _logger;
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;


    public AuthController(ITokenService tokenService,IUserService userService,
                          IConfiguration configuration, IMapper mapper)
    {
        _tokenService = tokenService;
        _userService = userService;
        _configuration = configuration;
        _mapper = mapper;
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    [AllowAnonymous]
    public async Task<ActionResult<LoggedUserResponse>> Login([FromBody] LoginModelRequestDTO userRequest)
    {
        var user = await _userService.CheckUser(userRequest) ?? throw new UnauthorizedAccessException("Invalid Email");

        var validPass = _userService.VerifyPassword(user.Password, userRequest.Password!);

        if (!validPass)
            return Unauthorized(new { message = "Password Incorrect" });


        

        return Ok(new LoggedUserResponse
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            Password = user.Password,
            AcessToken = _tokenService.GenerateAccessToken(user,_configuration)
        });

    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<LoggedUserResponse>> Register([FromBody] UserResquestDTO user)
    {

        var userMapped =  _mapper.Map<LoginModelRequestDTO>(user);

        var userResult = await _userService.CheckUser(userMapped);

        if (userResult is not null)
            return Conflict("User Already Exists!");

        var result = await _userService.CreateUser(user) ?? throw new BadHttpRequestException("An Error occured");
       


        return Ok(new LoggedUserResponse
        {
            Id = result.Id,
            Email = result.Email,
            Name = result.Name,
            Password = result.Password,
            AcessToken = _tokenService.GenerateAccessToken(result,_configuration)
        });


    }

    [HttpPut("UpdatePassword/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdatePassWord([FromBody] UpdatePasswordRequest updatePasswordDTO, Guid id)
    {
        var user = await _userService.GetUserById(id);

        if (user == null)
            return NotFound("User not found");

        var isUpdate = await _userService.UpdatePassword(id, updatePasswordDTO.oldPassword, updatePasswordDTO.NewPassword);

        if (isUpdate)
            return Ok(true);

        return BadRequest("Unable to change your password");
    }
}
