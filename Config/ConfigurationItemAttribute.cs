namespace Reflection
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ConfigurationItemAttribute : Attribute
    {
        public string SettingName { get; }
        public string ProviderType { get; } // "File or "ConfigurationManager"

        public ConfigurationItemAttribute(string settingName, string providerType)
        {
            SettingName = settingName;
            ProviderType = providerType;
        }

    }
}
