using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

using Altinn2Convert.Models.Altinn2.InfoPath;

namespace Altinn2Convert.Models.Altinn2
{
    public class Altinn2AppData
    {
        public string Org { get; set; }
        
        public string App { get; set; }

        public string ModelName { get; set; }

        public ServiceEditionVersion ServiceEditionVersion { get; set; }

        public List<string> Languages { get; } = new List<string>();
        
        public List<FormMetadata.FormMetadata> FormMetadata { get; set; }

        public XmlDocument AttachmentTypes { get; set; }

        public XmlDocument AutorizationRules { get; set; }

        public FormFieldPrefill.FormFieldPrefill FormFieldPrefill { get; set; }

        public XmlDocument FormTrack { get; set; }

        public Dictionary<string, Translation> TranslationsParsed { get; set; } = new ();
        
        public Dictionary<string, XmlDocument> TranslationsXml { get; set; } = new ();

        public Dictionary<string, XSNFileContent> XSNFiles { get; set; } = new ();

        public XDocument Manifest { get; set; }

    }
}