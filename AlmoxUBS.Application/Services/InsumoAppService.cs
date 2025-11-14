#region Comentários de Atualização
/*DATA: 13/11/2025
 MANUTENÇÃO: Criação de exceção personalizada para o domínio.*/
#endregion

using AlmoxUBS.Application.DTOs;
using AlmoxUBS.Application.Interfaces;
using AlmoxUBS.Domain.Entities;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;

namespace AlmoxUBS.Application.Services;

/// <summary>
/// Classe de serviço para operações relacionadas a Insumo.
/// </summary>
public sealed class InsumoAppService
{
    private readonly IInsumoRepository _repo;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _cache;

    public InsumoAppService(IInsumoRepository repo, IMapper mapper, IMemoryCache cache)
    {
        _repo = repo;
        _mapper = mapper;
        _cache = cache;
    }

    /// <summary>
    /// Serviço que Lista os insumos
    /// </summary>
    /// <param name="ct">Parâmetro de CancellationToken</param>
    /// <returns>Lista de insumos disponíveis</returns>
    public async Task<IEnumerable<InsumoDto>> ListarAsync(CancellationToken ct = default)
    {
        if (_cache.TryGetValue("insumos_cache", out IEnumerable<InsumoDto>? cacheInsumos))
            return cacheInsumos!;

        var insumos = await _repo.ListarAsync(ct);
        var dto = _mapper.Map<IEnumerable<InsumoDto>>(insumos);

        _cache.Set("insumos_cache", dto, TimeSpan.FromSeconds(30));

        return dto;
    }

    /// <summary>
    /// Cria um novo insumo
    /// </summary>
    /// <param name="request">Dados de request para serviço de cadastro</param>
    /// <param name="ct">Parâmetro de CancellationToken</param>
    /// <returns>Id único do insumo cadastrado</returns>
    public async Task<long> CriarAsync(CriarInsumoRequest request, CancellationToken ct = default)
    {
        var insumo = Insumo.Criar(request.nome, request.nomeTecnico, request.codigo, request.quantidadeInicial);

        await _repo.AdicionarAsync(insumo, ct);

        // Atualizar cache explicitamente ao invés de invalidar
        var insumos = await _repo.ListarAsync(ct);
        var dto = _mapper.Map<IEnumerable<InsumoDto>>(insumos);
        _cache.Set("insumos_cache", dto, TimeSpan.FromSeconds(30));

        return insumo.Id;
    }
}
