#region Comentários de Atualização
/*DATA: 13/11/2025
 MANUTENÇÃO: Criação de exceção personalizada para o domínio.*/
#endregion

namespace AlmoxUBS.Application.Exceptions;

/// <summary>
/// Classe de exceção personalizada para erros na camada de aplicação.
/// </summary>
public sealed class ApplicationException : Exception
{
    public ApplicationException(string mensagem) : base(mensagem) { }
}
