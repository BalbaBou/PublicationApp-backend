using Microsoft.EntityFrameworkCore;
using PA.Data;
using PA.Data.Models;
using PA.Interfaces;
using PA.Interfaces.Enums;
using PA.Interfaces.Exceptions;
using PA.Interfaces.Models.Author;
using PA.Interfaces.Pagination;
using PA.Services.Mail;

namespace PA.Services;

public class AuthorService : IAuthorService
{
    private readonly DataContext _db;

    public AuthorService(DataContext db)
    {
        _db = db;
    }
    public async Task<AuthorShortModel> Add(AuthorAddModel model)
	{
		var isTeacher = model.IsTeacher;

		var author = new Author
		{
			Contacts = model.Contacts,
			SureName = model.SureName,
			FirstName = model.FirstName,
			IsTeacher = model.IsTeacher,
			LastName = model.LastName,
			AcademicDegree = isTeacher ? model.DegreeId : null,
			EmployerPosition = isTeacher ? model.PositionId : null,
			NonStuffPosition = !isTeacher ? model.NonStuffPosition : null,
			NonStuffWorkPlace = !isTeacher ? model.NonStuffWorkPlace : null
		};

		if (model.DepartmentId.HasValue && model.DepartmentId != 0 && await _db.Departments.AnyAsync(x => x.Id==model.DepartmentId))
			author.DepartmentId = isTeacher ? model.DepartmentId : null;

		if (!string.IsNullOrWhiteSpace(model.Email))
		{
			if (MailService.IsValidEmailAddress(model.Email))
				author.Email = model.Email;
			else
				throw new PublicationAppException($"Email address {model.Email} is not valid!", EnumErrorCode.EmailIsNotValid);
		}

		await _db.AddAsync(author);
		await _db.SaveChangesAsync();

		return new AuthorShortModel
		{
			SureName = author.SureName,
			FirstName = author.FirstName,
			Id = author.Id,
			SecondName = author.LastName
		};
	}

	public async Task<SearchAuthorResponse> SearchAuthor(AuthorGetModel model)
	{
		return await _db.Authors
			.Where(x =>
				x.SureName.Contains(model.Search)
				|| x.FirstName.Contains(model.Search)
				|| x.LastName.Contains(model.Search)
			).GetPageAsync<SearchAuthorResponse, Author, AuthorShortModel>(model, x => new AuthorShortModel
			{
				Id = x.Id,
				FirstName = x.FirstName,
				SecondName = x.LastName,
				SureName = x.SureName
			});
	}

	public async Task<GetAuthorResponse> GetAuthorsAsync(GetAuthorRequest request)
	{
		var query = _db.Authors.AsQueryable();

		if (request.AuthorId.HasValue)
			query = query.Where(x => x.Id == request.AuthorId);

		return await query.GetPageAsync<GetAuthorResponse, Author, AuthorModel>(request, x => new AuthorModel
		{
			Id = x.Id,
			SureName = x.SureName,
			FirstName = x.FirstName,
			SecondName = x.LastName,
			Email = x.Email,
			DepartmentId = x.DepartmentId,
			Contacts = x.Contacts,
			IsTeacher = x.IsTeacher,
			EmployerPosition = x.EmployerPosition,
			AcademicDegree = x.AcademicDegree,
			NonStuffPosition = x.NonStuffPosition,
			NonStuffWorkPlace = x.NonStuffWorkPlace
		});
	}

	public async Task Update(AuthorUpdateModel model)
	{
		var author = await _db.Authors.FirstOrDefaultAsync(x => x.Id == model.AuthorId);
		if (author is null)
			throw new PublicationAppException($"Author Id = {model.AuthorId} is not found!", EnumErrorCode.EntityIsNotFound);

		if (!string.IsNullOrWhiteSpace(model.FirstName))
			author.FirstName = model.FirstName;

		if (!string.IsNullOrWhiteSpace(model.LastName))
			author.LastName = model.LastName;

		if (!string.IsNullOrWhiteSpace(model.SureName))
			author.SureName = model.SureName;

		if (!string.IsNullOrWhiteSpace(model.Email))
			author.Email = model.Email;

		if (model.AcademicDegree.HasValue)
			author.AcademicDegree = model.AcademicDegree;

		if (model.EmployerPosition.HasValue)
			author.EmployerPosition = model.EmployerPosition;

		await _db.SaveChangesAsync();
	}

	public async Task Remove(long id)
	{
		if (await _db.Authors.AllAsync(x => x.Id != id))
			throw new PublicationAppException($"Author id = {id} is not exists!",EnumErrorCode.EntityIsNotFound);

		if (await _db.PublicationAuthor.AnyAsync(x => x.AuthorId == id))
			throw new PublicationAppException("Author with publications can't be deleted!", EnumErrorCode.EntityWithRelationsCantBeDeleted);

		_db.Authors.Remove(new Author { Id = id });
		await _db.SaveChangesAsync();
	}
}