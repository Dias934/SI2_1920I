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

namespace Ex2
{
    class Program
    {

// ponto 1

        static void Main(string[] args)
        {
 
            using (var ctx = new SI2Entities())
            {
                // em alternativa a usar o Sql Server Profiler(com eventos RPC:Starting e Sql:stmtStarting), pode fazer:
                //ctx.Database.Log = Console.Write;
               
               var q = (from a in ctx.Alunos
                         select a );


                foreach (var a in q)
                {

                    Console.WriteLine(a.NumAl);

// Ver output do Sql Profiler
                    foreach (var h in a.Hobbies)
                    {
// Ver output do Sql Profiler
                        Console.WriteLine("{0}:{1}", h.nSeq, h.Descr);
                    }

                }
            }

//ponto 2
// clear trace no Sql Profiler
            using (var ctx = new SI2Entities())
            {
                // em alternativa a usar o Sql Server Profiler, pode fazer:
                // ctx.Database.Log = Console.Write;

                ctx.Configuration.ProxyCreationEnabled = false;

                var q = (from a in ctx.Alunos.Include(a => a.Hobbies)
                         select a);


                foreach (var a in q)
                {

                    Console.WriteLine(a.NumAl);

// Ver output do Sql Profiler
                    foreach (var h in a.Hobbies)
                    {
// Ver output do Sql Profiler
                        Console.WriteLine("{0}:{1}", h.nSeq, h.Descr);
                    }

                }
            }

            Console.ReadLine();

        }
    }
}
