using Microsoft.EntityFrameworkCore;
using PA.Data;
using PA.Data.Models;
using PA.Interfaces;
using PA.Interfaces.Enums;
using PA.Interfaces.Exceptions;

namespace PA.Services;

public class PublicationAuthorService : IPublicationAuthorService
{
    private readonly DataContext _db;

    public PublicationAuthorService(DataContext db)
    {
        _db = db;
    }

    public async Task SetPublicationAuthorAsync(long publicationId, long authorId)
    {
		
        if (await _db.Publications.AllAsync(x => x.Id != publicationId))
            throw new PublicationAppException($"Publication id = {publicationId} is not exists!", EnumErrorCode.EntityIsNotFound);

		
        if (await _db.Authors.AllAsync(x => x.Id != authorId))
            throw new PublicationAppException($"Authors id = {authorId} is not exists!", EnumErrorCode.EntityIsNotFound);

        if (!await _db.PublicationAuthor.AnyAsync(x => x.AuthorId == authorId && x.PublicationId == publicationId))
        {
            await _db.PublicationAuthor.AddAsync(new PublicationAuthor
            {
                AuthorId = authorId, 
                PublicationId = publicationId
            });

            await _db.SaveChangesAsync();
        }
    }

    public async Task<IReadOnlyCollection<long>> GetPublicationAuthors(long publicationId)
    {
        return await _db.PublicationAuthor
            .Where(x => x.PublicationId == publicationId)
            .Select(x => x.AuthorId)
            .ToArrayAsync();
    }

    public async Task RemovePublicationAuthorAsync(long publicationId, long authorId)
    {
        if (await _db.Publications.AllAsync(x => x.Id != publicationId))
            throw new PublicationAppException($"Publication id = {publicationId} is not exists!", EnumErrorCode.EntityIsNotFound);

        if (await _db.Authors.AllAsync(x => x.Id != authorId))
            throw new PublicationAppException($"Authors id = {authorId} is not exists!", EnumErrorCode.EntityIsNotFound);

        var publicationAuthor = await _db.PublicationAuthor
            .FirstOrDefaultAsync(x => x.AuthorId == authorId && x.PublicationId == publicationId);
        if (publicationAuthor is not null)
        {
            _db.PublicationAuthor.Remove(publicationAuthor);
            await _db.SaveChangesAsync();
        }
    }
}