#region Comentários de Atualização
/*DATA: 13/11/2025
 MANUTENÇÃO: Criação de exceção personalizada para o domínio.*/
#endregion

namespace AlmoxUBS.Domain.Entities;

/// <summary>
/// Classe que representa um movimento de estoque no sistema de almoxarifado.
/// </summary>
public sealed class MovimentoEstoque
{
    protected MovimentoEstoque() { }

    /// <summary>
    /// Id único do movimento de estoque.
    /// </summary>
    public long Id { get; private set; }
    /// <summary>
    /// Id do insumo relacionado ao movimento de estoque.
    /// </summary>
    public long InsumoId { get; private set; }
    /// <summary>
    /// Objeto do insumo relacionado ao movimento de estoque.
    /// </summary>
    public Insumo Insumo { get; private set; } = default!;
    /// <summary>
    /// Tipo do movimento de estoque (Entrada, Saída, Ajuste).
    /// </summary>
    public TipoMovimentoEstoque Tipo { get; private set; }
    /// <summary>
    /// Quantidade movimentada no estoque.
    /// </summary>
    public int Quantidade { get; private set; }
    /// <summary>
    /// Data e hora do movimento de estoque em UTC.
    /// </summary>
    public DateTime DataHora { get; private set; } = DateTime.UtcNow;
    /// <summary>
    /// Id do usuário que realizou o movimento de estoque (opcional).
    /// </summary>
    public Guid? UsuarioId { get; private set; }
    /// <summary>
    /// Usuario que realizou o movimento de estoque (opcional).
    /// </summary>
    public Usuario? Usuario { get; private set; }

    public MovimentoEstoque(Insumo insumo, TipoMovimentoEstoque tipo, int quantidade, Usuario? usuario = null)
    {
        Insumo = insumo;
        InsumoId = insumo.Id;
        Tipo = tipo;
        Quantidade = quantidade;
        Usuario = usuario;
    }
}

/// <summary>
/// Enum que representa os tipos de movimento de estoque | 1 - Entrada, 2 - Saída, 3 - Ajuste.
/// </summary>
public enum TipoMovimentoEstoque
{
    Entrada = 1,
    Saida = 2,
    Ajuste = 3
}