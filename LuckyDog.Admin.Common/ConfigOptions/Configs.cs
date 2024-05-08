using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Common.ConfigOptions
{
    public class Configs
    {

        #region IsInitData
        private bool? _isInitData;
        public bool IsInitData
        {
            get => _isInitData ?? false;
            set => _isInitData = value;
        }
        #endregion


        #region 是否开发模式

        private bool? _isQuickDebug;

        /// <summary>
        /// 是否开发模式，生产环境建议设置为False
        /// </summary>
        public bool IsQuickDebug
        {
            get => _isQuickDebug ?? false;
            set => _isQuickDebug = value;
        }

        #endregion

        #region DB connector
        private DataConnection? _connection;
        public DataConnection  DataConnection {
            get {
                if (_connection == null)
                {
                    _connection = new DataConnection
                    {
                        ConnectionItem = new List<ConnectionItem>()
                    };
                }
                return _connection;    
                } 
            set => _connection = value;
        }
        #endregion

        #region cors
        private Cors _cors;
        public Cors Cors
        {
            get
            {

                if (_cors == null)
                {
                    _cors = new Cors
                    {
                        EnableAll = false,
                        Name = "",
                        Policy = new List<Policy>()
                    };

                }
                return _cors;
            }
            set => _cors = value;   
        }
        #endregion

        #region Aop
        private Aop?  _aop;
        public Aop Aop
        {
            get
            {
                if(_aop == null)
                {
                    _aop = new Aop();
                    _aop.Tran ??= new Tran
                    {
                        Enabled = false
                    };
                     
                }
                return _aop;
            }
            set { _aop = value; }   
        }
        #endregion

        #region Swagger 
        private Swagger? _swagger;
        public  Swagger Swagger
        {
            get
            {
                if(_swagger == null)
                {
                    _swagger = new Swagger();   
                    _swagger.Enabled = false;
                }
                return _swagger;
            }
            set => _swagger = value;
        }
        #endregion

        #region Input Log
        public SqlLog _sqlLog;
        public SqlLog SqlLog { 
            get { if (_sqlLog == null)
                {
                  _sqlLog = new SqlLog();   
                  _sqlLog.Enabled = false;
                    _sqlLog.ToDb ??= new ToDb
                    {
                        Enabled = false
                    };
                    _sqlLog.ToFile ??= new ToFile
                    {
                        Enabled = false
                    };
                    _sqlLog.ToConsole ??= new ToConsole
                    {
                        Enabled = false
                    };
                    _sqlLog.ToElasticsearch ??= new ToElasticsearch
                    {
                        Enabled = false
                    };

                }
            return _sqlLog; 
            } 
            set => _sqlLog = value;
        }
        #endregion


        #region Default DB
        private string? _defaultDataBase;
        public string DefaultDataBase
        {
            get => _defaultDataBase ?? "LuckyDog.Admin.SqlServer";
            set => _defaultDataBase = value;
        }
        #endregion

        #region crs

        private bool? _isCqrs;
        public bool IsCqrs
        {
            get => _isCqrs ?? false;
            set => _isCqrs = value;
        }
        #endregion

        #region Log Db

        public string? _logDataBase;
        public string LogDataBase
        {
            get=>  _logDataBase ?? "LuckyDog.Admin.Log"; 
            set => _logDataBase = value;

        }
        #endregion
    }
}
