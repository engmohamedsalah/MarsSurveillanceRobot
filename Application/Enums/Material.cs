using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Application.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Material
    {
        [EnumMember(Value = "Unkown")]
        Unkown,// in case of material not known yet

        [EnumMember(Value = "Empty")]
        Empty,//in case the cell is already taken

        [EnumMember(Value = "Fe")]
        Fe, //Ferrum. A deposit of iron.

        [EnumMember(Value = "Se")]
        Se,//Selenium. A deposit of selenium.

        [EnumMember(Value = "W")]
        W,//Water. A deposit that contains water.

        [EnumMember(Value = "Si")]
        Si,//Silicon. A deposit that contains silicon.

        [EnumMember(Value = "Zn")]
        Zn,//Zinc. A deposit that contains zinc.

        [EnumMember(Value = "Obs")]
        Obs,//An obstacle cell in which the robot can’t go.
    }
}