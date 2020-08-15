using System.Configuration;

namespace ConfigExample.Configuration {
    public class ComplexSection : ConfigurationSection
    {
        [ConfigurationProperty("height", IsRequired = true)]
        public int Height {
            get => (int)base["height"];
            set => base["height"] = value;
        }

        [ConfigurationProperty("child", IsDefaultCollection = false)]
        public ChildSection Child {
            get => (ChildSection)base["child"];
            set => base["child"] = value;
        }

        [ConfigurationProperty("children", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ChildSection), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap, RemoveItemName = "remove")]
        public Children Children {
            get => (Children)base["children"];
            set => base["children"] = value;
        }

        [ConfigurationProperty("NVs", IsDefaultCollection = false)]
        public NameValueConfigurationCollection NVs {
            get => (NameValueConfigurationCollection)base["NVs"];
            set => base["NVs"] = value;
        }
    }

    public class Children : ConfigurationElementCollection {
        protected override object GetElementKey(ConfigurationElement element) => ((ChildSection)element).FirstName;

        protected override ConfigurationElement CreateNewElement() => new ChildSection();

        public ChildSection this[int i] => (ChildSection)base.BaseGet(i);

        public ChildSection this[string key] => (ChildSection)base.BaseGet(key);

    }

    public class ChildSection : ConfigurationElement
    {
        [ConfigurationProperty("firstName", IsRequired = true, IsKey = true)]
        public string FirstName {
            get => (string)base["firstName"];
            set => base["firstName"] = value;
        }

        [ConfigurationProperty("lastName", IsRequired = true)]
        public string LastName {
            get => (string)base["lastName"];
            set => base["lastName"] = value;
        }
    }
}
