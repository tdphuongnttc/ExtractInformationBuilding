using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityModel
{

    class ModelGeometry
    {
        private int mId;
        private string mModelSerialNumber;
        private string mType;
        private string mIdCode;
        private string mIndex;
        private string mName;
        private string mContentVersionNumber;
        private string mObjectName;
        private string mObjectUuid;
        private string mObjectMode;
        private int mObjectLayerIndex;
        private int mObjectMaterialIndex;
        private string mMaterialSource;

        private double[] mStartPoint;
        private double[] mEndPoint;
        private List<double[]> mPolyLine = new List<double[]>();

        public ModelGeometry(List<string> dataModelGeometryInput)
        {

            this.mId = Int32.Parse(dataModelGeometryInput[0]);
            this.mModelSerialNumber = dataModelGeometryInput[1];
            this.mType = dataModelGeometryInput[2];
            this.mIdCode = dataModelGeometryInput[3];
            this.mIndex = dataModelGeometryInput[4];
            this.mName = dataModelGeometryInput[5];
            this.mContentVersionNumber = dataModelGeometryInput[6];
            this.mObjectName = dataModelGeometryInput[7];
            this.mObjectUuid = dataModelGeometryInput[8];
            this.mObjectMode = dataModelGeometryInput[9];
            this.mObjectLayerIndex = Int32.Parse(dataModelGeometryInput[10]);
            this.mObjectMaterialIndex = Int32.Parse(dataModelGeometryInput[11]);
            this.mMaterialSource = dataModelGeometryInput[12];
            this.mStartPoint = new double[3] { Convert.ToDouble(dataModelGeometryInput[13]), Convert.ToDouble(dataModelGeometryInput[14]), Convert.ToDouble(dataModelGeometryInput[15]) };
            this.mEndPoint = new double[3] { Convert.ToDouble(dataModelGeometryInput[16]), Convert.ToDouble(dataModelGeometryInput[17]), Convert.ToDouble(dataModelGeometryInput[18]) };

            for (int k = 1; k <= Int32.Parse(dataModelGeometryInput[19]); k++)
            {
                double[] pointarr = new double[3] { Convert.ToDouble(dataModelGeometryInput[19 + 3 * k - 2]), Convert.ToDouble(dataModelGeometryInput[19 + 3 * k - 1]), Convert.ToDouble(dataModelGeometryInput[19 + 3 * k]) };

                this.mPolyLine.Add(pointarr);
            }
        }

        /*
        * Print the information with the string.
        */
        public void showInformation(string a, string b)
        {
            Console.WriteLine("get " + a + " : " + b);
        }
        /*
         * Print the information with the string.
         */
        public void showintInformation(string a, int b)
        {
            Console.WriteLine("get " + a + " : " + b);
        }
        /*
        * Print the information of extrusion point.
        */
        public void showPoint(List<double[]> listarr)
        {

            if (listarr != null)
            {
                Console.WriteLine("The extrusion point is: ");
                foreach (var u in listarr.ElementAt(0))
                {
                    Console.WriteLine("start_point: " + u);
                }
                foreach (var u in listarr.ElementAt(1))
                {
                    Console.WriteLine("end_point: " + u);
                }
            }
            else
            {
                Console.WriteLine("No ON_Extrusion");
            }
        }
        /*
        * Print the information of extrusion point.
        */
        public void showPolyPoint(List<double[]> listPolyPoint)
        {

            if (listPolyPoint == null)
            {
                Console.WriteLine("No ON_Extrusion");
            }
            else
            {
                Console.WriteLine("The poly point is: ");
                foreach (var listPoly in listPolyPoint)
                {
                    foreach (var point in listPoly)
                    {
                        Console.WriteLine(point);
                    }
                }
                Console.ReadKey();
            }
        }
        public int getId()
        {
                  return this.mId;
        }
        public string getModel_serial_number()
        {
            return this.mModelSerialNumber;
        }
        public string getType()
        {
            return this.mType;
        }
        public string getIdcode()
        {
            return this.mIdCode;
        }
        public string getIndex()
        {
            return this.mIndex;
        }
        public string getName()
        {
            return this.mName;
        }
        public string getContent_version_number()
        {
            return this.mContentVersionNumber;
        }
        public string getObject_name()
        {
            return this.mObjectName;
        }
        public string getObject_uuid()
        {
            return this.mObjectUuid;
        }
        public string getObject_mode()
        {
            return this.mObjectMode;
        }
        public int getObject_layer_index()
        {
            return this.mObjectLayerIndex;
        }
        public int getObject_material_index()
        {
            return this.mObjectMaterialIndex;
        }
        public string getObject_material_source()
        {
            return this.mMaterialSource;
        }
        public double[] getStartPoint()
        {
            return this.mStartPoint;
        }
        public double[] getEndPoint()
        {
            return this.mEndPoint;
        }
        public List<double[]> getPolyPoint()
        {
            return this.mPolyLine;
        }


    }
}
