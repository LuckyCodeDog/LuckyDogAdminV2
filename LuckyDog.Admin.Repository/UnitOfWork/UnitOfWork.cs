using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Repository.UnitOfWork
{
    /// <summary>
    /// Keep Db as a unit 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISqlSugarClient _sqlSugarClient;

        
        public UnitOfWork(ISqlSugarClient sqlSugarClient) 
        {
            _sqlSugarClient =  sqlSugarClient;
        }

        public void BeginTran()
        {
            GetDbClient().BeginTran();
        }

        public void CommitTran()
        {
            try {
                GetDbClient().CommitTran();

            }
            catch(Exception ex)
            {
                GetDbClient().RollbackTran();

                throw;
                   

            }
        }

        public SqlSugarScope GetDbClient()
        {
            return _sqlSugarClient as SqlSugarScope;
        }

        public void RollBackTrac()
        {
            GetDbClient().RollbackTran();
        }
    }
}
