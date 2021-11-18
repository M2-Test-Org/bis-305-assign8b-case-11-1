using Xunit;
using System.IO;
using System;
using System.Text;

public class TestAssign8B11_1Case
{

    [Fact]
    public void TestCase()
    {
        //Sets the Out property to target the TextWriter object. Note that the System.IO.StringWriter is 
        //derived from TextWriter. The TextWriter class is an abstract class. Therefore, you do not 
        //instantiate it in your code.
        //The StreamWriter class derives from TextWriter and provides implementations of the members for 
        //writing to a stream. 
        var output = new StringWriter();
        Console.SetOut(output);

        //Sets the In property to the specified TextReader object. System.IO.StringReader is derived
        //from TextReader. The TextReader class is an abstract class. Therefore, you do not instantiate 
        //it in your code.
        //The StreamReader class derives from TextReader and provides implementations of the 
        //members for reading from a stream.
        //Use case 1
        var contestantErrorNumber1 = "31";
        var contestantErrorNumber2 = "-1";
        var contestantNumber = "3";
        var contestant1Name = "Jill";
        var contestant1TalentCode = "S";
        var contestant1Age = "10";
        var contestant2Name = "Mikia";
        var contestant2TalentCode = "M";
        var contestant2Age = "15";
        var contestant3Name = "Sarah";
        var contestant3TalentCode = "D";
        var contestant3Age = "25";
        var firstTalentCodeToObserve = "S";
        var secondTalentCodeToObserve = "D";
        var thirdTalentCodeToObserve = "M";
        var fourthTalentCodeToObserve = "O";
        var endInput = "Z";
        //separte multiple inputs with a new line break
        var stringReaderInput = new StringBuilder();
        //invalid entries
        stringReaderInput.Append(contestantErrorNumber1);
        stringReaderInput.Append(Environment.NewLine);
        stringReaderInput.Append(contestantErrorNumber2);
        stringReaderInput.Append(Environment.NewLine);
        //valid entry
        stringReaderInput.Append(contestantNumber);
        stringReaderInput.Append(Environment.NewLine);
        //contestant 1
        stringReaderInput.Append(contestant1Name);
        stringReaderInput.Append(Environment.NewLine);
        stringReaderInput.Append(contestant1TalentCode);
        stringReaderInput.Append(Environment.NewLine);
        stringReaderInput.Append(contestant1Age);
        stringReaderInput.Append(Environment.NewLine);
        //contestant 2
        stringReaderInput.Append(contestant2Name);
        stringReaderInput.Append(Environment.NewLine);
        stringReaderInput.Append(contestant2TalentCode);
        stringReaderInput.Append(Environment.NewLine);
        stringReaderInput.Append(contestant2Age);
        stringReaderInput.Append(Environment.NewLine);
        //contestant 3
        stringReaderInput.Append(contestant3Name);
        stringReaderInput.Append(Environment.NewLine);
        stringReaderInput.Append(contestant3TalentCode);
        stringReaderInput.Append(Environment.NewLine);
        stringReaderInput.Append(contestant3Age);
        stringReaderInput.Append(Environment.NewLine);
        //talent code entries to observe the contestant(s) with that talent
        stringReaderInput.Append(firstTalentCodeToObserve);
        stringReaderInput.Append(Environment.NewLine);
        stringReaderInput.Append(secondTalentCodeToObserve);
        stringReaderInput.Append(Environment.NewLine);
        stringReaderInput.Append(thirdTalentCodeToObserve);
        stringReaderInput.Append(Environment.NewLine);
        stringReaderInput.Append(fourthTalentCodeToObserve);
        stringReaderInput.Append(Environment.NewLine);
        //end input
        stringReaderInput.Append(endInput);

        var input = new StringReader(stringReaderInput.ToString());
        Console.SetIn(input);
        
        GreenvilleRevenue.Main();

        //use a string writer to format the expected outcome
        var expectedOutcome = new StringBuilder();
        expectedOutcome.Append("Enter number of contestants >> ");
        //expectedOutcome.AppendLine("Value does not fall within the expected range.");
        expectedOutcome.AppendLine("Number must be between 0 and 30");
        expectedOutcome.Append("Enter number of contestants >> ");
        //expectedOutcome.AppendLine("Value does not fall within the expected range.");
        expectedOutcome.AppendLine("Number must be between 0 and 30");
        expectedOutcome.Append("Enter number of contestants >> ");
        expectedOutcome.Append("Enter contestant name >> ");
        expectedOutcome.AppendLine("Talent codes are:");
        expectedOutcome.AppendLine("  S   Singing");
        expectedOutcome.AppendLine("  D   Dancing");
        expectedOutcome.AppendLine("  M   Musical instrument");
        expectedOutcome.AppendLine("  O   Other");
        expectedOutcome.Append("       Enter talent code >> ");
        expectedOutcome.Append("       Enter contestant's age >> ");
        expectedOutcome.Append("Enter contestant name >> ");
        expectedOutcome.AppendLine("Talent codes are:");
        expectedOutcome.AppendLine("  S   Singing");
        expectedOutcome.AppendLine("  D   Dancing");
        expectedOutcome.AppendLine("  M   Musical instrument");
        expectedOutcome.AppendLine("  O   Other");
        expectedOutcome.Append("       Enter talent code >> ");
        expectedOutcome.Append("       Enter contestant's age >> ");
        expectedOutcome.Append("Enter contestant name >> ");
        expectedOutcome.AppendLine("Talent codes are:");
        expectedOutcome.AppendLine("  S   Singing");
        expectedOutcome.AppendLine("  D   Dancing");
        expectedOutcome.AppendLine("  M   Musical instrument");
        expectedOutcome.AppendLine("  O   Other");
        expectedOutcome.Append("       Enter talent code >> ");
        expectedOutcome.Append("       Enter contestant's age >> ");
        expectedOutcome.AppendLine("");
        expectedOutcome.AppendLine("Revenue expected this year is $65.00");
        expectedOutcome.AppendLine("");
        expectedOutcome.AppendLine("The types of talent are:");
        expectedOutcome.AppendLine("S     Singing");
        expectedOutcome.AppendLine("D     Dancing");
        expectedOutcome.AppendLine("M     Musical instrument");
        expectedOutcome.AppendLine("O     Other");
        expectedOutcome.AppendLine("");
        expectedOutcome.AppendLine("Enter a talent type or Z to quit >> ");
        expectedOutcome.AppendLine("Contestants with talent Singing are:");
        expectedOutcome.AppendLine("Child Contestant Jill S   Fee $15.00");
        expectedOutcome.AppendLine("");
        expectedOutcome.AppendLine("The types of talent are:");
        expectedOutcome.AppendLine("S     Singing");
        expectedOutcome.AppendLine("D     Dancing");
        expectedOutcome.AppendLine("M     Musical instrument");
        expectedOutcome.AppendLine("O     Other");
        expectedOutcome.AppendLine("");
        expectedOutcome.AppendLine("Enter a talent type or Z to quit >> ");
        expectedOutcome.AppendLine("Contestants with talent Dancing are:");
        expectedOutcome.AppendLine("Adult Contestant Sarah D   Fee $30.00");
        expectedOutcome.AppendLine("");
        expectedOutcome.AppendLine("The types of talent are:");
        expectedOutcome.AppendLine("S     Singing");
        expectedOutcome.AppendLine("D     Dancing");
        expectedOutcome.AppendLine("M     Musical instrument");
        expectedOutcome.AppendLine("O     Other");
        expectedOutcome.AppendLine("");
        expectedOutcome.AppendLine("Enter a talent type or Z to quit >> ");
        expectedOutcome.AppendLine("Contestants with talent Musical instrument are:");
        expectedOutcome.AppendLine("Teen Contestant Mikia M   Fee $20.00");
        expectedOutcome.AppendLine("");
        expectedOutcome.AppendLine("The types of talent are:");
        expectedOutcome.AppendLine("S     Singing");
        expectedOutcome.AppendLine("D     Dancing");
        expectedOutcome.AppendLine("M     Musical instrument");
        expectedOutcome.AppendLine("O     Other");
        expectedOutcome.AppendLine("");
        expectedOutcome.AppendLine("Enter a talent type or Z to quit >> ");
        expectedOutcome.AppendLine("Contestants with talent Other are:");
        expectedOutcome.AppendLine("No contestants had talent Other");
        expectedOutcome.AppendLine("");
        //Enter a talent type or Z to quit >>
        expectedOutcome.Append("Enter a talent type or Z to quit >> ");
        
        Assert.Equal(expectedOutcome.ToString(), output.ToString());

        //clean up
        output.Dispose();
        input.Dispose();
    }
}
