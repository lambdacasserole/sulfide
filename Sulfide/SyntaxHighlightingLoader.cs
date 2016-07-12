using System.IO;
using System.Xml;

using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;

namespace Sulfide
{
    /// <summary>
    /// Provides convenient methods for loading syntax highlighting schemes for various languages.
    /// </summary>
    class SyntaxHighlightingLoader
    {
        /// <summary>
        /// Loads a syntax highlighting definition by name and returns it.
        /// </summary>
        /// <param name="name">The name of the definition to load.</param>
        /// <returns></returns>
        private static IHighlightingDefinition LoadHighlightingDefinition(string name)
        {
            var reader = new XmlTextReader(new FileStream($"xshd/{name}.xshd", FileMode.Open));
            return HighlightingLoader.Load(reader, HighlightingManager.Instance);
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
