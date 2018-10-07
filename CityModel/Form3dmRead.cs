using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityModel
{
    public partial class Form3dmRead : Form
    {
        public Form3dmRead()
        {
            InitializeComponent();

            mModelGeometryList = new List<ModelGeometry>();
        }

        private void btnBrowse3dm_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "3dm files (*.3dm)|*.3dm|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbFilename.Text = openFileDialog1.FileName;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtb3dmReport.Clear();
        }

        private void btnDump_Click(object sender, EventArgs e)
        {
            if (tbFilename.Text != "")
            {
                rtbStatus.AppendText("Dump started.\n");
                rtbStatus.Update();

                try
                {
                    m_f3dm = Rhino.FileIO.File3dm.Read(tbFilename.Text);
                    rtbStatus.AppendText("Read 3dm from " + tbFilename.Text + " successfully\n");
                }
                catch (Exception ex)
                {
                    m_f3dm = null;
                    rtbStatus.AppendText("Can't read " + tbFilename.Text + "\n");
                    rtbStatus.AppendText("Error: " + ex.ToString() + "\n");
                }
            }
            else
                rtbStatus.AppendText("Text field name is empty. Can't read.\n");

            if (m_f3dm != null)
            {
                rtb3dmReport.AppendText(m_f3dm.Dump() + "\n");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Txt|*.txt";
            saveFileDialog1.Title = "Save dumping to text file";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog1.FileName != "")
            {
                // Saves the text via a FileStream created by the OpenFile method.  
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();

                byte[] info = new UTF8Encoding(true).GetBytes(rtb3dmReport.Text);
                fs.Write(info, 0, info.Length);

                fs.Close();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (m_f3dm != null)
            {
                //    //foreach (object o in m_f3dm.Objects)
                //    //{
                //    //    rtb3dmReport.AppendText(o.ToString());
                //    //}

                Rhino.FileIO.File3dmObjectTable table = m_f3dm.Objects;
                Rhino.FileIO.File3dmObject[] f3dmo0 = table.FindByLayer("material");

                List<Rhino.FileIO.File3dmObject> list_objects = table.ToList<Rhino.FileIO.File3dmObject>();

                Rhino.FileIO.File3dmObject[] array_objects = table.ToArray<Rhino.FileIO.File3dmObject>();

                IEnumerator<Rhino.FileIO.File3dmObject> enu = table.GetEnumerator();

                //    //rtb3dmReport.AppendText(list_objects.Count.ToString());
                //    //rtb3dmReport.AppendText(list_objects[1970].ToString());
                //    //rtb3dmReport.AppendText(list_objects[100].Geometry.ToString());

                Rhino.FileIO.File3dmObject f3dmo = table.ElementAt<Rhino.FileIO.File3dmObject>(0);

                Rhino.Geometry.Extrusion ge = new Rhino.Geometry.Extrusion();


                //    foreach (Rhino.FileIO.File3dmObject f3dmo in list_objects)
                //    {
                //        try
                //        {
                //            //Rhino.Geometry.Extrusion eo = (Rhino.Geometry.Extrusion)f3dmo.Geometry;
                //            //rtb3dmReport.AppendText(eo.ToString());

                //            //Rhino.DocObjects.RhinoObject ro = (Rhino.DocObjects.RhinoObject)f3dmo;
                //        }
                //        catch (Exception ex)
                //        {
                //            //rtb3dmReport.AppendText(ex.ToString());
                //            //rtb3dmReport.AppendText("object " + f3dmo.Id.ToString() + " is not ON_Extrusion\n");
                //        }
                //    }
            }
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            rtbStatus.Clear();
            var lineCount = 0; 
            string line = string.Empty;
            //Create list_ModelGeometry with no line null            
            List<int> linenumber_ModelGeometry = new List<int>();

            //Create list with key = line number; value = line
            Dictionary<int, string> dic_Content = new Dictionary<int, string>();

            //Read rtb3dmReport from the form
            TextReader readerlines = new System.IO.StringReader(rtb3dmReport.Text);
            {
                //delete empty space , store in list_Content
                while ((line = readerlines.ReadLine()) != null)
                {
                    if ((line != null) && (line != ""))
                    {
                        lineCount++;
                        dic_Content.Add(lineCount, line);
                        if (line.Contains("ModelGeometry") && (!line.Contains("table")) && (line.Contains(":")))
                        {
                            linenumber_ModelGeometry.Add(lineCount);
                        }
                    }
                }

                //Print the number of ModelGeometry
                Console.Write(linenumber_ModelGeometry.Count + "\n"); 
                //Print number of line of all ModelGeometry
                Console.Write(dic_Content.Count + "\n");
                //Font myfont = new Font("Times New Roman", 7.0f);
                //rtbStatus.Font = myfont;
                //System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Admin\Desktop\WriteLines222.txt");
                //Dictionary<int, string> ht1 = new Dictionary<int, string>();
                
                //Create the list of string with ModelGeometry string
                // to store all the meaningful lines in the data file
                List<string> list_Data_ModelGeometry = new List<string>(); 
                
                for (int i = 0; i < linenumber_ModelGeometry.Count - 1; i++) // Loop through List with for
                {
                    if (i < linenumber_ModelGeometry.Count - 2)
                    {
                        
                        int a = linenumber_ModelGeometry[i];
                        int b = linenumber_ModelGeometry[i + 1];
                        for (int j = a; j < b; j++)
                        {
                            string h= dic_Content[j] + "\n";
                            //rtbStatus.AppendText(h.TrimStart());                            
                            list_Data_ModelGeometry.Add(h.TrimStart().TrimEnd());
                            
                        }
                    }
                    else
                    {
                        for (int j = linenumber_ModelGeometry[i]; j < dic_Content.Count - 1; j++)
                        {
                            string h = dic_Content[j] + "\n";
                            //rtbStatus.AppendText(h.TrimStart());
                            list_Data_ModelGeometry.Add(h.TrimStart().TrimEnd());
                        }                        
                    }
                }
                ModelGeometryDataProvider dataPro = new ModelGeometryDataProvider(list_Data_ModelGeometry, linenumber_ModelGeometry.Count);
                // populate the model geometry container
                mModelGeometryList.Clear();
                for (int i = 0; i < linenumber_ModelGeometry.Count; ++i)
                {

                    List<String> parsedStrGeom = dataPro.parseModelGeometry(i);
                    List<string> strGeom = dataPro.filterString(parsedStrGeom);
                    
                    // check ON_Extrusion
                    if (parsedStrGeom[16] == "ON_Extrusion:")
                    {
                        ModelGeometry m = new ModelGeometry(strGeom);
                        mModelGeometryList.Add(m);
                    }

                }

                /*
                int numberModelgeometry = 706;

                List<string> mdl1 = dataPro.characterGeometry(dataPro.getModelGeometry(numberModelgeometry));
                ModelGeometry m = new ModelGeometry(mdl1);

                m.showintInformation("Id", m.getId());
                m.showInformation("model serial number", m.getModel_serial_number());
                m.showInformation("type", m.getType());
                m.showInformation("Id code", m.getIdcode());
                m.showInformation("index", m.getIndex());
                m.showInformation("name", m.getName());
                m.showInformation("content version number", m.getContent_version_number());
                m.showInformation("object name", m.getObject_name());
                m.showInformation("object uuid", m.getObject_uuid());
                m.showInformation("object mode", m.getObject_mode());
                m.showintInformation("object layer index", m.getObject_layer_index());
                m.showintInformation("object object material", m.getObject_material_index());
                m.showInformation("object material source", m.getObject_material_source());
                //m.showPoint(m.getPath());            
                //m.showPolyPoint(m.getPolyPoint());
                */

                rtbStatus.AppendText("Parse completed.");



            }                        
        }
    }
}
