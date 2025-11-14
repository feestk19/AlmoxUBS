#region Comentários de Atualização
/*DATA: 13/11/2025
 MANUTENÇÃO: Criação de exceção personalizada para o domínio.*/
#endregion

using AlmoxUBS.Domain.Exceptions;

namespace AlmoxUBS.Domain.Entities;

/// <summary>
/// Classe que representa um usuário no sistema de almoxarifado.
/// </summary>
public sealed class Usuario
{
    protected Usuario() { }

    /// <summary>
    /// Id único do usuário.
    /// </summary>
    public long Id { get; private set; }
    /// <summary>
    /// Nome do usuário.
    /// </summary>
    public string Nome { get; private set; } = default!;
    /// <summary>
    /// Login do usuário.
    /// </summary>
    public string Login { get; private set; } = default!;
    /// <summary>
    /// Senha hash do usuário.
    /// </summary>
    public string SenhaHash { get; private set; } = default!;
    /// <summary>
    /// Indica se o usuário está ativo no sistema.
    /// </summary>
    public bool Ativo { get; private set; } = true;

    private readonly List<AcessoRotina> _acessos = new();
    public IReadOnlyCollection<AcessoRotina> Acessos => _acessos;

    /// <summary>
    /// Método estático para criar uma nova instância de Usuario com validações.
    /// </summary>
    /// <param name="nome">Nome do usuário</param>
    /// <param name="login">Login do usuário</param>
    /// <param name="senhaHash">Senha Hash do usuário</param>
    /// <returns>Objeto do tipo Usuário contendo as informações do usuário do sistema</returns>
    /// <exception cref="DomainException">Disparado quando ocorrer algum erro na validação de usuário, seja por nome, login ou senha hash.</exception>
    public static Usuario Criar(string nome, string login, string senhaHash)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new DomainException("Nome é obrigatório.");

        if (string.IsNullOrWhiteSpace(login))
            throw new DomainException("Login é obrigatório.");

        if (string.IsNullOrWhiteSpace(senhaHash))
            throw new DomainException("Senha inválida.");

        return new Usuario
        {
            Nome = nome,
            Login = login.ToLower(),
            SenhaHash = senhaHash
        };
    }

    /// <summary>
    /// Método que atribui acesso a uma rotina para o usuário.
    /// </summary>
    /// <param name="rotina">Nome da rotina que será atribuída ao usuário</param>
    public void AtribuirAcesso(string rotina)
    {
        if (_acessos.Any(a => a.NomeRotina == rotina))
            return;

        _acessos.Add(new AcessoRotina(rotina));
    }

    /// <summary>
    /// Método que ativa o usuário no sistema.
    /// </summary>
    public void Ativar() => Ativo = true;

    /// <summary>
    /// Método que desativa o usuário no sistema.
    /// </summary>
    public void Desativar() => Ativo = false;
}
