using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Usuariosapp.Aplication.Models.AtualizarDados;

using UsuariosApp.Tests.Helpers;
using Xunit;

namespace UsuariosApp.Tests.Facts
{
    /// <summary>
    /// Classe de testes para o endpoint de atualização de dados
    /// </summary>
    public class AtualizarDadosFact
    {
        [Fact]
        public void AtualizarDados_Returns_Ok()
        {
            var request = new AtualizarDadosRequestModel();
            request.Nome = "Usuário Teste";
            request.Senha = "@Teste123";
            request.SenhaConfirmacao = "@Teste123";

            
            var token = new AutenticarFact().Autenticar_Ok().Token;

          
            var client = TestHelper.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var caminho = "/api/usuarios/atualizar-dados";


            var response = client.PutAsync(caminho, TestHelper.CreateContent(request)).Result;

            
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public void AtualizarDados_Returns_Unauthorized()
        {
            var request = new AtualizarDadosRequestModel
            {
                Nome = "Usuário Teste",
                Senha = "@Teste123",
                SenhaConfirmacao = "@Teste123"
            };

            //enviando o token no cabeçalho da requisição para a API
            //realizando o cadastro na API
            var response = TestHelper.CreateClient().PutAsync("/api/usuarios/atualizar-dados",
                TestHelper.CreateContent(request)).Result;

            //verificando o resultado esperado X resultado obtido
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
        }
    }
}



