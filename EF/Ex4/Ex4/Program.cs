﻿using System;
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

namespace Ex4
{
    class Program
    {

        
        static void Main(string[] args)
        {

            using (var ts = new TransactionScope())
            {


                using (var ctx = new SI2Entities())
                {
                    //Em EF 5:
                    //((IObjectContextAdapter)ctx).ObjectContext.Connection.Open(); 
                    ctx.Database.Connection.Open();
                    var al = (from a in ctx.Alunos
                              where a.NumAl == 1111
                              select a)
                                .First();


                    al.Nome = "xico";


                   
                    using (var ctx1 = new SI2Entities())
                    {
                        //Em EF5:
                        //((IObjectContextAdapter)ctx1).ObjectContext.Connection.Open(); 
                        ctx1.Database.Connection.Open();
                        var al1 = (from a in ctx.Alunos
                                   where a.NumAl == 4444
                                   select a)
                                .First();
                        al1.Nome = "xxxx";
                        ctx1.SaveChanges();
                    }

                    ctx.SaveChanges();
                }

                ts.Complete();
            }
        }
    }
}
