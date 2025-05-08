using System.Configuration;

namespace Reflection;

public static class ConfigurationManagerConfigurationProvider
{
    public static void Save(string settingName, object value)
    {
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        if (config.AppSettings.Settings[settingName] != null)
        {
            config.AppSettings.Settings[settingName].Value = value.ToString();
        }
        else
        {
            config.AppSettings.Settings.Add(settingName, value.ToString());
        }
        config.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection(settingName);
    }

    public static object Load(Type type, string settingName)
    {
        var value = ConfigurationManager.AppSettings[settingName];
        if (value == null)
        {
            return Convert.ChangeType(value, type);  
        }

        return GetDefaultValue(type);
    }
    private static object GetDefaultValue(Type type) =>
    type.IsValueType ? Activator.CreateInstance(type) : null;
}
