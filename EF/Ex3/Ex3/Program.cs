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

namespace Ex3
{
    class Program
    {

        
        static void Main(string[] args)
        {


            var al1 = new Aluno { NumAl = 7777, Nome = "ana" };
            al1.Hobbies = new HashSet<Hobby>();

            using (var ctx = new SI2Entities())
            {
                ctx.Configuration.AutoDetectChangesEnabled = false;


                ctx.Alunos.Add(al1);

                var interesse = new Hobby { NumAl = 7777, Descr = "musica" };

                al1.Hobbies.Add(interesse); 

                var al2= ctx.Alunos.Create<Aluno>();
                al2.NumAl = 9999;
                al2.Nome = "xavier";

                ctx.Alunos.Add(al2);

                interesse = new Hobby { NumAl = 9999, Descr = "futebol" };

                al2.Hobbies.Add(interesse);

                
// ponto 1: correr o programa primeiro com o comentário na linha seguinte e depois, sem
                //ctx.ChangeTracker.DetectChanges();

                ctx.SaveChanges();

// verificar a saída do Sql Server Profiler

            }

 
        }
    }
}
