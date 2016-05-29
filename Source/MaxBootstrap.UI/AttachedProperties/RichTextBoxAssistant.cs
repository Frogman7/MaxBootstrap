using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxBootstrap.UI.AttachedProperties
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;

    public static class RichTextBoxAssistant
    {
        public static readonly DependencyProperty FileProperty = DependencyProperty.RegisterAttached("File", typeof(string), typeof(RichTextBoxAssistant), new PropertyMetadata(string.Empty, FileChanged));

        public static string GetFile(DependencyObject dependencyObject)
        {
            return (string)dependencyObject.GetValue(FileProperty);
        }

        public static void SetFile(DependencyObject dependencyObject, object value)
        {
            dependencyObject.SetValue(FileProperty, value);
        }

        private static void FileChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            byte[] fileContents = null;
            var richTextbox = sender as RichTextBox;
            var path = (string)e.NewValue;

            if (richTextbox == null)
            {
                throw new ArgumentException("RichTextBox assistant can only be used with RichTextbox controls");
            }

            if (string.IsNullOrEmpty(path))
            {
                fileContents = Encoding.UTF8.GetBytes("No source file specified");
                // TODO Log error
                // throw new ArgumentException("The file path cannot be null or empty");
            }
            else if (!File.Exists(path))
            {
                fileContents = Encoding.UTF8.GetBytes("Source file could not be located");
                // TODO Log error
                //throw new FileNotFoundException("Could not find the file at " + path);
            }
            else
            {
                fileContents = File.ReadAllBytes(path);
            }

            var doc = new FlowDocument();
            var range = new TextRange(doc.ContentStart, doc.ContentEnd);

            using (var stream = new MemoryStream(fileContents))
            {
                range.Load(stream, DataFormats.Rtf);
            }

            richTextbox.Document = doc;
        }
    }
}
