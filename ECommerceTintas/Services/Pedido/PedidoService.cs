using ECommerceTintas.Data;
using ECommerceTintas.Dto.Pedido;
using ECommerceTintas.Dto.ItemPedido;
using ECommerceTintas.Models;
using ECommerceTintas.Models.Enum;
using ECommerceTintas.Models.Pedidos;
using ECommerceTintas.Models.Validators;
using Microsoft.EntityFrameworkCore;

namespace ECommerceTintas.Services.Pedido
{
    public class PedidoService : IPedidoInterface
    {
        private readonly AppDbContext _context;

        public PedidoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<PedidoDto>>> ObterListaDePedidos()
        {
            var resposta = new ResponseModel<List<PedidoDto>>();
            try
            {
                var pedidos = await _context.Pedidos.Include(p => p.Itens).ToListAsync();
                var pedidoDtos = pedidos.Select(pedido => new PedidoDto
                {
                    Id = pedido.Id,
                    UsuarioId = pedido.UsuarioId,
                    DataPedido = pedido.DataPedido,
                    Status = pedido.Status.ToString(),
                    Total = pedido.Itens.Sum(i => i.PrecoUnitario * i.Quantidade),
                    Itens = pedido.Itens.Select(item => new ItemPedidoDto
                    {
                        ProdutoId = item.ProdutoId,
                        Quantidade = item.Quantidade,
                        PrecoUnitario = item.PrecoUnitario
                    }).ToList()
                }).ToList();

                resposta.Dados = pedidoDtos;
                resposta.Mensagem = "Todos os pedidos foram listados.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<PedidoModel>> CadastrarPedido(CadastrarPedidoDto novoPedido)
        {
            var resposta = new ResponseModel<PedidoModel>();
            try
            {
                var pedido = new PedidoModel
                {
                    UsuarioId = novoPedido.UsuarioId,
                    DataPedido = DateTime.Now,
                    Status = EStatusPedido.Pendente,
                    Itens = novoPedido.Itens.Select(item => new ItemPedidoModel
                    {
                        ProdutoId = item.ProdutoId,
                        Quantidade = item.Quantidade,
                        PrecoUnitario = item.PrecoUnitario
                    }).ToList()
                };

                var validator = new PedidoValidation();
                var validationResult = validator.Validate(pedido);

                if (!validationResult.IsValid)
                {
                    resposta.Mensagem = "Erro de validação";
                    resposta.status = false;
                    resposta.Erros = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    return resposta;
                }

                await _context.Pedidos.AddAsync(pedido);
                await _context.SaveChangesAsync();

                resposta.Dados = pedido;
                resposta.Mensagem = "Pedido cadastrado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<PedidoModel>> AtualizarPedido(AtualizarPedidoDto atualizarPedido, int idPedido)
{
    var resposta = new ResponseModel<PedidoModel>();
    try
    {
        var pedido = await _context.Pedidos.FindAsync(idPedido);
        if (pedido == null)
        {
            resposta.Mensagem = "Pedido não encontrado";
            resposta.status = false;
            return resposta;
        }

        // Usando Enum.TryParse para garantir uma conversão segura
        if (Enum.TryParse(atualizarPedido.Status, out EStatusPedido status))
        {
            pedido.Status = status;
        }
        else
        {
            resposta.Mensagem = "Status inválido";
            resposta.status = false;
            return resposta;
        }

        _context.Pedidos.Update(pedido);
        await _context.SaveChangesAsync();

        resposta.Dados = pedido;
        resposta.Mensagem = "Pedido atualizado com sucesso";
        return resposta;
    }
    catch (Exception ex)
    {
        resposta.Mensagem = ex.Message;
        resposta.status = false;
        return resposta;
    }
}
        public async Task<ResponseModel<PedidoModel>> ExcluirPedido(int idPedido)
        {
            var resposta = new ResponseModel<PedidoModel>();
            try
            {
                var pedido = await _context.Pedidos.FindAsync(idPedido);
                if (pedido == null)
                {
                    resposta.Mensagem = "Pedido não encontrado";
                    resposta.status = false;
                    return resposta;
                }

                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();

                resposta.Mensagem = "Pedido excluído com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<PedidoModel>> BuscarPedidoPorId(int idPedido)
        {
            var resposta = new ResponseModel<PedidoModel>();
            try
            {
                var pedido = await _context.Pedidos.Include(p => p.Itens).FirstOrDefaultAsync(p => p.Id == idPedido);
                if (pedido == null)
                {
                    resposta.Mensagem = "Pedido não encontrado";
                    resposta.status = false;
                    return resposta;
                }

                resposta.Dados = pedido;
                resposta.Mensagem = "Pedido encontrado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }
    }
}
