#region Comentários de Atualização
/*DATA: 13/11/2025
 MANUTENÇÃO: Criação de exceção personalizada para o domínio.*/
#endregion

namespace AlmoxUBS.Domain.Entities;

/// <summary>
/// Classe que representa o acesso a uma rotina no sistema de almoxarifado.
/// </summary>
public sealed class AcessoRotina
{
    protected AcessoRotina() { }

    /// <summary>
    /// Id único do acesso à rotina.
    /// </summary>
    public long Id { get; private set; }
    /// <summary>
    /// Nome da rotina à qual o acesso é concedido.
    /// </summary>
    public string NomeRotina { get; private set; } = default!;

    /// <summary>
    /// Construtor que inicializa uma nova instância de AcessoRotina com o nome da rotina.
    /// </summary>
    /// <param name="nomeRotina">Nome da rotina</param>
    public AcessoRotina(string nomeRotina)
    {
        NomeRotina = nomeRotina;
    }
}
