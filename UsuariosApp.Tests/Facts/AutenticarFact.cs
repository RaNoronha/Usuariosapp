using Azure.Core;
using Bogus;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuariosapp.Aplication.Models.Autenticar;
using UsuariosApp.Tests.Helpers;
using Xunit;

namespace UsuariosApp.Tests.Facts
{
    public class AutenticarFact
    {
        [Fact]
        public void Autenticar_Ok()
        {
            var criarContaFact = new CriarContaFact();
            var usuario = criarContaFact.CriarConta_Ok();

            var request = new AutenticarRequestModel();
            request.Email = usuario.Email;
            request.Senha = usuario.Senha;

            var caminho = "/api/usuarios/autenticar";

            var response = TestHelper.CreateClient().PostAsync(caminho, TestHelper.CreateContent(request)).Result;

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public void Autenticar_Unauthorize()
        {
            var faker = new Faker();

            var request = new AutenticarRequestModel();
            request.Email = faker.Internet.Email();
            request.Senha = "Teste@1234";

            var caminho = "/api/usuarios/autenticar";

            var response = TestHelper.CreateClient().PostAsync(caminho, TestHelper.CreateContent(request)).Result;

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
        }

        [Fact]
        public void Autenticar_BadRequest()
        {
           

            var request = new AutenticarRequestModel();
            request.Email = string.Empty;
            request.Senha = string.Empty;

            var caminho = "/api/usuarios/autenticar";

            var response = TestHelper.CreateClient().PostAsync(caminho, TestHelper.CreateContent(request)).Result;

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }
    }
}
