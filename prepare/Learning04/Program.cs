using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment Assignment1 = new Assignment("Vaughn Palmer", "Test");
        Assignment1.GetSummary();
        MathAssignment MathAssignment1 = new MathAssignment("Vaughn Palmer", "Math", "7.3", "8-19");
        MathAssignment1.GetSummary();
        MathAssignment1.GetHomeworkList();
        WritingAssignment WritingAssignment1 = new WritingAssignment("Vaughn Palmer", "Writing", "The Cause of World War II");
        WritingAssignment1.GetSummary();
        WritingAssignment1.GetWritingInformation();
    }
}