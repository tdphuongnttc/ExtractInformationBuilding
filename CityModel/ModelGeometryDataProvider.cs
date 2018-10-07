using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityModel
{
    class ModelGeometryDataProvider
    {

        private List<string> listDataModelGeometry = new List<string>();
        public int numberModelGeometry;

        public ModelGeometryDataProvider(List<string> list, int numberModelGeometry)
        {
            listDataModelGeometry = new List<string>(list);
            //list_ModelGeometry = new List<int>(list_ModelGeometry);
            this.numberModelGeometry = numberModelGeometry;
        }
        public List<string> parseModelGeometry(int ordi)
        {
            string h1 = Convert.ToString(ordi);
            string h2 = Convert.ToString(ordi + 1);
            int a = 0, b = 0;
            List<string> list = new List<string>();
            if (ordi < numberModelGeometry - 1)
            {
                for (int i = 0; i < listDataModelGeometry.Count; i++)
                {
                    if ((listDataModelGeometry[i].Contains("ModelGeometry" + " " + h1 + ":")))
                    {
                        a = i;
                    }
                    if ((listDataModelGeometry[i].Contains("ModelGeometry" + " " + h2 + ":")))
                    {
                        b = i;
                    }
                }
                for (int j = a; j < b; j++)
                {
                    Console.WriteLine(listDataModelGeometry[j]);
                    list.Add(listDataModelGeometry[j]);
                }
            }

            if (ordi == (numberModelGeometry - 1))
            {
                for (int i = 0; i < listDataModelGeometry.Count; i++)
                {
                    if ((listDataModelGeometry[i].Contains("ModelGeometry" + " " + h1 + ":")))
                    {
                        a = i;
                    }
                }
                for (int j = a; j < listDataModelGeometry.Count; j++)
                {
                    Console.WriteLine(listDataModelGeometry[j]);
                    list.Add(listDataModelGeometry[j]);
                }
            }
            return list;
        }
        public List<string> filterString(List<string> listModelGeometry)
        {
            List<string> listModelCharacter = new List<string>();
            listModelCharacter.Add(removeLastCharacter(getAfterCharacter_Space(listModelGeometry[0], 1)));
            listModelCharacter.Add(getAfterCharacter_nEqual(listModelGeometry[2], 1));
            listModelCharacter.Add(getAfterCharacter_nEqual(listModelGeometry[3], 1));
            listModelCharacter.Add(getAfterCharacter_nEqual(listModelGeometry[4], 1));
            listModelCharacter.Add(getAfterCharacter_nEqual(listModelGeometry[5], 1));
            listModelCharacter.Add(getAfterCharacter_nEqual(listModelGeometry[6], 1));
            listModelCharacter.Add(getAfterCharacter_nEqual(listModelGeometry[7], 1));
            listModelCharacter.Add(getAfterCharacter_nEqual(listModelGeometry[9], 1));
            listModelCharacter.Add(getAfterCharacter_nEqual(listModelGeometry[10], 1));
            listModelCharacter.Add(getAfterCharacter_nEqual(listModelGeometry[11], 1));
            listModelCharacter.Add(getAfterCharacter_nEqual(listModelGeometry[12], 1));
            listModelCharacter.Add(getAfterCharacter_nEqual(listModelGeometry[13], 1));
            listModelCharacter.Add(getAfterCharacter_nEqual(listModelGeometry[14], 1));
            if (listModelGeometry[16] == "ON_Extrusion:")
            {
                string h3 = listModelGeometry[16 + 1].Substring(listModelGeometry[16 + 1].LastIndexOf(':') + 3);
                string h2 = h3.Replace("(", ",");
                string h1 = deleteCurve(h2);
                List<string> coordinate_path = h1.Split(',').ToList<string>();
                for (int j = 0; j < 6; j++)
                {
                    listModelCharacter.Add(coordinate_path[j]);
                }
                //Point Poly - 
                for (int i = 0; i < listModelGeometry.Count; i++)
                {
                    //Identify the Profile Count
                    string profileCount = listModelGeometry[24].Substring(listModelGeometry[24].LastIndexOf(':') + 2);
                    //Create list string
                    string stringline = getStringFromListString(listModelGeometry);
                    //Case Profile Count=1
                    if (Int32.Parse(profileCount)==1)
                    {
                        listModelCharacter.Add("Segment "+profileCount);
                        string d1 = listModelGeometry[26].Substring(listModelGeometry[26].LastIndexOf(',') + 1);
                        string d2 = d1.Remove(d1.Length - 1);
                        int number_point = 1 + Int32.Parse(d2);
                        listModelCharacter.Add(Convert.ToString(number_point));
                        for (int k = 1; k <= number_point; k++)
                        {
                            string p1 = deleteSpace(deleteCurve(getAfterCharacter_nEqual(listModelGeometry[26 + k], 1)));
                            string p2 = p1.Remove(p1.Length - 1);
                            List<string> coordinatePoly = p2.Split(',').ToList<string>();
                            for (int l = 0; l < 3; l++)
                            {
                                listModelCharacter.Add(coordinatePoly[l]);
                            }
                        }
                    }
                    //Case Profile Count >1
                    else
                    {
                        //Create list with ordinate line of Segment
                        List<int> ordinateLineSegment = new List<int>();                        
                        for (int line = 0; line < listModelGeometry.Count; line++)
                        {
                            if (listModelGeometry[line].Contains("Segment"))
                            {
                                ordinateLineSegment.Add(line);
                            }
                        }
                        
                        int a = ordinateLineSegment[0];
                        int b = ordinateLineSegment[1];
                        //Create two list string to store data point segmentOne and segmentTwo
                        List<string> segmentOne = new List<string>();
                        List<string> segmentTwo = new List<string>();
                        for (int j = a+2; j < b; j++)
                        {
                            segmentOne.Add(listDataModelGeometry[j]);
                            
                        }
                        for (int u=b+2; u < listModelGeometry.Count-1; u++)
                        {
                            segmentTwo.Add(listDataModelGeometry[u]);
                        }
                        

                        for (int m = 0; m < listModelGeometry.Count; m++)
                        {

                            if(listModelGeometry[m].Contains("Segment"))
                            {
                                int Segment = m;
                                listModelCharacter.Add("Segment 1");
                                string d1 = listModelGeometry[m+1].Substring(listModelGeometry[m+1].LastIndexOf(',') + 1);
                                string d2 = d1.Remove(d1.Length - 1);
                                int number_point = 1 + Int32.Parse(d2);
                                listModelCharacter.Add(Convert.ToString(number_point));
                                for (int k = 1; k <= number_point; k++)
                                {
                                    string p1 = deleteSpace(deleteCurve(getAfterCharacter_nEqual(listModelGeometry[m+1 + k], 1)));
                                    string p2 = p1.Remove(p1.Length - 1);
                                    List<string> coordinatePoly = p2.Split(',').ToList<string>();
                                    for (int l = 0; l < 3; l++)
                                    {
                                        listModelCharacter.Add(coordinatePoly[l]);
                                    }
                                }
                            }
                        }
                    }
                }

               
               
            }

            return listModelCharacter;
        }
        
        private string getStringFromListString(List<string> listModelGeometry)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string lines in listModelGeometry) // Loop through all strings
            {
                builder.Append(lines).Append("\n"); // Append string to StringBuilder
            }
            string result = builder.ToString();
            return result;
        }
        
          

    /*
    * Get character after = n character
    */
    private string getAfterCharacter_nEqual(string str, int n)
        {
            string result;
            return result = str.Substring(str.LastIndexOf('=') + n);
        }
        private string getAfterCharacter_Space(string str, int n)
        {
            string result;
            return result = str.Substring(str.LastIndexOf(" ") + n);
        }
        private string removeLastCharacter(string str)
        {
            string result;
            return result = str.Remove(str.Length - 1);
        }
        /*
        * Delete space in the string
        */
        public string deleteSpace(string a)
        {
            string[] b = a.Split(' ');
            string c = "";
            for (int i = 0; i < b.Length - 1; i++)
            {
                if (!b[i].Equals(" "))
                {
                    c += b[i];
                }
            }
            return c;
        }
        /*
         * Delete the brackets ( or )
         */
        private string deleteCurve(string a)
        {
            var h = new StringBuilder();
            foreach (char c in a)
            {
                if ((!(c == '(')) && (!(c == ')')))
                {
                    h.Append(c);
                }
            }
            return h.ToString();
        }
        /*
        * Replace the character 10 in the string by ,
        */
        private string replace(string a)
        {
            StringBuilder sb = new StringBuilder(a);
            sb[10] = ',';
            return sb.ToString();
        }

    }

}
