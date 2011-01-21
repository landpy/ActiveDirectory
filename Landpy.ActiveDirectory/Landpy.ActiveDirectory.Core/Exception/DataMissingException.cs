using System;

namespace Landpy.ActiveDirectory.Exception
{
    class DataMissingException : System.Exception
    {
        public DataMissingException(string dataMissingMessage)
            : base(dataMissingMessage)
        {
        }

        public override string Message
        {
            get
            {
                return String.Format("Missing the data as following, please assign the value:\r\n{0}", base.Message);
            }
        }
    }
}
