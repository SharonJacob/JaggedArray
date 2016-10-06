/**
 * Group 07
 * Assignment 08
 * Angileena Jacob
 * Vimal Anusha Sharon Jacob
 * Ismail Mohammed Hanif Shaikh
 **/
using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace JaggedArray
{
    public class ScoresVM : INotifyPropertyChanged
    {
        #region Constants
        private const string DATA_PATH_SEC_ONE = @"Scores_data\Section1.txt";
        private const string DATA_PATH_SEC_TWO = @"Scores_data\Section2.txt";
        private const string DATA_PATH_SEC_THREE = @"Scores_data\Section3.txt";
        private const int SECTION_ONE_STUDENTS = 12;
        private const int SECTION_TWO_STUDENTS = 8;
        private const int SECTION_THREE_STUDENTS = 10;
        #endregion

        #region properties
        private double _avgsectionmarksone;
        public double AvgSectionMarksOne {
        get { return _avgsectionmarksone; }
        set { _avgsectionmarksone = value; OnPropertyChanged(); }
        }

        private double _avgsectionmarkstwo;
        public double AvgSectionMarksTwo {
        get { return _avgsectionmarkstwo; }
        set { _avgsectionmarkstwo = value; OnPropertyChanged(); }
        }
        
        private double _avgsectionmarksthree;
        public double AvgSectionMarksThree {
        get { return _avgsectionmarksthree; }
        set { _avgsectionmarksthree = value; OnPropertyChanged(); }
        }

        List<FirstScores> _firstscores;
        public List<FirstScores> FirstScores {
        get { return _firstscores; }
        set { _firstscores = value; OnPropertyChanged(); }
        }

        List<SecondScores> _secondscores;
        public List<SecondScores> SecondScores
        {
            get { return _secondscores; }
            set { _secondscores = value; OnPropertyChanged(); }
        }

        List<ThirdScores> _thirdscores;
        public List<ThirdScores> ThirdScores
        {
            get { return _thirdscores; }
            set { _thirdscores = value; OnPropertyChanged(); }
        }

        private double _totalavg;
        public double TotalAvg {
        get { return _totalavg; }
        set { _totalavg = Math.Round(value,2); OnPropertyChanged(); }
        }

        private double _highestscore;
        public double HighestScore {
        get { return _highestscore; }
        set { _highestscore = value; OnPropertyChanged(); }
        }

        private double _leastscore;
        public double LeastScore {
        get { return _leastscore; }
        set { _leastscore = value; OnPropertyChanged(); }
        }

        private string _highestscoresec;
        public string HighestScoreSec
        {
            get { return _highestscoresec; }
            set { _highestscoresec = value; OnPropertyChanged(); }
        }

        private string _leastscoresec;
        public string LeastScoreSec
        {
            get { return _leastscoresec; }
            set { _leastscoresec = value; OnPropertyChanged(); }
        }
        #endregion

        #region Constructor
        public ScoresVM() {

            HighestScoreSec = string.Empty;
            LeastScoreSec = string.Empty;

            double[][] secscores = new double[3][];
            
            double sumsectionmarksone = 0;
            double sumsectionmarkstwo = 0;
            double sumsectionmarksthree = 0;

            List<FirstScores> tmp1 = new List<FirstScores>();
            List<SecondScores> tmp2 = new List<SecondScores>();
            List<ThirdScores> tmp3 = new List<ThirdScores>();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//AppDomain.CurrentDomain.BaseDirectory;
            string sectiononefile = Path.Combine(path, DATA_PATH_SEC_ONE);
            string sectiontwofile = Path.Combine(path, DATA_PATH_SEC_TWO);
            string sectionthreefile = Path.Combine(path, DATA_PATH_SEC_THREE);
            
            try {               

                if (File.Exists(sectiononefile))
                {
                    StreamReader sr = new StreamReader(sectiononefile);
                    string line = sr.ReadToEnd();
                    string[] lines = line.Split(new char[] { '\r','\n' }, StringSplitOptions.RemoveEmptyEntries);
                    secscores[0] = new double[lines.Length];
                    for (int idx = 0; idx < lines.Length; idx++)
                    {
                       secscores[0][idx] = double.Parse(lines[idx]) ;
                       sumsectionmarksone = sumsectionmarksone + secscores[0][idx];
                        tmp1.Add(new FirstScores() { FirstSection = secscores[0][idx] } );
                    }
                    _avgsectionmarksone = sumsectionmarksone/lines.Length;
                }

                if (File.Exists(sectiontwofile))
                {
                    StreamReader sr = new StreamReader(sectiontwofile);
                    string line = sr.ReadToEnd();
                    string[] lines = line.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    secscores[1] = new double[lines.Length];
                    int num1 = lines.Length;
                    for (int idx = 0; idx < lines.Length; idx++)
                    {
                        secscores[1][idx] = double.Parse(lines[idx]);
                        sumsectionmarkstwo = sumsectionmarkstwo + secscores[1][idx];
                        tmp2.Add(new SecondScores() { SecondSection = secscores[1][idx] });
                    }
                    _avgsectionmarkstwo = sumsectionmarkstwo / lines.Length;
                }

                if (File.Exists(sectionthreefile))
                {
                    StreamReader sr = new StreamReader(sectionthreefile);
                    string line = sr.ReadToEnd();
                    string[] lines = line.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    secscores[2] = new double[lines.Length];
                    for (int idx = 0; idx < lines.Length; idx++)
                    {
                        secscores[2][idx] = double.Parse(lines[idx]);
                        sumsectionmarksthree = sumsectionmarksthree + secscores[2][idx];
                        tmp3.Add(new ThirdScores() { ThirdSection = secscores[2][idx] });
                    }
                    _avgsectionmarksthree = sumsectionmarksthree / lines.Length;
                }

                _totalavg = (sumsectionmarksone + sumsectionmarkstwo + sumsectionmarksthree)/30;
                        
                FirstScores = new List<FirstScores>(tmp1);
                SecondScores = new List<SecondScores>(tmp2);
                ThirdScores = new List<ThirdScores>(tmp3);

                //Logic to get Highest and least Scores
                double[] highscores = new double[3];
                double[] leastscores = new double[3];
                for (int i = 0; i < secscores.Length; i++)
                {
                    highscores[i] = secscores[i].Max();
                    leastscores[i] = secscores[i].Min();
                }
                HighestScore = highscores.Max();
                LeastScore = leastscores.Min();

                
                //Logic to get the Highest and least scored sections
                for(int i = 0; i < highscores.Length; i++)
                {
                    if(highscores[i] == HighestScore)
                    {
                        int pos = i + 1;
                        if(HighestScoreSec == string.Empty)
                        {
                            HighestScoreSec = HighestScoreSec + pos;
                        }
                        else
                        {
                            HighestScoreSec = HighestScoreSec + "," + pos;
                        }                        
                    }

                    if(leastscores[i] == LeastScore)
                    {
                        int pos = i + 1;
                        if(LeastScoreSec == string.Empty)
                        {
                            LeastScoreSec = LeastScoreSec + pos;
                        }
                        else
                        {
                            LeastScoreSec = LeastScoreSec + "," + pos;
                        }
                        
                    }
                }
                
            }
            catch {
                //Handles Exceptions
            }
            
            }
        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
         protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
         {
             if (PropertyChanged != null)
             {
                 PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
             }
         } 
        #endregion
    }
}
