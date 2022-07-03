using System;
using System.Collections.Generic;

namespace Children_sRatingApp
{
    public delegate void RateAddedDelegate(object sender, EventArgs args);
    
    public class NamedObject
    {
        public NamedObject(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }

    public interface IChildren
    {
        void AddRating(string rate);
        void RemoveRating(string rate);
        void WritingFileIntoList();
        Statistics GetStatistics();
        string Name {get;}
        event RateAddedDelegate RateAdded;
        public List<double> RatingLists {get;}
    }
    
    public abstract class ChildrenBase : NamedObject, IChildren
    {
        public ChildrenBase(string name) :base(name)
        {
        }
        public abstract event RateAddedDelegate RateAdded;
        
        public abstract List<double> RatingLists {get;}

        public abstract void ChangeName(string newName);

        public abstract void AddRating(string rate);

        public abstract void RemoveRating(string rate);

        public abstract void WritingFileIntoList();

        public abstract Statistics GetStatistics();
    }
}