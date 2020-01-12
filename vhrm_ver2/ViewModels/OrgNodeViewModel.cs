using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.ViewModels
{
    //public class OrgNodeViewModel
    //{
    //    //public string NAME { get; set; }
    //    public KeyValuePair<string, OrgNodeGroupViewModel> TAG{ get; set; }
    //}

    //public class OrgNodeGroupViewModel
    //{
    //    public bool group { get; set; }
    //    public string groupName { get; set; }
    //    public string groupState { get; set; }
    //    public string template { get; set; }
    //}

    //public class ElementViewModel
    //{
    //    public bool display { get; set; }
    //    public string id { get; set; }
    //    public string pid { get; set; }
    //}
    //class MyConverter : JsonConverter
    //{
    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        List<KeyValuePair<string, object>> list = value as List<KeyValuePair<string, object>>;
    //        writer.WriteStartArray();
    //        foreach (var item in list)
    //        {
    //            writer.WriteStartObject();
    //            writer.WritePropertyName(item.Key);
    //            writer.WriteValue(item.Value);
    //            writer.WriteEndObject();
    //        }
    //        writer.WriteEndArray();
    //    }

    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        return null;
    //    }

    //    public override bool CanConvert(Type objectType)
    //    {
    //        return objectType == typeof(List<KeyValuePair<string, object>>);
    //    }
    //}
    //public class GEOSuperVisorViewMode
    //{
    //    public string id { get; set; }
    //    public string pid { get; set; }

    //    public string[] tags { get; set; }

    //    public string EMPNAME { get; set; }

    //    public string EMPID { get; set; }

    //    public string EMAIL { get; set; }

    //    public string POSITION { get; set; }

    //    public string IMAGE { get; set; }
    //}
}