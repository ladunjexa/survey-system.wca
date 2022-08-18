/*
    SA-MP 0.3 Development
    Liron "T3D" Youngl's Survey Program v1.0RC2
    ----------------------

    SURVProg developed by [T]he3DeVi[L] (_EvilBoy_) for Fxp.co.il
    - Info
	    version: 1.0RC2 beta
	    developer: _EvilBoy_
	    creation time: 11th October 2013 (11.10.2013)

    (c) Copyrighted 2013, by T3D - All Reserved Right.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SurveyProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Constantly Variables (Limits / Properties)
            const string iVer = "v1.0RC2", iDeveloper = "_EvilBoy_";
            const int maximumNOV = 15, maximumNOQR = 10;

            Console.ForegroundColor = ConsoleColor.White; 
            Console.BackgroundColor = ConsoleColor.Blue;
            for (int i = 0; i <= 100; i++)
            {
                Console.Write("\r{0}% Loading...", i);
                Thread.Sleep(25);
            }

            // Start
            Console.ResetColor(); 
            Console.Clear();
            DateTime thisDate = DateTime.Now;
            Console.WriteLine("\t\t\t\t\t\t\t  " + thisDate);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\t\t\t- DYNAMIC Survey-Program -\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("DSurv Program loaded sucessfully. (»{0})\n\tDeveloped by {1}\nThis program allows you to create survey\nCurrently the software is run DOS interface\n", iVer, iDeveloper);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("To start type 'start'. \n\totherwise the program will be closed");
            Console.WriteLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(".. ");
            if (Console.ReadLine().ToUpper().Equals("start".ToUpper())) goto StartSURV;
            else Environment.Exit(0);

            /*
             * Start Survey Code
             */

        StartSURV:
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\t\t\t- Survey System Program -");
                Console.WriteLine("Welcome to RUN-Process of the Program");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("/CreateSurvey (/CS) - Create a new survey");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("Command: ");
                Console.ForegroundColor = ConsoleColor.White;
                if (Console.ReadLine().ToUpper().Equals("/cs".ToUpper()) || Console.ReadLine().ToUpper().Equals("/createsurvey".ToUpper()))
                {
                    Console.WriteLine("\n\t\tSurvey InfCreation Progress:");
                    Console.WriteLine("- Please enter the survey question");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string SURVEY_QUESTION = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    int MAX_VOTES_PER_SURVEY = 100;
                    while (MAX_VOTES_PER_SURVEY > maximumNOV) {
                        Console.Write("\n- Please enter the maximum number of votes (Limit: " + maximumNOV + "): ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        MAX_VOTES_PER_SURVEY = Convert.ToInt32(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    int MAX_ANSWERS_PER_SURVEY = 100;
                    while (MAX_ANSWERS_PER_SURVEY > maximumNOQR) {
                        Console.Write("\n- Please enter the maximum number of survey responses (Limit: " + maximumNOQR + "): ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        MAX_ANSWERS_PER_SURVEY = Convert.ToInt32(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    // Answers Array.
                    string[] gSurveyAnswers = new string[MAX_ANSWERS_PER_SURVEY];
                    Console.WriteLine();
                    Console.WriteLine("\t(STEP: SELECTING ANSWERS)");
                    for (int i = 0; i < MAX_ANSWERS_PER_SURVEY; i++) {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nPlease enter answer number " + (i + 1));
                        Console.ForegroundColor = ConsoleColor.Red;
                        gSurveyAnswers[i] = Console.ReadLine();
                    }
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n");
                    Console.WriteLine("The survey was successfully created");
                    Console.WriteLine("\t- Survey Information -");
                    Console.WriteLine("Question: \"" + SURVEY_QUESTION + "\"?");
                    Console.WriteLine("Answers:");
                    for (int i = 0; i < MAX_ANSWERS_PER_SURVEY; i++) Console.WriteLine((i + 1) + ". " + gSurveyAnswers[i]);
                    Console.WriteLine("Maximum number of votes: " + MAX_VOTES_PER_SURVEY);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("To confirm the survey press any key...");
                    Console.ReadKey();

                    /*
                     * Process Survey
                     */

                    Console.Clear();
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\t\t - Survey -\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Question: \"" + SURVEY_QUESTION + "\"{0}", SURVEY_QUESTION.EndsWith("?")? ("") : ("?"));
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Answers:");
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int i = 0; i < MAX_ANSWERS_PER_SURVEY; i++) {
                        Console.WriteLine("\t" + (i + 1) + ". " + gSurveyAnswers[i]);
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Maximum number of votes: " + MAX_VOTES_PER_SURVEY);
                    int[] Voted = new int[MAX_ANSWERS_PER_SURVEY];
                    int allVotes = 0;
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine();
                    while (allVotes < MAX_VOTES_PER_SURVEY) {
                        Console.WriteLine("To vote press number of answer.");
                        Voted[(Convert.ToInt32(Console.ReadLine()) - 1)]++;
                        allVotes++;
                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[Survey Results]:");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    int highestVoting = 0;
                    for (int i = 0; i < MAX_ANSWERS_PER_SURVEY; i++)
                    {
                        Console.WriteLine("({0}) {1} - {2} votes - {3}% percent of the voting", (i + 1), gSurveyAnswers[i], Voted[i], ((Voted[i] * 100) / allVotes));
                        if (Voted[i] > highestVoting) highestVoting = i;
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nThank you for using " + iDeveloper + "'s Survey Program, Bye-Bye! :)");
                    Thread.Sleep(10000);
                }
                else Environment.Exit(0);
            }
        } 
            // End of main
    } 
        // End of Program
} 
    // End of SurveyProgram
