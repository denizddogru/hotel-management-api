using HotelManagement.Core.Repositories;
using HotelManagement.Core.Services;
using HotelManagement.Core.UnitOfWork;
using HotelManagement.Service.Mapper;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using System.Linq.Expressions;

namespace HotelManagement.Service.Services;
public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto> where TEntity : class where TDto : class
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<TEntity> _genericRepository;

    public GenericService(IUnitOfWork unitOfWork, IGenericRepository<TEntity> genericRepository)
    {
        _unitOfWork = unitOfWork;
        _genericRepository = genericRepository;
    }
    public async Task<Response<TDto>> AddAsync(TDto entity)
    {
        var newEntity = ObjectMapper.Mapper.Map<TEntity>(entity);
        await _genericRepository.AddAsync(newEntity);

        await _unitOfWork.CommitAsync();

        var newDto = ObjectMapper.Mapper.Map<TDto>(newEntity);

        return Response<TDto>.Success(newDto, 200);
    }

    public async Task<Response<IEnumerable<TDto>>> GetAllAsync()
    {
        var items = ObjectMapper.Mapper.Map<List<TDto>>(await _genericRepository.GetAllAsync());

        return Response<IEnumerable<TDto>>.Success(items, 200);
    }

    public async Task<Response<TDto>> GetByIdAsync(int id)
    {
        var item = await _genericRepository.GetByIdAsync(id);

        if(item == null)
        {
            return Response<TDto>.Fail("Id not found", 404, true);
        }

        return Response<TDto>.Success(ObjectMapper.Mapper.Map<TDto>(item), 200);
    }

    public async Task<Response<NoDataDto>> Remove(int id)
    {
        var isExist = await _genericRepository.GetByIdAsync(id);

        if (isExist == null)
        {
            return Response<NoDataDto>.Fail("Id not found.", 404, true);
        }

        _genericRepository.Remove(isExist); // Entity'nin state'i değişti
        await _unitOfWork.CommitAsync();

        return Response<NoDataDto>.Success(204);
    }

    public async Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate)
    {
        var list = _genericRepository.Where(predicate);

        return Response<IEnumerable<TDto>>.Success(ObjectMapper.Mapper.Map<IEnumerable<TDto>>(await list.ToListAsync()), 200);

    }

    public async Task<Response<NoDataDto>> Update(TDto entity, int id)
    {
        var isExistEntity = await _genericRepository.GetByIdAsync(id);

        if (isExistEntity == null)
        {
            return Response<NoDataDto>.Fail("Id not found", 404, true);
        }
        // Dto tipinde bir entity aldık ( TDto entity ) ve bunu Map işlemiyle Entity'ye dönüştürdük
        var updateEntity = ObjectMapper.Mapper.Map<TEntity>(entity);
        _genericRepository.Update(updateEntity);

        await _unitOfWork.CommitAsync();

        // 204 durum kodu => NoContent => Response bodysinde hiçbir dat kontrol olmayacak.
        return Response<NoDataDto>.Success(204);
    }

}
