using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Nastya.Nastya.Configs;
using Nastya.Nastya.Datatypes.Words;
using Nastya.Nastya.Datatypes.Words.Comparer;

namespace NastyaConfigHelper
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void genSeqBtn_Click(object sender, EventArgs e)
        {
            WordSequence genSequence = new WordSequence();
            genSequence.Comparer = new WordsComparer((double)thresholdNud.Value);
            genSequence.Type = orderedCbx.Checked ? SequenceType.Ordered : SequenceType.Disordered;
            genSequence.Sequence = wordsTxt.Text.Trim().Split(' ');
            wordSequencesResultRtb.Text += GenerateWordSequenceXml(genSequence);
        }

        private static String GenerateWordSequenceXml(WordSequence wordSequence)
        {
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(WordSequence));
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, wordSequence, emptyNamepsaces);
                return stream.ToString() + "\n\n\n";
            }





        }

        private static string ReadStreamToString(Stream stream)
        {
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }


    }
}
