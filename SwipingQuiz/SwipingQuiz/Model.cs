using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.ComponentModel;
using Xamarin.Forms;
using System.Windows.Input;

namespace SwipingQuiz
{
    class Model
    {
        private string[] image;
        private int points = 0;
        private char code;

        public Model()
        {
            points = 0;
            code = ' ';
        }

        public void Add(int point)
        {
            points += point;
        }

        public int GetTotalPoints()
        {
            return points;
        }

        public char GetCode(int points)
        {
            CalculatePointCode(points);
            return code;
        }

        private void CalculatePointCode(int point)
        {
            points = point;
            if (points <= 6)
                code = 'G';
            else if (points > 6 && points <= 9)
                code = 'L';
            else if (points > 9 && points <= 12)
                code = 'A';
            else if (points > 12)
                code = 'W';
        }

        public string GetRandomImage(string[] myImages)
        {
            int size = myImages.Length-1;
            Random random = new Random();
            int i = random.Next(0, size);

            return myImages[i].ToString();
        }
    }
}
