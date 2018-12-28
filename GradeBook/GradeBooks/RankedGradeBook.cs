using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            var top20 = (int)(Students.Count * 0.2);
            var grades = Students.OrderByDescending(o => o.AverageGrade).Select(o => o.AverageGrade).ToList();
            if (grades[top20 - 1] <= averageGrade)
                return 'A';
            else if (grades[(top20 * 2) - 1] <= averageGrade)
                return 'B';
            else if (grades[(top20 * 3) - 1] <= averageGrade)
                return 'C';
            else if (grades[(top20 * 4) - 1] <= averageGrade)
                return 'D';

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }

            base.CalculateStatistics();
        }
            
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
