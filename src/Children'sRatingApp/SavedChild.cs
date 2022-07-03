using System;
using System.Collections.Generic;
using System.IO;

namespace Children_sRatingApp
{
    public class SavedChild : ChildrenBase
    {
        const string FileNameName = "Rate.txt";
        const string FileNameAudit = "_Audit.txt";
        DateTime actualTime = DateTime.UtcNow;

        public SavedChild(string name) : base(name)
        {
        }

        public override event RateAddedDelegate RateAdded;

        public override List<double> RatingLists
        {
            get
            {
                return ratingList;
            }
        }

        private List<double> ratingList = new List<double>();


        public override void ChangeName(string newName)
        {
            bool checkName = false;
            foreach (var l in newName)
            {
                if (char.IsDigit(l))
                {
                    checkName = true;
                }
            }
            if (checkName)
            {
                Console.WriteLine("Invalid new name");
            }
            else
            {
                Name = newName;
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using (var reader = File.OpenText($"{Name}{FileNameName}"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            return result;
        }

        public override void AddRating(string rate)
        {
            int result;
            bool success = int.TryParse(rate, out result);
            if (success)
            {
                if (result > 0 && result < 3)
                {
                    CreateAndWriteFileWithEvent(result);
                }
                else if (result >= 3 && result <= 6)
                {
                    CreateAndWriteFile(result);
                }
                else
                {
                    Console.WriteLine("This grade is out of range. The range is 1-6 every half.");
                }
            }
            else if (!success)
            {
                if (rate == "1+" || rate == "2+" || rate == "3+" || rate == "4+" || rate == "5+")
                {
                    switch (rate)
                    {
                        case "1+":
                            CreateAndWriteFileWithEvent(1.5);
                        break;
                        case "2+":
                            CreateAndWriteFileWithEvent(2.5);
                            break;
                        case "3+":
                            CreateAndWriteFile(3.5);
                        break;
                        case "4+":
                            CreateAndWriteFile(4.5);
                            break;
                        case "5+":
                            CreateAndWriteFile(5.5);
                            break;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Invalid value");
                }
            }
        }

        public override void RemoveRating(string rate)
        {
            int result;
            bool success = int.TryParse(rate, out result);
            if (success)
            {
                if (result > 0 && result <= 6)
                {
                    DeleteRateMethod(result);
                }
                else
                {
                    Console.WriteLine("This grade is out of range. The range is 1-6 every half.");
                }
            }
            else if (!success)
            {
                if (rate == "1+" || rate == "2+" || rate == "3+" || rate == "4+" || rate == "5+")
                {
                    switch (rate)
                    {
                        case "1+":
                            DeleteRateMethod(1.5);
                            break;
                        case "2+":
                            DeleteRateMethod(2.5);
                            break;
                        case "3+":
                            DeleteRateMethod(3.5);
                            break;
                        case "4+":
                            DeleteRateMethod(4.5);
                            break;
                        case "5+":
                            DeleteRateMethod(5.5);
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Invalid value");
                }
            }
        }

        private void CreateAndWriteFileWithEvent(double result)
        {
            CreateAndWriteFile(result);

            if (RateAdded != null)
            {
                RateAdded(this, new EventArgs());
            }
        }

        private void CreateAndWriteFile(double result)
        {
            using (var writer = File.AppendText($"{Name}{FileNameName}"))
            {
                writer.WriteLine(result);
            }
            using (var writer = File.AppendText($"{Name}{FileNameAudit}"))
            {
                writer.WriteLine($"{actualTime}: {result}");
            }
        }

        private void DeleteRateMethod(double value)
        {
            WritingGradesIntoList();
            this.ratingList.Remove(value);
            DeleteAndRecreateFile();
        }

        public override void WritingGradesIntoList()
        {
            using (var reader = File.OpenText($"{Name}{FileNameName}"))
            {
                ratingList.Clear();
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    ratingList.Add(number);
                    line = reader.ReadLine();
                }
            }
        }

        private void DeleteAndRecreateFile()
        {
            File.Delete($"{Name}{FileNameName}");

            using (var writer = File.AppendText($"{Name}{FileNameName}"))
            {
                foreach (var item in ratingList)
                {
                    writer.WriteLine(item);
                }
            }
        }
    }
}