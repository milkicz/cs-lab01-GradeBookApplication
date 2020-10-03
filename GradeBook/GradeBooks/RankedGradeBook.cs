using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook (string name, bool isWeight) : base(name, isWeight)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            var betterThanInput = 0;
            var twentyPerOfStudents = Students.Count / 5.0;
            foreach (var student in Students)
            {
                if (student.AverageGrade > averageGrade) betterThanInput += 1;
            }
            if (betterThanInput < twentyPerOfStudents)
                return 'A';
            else if (betterThanInput < twentyPerOfStudents * 2)
                return 'B';
            else if (betterThanInput < twentyPerOfStudents * 3)
                return 'C';
            else if (betterThanInput < twentyPerOfStudents * 4)
                return 'D';
            else
                return 'F';                 
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students");
            else
                base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students");
            else
                base.CalculateStudentStatistics(name);
        }
    }
}
