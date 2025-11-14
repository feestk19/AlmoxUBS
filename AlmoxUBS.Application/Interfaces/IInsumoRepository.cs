#region Comentários de Atualização
/*DATA: 13/11/2025
 MANUTENÇÃO: Criação de exceção personalizada para o domínio.*/
#endregion

using AlmoxUBS.Domain.Entities;

namespace AlmoxUBS.Application.Interfaces;

/// <summary>
/// Representa o repositório de insumos no sistema de almoxarifado.
/// </summary>
public interface IInsumoRepository
{
    /// <summary>
    /// Task assíncrona para obter um insumo pelo seu ID.
    /// </summary>
    /// <param name="id">Id do insumo</param>
    /// <param name="ct">parâmetro de CancellationToken</param>
    /// <returns>Objeto Insumo</returns>
    Task<Insumo?> ObterPorIdAsync(long id, CancellationToken ct);
    /// <summary>
    /// Task assíncrona para listar todos os insumos.
    /// </summary>
    /// <param name="ct">Parâmetro de CancellationToken</param>
    /// <returns>Lista de Insumos disponíveis em estoque</returns>
    Task<IEnumerable<Insumo>> ListarAsync(CancellationToken ct);
    /// <summary>
    /// Task que adiciona um novo insumo ao repositório.
    /// </summary>
    /// <param name="insumo">Objeto insumo</param>
    /// <param name="ct">Parâmetro de CancellationToken</param>
    /// <returns>Dados do insumo adicionado</returns>
    Task AdicionarAsync(Insumo insumo, CancellationToken ct);
    /// <summary>
    /// Task que atualiza um insumo existente no repositório.
    /// </summary>
    /// <param name="insumo">Objeto insumo</param>
    /// <param name="ct">Parâmetro de CancellationToken</param>
    /// <returns>Dados do insumo atualizado</returns>
    Task AtualizarAsync(Insumo insumo, CancellationToken ct);
    /// <summary>
    ///  Task que remove um insumo do repositório.
    /// </summary>
    /// <param name="insumo">Objeto insumo</param>
    /// <param name="ct">Parâmetro de CancellationToken</param>
    /// <returns>Dados do insumo removido</returns>
    Task RemoverAsync(Insumo insumo, CancellationToken ct);
}
