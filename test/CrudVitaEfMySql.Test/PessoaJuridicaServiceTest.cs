using CrudProjectVita.Models;
using CrudVitaEfMySql.Abstrations;
using CrudVitaEfMySql.Service;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace CrudVitaEfMySql.Test
{
    [TestFixture]
    public class PessoaJuridicaServiceTest
    {
        private PessoaJuridica _pessoaJuridica;
        private IPessoaJuridica _service;

        [OneTimeSetUp]
        public void Setup()
        {
            _pessoaJuridica = new PessoaJuridica()
            {
                RazaoSocial = "Usuario UnitTest",
                NomeFantasia = "Usuario UniTest",
                CEP = "12345-678",
                Logradouro = "Rua do Joao da Silva",
                Complemento = "Complemento UnitTest",
                Bairro = "Bairro UnitTest",
                Cidade = "Cidade UnitTest",
                Uf = "SP",
                Cnpj = "99.999.999/9999-99",
                Numero = "111",
            };

            var conn = "Server=localhost;port=3306;DataBase=CiaTecnicaDev;Uid=root;Pwd=adminMaster";
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(conn);
            var context = new AppDbContext(optionsBuilder.Options);

            _service = new PessoaJuridicaService(context);
        }

        [Test]
        public void TestInclude()
        {
            var response = _service.Include(_pessoaJuridica);
            Assert.IsTrue(response.Result.Result == ResultEnum.Success ? true : false);
        }

        [Test]
        public void TestIncludeNomeFantasiaEmpty()
        {
            _pessoaJuridica.NomeFantasia = null;
            var response = _service.Include(_pessoaJuridica);
            Assert.IsTrue(response.Result.Result == ResultEnum.Fail ? true : false);
        }

    }
}
