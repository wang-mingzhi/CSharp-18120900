namespace ConfigExample.Configuration {
    public class SampleSectionGroup : System.Configuration.ConfigurationSectionGroup
    {
        public SimpleSection Simple => (SimpleSection)base.Sections["simple"];

        public ComplexSection Complex => (ComplexSection)base.Sections["complex"];
    }
}
