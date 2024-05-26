using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace draft
{   public class applicant
    {
        public string Name { get; set; }  
        public int Employment_status { get; set; } 
        public int YearCurrentJob_ { get; set; }
        public int YearsCurrentResidence { get; set; }
        public double MonthlySalary { get; set; }
        public double Debt{ get; set; }
        public int NumChildren { get; set; }
    }
    enum menu
    {
        CaptureDetails = 1,
        CheckCreditQualification = 2,
        DisplayQualificationStats = 3,
        ExitProgram = 4,
    }
   







    internal class Program
    {
        
        

        static void Main(string[] args)
        {
            bool Exit1 = false;
            bool finished = false;

            do
            {

                Console.Clear();
                Console.WriteLine("Select a number");
                Console.WriteLine("");
                Console.WriteLine("1.Capture details \n" + "2.Check credit qualification \n"
                    + "3.Show qualification stats \n" + "4.Exit \n");



                int option = Convert.ToInt32(Console.ReadLine());
                switch ((menu)option)
                {
                    case menu.CaptureDetails:

                        do
                        {
                            Console.Clear();
                            int i = 1;

                            Console.WriteLine("Enter following information on customer");

                            AddPerson();
                            Console.WriteLine("Would you like to enter another applicants information? Type y-yes or n-no");
                            var appcontinue = Console.ReadLine();
                            if (appcontinue == "y")
                            {

                                finished = false;
                                Console.Clear();
                                // break;
                            }
                            else if (appcontinue == "n")
                            {
                                Exit1 = false;
                                finished = true;

                                //Exit1 = true;
                            }

                        } while (!finished);



                        break;
                    case menu.CheckCreditQualification:
                        //add the credit qualification method
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Qualification status : ");
                            Listofapplicants();
                            Console.WriteLine(" \n" + "1.Back ");

                            int back = Convert.ToInt32(Console.ReadLine());
                            if (back == 1)
                            {
                                finished = true;
                                Console.Clear();
                            }
                            else
                            {
                                finished = false;
                            }
                        } while (!finished);

                        break;

                    case menu.DisplayQualificationStats:



                        do
                        {
                            Console.Clear();



                            Console.WriteLine("Amount of applicants that qualify : \n"//add method that saves the amount of qualified and unqualified
                                + "Amount of applicants who did not qualify : \n"
                                + " \n"
                                + "1.back ");



                            int back = Convert.ToInt32(Console.ReadLine());
                            if (back == 1)
                            {
                                finished = true;
                                Console.Clear();
                            }
                            else
                            {
                                finished = false;
                            }



                        } while (!finished);





                        break;


                    case menu.ExitProgram:

                        Console.Clear();
                        Console.WriteLine("I like your suit sir, Please give me  80%");
                        int exit = Convert.ToInt32(Console.ReadLine());//Dont have to add anything its just the exit
                        if (exit == 4)
                        {
                            Exit1 = true;



                        }
                        else
                        {
                            Exit1 = false;
                        }




                        break;



                    default:
                        Console.Clear();

                        break;






                }

            } while (Exit1 == false);
        }
        public static List<applicant> numApplicants = new List<applicant>();
        private static void AddPerson()
        {
            applicant a = new applicant();
            Console.WriteLine("Enter Applicant name");
            a.Name = Console.ReadLine();
            Console.WriteLine("Enter employment status (1.Employed or 2. Unemployed");
            a.Employment_status=int.Parse(Console.ReadLine());
            if (a.Employment_status.Equals( 1))
            {
                Console.WriteLine("Duration at current job");
                a.YearCurrentJob_ = int.Parse(Console.ReadLine());
            }
            else if (a.Employment_status.Equals(2))
            {
                Console.WriteLine();
            }
            
            Console.WriteLine("Number of years in current residence");
            a.YearsCurrentResidence = int.Parse(Console.ReadLine());
            Console.WriteLine("Monthly salary");
            a.MonthlySalary = double.Parse(Console.ReadLine());
            Console.WriteLine("Amount of non-mortgage debt");
            a.Debt = double.Parse(Console.ReadLine());
            Console.WriteLine("Num of Children");
            a.NumChildren = int.Parse(Console.ReadLine());
            numApplicants.Add(a);
        }
        private static void PrintApplicant(applicant a ) 
        { 
            Console.WriteLine("Applicant name: "+ a.Name);
            Console.WriteLine("Employment status: "+ a.Employment_status);
            Console.WriteLine("Years in Current Job: "+ a.YearCurrentJob_);
            Console.WriteLine("Years in current residential area: "+ a.YearsCurrentResidence);
            Console.WriteLine("Monthly Salary: " + a.MonthlySalary);
            Console.WriteLine("Amount of non-mortgage debt: " + a.Debt);
            Console.WriteLine("Number of children: "+ a.NumChildren);
            CreditVerifier(a.Name, a.Employment_status, a.YearCurrentJob_, a.YearsCurrentResidence, a.NumChildren, a.Debt, a.MonthlySalary);



            Console.WriteLine("----------------------------------------------------------------------------------------------");
        }
        private static void Listofapplicants()
        {   applicant applicant = new applicant();
            if(numApplicants.Count == 0)
            {
                Console.WriteLine("There no applicants");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("List of applicants");
            foreach( var x in numApplicants)
            {
                PrintApplicant(x);
            }


        }
        public static void CreditVerifier( string appName, int employStatus, int yearsJob, int yearsResidence, int numChildren, double debt, double monthlySalary)
        {
            int score;
            int point = 0;
            Console.WriteLine("\n Credit verifier");
            Console.WriteLine("-----------------------");

            if (employStatus == 1)
            {
                score = point++;

                if (yearsJob >= 1)
                {
                    score = point++;

                    if (yearsResidence >= 2)
                    {
                        score = point++;
                        if (numChildren < 6)
                        {
                            score = point++;

                            if (debt < (2 * monthlySalary))
                            {
                                score = point++;
                                Console.WriteLine("You scored a total of:\t" + score + "point(s). \nCongradulations you qualify for credit!");
                                Console.ReadKey();
                                
                            }
                            if (debt >= 2 * monthlySalary)
                            {
                                score = 0;
                                Console.WriteLine("total score of:\t" + score + "point(s). Doesnt meet debt requirement");
                                Console.ReadKey();
                                
                            }
                        }
                        if (numChildren >= 6)
                        {
                            Console.WriteLine(" Applicant does not qualify for credit!");

                        }
                    }
                    else
                        score = point += 0;
                }
                else
                    score = point += 0;
            }
            else
                score = point;



            if (score >= 3)
            {
                Console.WriteLine("You scored a total of:" + score + "point(s). \nCongradulations you qualify for credit!");

            }



            if (score < 3)
            {
                Console.WriteLine("You scored a total of:" + score + "point(s). You unfortunately do not qualify for credit.");

            }


        }


    }
}
