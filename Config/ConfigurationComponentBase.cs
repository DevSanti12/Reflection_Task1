using System.Reflection;

namespace Reflection;

public abstract class ConfigurationComponentBase
{
    public void SaveSettings()
    {
        foreach (var property in GetPropertiesWithConfigurationAttributes())
        {
            var attribute = property.GetCustomAttribute<ConfigurationItemAttribute>();
            var value = property.GetValue(this);

            if(attribute.ProviderType == "File")
            {
                FileConfigurationProvider.Save(attribute.SettingName, value);
            }
            else if(attribute.ProviderType == "ConfigurationManager")
            {
                ConfigurationManagerConfigurationProvider.Save(attribute.SettingName, value);
            }
        }
    }

    public void LoadSettings()
    {
        foreach(var property in GetPropertiesWithConfigurationAttributes())
        {
            var attribute = property.GetCustomAttribute<ConfigurationItemAttribute>();

            if(attribute.ProviderType == "File")
            {
                var value = FileConfigurationProvider.Load(property.PropertyType, attribute.SettingName);
                property.SetValue(this, value);
            }
            else if(attribute.ProviderType == "ConfigurationManager")
            {
                var value = ConfigurationManagerConfigurationProvider.Load(property.PropertyType, attribute.SettingName);
                property.SetValue(this, value);
            }
        }
    }

    private IEnumerable<PropertyInfo> GetPropertiesWithConfigurationAttributes()
    {
        return GetType().GetProperties()
            .Where(p => p.IsDefined(typeof(ConfigurationItemAttribute), false));
    }
}
