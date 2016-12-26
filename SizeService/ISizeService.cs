using System.ServiceModel;

namespace SizeService
{
    
    [ServiceContract]
    public interface ISizeService
    {
        [OperationContract]
        string GetSizeInfo();

        [OperationContract]
        string GetSizeInfoForMonth(int month);
    }
}
