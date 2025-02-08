using ECommerceTintas.Data;
using ECommerceTintas.Dto.Tinta;
using ECommerceTintas.Models;
using ECommerceTintas.Models.Tinta;
using ECommerceTintas.Models.Validators.Tintas;
using Microsoft.EntityFrameworkCore;

namespace ECommerceTintas.Services.Tinta
{
    public class TintaService : ITintaInterface
    {
        private readonly AppDbContext _context;

        public TintaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<TintaDto>>> ObterListaDeTintas()
        {
            var resposta = new ResponseModel<List<TintaDto>>();
            try
            {
                var tintas = await _context.Tintas.ToListAsync();
                var tintasDto = tintas.Select(tinta => new TintaDto
                {
                    Id = tinta.Id,
                    Nome = tinta.Nome,
                    Descricao = tinta.Descricao,
                    Preco = tinta.Preco,
                    QuantidadeEmEstoque = tinta.QuantidadeEmEstoque,
                    Fabricante = tinta.Fabricante,
                    TipoDeTinta = tinta.TipoDeTinta,
                    Cor = tinta.Cor,
                    Base = tinta.Base,
                    UsoExterno = tinta.UsoExterno,
                    RendimentoPorLitro = tinta.RendimentoPorLitro
                }).ToList();

                resposta.Dados = tintasDto;
                resposta.Mensagem = "Lista de tintas obtida com sucesso.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<TintaModel>> BuscarTintaPorId(int idTinta)
        {
            var resposta = new ResponseModel<TintaModel>();
            try
            {
                var tinta = await _context.Tintas.FindAsync(idTinta);
                if (tinta == null)
                {
                    resposta.Mensagem = "Tinta não encontrada.";
                    resposta.status = false;
                    return resposta;
                }

                resposta.Dados = new TintaModel
                {
                    Id = tinta.Id,
                    Nome = tinta.Nome,
                    Descricao = tinta.Descricao,
                    Preco = tinta.Preco,
                    QuantidadeEmEstoque = tinta.QuantidadeEmEstoque,
                    Fabricante = tinta.Fabricante,
                    TipoDeTinta = tinta.TipoDeTinta,
                    Cor = tinta.Cor,
                    Base = tinta.Base,
                    UsoExterno = tinta.UsoExterno,
                    RendimentoPorLitro = tinta.RendimentoPorLitro
                };
                resposta.Mensagem = "Tinta encontrada.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<TintaModel>> CadastrarTinta(CadastrarTintaDto tintaDto)
        {
            var resposta = new ResponseModel<TintaModel>();
            try
            {
                var novaTinta = new TintaModel
                {
                    Nome = tintaDto.Nome,
                    Descricao = tintaDto.Descricao,
                    Preco = tintaDto.Preco,
                    QuantidadeEmEstoque = tintaDto.QuantidadeEmEstoque,
                    Fabricante = tintaDto.Fabricante,
                    TipoDeTinta = tintaDto.TipoDeTinta,
                    Cor = tintaDto.Cor,
                    Base = tintaDto.Base,
                    UsoExterno = tintaDto.UsoExterno,
                    RendimentoPorLitro = tintaDto.RendimentoPorLitro
                };

                var validator = new TintaValidation();
                var validationResult = validator.Validate(novaTinta);

                if (!validationResult.IsValid)
                {
                    resposta.Mensagem = "Erro de validação.";
                    resposta.status = false;
                    resposta.Erros = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    return resposta;
                }

                await _context.Tintas.AddAsync(novaTinta);
                await _context.SaveChangesAsync();

                resposta.Dados = novaTinta;
                resposta.Mensagem = "Tinta cadastrada com sucesso.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<TintaModel>> ExcluirTinta(int idTinta)
        {
            var resposta = new ResponseModel<TintaModel>();
            try
            {
                var tinta = await _context.Tintas.FindAsync(idTinta);
                if (tinta == null)
                {
                    resposta.Mensagem = "Tinta não encontrada.";
                    resposta.status = false;
                    return resposta;
                }

                _context.Tintas.Remove(tinta);
                await _context.SaveChangesAsync();

                resposta.Dados = tinta;
                resposta.Mensagem = "Tinta excluída com sucesso.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<TintaModel>> AtualizarTinta(AtualizarTintaDto atualizarTinta, int idTinta)
        {
            var resposta = new ResponseModel<TintaModel>();
            try
            {
                var tintaExistente = await _context.Tintas.FindAsync(idTinta);
                if (tintaExistente == null)
                {
                    resposta.Mensagem = "Tinta não encontrada.";
                    resposta.status = false;
                    return resposta;
                }

                tintaExistente.Nome = atualizarTinta.Nome ?? tintaExistente.Nome;
                tintaExistente.Descricao = atualizarTinta.Descricao ?? tintaExistente.Descricao;
                tintaExistente.Preco = atualizarTinta.Preco ?? tintaExistente.Preco;
                tintaExistente.QuantidadeEmEstoque = atualizarTinta.QuantidadeEmEstoque ?? tintaExistente.QuantidadeEmEstoque;
                tintaExistente.Fabricante = atualizarTinta.Fabricante ?? tintaExistente.Fabricante;
                tintaExistente.TipoDeTinta = atualizarTinta.TipoDeTinta ?? tintaExistente.TipoDeTinta;
                tintaExistente.Cor = atualizarTinta.Cor ?? tintaExistente.Cor;
                tintaExistente.Base = atualizarTinta.Base ?? tintaExistente.Base;
                tintaExistente.UsoExterno = atualizarTinta.UsoExterno ?? tintaExistente.UsoExterno;
                tintaExistente.RendimentoPorLitro = atualizarTinta.RendimentoPorLitro ?? tintaExistente.RendimentoPorLitro;

                var validator = new TintaValidation();
                var validationResult = validator.Validate(tintaExistente);

                if (!validationResult.IsValid)
                {
                    resposta.Mensagem = "Erro de validação.";
                    resposta.status = false;
                    resposta.Erros = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    return resposta;
                }

                _context.Tintas.Update(tintaExistente);
                await _context.SaveChangesAsync();

                resposta.Dados = tintaExistente;
                resposta.Mensagem = "Tinta atualizada com sucesso.";
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
