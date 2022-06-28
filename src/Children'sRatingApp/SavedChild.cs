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
                throw new NotImplementedException("This command is not available");
            }
        }

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
            if (success == true)
            {
                if (result > 0 && result < 3)
                {
                    using (var writer = File.AppendText($"{Name}{FileNameName}"))
                    {
                        writer.WriteLine(result);
                    }
                    using (var writer = File.AppendText($"{Name}{FileNameAudit}"))
                    {
                        writer.WriteLine($"{actualTime}: {result}");
                    }

                    if (RateAdded != null)
                    {
                        RateAdded(this, new EventArgs());
                    }
                }
                else if (result >= 3 && result <= 6)
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
                else
                {
                    Console.WriteLine("This grade is out of range. The range is 1-6 every half.");
                }
            }
            else if (success == false)
            {
                if (rate == "1+" || rate == "2+" || rate == "3+" || rate == "4+" || rate == "5+")
                {
                    switch (rate)
                    {
                        case "1+":
                            using (var writer = File.AppendText($"{Name}{FileNameName}"))
                            {
                                writer.WriteLine(1.5);
                            }
                            using (var writer = File.AppendText($"{Name}{FileNameAudit}"))
                            {
                                writer.WriteLine($"{actualTime}: {1.5}");
                            }
                            if (RateAdded != null)
                            {
                                RateAdded(this, new EventArgs());
                            }
                        break;
                        case "2+":
                            using (var writer = File.AppendText($"{Name}{FileNameName}"))
                            {
                                writer.WriteLine(2.5);
                            }
                            using (var writer = File.AppendText($"{Name}{FileNameAudit}"))
                            {
                                writer.WriteLine($"{actualTime}: {2.5}");
                            }
                            if (RateAdded != null)
                            {
                                RateAdded(this, new EventArgs());
                            }
                        break;
                        case "3+":
                            using (var writer = File.AppendText($"{Name}{FileNameName}"))
                            {
                                writer.WriteLine(3.5);
                            }
                            using (var writer = File.AppendText($"{Name}{FileNameAudit}"))
                            {
                                writer.WriteLine($"{actualTime}: {3.5}");
                            }
                        break;
                        case "4+":
                            using (var writer = File.AppendText($"{Name}{FileNameName}"))
                            {
                                writer.WriteLine(4.5);
                            }
                            using (var writer = File.AppendText($"{Name}{FileNameAudit}"))
                            {
                                writer.WriteLine($"{actualTime}: {4.5}");
                            }
                        break;
                        case "5+":
                            using (var writer = File.AppendText($"{Name}{FileNameName}"))
                            {
                                writer.WriteLine(5.5);
                            }
                            using (var writer = File.AppendText($"{Name}{FileNameAudit}"))
                            {
                                writer.WriteLine($"{actualTime}: {5.5}");
                            }
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
            throw new NotImplementedException("In progress...");
        }
    }
}