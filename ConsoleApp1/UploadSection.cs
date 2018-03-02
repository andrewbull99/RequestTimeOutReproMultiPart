using System.Configuration;

namespace ConsoleApp1
{
    public class UploadSection : ConfigurationSection
    {
        public static readonly UploadSection Settings = ConfigurationManager.GetSection("uploadConfig") as UploadSection;

        [ConfigurationProperty("url", IsRequired = true)]
        public string Url
        {
            get => (string)this["url"];
            set => this["url"] = value;
        }

        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        public FileCollection Files
        {
            get => (FileCollection)this[""];
            set => this[""] = value;
        }
    }

    public class FileCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new FileUploadElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FileUploadElement)element).Name;
        }
    }

    public class FileUploadElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get => (string)base["name"];
            set => base["name"] = value;
        }

        [ConfigurationProperty("path", IsRequired = true)]
        public string Path
        {
            get => (string)base["path"];
            set => base["path"] = value;
        }
    }
}
