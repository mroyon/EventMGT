using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.Text;

namespace BDO.Core.DataAccessObjects.ExtendedEntities
{
    [Serializable]
    [DataContract(Name = "OfficersClubRegReturnEntity", Namespace = "http://www.KAF.com/types")]

    public class OfficersClubRegReturnEntity
    {
        protected string _returnCode;
        protected String _returnJson;


        [DataMember]
        public String returnCode
        {
            get { return _returnCode; }
            set { _returnCode = value; }
        }

        [DataMember]
        public String returnJson
        {
            get { return _returnJson; }
            set { _returnJson = value; }
        }


        public OfficersClubRegReturnEntity() : base()
        {

        }

        public OfficersClubRegReturnEntity(IDataReader reader)
        {
            this.LoadFromReader(reader);
        }

        protected void LoadFromReader(IDataReader reader)
        {
            if (!reader.IsDBNull(reader.GetOrdinal("returnCode"))) _returnCode = reader.GetString(reader.GetOrdinal("returnCode"));
            if (!reader.IsDBNull(reader.GetOrdinal("returnJson"))) _returnJson = reader.GetString(reader.GetOrdinal("returnJson"));
        }

    }
}
