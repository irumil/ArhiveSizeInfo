﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace ClientManager
{
    public class ServerInfoManager
    {
        private readonly BindingList<ServerInfo> _listManger;
        private readonly IManageList<ServerInfo> _serverManagerList = new XmlManageList<ServerInfo>();

        public event Action<string> UpdateLog;

        public bool IsServerListChanged
        {
            get;
            private set;
        }

        public BindingList<ServerInfo> GetServerList()
        {
            return _listManger;
        }

        public void SaveServerList()
        {
            if (!IsServerListChanged) return;

            _serverManagerList.SaveList(_listManger);
            //WriteLog("Список серверов сохранен!");
            IsServerListChanged = false;
        }

        public ServerInfoManager()
        {
            _listManger = _serverManagerList.ReadList();
            _listManger.ListChanged += OnListChange;
        }

        private void OnListChange(object sender, ListChangedEventArgs e)
        {
            try
            {

                if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted)
                {
                    IsServerListChanged = true;
                }

                if (!e.PropertyDescriptor.Attributes.OfType<XmlIgnoreAttribute>().Any())
                {
                    //WriteLog("Изменено свойство " + e.PropertyDescriptor.Name);
                    IsServerListChanged = true;
                }
            }
            catch (Exception)
            {
                // чето не нравится
            }
        }

        public void StartGetSizeInfo(int month)
        {
            WriteLog("----------Получение информации от серверов!!!----------");

            foreach (var serverInfo in _listManger.Where(x => x.NeedSize))
            {
                WriteLog(serverInfo.GetSizeInfoFromServer(month));
            }
        }
        

        public void AddServer()
        {
            _listManger.Add(new ServerInfo
            {
                NeedSize = false,
                Description = "Новый сервер",
                IpAdress = "localhost"
            });

            //WriteLog("Добавили новый сервер");
        }

        public void DeleteServer(int serverIndex)
        {
            try
            {
                _listManger.RemoveAt(serverIndex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.InnerException.Message);
            }
            //WriteLog("Удалили сервер");
        }

        private void WriteLog(string info)
        {
            if (UpdateLog != null) UpdateLog(info);
        }
    }
}
