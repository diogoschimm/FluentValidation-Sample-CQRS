using FluentValidationSampleCore;
using System;
using System.Collections.Generic;

namespace FluentValidationSampleData
{
    public static class Bd
    {
        public static List<Pessoa> Pessoas = new List<Pessoa>();

        static Bd()
        {
            Pessoas.AddRange(new List<Pessoa>
            {
                new Pessoa() { Id= Guid.NewGuid().ToString(), Nome = "Pessoa 1", CPF = "12345678912", DataNascimento = DateTime.Parse( "20/08/1993") },
                new Pessoa() { Id= Guid.NewGuid().ToString(), Nome = "Pessoa 2", CPF = "32158484525", DataNascimento = DateTime.Parse( "12/01/1995") }
            });
        }
    }
}
