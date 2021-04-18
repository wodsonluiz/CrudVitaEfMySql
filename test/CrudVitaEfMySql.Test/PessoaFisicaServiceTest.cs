using CrudProjectVita.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace CrudVitaEfMySql.Test
{
    [TestFixture]
    public class PessoaFisicaServiceTest
    {
        private PessoaFisica _pessoa;
        private IPessoaFisica _service;

        [OneTimeSetUp]
        public void Setup()
        {
            _pessoa = new PessoaFisica()
            {
                Nome = "Usuario UnitTest",
                SobreNome = "Usuario UniTest",
                CEP = "12345-678",
                Logradouro = "Rua do João da Silva",
                Complemento = "Complemento UnitTest",
                Bairro = "Bairro UnitTest",
                Cidade = "Cidade UnitTest",
                Uf = "SP",
                Cpf = "999.999.999-99",
                Numero = "111",
                DataNascimento = DateTime.Now
            };

            var conn = "Server=localhost;port=3306;DataBase=CiaTecnicaDev;Uid=root;Pwd=adminMaster";
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(conn);
            var context = new AppDbContext(optionsBuilder.Options);

            _service = new PessoaFisicaService(context);
        }
        [Test]
        public void TestInclude()
        {
            var response = _service.Include(_pessoa);
            Assert.IsTrue(response.Result.Result == ResultEnum.Success ? true : false);
        }

        [Test]
        public void TestIncludeNomeEmpty()
        {
            _pessoa.Nome = null;
            var response = _service.Include(_pessoa);
            Assert.IsTrue(response.Result.Result == ResultEnum.Fail ? true : false);
        }

        [Test]
        public void TestIncludeComplementoEmpty()
        {
            _pessoa.Complemento = null;
            var response = _service.Include(_pessoa);
            Assert.IsTrue(response.Result.Result == ResultEnum.Success ? true : false);
        }
    }
}
