using System;
using static System.Console;
using System.Globalization;

class GreenvilleRevenue
{
    static void Main()
    {
        const int MIN_CONTESTANTS = 0;
        const int MAX_CONTESTANTS = 30;
        int num;
        int revenue = 0;
        Contestant[] contestants = new Contestant[MAX_CONTESTANTS];
        num = getContestantNumber(MIN_CONTESTANTS, MAX_CONTESTANTS);
        revenue = getContestantData(num, contestants, revenue);
        WriteLine("\n\nRevenue expected this year is {0}", revenue.ToString("C"));
        getLists(num, contestants);
    }

    /// <summary>
    /// Get and validate the contestant number from the user.
    /// </summary>
    /// <param name="min">Minimum number of contestants.</param>
    /// <param name="max">Maximum number of contestants.</param>
    /// <returns>Number of contestants.</returns>
    private static int getContestantNumber(int min, int max)
    {
        string entryString;
        //set the number greater than the max so that the while loop is entered
        int num = max + 1;
        Write("Enter number of contestants >> ");
        entryString = ReadLine();
        while (num < min || num > max)
        {
            if (!int.TryParse(entryString, out num))//set the entry to the num
            {
                WriteLine("Format invalid");
                num = max + 1;
                Write("Enter number of contestants >> ");
                entryString = ReadLine();
            }
            else
            {
				//From the instructions:
				//The program prompts the user for the number of contestants in this year’s competition;
				//the number must be between 0 and 30. Use exception-handling techniques to ensure a valid value 
				//and display the error message: Number must be between 0 and 30
                
                //HINT (2) - use a Try/Catch block. 
                //HINT: in the Try block use the condition below. If true throw an ArgumentException.
                    if (num < min || num > max)
                
                //HINT: in the Catch block use the code section below to write the exception message to the user
                //and allow the user to correct the input
                {
                    WriteLine("Number must be between {0} and {1}", min, max);
                    num = max + 1;
                    Write("Enter number of contestants >> ");
                    entryString = ReadLine();
                }
            }
        }
        return num;
    }

    /// <summary>
    /// Get and validate the contestant data from the user.
    /// </summary>
    /// <param name="num">Number of contentants.</param>
    /// <param name="contestants">The array of potential contestants.</param>
    /// <param name="revenue">Revenue variable passed in, set, and then returned.</param>
    /// <returns>Revenue generated from contestants.</returns>
    private static int getContestantData(int num, Contestant[] contestants, int revenue)
    {
        const int ADULTAGE = 17;
        const int TEENAGE = 12;
        int x = 0;
        string name;
        char talent;
        int age;
        while (x < num)
        {
            Write("Enter contestant name >> ");
            name = ReadLine();
            WriteLine("Talent codes are:");
            for (int y = 0; y < Contestant.talentCodes.Length; ++y)
                WriteLine("  {0}   {1}", Contestant.talentCodes[y], Contestant.talentStrings[y]);
            Write("       Enter talent code >> ");
            char.TryParse(ReadLine(), out talent);
            //From the instructions:
            //The program prompts the user for talent codes. Use exception-handling techniques to 
            //ensure a valid code and update the displayed message to the following message:
            //x is not a valid talent code. Assigned as Invalid.
            //where x was the invalid code entered into the console.
            
            //HINT (4) - do fourth - Use a Try/Catch block here
            //HINT: the Catch block should contain:
            //WriteLine("{0} is not a valid talent code. Assigned as Invalid.", talent);
				
            Write("       Enter contestant's age >> ");
            int.TryParse(ReadLine(), out age);
            if (age > ADULTAGE)
                contestants[x] = new AdultContestant();
            else
               if (age > TEENAGE)
                contestants[x] = new TeenContestant();
            else
                contestants[x] = new ChildContestant();
            contestants[x].Name = name;
            contestants[x].TalentCode = talent;
            revenue += contestants[x].Fee;
            ++x;
        }
        return revenue;
    }

    /// <summary>
    /// Display talents and get input for a contestant with a particular talent.
    /// </summary>
    /// <param name="num">Number of contestants.</param>
    /// <param name="contestants">The array of contestants.</param>
    private static void getLists(int num, Contestant[] contestants)
    {
        int x;
        char QUIT = 'Z';
        //HINT (1) - do this first
        //HINT: char option = ' ';
        bool isValid;
        int pos = 0;
        bool found;
        WriteLine("\nThe types of talent are:");
        for (x = 0; x < Contestant.talentStrings.Length; ++x)
            WriteLine("{0, -6}{1, -20}", Contestant.talentCodes[x], Contestant.talentStrings[x]);
        Write("\nEnter a talent type or {0} to quit >> ", QUIT);
        isValid = false;//set to false first time to enter while loop
        while (!isValid)
        {
            if (!char.TryParse(ReadLine(), out option))
            {
                isValid = false;

                WriteLine("Invalid format - entry must be a single character");
                Write("\nEnter a talent type or {0} to quit >> ", QUIT);
            }
            else
            {
                if (option == QUIT)
                    isValid = true;
                else
                {
					//HINT (5) use a loop the talent codes and find match with user input 
                    //From the instructions:
                    //Use exception-handling techniques for the code verification and display the following message:
                    //Enter a talent type or Z to quit >> x
                    //x is not a valid code
                    //Enter a talent type or Z to quit >>

                    //HINT (6) do sixth - Use a Try/Catch block here.
					//Check of the isValid is false. If so, throw an exception 
                    {
                        WriteLine("{0} is not a valid code", option);
                        Write("\nEnter a talent type or {0} to quit >> ", QUIT);
                        //HINT: set isValid to false
                    }
                }
                //HINT(7) - do seventh
                //HINT: use section below in the try catch block hinted at above.
                {

                    WriteLine("\nContestants with talent {0} are:", Contestant.talentStrings[pos]);
                    found = false;
                    for (x = 0; x < num; ++x)
                    {
                        if (contestants[x].TalentCode == option)
                        {
                            WriteLine(contestants[x].ToString());
                            found = true;
                        }
                    }
                    if (!found)
                    //HINT (8) do eight - add brackets: {
                        WriteLine("No contestants had talent {0}", Contestant.talentStrings[pos]);
                        isValid = false;
                        Write("\nEnter a talent type or {0} to quit >> ", QUIT);
                    }
                //HINT: }
            }
        }
    }
	
    //HINT(3) - do this third - Copy the code block at the bottom of this file and paste into 
    //the Main method above to debug this new method. When done debugging remove the code
    //HINT: create a new method with the following method header:
	//public static void validateCode(char option, out int pos)
    //HINT: use a for loop in which you check the option input parameter against the
    //Contestant.talentCodes. When the talent is found, set the position out parameter
    //to the index value of the matched talend code.
    //HINT: if the talent code is invalid, throw an ArgumentException
    
}

class Contestant
{
    public static char[] talentCodes = { 'S', 'D', 'M', 'O' };
    public static string[] talentStrings = {"Singing", "Dancing",
           "Musical instrument", "Other"};
    public string Name { get; set; }
    private char talentCode;
    private string talent;
    public char TalentCode
    {
        get
        {
            return talentCode;
        }
        set
        {
            int pos = talentCodes.Length;
            for (int x = 0; x < talentCodes.Length; ++x)
                if (value == talentCodes[x])
                    pos = x;
            if (pos == talentCodes.Length)
            {
                talentCode = 'I';
                talent = "Invalid";
            }
            else
            {
                talentCode = value;
                talent = talentStrings[pos];
            }
        }

    }
    public string Talent
    {
        get
        {
            return talent;
        }
    }
   public int Fee {get; set;}
}

class AdultContestant : Contestant
{
    public int ADULT_FEE = 30;
    public AdultContestant()
    {
        Fee = ADULT_FEE;
    }
    public override string ToString()
    {
        return ("Adult Contestant " + Name + " " + TalentCode + "   Fee " + Fee.ToString("C"));
    }
}
class TeenContestant : Contestant
{
    public int TEEN_FEE = 20;
    public TeenContestant()
    {
        Fee = TEEN_FEE;
    }
    public override string ToString()
    {
        return ("Teen Contestant " + Name + " " + TalentCode + "   Fee " + Fee.ToString("C"));
    }
}
class ChildContestant : Contestant
{
    public int CHILD_FEE = 15;
    public ChildContestant()
    {
        Fee = CHILD_FEE;
    }
    public override string ToString()
    {
        return ("Child Contestant " + Name + " " + TalentCode + "   Fee " + Fee.ToString("C"));
    }
}

//use this code to debug the validateCode method
// Write("Enter talent code >> ");
// char talent;
// int pos = 0;
// char.TryParse(ReadLine(), out talent);
// try
// {
//     validateCode(talent, out pos);
// }
// catch
// {
//     WriteLine("{0} is not a valid code", talent);
// }