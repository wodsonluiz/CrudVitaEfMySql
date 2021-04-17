using System;
using System.Linq;
using CrudProjectVita.Models;
using CrudVitaEfMySql;

public static class InicializaBD
{
    public static void Initialize(AppDbContext dbContext){

        dbContext.Database.EnsureCreated();

        if(dbContext.PessoaFisicas.Any()){
            return;
        }

        var pessoa = new PessoaFisica(
            "23069551823",
            DateTime.Now,
            "Wodson Luiz",
            "Correia",
            "08340146",
            "Rua Forte do Triunfo",
            "301",
            "Apto 52",
            "Parque São Lourenco",
            "São Paulo",
            "SP"
        );

        dbContext.PessoaFisicas.Add(pessoa);
        dbContext.SaveChanges();

    }

}