using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Configuration;

using System.Data.SqlClient;

using System.Data.Entity.Core.Objects;

using System.Transactions;

namespace Ex5
{
    class Program
    {


        static void Main(string[] args)
        {

//ponto 1
// Com o Sql Server MAnagement Studio crie um aluno de número 1111 com dois interesses i1 e i2
            var al = new Aluno();

            using (var ctx = new SI2Entities())
            {

                al = (from a in ctx.Alunos
                     where a.NumAl == 1111
                     select a)
                             .SingleOrDefault();

            }
            Console.WriteLine("Aluno {0}, número {1}", al.Nome, al.NumAl);
            Console.WriteLine("Com hobbies:");
//ponto 2
// observar o que se passará a seguir
            foreach (var h in al.Hobbies)
                Console.WriteLine(h.Descr);
        }
    }
}
