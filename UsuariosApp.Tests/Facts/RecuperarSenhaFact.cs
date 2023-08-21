using Bogus;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuariosapp.Aplication.Models.RecuperarSenha;
using UsuariosApp.Tests.Helpers;
using Xunit;

namespace UsuariosApp.Tests.Facts
{
    public class RecuperarSenhaFact
    {
        [Fact]
        public void RecuperarSenha_Ok()
        {
            var criarContaFact = new CriarContaFact();
            var usuario = criarContaFact.CriarConta_Ok();

            var request = new RecuperarSenhaRequestModel();

            request.Email = usuario.Email;

            var caminho = "/api/usuarios/recuperar-senha";

            var response = TestHelper.CreateClient().PostAsync(caminho, TestHelper.CreateContent(request)).Result;

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            
        }

        [Fact]
        public void RecuperarSenha_BadRequest()
        {
            var faker = new Faker("pt_BR");

            var request = new RecuperarSenhaRequestModel();
            request.Email = faker.Internet.Email();

            var caminho = "/api/usuarios/recuperar-senha";

            var response = TestHelper.CreateClient().PostAsync(caminho, TestHelper.CreateContent(request)).Result;

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);

        }
    }
}
