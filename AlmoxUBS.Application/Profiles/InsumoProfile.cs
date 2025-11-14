#region Comentários de Atualização
/*DATA: 13/11/2025
 MANUTENÇÃO: Criação de exceção personalizada para o domínio.*/
#endregion

using AlmoxUBS.Application.DTOs;
using AlmoxUBS.Domain.Entities;
using AutoMapper;

namespace AlmoxUBS.Application.Profiles;

/// <summary>
/// Classe  de perfil para mapeamento de Insumo.
/// </summary>
public sealed class InsumoProfile : Profile
{
    public InsumoProfile()
    {
        // Mapear Insumo para InsumoDto
        CreateMap<Insumo, InsumoDto>();
    }
}
