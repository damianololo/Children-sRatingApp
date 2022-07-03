using System;
using System.Collections.Generic;

namespace Children_sRatingApp
{
    public abstract class ChildrenBase : NamedObject, IChildren
    {
        public ChildrenBase(string name) : base(name)
        {
        }
        public abstract event RateAddedDelegate RateAdded;

        public abstract List<double> RatingLists { get; }

        public abstract void ChangeName(string newName);

        public abstract void AddRating(string rate);

        public abstract void RemoveRating(string rate);

        public abstract void WritingGradesIntoList();

        public abstract Statistics GetStatistics();
    }
}