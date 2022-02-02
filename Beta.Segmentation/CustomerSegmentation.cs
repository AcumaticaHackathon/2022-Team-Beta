using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections;
using System.Data;
using Accord.IO;
using PX.Data;
using Accord;
using Accord.Controls;
using Accord.IO;
using Accord.MachineLearning;
using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Math;
using Accord.Math.Distances;
using Accord.Statistics;
using Accord.Statistics.Analysis;
using Accord.Statistics.Distributions.Fitting;
using Accord.Statistics.Kernels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using PX.Commerce.Core;
using PX.Data.BQL.Fluent;
using ZedGraph;

using TClustering = Accord.MachineLearning.IMulticlassClassifier<double[], int>;
using TLearning = Accord.MachineLearning.IUnsupervisedLearning<
    Accord.MachineLearning.IMulticlassClassifier<double[], int>, double[], int>;

namespace Beta.Segmentation
{
        public class CustomerSegmentation : PXGraph<CustomerSegmentation>
        {
            public PXFilter<TrainingInput> TrainingInput;

            public PXAction<TrainingInput> createClusteringAC;

            [PXButton]
            [PXUIField(DisplayName = "Create clustering")]
            public IEnumerable CreateClusteringAC(PXAdapter adapter)
            {
                var dataValues2 = SelectFrom<AcumaticaData>.View.Select(this).ToList().Select(a => a.GetItem<AcumaticaData>())
                    .OrderBy(t =>  t.X).ThenBy(t => t.Y).ThenBy(t => t.Z).ThenBy(t => t.W).ToList();

                double[,] table = new double[dataValues2.Count, 4];

                int z = 0;
                foreach (AcumaticaData acumaticaData in dataValues2)
                {
                    table[z, 0] = (double)acumaticaData.X.Value;
                    table[z, 1] = (double)acumaticaData.Y.Value;
                    table[z, 2] = (double)acumaticaData.Z.Value;
                    table[z, 3] = (double)acumaticaData.Z.Value;
                    z++;
                }

                
                double[][] inputs = table.GetColumns(0, 1).ToJagged();

                QLearning learning;
                TClustering clustering;




                try
                {
                    // Create and run the specified algorithm
                    var learning1 = new KMeans(TrainingInput.Current.GroupsQuant.Value);

                    clustering = learning1.Learn(inputs);
                    
                    createSurface(table, clustering);

                    var output = clustering.Decide(inputs);

                    ScatterplotView scatterplotView2 = new ScatterplotView();
                    scatterplotView2.DataSource = inputs.InsertColumn(output);
                    scatterplotView2.Graph.Text = "1111111111111";
                    SizeF sz = new SizeF(354 * 2, 230 * 2);
                    scatterplotView2.Graph.Scale(sz);
                    var im = scatterplotView2.Graph.GetImage();
                    

                    im.Save("D:\\Instances\\21.206.0024\\hack2022\\Icons\\" + imageRes);

                }
                catch (ConvergenceException)
                {
                    //lbStatus.Text = "Convergence could not be attained. " +
                    //                "The learned clustering might still be usable.";
                }


                var gr = PXGraph.CreateInstance<CustomerSegmentation>();
                gr.TrainingInput.Current.GroupsQuant = TrainingInput.Current.GroupsQuant.Value;

                PXRedirectHelper.TryRedirect(gr, PXRedirectHelper.WindowMode.Same);

                return adapter.Get();
            }



            private string imageRes = "imgRes.png";
            private string imageClass = "img.png";

            private void createSurface(double[,] table, TClustering clustering)
            {
                // Get the ranges for each variable (X and Y)
                DoubleRange[] ranges = table.GetRange(0);

                // Generate a Cartesian coordinate system
                double[][] map = Matrix.Mesh(ranges[0], 200, ranges[1], 200);

                // Classify each point in the Cartesian coordinate system
                double[] result = clustering.Decide(map).ToDouble();
                double[,] surface = map.ToMatrix().InsertColumn(result);
                ScatterplotView scatterplotView3 = new ScatterplotView();
                scatterplotView3.DataSource = surface;
                scatterplotView3.Graph.Text = "Splitting by groups";
                SizeF sz = new SizeF(354 * 2, 230 * 2);
                scatterplotView3.Graph.Scale(sz);
                var im = scatterplotView3.Graph.GetImage();
                

                im.Save("D:\\Instances\\21.206.0024\\hack2022\\Icons\\" + imageClass);
            }


            
            

            public PXFilter<MasterTable> MasterView;
            public SelectFrom<AcumaticaData>.OrderBy<Asc<AcumaticaData.x>, Asc<AcumaticaData.y>, Asc< AcumaticaData.z>, Asc<AcumaticaData.w>>.View DetailsView;

            [Serializable]
            public class MasterTable : IBqlTable
            {

            }

            [Serializable]
            public class DetailsTable : IBqlTable
            {

            }
        }


        public class TrainingInput : IBqlTable
        {
            #region GroupsQuant
            public abstract class groupsQuant : PX.Data.BQL.BqlInt.Field<groupsQuant> { }
            
            [PXDBInt()]
            [PXDefault(3)]
            [PXUIField(DisplayName = "Groups quantity", Visible = true)]
            public virtual Int32? GroupsQuant
            {
                get; set;
            }
            #endregion

    }
}
