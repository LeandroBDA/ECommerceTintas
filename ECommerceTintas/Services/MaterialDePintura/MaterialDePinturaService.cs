using ECommerceTintas.Data;
using ECommerceTintas.Dto.MaterialDePintura;
using ECommerceTintas.Models;
using ECommerceTintas.Models.MaterialDePintura;
using ECommerceTintas.Models.Validators.MaterialDePinturaValidation;
using Microsoft.EntityFrameworkCore;

namespace ECommerceTintas.Services.MaterialDePintura
{
    public class MaterialDePinturaService : IMaterialDePinturaInterface
    {
        private readonly AppDbContext _context;

        public MaterialDePinturaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<MaterialDePinturaDto>>> ObterListaDeMateriais()
        {
            var resposta = new ResponseModel<List<MaterialDePinturaDto>>();
            try
            {
                var materiais = await _context.MaterialDePintura.ToListAsync();
                var materiaisDto = materiais.Select(material => new MaterialDePinturaDto
                {
                    Id = material.Id,
                    Nome = material.Nome,
                    Descricao = material.Descricao,
                    Preco = material.Preco,
                    QuantidadeEmEstoque = material.QuantidadeEmEstoque,
                    Fabricante = material.Fabricante,
                    Tamanho = material.Tamanho,
                    Material = material.Material,
                    IndicacaoUso = material.IndicacaoUso,
                    Compatibilidade = material.Compatibilidade,
                    QuantidadePorPacote = material.QuantidadePorPacote
                }).ToList();

                resposta.Dados = materiaisDto;
                resposta.Mensagem = "Todos os materiais foram listados";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<MaterialDePinturaModel>> BuscarMaterialPorId(int idMaterial)
        {
            var resposta = new ResponseModel<MaterialDePinturaModel>();
            try
            {
                var material = await _context.MaterialDePintura.FindAsync(idMaterial);
                if (material == null)
                {
                    resposta.Mensagem = "Material não encontrado";
                    resposta.status = false;
                    return resposta;
                }

                resposta.Dados = material;
                resposta.Mensagem = "Material encontrado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<MaterialDePinturaModel>> CadastrarMaterial(CadastrarMaterialDePinturaDto materialDto)
        {
            var resposta = new ResponseModel<MaterialDePinturaModel>();
            try
            {
                var novoMaterial = new MaterialDePinturaModel
                {
                    Nome = materialDto.Nome,
                    Descricao = materialDto.Descricao,
                    Preco = materialDto.Preco,
                    QuantidadeEmEstoque = materialDto.QuantidadeEmEstoque,
                    Fabricante = materialDto.Fabricante,
                    Tamanho = materialDto.Tamanho,
                    Material = materialDto.Material,
                    IndicacaoUso = materialDto.IndicacaoUso,
                    Compatibilidade = materialDto.Compatibilidade,
                    QuantidadePorPacote = materialDto.QuantidadePorPacote
                };

                var validator = new MaterialDePinturaValidation();
                var validationResult = validator.Validate(novoMaterial);

                if (!validationResult.IsValid)
                {
                    resposta.Mensagem = "Erro de validação";
                    resposta.status = false;
                    resposta.Erros = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    return resposta;
                }

                await _context.MaterialDePintura.AddAsync(novoMaterial);
                await _context.SaveChangesAsync();

                resposta.Dados = novoMaterial;
                resposta.Mensagem = "Material cadastrado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<MaterialDePinturaModel>> ExcluirMaterial(int idMaterial)
        {
            var resposta = new ResponseModel<MaterialDePinturaModel>();
            try
            {
                var material = await _context.MaterialDePintura.FindAsync(idMaterial);
                if (material == null)
                {
                    resposta.Mensagem = "Material não encontrado para exclusão";
                    resposta.status = false;
                    return resposta;
                }

                _context.MaterialDePintura.Remove(material);
                await _context.SaveChangesAsync();

                resposta.Dados = material;
                resposta.Mensagem = "Material excluído com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<MaterialDePinturaModel>> AtualizarMaterial(AtualizarMaterialDePinturaDto atualizarMaterial, int idMaterial)
        {
            var resposta = new ResponseModel<MaterialDePinturaModel>();
            try
            {
                var materialExistente = await _context.MaterialDePintura.FindAsync(idMaterial);
                if (materialExistente == null)
                {
                    resposta.Mensagem = "Material não encontrado para atualização";
                    resposta.status = false;
                    return resposta;
                }

                materialExistente.Nome = atualizarMaterial.Nome ?? materialExistente.Nome;
                materialExistente.Descricao = atualizarMaterial.Descricao ?? materialExistente.Descricao;
                materialExistente.Preco = atualizarMaterial.Preco ?? materialExistente.Preco;
                materialExistente.QuantidadeEmEstoque = atualizarMaterial.QuantidadeEmEstoque ?? materialExistente.QuantidadeEmEstoque;
                materialExistente.Fabricante = atualizarMaterial.Fabricante ?? materialExistente.Fabricante;
                materialExistente.Tamanho = atualizarMaterial.Tamanho ?? materialExistente.Tamanho;
                materialExistente.Material = atualizarMaterial.Material ?? materialExistente.Material;
                materialExistente.IndicacaoUso = atualizarMaterial.IndicacaoUso ?? materialExistente.IndicacaoUso;
                materialExistente.Compatibilidade = atualizarMaterial.Compatibilidade ?? materialExistente.Compatibilidade;
                materialExistente.QuantidadePorPacote = atualizarMaterial.QuantidadePorPacote ?? materialExistente.QuantidadePorPacote;

                var validator = new MaterialDePinturaValidation();
                var validationResult = validator.Validate(materialExistente);

                if (!validationResult.IsValid)
                {
                    resposta.Mensagem = "Erro de validação";
                    resposta.status = false;
                    resposta.Erros = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    return resposta;
                }

                _context.MaterialDePintura.Update(materialExistente);
                await _context.SaveChangesAsync();

                resposta.Dados = materialExistente;
                resposta.Mensagem = "Material atualizado com sucesso";
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
