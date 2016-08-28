using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;
using System.Xml.Serialization;
using ClientManager.SizeServiceReference;

namespace ClientManager
{
    public enum ServerStatus
    {
        CheckServerState,       // проверка статуса сервера

        ServerAvailable,        // сервер доступен
        ServerNotAvailable,     // сервер не доступен
        SizeInfoRejected,       // информация получена
        ServiceError            // ошибка получения информации
    }

    [Serializable]
    public class ServerInfo: INotifyPropertyChanged
    {
        #region Private Fields
        private bool _needSize;
        private string _ipAdress;
        private string _description;
        private string _info;
        private string _errorText;

        private readonly Dictionary<ServerStatus, Action> _serverStatusCollection;

        #endregion Private Fileds  

        
        public ServerInfo()
        {
            _serverStatusCollection = new Dictionary<ServerStatus, Action>();

            _serverStatusCollection.Add(ServerStatus.CheckServerState, () =>
            {
                _info = "Подключение к серверу...";
            });
            _serverStatusCollection.Add(ServerStatus.ServerAvailable, () =>
            {
                _info = "Cервер доступен";
            });
            _serverStatusCollection.Add(ServerStatus.ServerNotAvailable, () =>
            {
                _info = "Сервер не доступен!!!";
            });
            _serverStatusCollection.Add(ServerStatus.SizeInfoRejected, () =>
            {
                _info = "Информация с сервера получена";
            });
            _serverStatusCollection.Add(ServerStatus.ServiceError, () =>
            {
                _info = string.Format("Ошибка: {0}", _errorText);
            });
        }
        
        [DisplayName(@"Получать")]
        public bool NeedSize
        {
            get{return _needSize;}
            set 
            { 
                _needSize = value; 
                OnPropertyChanged("NeedSize");
            }
        }

        [DisplayName(@"IP Адрес")]
        public string IpAdress
        {
            get { return _ipAdress; }
            set
            {
                _ipAdress = value;
                OnPropertyChanged("IpAdress");
            }
        }

        [DisplayName(@"Описание")]
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        [XmlIgnore]
        [DisplayName(@"Статус Инфо")]
        public string StatusInfo
        {
            get { return _info; }
        }

        [XmlIgnore]
        [Browsable(false)]
        public string ErrorText { get; set; }

        [XmlIgnore]
        [Browsable(false)]
        public ServerStatus ServerStatus
        {
            set
            {
                _serverStatusCollection[value].Invoke();
                //говорим подписчику свойсва что изменился статус
                OnPropertyChanged("StatusInfo");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) 
                handler(this, new PropertyChangedEventArgs(name));
        }

        private SizeServiceClient GetClient()
        {
            var client = new SizeServiceClient(); 

            client.Endpoint.Address =
                new EndpointAddress(string.Format("http://{0}:8004/SizeService/mex", _ipAdress));

            return client;
        }

      
        public string GetSizeInfoFromServer()
        {
            var client = GetClient();
            string result = string.Empty;

            try
            {
                ServerStatus = ServerStatus.CheckServerState;

                result = client.GetSizeInfo();

                ServerStatus = ServerStatus.SizeInfoRejected;
                

            }
            catch (Exception ex)
            {
                SetExceptionStatus(ex);
            }
            finally
            {
                client.Close();
                
            }
            
            return Description+ ":  " + result;
        }

        private void SetExceptionStatus(Exception ex)
        {
            _errorText = ex.Message;

            if (ex.InnerException != null)
            {
                _errorText = ex.InnerException.Message;
            }

            ServerStatus = ServerStatus.ServerNotAvailable;
        }
    }
}
