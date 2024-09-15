using BDO.Core.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BDO.Core.DataAccessObjects.ExtendedEntities
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Action
    {
        public string actionType { get; set; }
        public string actionUrl { get; set; }
        public string viewBag { get; set; }
        public string labelAr { get; set; }
        public string labelEn { get; set; }
    }

    public class ControlsModel
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string LabelAr { get; set; }
        public string LabelEn { get; set; }
        public string HintAr { get; set; }
        public string HintEn { get; set; }
        public string MaxLength { get; set; }
        public bool IsRequired { get; set; }
        public string DefaultValue { get; set; }
        public string AllowedExtensions { get; set; }
        public List<OptionControlModel> OptionControlModels { get; set; }
        public string LastDate { get; set; }
        public string FirstDate { get; set; }
        public bool IsMultiline { get; set; }
        public bool IsDisabled { get; set; }
        public List<Validator> Validators { get; set; }
    }

    public class OptionControlModel
    {
        public string Value { get; set; }
        public string TextAr { get; set; }
        public string TextEn { get; set; }
    }

    public class Result
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string HintAr { get; set; }
        public string HintEn { get; set; }
        public int StepNo { get; set; }
        public object TOS { get; set; }
        public List<ControlsModel> ControlsModels { get; set; }
        public string ButtonLabelAr { get; set; }
        public string ButtonLabelEn { get; set; }
    }

    public class sahelEntity
    {
        [DataMember]
        public bool IsSuccess { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string MessageEn { get; set; }
        [DataMember]
        public Result Result { get; set; }
        [DataMember]
        public List<Action> Actions { get; set; }
        [DataMember]
        public string alertType { get; set; }
    }

    public class Validator
    {
        public string Regex { get; set; }
        public string MessageAr { get; set; }
        public string MessageEn { get; set; }
    }
    public class InputModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string Extension { get; set; }
    }

    public class ServiceStatusCreate
    {
        public string subscriberCivilId { get; set; }
        public string identifierValue { get; set; }
        public string isForSubscriber { get; set; }
        public string serviceStatusType { get; set; }
        public string alertType { get; set; }


    }
}
