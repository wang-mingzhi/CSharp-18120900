using System;
using System.Configuration;

namespace ConfigExample.Configuration {
    public class SimpleSection: ConfigurationSection {
        [ConfigurationProperty("maxValue",IsRequired=false,DefaultValue=Int32.MaxValue)]
        public int MaxValue {
            get => (int)base["maxValue"];
            set => base["maxValue"] = value;
        }

        [ConfigurationProperty("minValue",IsRequired=false,DefaultValue=1)]
        public int MinValue {
            get => (int)base["minValue"];
            set => base["minValue"] = value;
        }

        [ConfigurationProperty("enabled",IsRequired=false,DefaultValue=true)]
        public bool Enable {
            get => (bool)base["enabled"];
            set => base["enabled"] = value;
        }
    }
}
