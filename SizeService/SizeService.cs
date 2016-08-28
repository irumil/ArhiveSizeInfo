using ArhivSizeInfoLib;

namespace SizeService
{
    
    public class SizeService : ISizeService
    {
        public string GetSizeInfo()
        {
            return ArhivSizeInfoMethod.GetInfoThisMohtn();
        }
    }
}
