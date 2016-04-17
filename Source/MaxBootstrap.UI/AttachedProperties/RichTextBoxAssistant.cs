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
            var richTextbox = sender as RichTextBox;
            var path = (string)e.NewValue;

            if (richTextbox == null)
            {
                throw new ArgumentException("RichTextBox assistant can only be used with RichTextbox controls");
            }
            else if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("The file path cannot be null or empty");
            }
            else if (!System.IO.File.Exists(path))
            {
                throw new FileNotFoundException("Could not find the file at " + path);
            }

            var doc = new FlowDocument();
            var range = new TextRange(doc.ContentStart, doc.ContentEnd);

            byte[] fileContents = System.IO.File.ReadAllBytes(path);

            using (var stream = new MemoryStream(fileContents))
            {
                range.Load(stream, DataFormats.Rtf);
            }

            richTextbox.Document = doc;
        }
    }
}
