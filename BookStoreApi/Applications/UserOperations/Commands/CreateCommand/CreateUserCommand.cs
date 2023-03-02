using AutoMapper;

public class CreateUserCommand
{
	public CreateUserViewModel Model { get; set; }
	private readonly IBookStoreDbContext _dbContext;
	private readonly IMapper _mapper;
	public CreateUserCommand(IBookStoreDbContext context, IMapper mapper)
	{
		_dbContext = context;
		_mapper = mapper;
	}
	
	public void Handle()
	{
		var user = _dbContext.Users.SingleOrDefault(u => u.Email == Model.Email);
		
		if (user is not null)
			throw new InvalidOperationException("Email is already used!");
			
		user = _mapper.Map<User>(Model);
		
		_dbContext.Users.Add(user);
		_dbContext.SaveChanges();
	}
}

public class CreateUserViewModel
{
	public string Name { get; set; }
	public string Surname { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
}