namespace Reflection;

public static class FileConfigurationProvider
{
    private const string ConfigFileName = "config.txt";

    public static void Save(string settingName, object value)
    {
        var lines = File.Exists(ConfigFileName) ? File.ReadAllLines(ConfigFileName) : new string[] { };
        var updated = false;

        for (int i=0; i<lines.Length; i++)
        {
            if(lines[i].StartsWith(settingName + "="))
            {
                lines[i] = $"{settingName}={value}";
                updated = true;
                break;
            }
        }

        if (!updated)
        {
            var linesList = new List<string>(lines) { $"{settingName}={value}"};
            lines = linesList.ToArray();
        }

        File.WriteAllLines(ConfigFileName, lines);
    }
    
    public static object Load(Type type, string settingName)
    {
        if(!File.Exists(ConfigFileName)) return GetDefaultValue(type);

        foreach (var line in File.ReadAllLines(ConfigFileName))
        {
            if (line.StartsWith(settingName + "="))
            {
                var value = line.Substring(settingName.Length + 1);
                return Convert.ChangeType(value, type);
            }
        }

        return GetDefaultValue(type);
    }
    private static object GetDefaultValue(Type type) => type.IsValueType ? Activator.CreateInstance(type) : null;
}
