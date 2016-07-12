using System.Collections.Generic;
using System.IO;
using System.Xml;

using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;

namespace Sulfide
{
    /// <summary>
    /// Provides convenient methods for loading syntax highlighting schemes for various languages.
    /// </summary>
    public class SyntaxHighlightingLoader
    {
        /// <summary>
        /// Cache loaded highlighting schemes.
        /// </summary>
        private static readonly Dictionary<string, IHighlightingDefinition> Cached
            = new Dictionary<string, IHighlightingDefinition>();

        /// <summary>
        /// Loads a syntax highlighting definition by name and returns it.
        /// </summary>
        /// <param name="name">The name of the definition to load.</param>
        /// <returns></returns>
        private static IHighlightingDefinition LoadHighlightingDefinition(string name)
        {
            // Load new scheme and add to cache.
            if (!Cached.ContainsKey(name))
            {
                var filename = $"xshd/{name}.xshd";
                var reader = new XmlTextReader(new FileStream(filename, FileMode.Open));
                var loaded = HighlightingLoader.Load(reader, HighlightingManager.Instance);
                reader.Close();
                Cached.Add(name, loaded);
            }
            
            return Cached[name];
        }

        /// <summary>
        /// Loads the syntax highlighting definition for the Boo language.
        /// </summary>
        /// <returns></returns>
        public static IHighlightingDefinition LoadBooHighlightingDefinition()
        {
            return LoadHighlightingDefinition("Boo");
        }
    }
}
