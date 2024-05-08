using LuckyDog.Admin.Common.ConfigOptions;
using LuckyDog.Admin.Common.Extention;
using Microsoft.Extensions.Options;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Entity.Seed
{
    public class DataContext
    {
     
        public DataContext(ISqlSugarClient sqlSugarClient, IOptionsMonitor<Configs>? configs = null) 
        {
            _configs =   configs?.CurrentValue ?? new Configs();
           
            _db = sqlSugarClient as SqlSugarScope ;
        }
       
        private Configs _configs;
        public Configs Configs { get => _configs; }


        private SqlSugarScope? _db;

        public SqlSugarScope Db
        {
            get => _db;
            private set => _db = value;
        }

        public DbType DbType => (DbType)ConnectObject.DbType;
        public ConnectionItem ConnectObject => GetCurrentDataBase();

        public string? ConnectionString => ConnectObject.ConnectionString;

        private ConnectionItem GetCurrentDataBase()
        {
            var defaultConnectionItem  = Configs?.DataConnection?.ConnectionItem?.FirstOrDefault(c=>c.ConnId == Configs.DefaultDataBase);
            if (defaultConnectionItem.IsNull())
            {
                throw new Exception("Please Config  DB Connetion Item");
            }
            return defaultConnectionItem;
        }



        #region 实例方法

        /// <summary>
        /// 获取数据库处理对象
        /// </summary>
        /// <returns>返回值</returns>
        public SimpleClient<T> GetEntityDb<T>() where T : class, new()
        {
            return new SimpleClient<T>(_db);
        }

        /// <summary>
        /// 获取数据库处理对象
        /// </summary>
        /// <param name="db">db</param>
        /// <returns>返回值</returns>
        public SimpleClient<T> GetEntityDb<T>(SqlSugarClient db) where T : class, new()
        {
            return new SimpleClient<T>(db);
        }

        #endregion

        #region 根据实体类生成数据库表

        /// <summary>
        /// 根据实体类生成数据库表
        /// </summary>
        /// <param name="blnBackupTable">是否备份表</param>
        /// <param name="entityList">指定的实体</param>
        public void CreateTableByEntity<T>(bool blnBackupTable, params T[] entityList) where T : class, new()
        {
            Type[] lstTypes = null;
            if (entityList != null)
            {
                lstTypes = new Type[entityList.Length];
                for (int i = 0; i < entityList.Length; i++)
                {
                    lstTypes[i] = typeof(T);
                }
            }

            CreateTableByEntity(blnBackupTable, lstTypes);
        }

        /// <summary>
        /// 根据实体类生成数据库表
        /// </summary>
        /// <param name="blnBackupTable">是否备份表</param>
        /// <param name="entityList">指定的实体</param>
        private void CreateTableByEntity(bool blnBackupTable, params Type[] entityList)
        {
            if (blnBackupTable)
            {
                Db.CodeFirst.BackupTable().InitTables(entityList); //change entity backupTable            
            }
            else
            {
                Db.CodeFirst.InitTables(entityList);
            }
        }

        #endregion
    }

}
