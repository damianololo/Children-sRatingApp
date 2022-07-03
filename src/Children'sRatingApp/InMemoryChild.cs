using System;
using System.Collections.Generic;

namespace Children_sRatingApp
{
    public class InMemoryChild : ChildrenBase
    {
        public override event RateAddedDelegate RateAdded;

        private List<double> ratingLists = new List<double>();

        public override List<double> RatingLists
        {
            get
            {
                return this.ratingLists;
            }
        }
        
        public InMemoryChild(string name) :base(name)
        {
        }

        public override void WritingGradesIntoList()
        {
            var n = 1;
            foreach (var item in ratingLists)
            {
                Console.WriteLine($"No.{n}:  {item}");
                n++;
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

        public override void AddRating(string rate)
        {
            int result;
            bool success = int.TryParse(rate, out result);
            if (success == true)
            {
                if (result > 0 && result < 3)
                {
                    this.ratingLists.Add(result);
                    if (RateAdded != null)
                    {
                        RateAdded(this, new EventArgs());
                    }
                }
                else if (result >= 3 && result <= 6)
                {
                    this.ratingLists.Add(result);
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
                            this.ratingLists.Add(1.5);
                            if (RateAdded != null)
                            {
                                RateAdded(this, new EventArgs());
                            }
                        break;
                        case "2+":
                            this.ratingLists.Add(2.5);
                            if (RateAdded != null)
                            {
                                RateAdded(this, new EventArgs());
                            }
                        break;
                        case "3+":
                            this.ratingLists.Add(3.5);
                        break;
                        case "4+":
                            this.ratingLists.Add(4.5);
                        break;
                        case "5+":
                            this.ratingLists.Add(5.5);
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
            if (success == true)
            {
                if (result > 0 && result <= 6)
                {
                    ratingLists.Remove(result);
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
                            this.ratingLists.Remove(1.5);
                        break;
                        case "2+":
                            this.ratingLists.Remove(2.5);
                        break;
                        case "3+":
                            this.ratingLists.Remove(3.5);
                        break;
                        case "4+":
                            this.ratingLists.Remove(4.5);
                        break;
                        case "5+":
                            this.ratingLists.Remove(5.5);
                        break;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Invalid value");
                }
            }
        }
        
        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            for (var index = 0; index < ratingLists.Count; index++)
            {
                result.Add(ratingLists[index]);
            }
            return result;
        }
    }
}