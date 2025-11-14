#region Comentários de Atualização
/*DATA: 13/11/2025
 MANUTENÇÃO: Criação de exceção personalizada para o domínio.*/
#endregion

namespace AlmoxUBS.Domain.Exceptions;

/// <summary>
/// Classe de exceção personalizada para erros de domínio.
/// </summary>
public sealed class DomainException : Exception
{
    public DomainException(string mensagem) : base(mensagem) { }
}
