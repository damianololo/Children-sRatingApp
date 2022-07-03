using System;
using System.Collections.Generic;

namespace Children_sRatingApp
{
    public delegate void RateAddedDelegate(object sender, EventArgs args);

    public interface IChildren
    {
        void AddRating(string rate);
        void RemoveRating(string rate);
        void WritingGradesIntoList();
        Statistics GetStatistics();
        string Name {get;}
        event RateAddedDelegate RateAdded;
        public List<double> RatingLists {get;}
    }
}