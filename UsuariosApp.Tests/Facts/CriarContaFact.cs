using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuariosapp.Aplication.Models.CriarConta;
using UsuariosApp.Tests.Helpers;
using Xunit;

namespace UsuariosApp.Tests.Facts
{
    public class CriarContaFact
    {
        [Fact]
        public CriarContaRequestModel CriarConta_Ok()
        {
            var faker = new Faker("pt_BR");

            var request = new CriarContaRequestModel();

            request.Nome = faker.Person.FullName;
            request.Email = faker.Internet.Email();
            request.Senha = "Admin@123";
            request.SenhaConfirmacao = "Admin@123";            

            var caminho = "/api/usuarios/criar-conta";            

            var response = TestHelper.CreateClient().PostAsync(caminho, TestHelper.CreateContent(request)).Result;

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            return request;
        }

        [Fact]
        public void CriarConta_BadRequest()
        {
            var request = CriarConta_Ok();           

            var caminho = "/api/usuarios/criar-conta";            

            var response = TestHelper.CreateClient().PostAsync(caminho, TestHelper.CreateContent(request)).Result;

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }
    }
}
