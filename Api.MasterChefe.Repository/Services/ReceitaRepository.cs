using Api.MasterChefe.Domain.Entidades;
using Api.MasterChefe.Repository.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using SqlHelpers.Standard;
using System.Data;

namespace Api.MasterChefe.Repository.Services
{
    public class ReceitaRepository : IReceitaRepository
    {
        private readonly IConfiguration _configuration;

        public ReceitaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Receita> BuscarPorId(int id)
        {
            using var connection = await ConnectionFactory.ConexaoAsync(_configuration["Base"]);
            const string query = @"SELECT 
                                     	CodigoConvidado AS Codigo,
                                     	CodigoConvidadoTurma AS CodigoTurma,
                                     	NomeConvidado AS Nome,
                                     	EmpresaConvidado AS Empresa,
                                     	FotoConvidado AS Foto,
										AtivoConvidado AS Ativo
                                     FROM
                                     	TurmaConvidado WITH (NOLOCK)
                                     WHERE
                                     	CodigoConvidado = @Codigo";

            var data = await connection.QueryFirstOrDefaultAsync<Receita>(query.ToString(), new { Id = id }, null, commandType: CommandType.Text);
            return data;
        }
    }
}
