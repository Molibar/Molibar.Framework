using System;
using System.Configuration;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Molibar.Infrastructure.Configuration.XMLConfigSection
{
    #region Directives

    

    #endregion

    /// <summary>
    /// The xml serializer section handler.
    /// </summary>
    public class XmlSerializerSectionHandler : IConfigurationSectionHandler
    {
        #region Public Methods

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="parent">
        /// The parent.
        /// </param>
        /// <param name="configContext">
        /// The config context.
        /// </param>
        /// <param name="section">
        /// The section.
        /// </param>
        /// <returns>
        /// The create.
        /// </returns>
        public object Create(
            object parent, 
            object configContext, 
            XmlNode section)
        {
            var nav = section.CreateNavigator();
            var typename = (string)nav.Evaluate("string(@type)");
            var t = Type.GetType(typename);
            var ser = new XmlSerializer(t);
            return ser.Deserialize(new XmlNodeReader(section));
        }

        /// <summary>
        /// Creates the specified path to config file.
        /// </summary>
        /// <param name="pathToConfigFile">The path to config file.</param>
        /// <param name="sectionName">Name of the section.</param>
        /// <returns></returns>
        public object Create(
            string pathToConfigFile,
            string sectionName)
        {
            var xmlDoc = XDocument.Load(pathToConfigFile);
            var sectionElement = xmlDoc.Descendants().FirstOrDefault(x => x.Name.LocalName.Equals(sectionName));
            return sectionElement != null ? Create(sectionElement) : null;
        }

        /// <summary>
        /// Creates the specified path to config file.
        /// </summary>
        /// <param name="sectionElement">The section element.</param>
        /// <returns>The strongly typed consfig section</returns>
        private object Create(XElement sectionElement)
        {
            var typeName = sectionElement.HasAttributes ? sectionElement.Attributes()
                                                            .SingleOrDefault(x => x.Name.LocalName.Equals("Type", StringComparison.InvariantCultureIgnoreCase)).Value
                                                            : string.Empty;
            var ser = new XmlSerializer(Type.GetType(typeName));
            return ser.Deserialize(sectionElement.CreateReader());
        }
       
        #endregion
    }
}