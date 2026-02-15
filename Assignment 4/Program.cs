using System.Text;

namespace Assignment_4
{
    internal class Program
    {
     
        static double CalculateAverage(List<double> grades)
        {
            double sum = 0;
            for(int i = 0; i < grades.Count; i++)
            {
                sum += grades[i];
            }
            return sum / grades.Count;
        }
        static GradeLevel DetermineGrade(double average)
        {
            if (average >= 60)
            {
                return GradeLevel.Senior;
            }
            else if (average >= 40)
            {
                return GradeLevel.Junior;
            }
            else if (average >= 20)
            {
                return GradeLevel.Sophomore;
            }
            else  
            {
                return GradeLevel.Freshman;
            }
           
        }
        enum GradeLevel
        {
            Freshman,
            Sophomore,
            Junior, 
            Senior
        }
        static void Main(string[] args)
        {
            Enum GradeLevel;
           Dictionary<string, List<double>> studentGrades = new Dictionary<string, List<double>>();
            int maxStudents = 5;
            for (int i = 0; i < maxStudents; i++)
            {
                Console.Write($"Enter the name of student {i + 1} or -1 to stop: ");
                string name = Console.ReadLine();
                if (name == "-1")
                {
                    break;
                }
                List<double> grades = new List<double>();
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"Enter grade {j + 1} for {name}: ");
                    double grade;
                    while (!double.TryParse(Console.ReadLine(), out grade))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number: ");
                    }
                    grades.Add(grade);
                }
                studentGrades[name] = grades;
            }
            StringBuilder report = new StringBuilder();
            for(int i = 0; i < studentGrades.Count; i++)
            {
               double average = CalculateAverage(studentGrades.Values.ElementAt(i));
                var gradeLevel = DetermineGrade(average);
                report.AppendLine($"{studentGrades.Keys.ElementAt(i)}: Average Grade = {average:F2}, Grade Level = {gradeLevel}");
            }
            Console.WriteLine($"\nStudent Report:\n{report}");
        }
    }
}

    

