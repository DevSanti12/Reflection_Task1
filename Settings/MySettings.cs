using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection;

public class MySettings : ConfigurationComponentBase
{
    [ConfigurationItem("SettingOne", "File")]
    public int SettingOne { get; set; }

    [ConfigurationItem("SettingTwo", "ConfigurationManager")]
    public string SettingTwo { get; set; }
}
