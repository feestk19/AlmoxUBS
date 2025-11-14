#region Comentários de Atualização
/*DATA: 13/11/2025
 MANUTENÇÃO: Criação de exceção personalizada para o domínio.*/
#endregion

using AlmoxUBS.Domain.Exceptions;

namespace AlmoxUBS.Domain.Entities;

/// <summary>
/// Classe que representa um insumo no sistema de almoxarifado.
/// </summary>
public sealed class Insumo
{
    protected Insumo() { }

    /// <summary>
    /// Id único do insumo.
    /// </summary>
    public long Id { get; private set; }

    /// <summary>
    /// Nome do insumo.
    /// </summary>
    public string Nome { get; private set; } = default!;

    /// <summary>
    /// Nome técnico do insumo.
    /// </summary>
    public string NomeTecnico { get; private set; } = default!;

    /// <summary>
    /// Código do insumo.
    /// </summary>
    public string Codigo { get; private set; } = default!;

    /// <summary>
    /// Quantidade em estoque do insumo.
    /// </summary>
    public int QuantidadeEstoque { get; private set; }

    /// <summary>
    /// Método estático para criar uma nova instância de Insumo com validações.
    /// </summary>
    /// <param name="nome">Nome do insumo</param>
    /// <param name="nomeTecnico">Nome técnico do insumo</param>
    /// <param name="codigo">Código do insumo</param>
    /// <param name="quantidadeInicial">Quantidade inicial</param>
    /// <returns>Retorna um objeto do tipo Insumo com os dados do insumo.</returns>
    /// <exception cref="DomainException">Exceção que pode ser disparada ao cair numa validação de regra de negócio do domínio.</exception>
    public static Insumo Criar(string nome, string nomeTecnico, string codigo, int quantidadeInicial)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new DomainException("Nome do insumo é obrigatório.");

        if(quantidadeInicial < 0)
            throw new DomainException("Quantidade inicial não pode ser negativa.");

        return new Insumo
        {
            Nome = nome.Trim(),
            NomeTecnico = nomeTecnico?.Trim() ?? string.Empty,
            Codigo = codigo?.Trim() ?? string.Empty,
            QuantidadeEstoque = quantidadeInicial
        };
    }

    /// <summary>
    /// Método que ajusta a quantidade em estoque do insumo.
    /// </summary>
    /// <param name="qtde">Quantidade do valor em estoque. Caso o valor seja menor do que zero 0 o estoque será insuficiente.</param>
    /// <exception cref="DomainException">Disparado quando o estoque resultar em um número negativo.</exception>
    public void AjustarEstoque(int qtde)
    {
        if(QuantidadeEstoque + qtde < 0)
            throw new DomainException("Estoque insuficiente.");

        QuantidadeEstoque += qtde;
    }

}
