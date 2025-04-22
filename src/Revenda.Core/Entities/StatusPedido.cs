namespace Revenda.Core.Entities;

public enum StatusPedido
{
    Pendente,
    Processando, // Status intermediário opcional
    Enviado,
    Falhou,
    ConcluidoComSucesso // Se houver confirmação da 
}