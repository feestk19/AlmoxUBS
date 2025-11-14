#region Comentários de Atualização
/*DATA: 13/11/2025
 MANUTENÇÃO: Criação de exceção personalizada para o domínio.*/
#endregion

namespace AlmoxUBS.Application.DTOs;

/// <summary>
/// Representa um Data Transfer Object (DTO) para Insumo.
/// </summary>
/// <param name="id">Id do insumo</param>
/// <param name="nome">Nome do insumo</param>
/// <param name="nomeTecnico">Nome técnico do insumo</param>
/// <param name="codigo">Código do insumo</param>
/// <param name="quantidadeEstoque">Quantidade em estoque</param>
public sealed record  InsumoDto(long id, string nome, string nomeTecnico, string codigo, int quantidadeEstoque);
/// <summary>
/// Representa um Data Transfer Object (DTO) para criar um novo Insumo.
/// </summary>
/// <param name="nome">Nome do insumo</param>
/// <param name="nomeTecnico">Nome Técnico do insumo</param>
/// <param name="codigo">Código do insumo</param>
/// <param name="quantidadeInicial">Quantidade inicial em estoque</param>
public sealed record CriarInsumoRequest(string nome, string nomeTecnico, string codigo, int quantidadeInicial);
