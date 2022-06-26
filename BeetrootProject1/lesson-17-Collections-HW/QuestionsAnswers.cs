using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lesson_17_Collections_HW
{
    class QuestionsAnswers
    {
        List<string> userQuestions = new List<string>();

        public void CreateVoteTopic()
        {
            Console.WriteLine("Please enter a question for voting. The answers should be Yes or No");
            var ListInput = Console.ReadLine();
            userQuestions.Add(ListInput);
        }
    }

    class Vote
    {
        List<string> users = new List<string>();
        List<string> results = new List<string>();
        int answerYes = 0;
        int answerNo = 0;
        public void MakeAVote()
        {
            Console.WriteLine("Hi users! Please enter your names and answer one by one. Only 3 users can make a vote.");

            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine("Please enter your name:");
                string userName = Console.ReadLine().ToLowerInvariant();
                users.Add(userName);

                Console.WriteLine("Please enter your answer: Yes or No");
                string userAnswer = Console.ReadLine().ToLowerInvariant();
                results.Add(userAnswer);

                if (userAnswer == "Yes" || userAnswer == "yes") answerYes++;
                else if (userAnswer == "No" || userAnswer == "no") answerNo++;
                else Console.WriteLine("Invalid input");
            }
        }

        public void GetTheResult()
        {
            int total = answerYes + answerNo;

            double persentYes = answerYes * 100.0 / total;
            double persentNo = answerNo * 100.0 / total;

            Console.WriteLine($"Yes counts: {answerYes} - {persentYes}%");
            Console.WriteLine($"No counts: {answerNo} - {persentNo}%");

            if (answerYes > answerNo) Console.WriteLine("Answer Yes won!");
            else if (answerNo > answerYes) Console.WriteLine("Anser No won!");
            else Console.WriteLine("draw");
        }

        public void GetStatistics()
        {
            Console.WriteLine();
            Console.WriteLine("User's votes");

            IEnumerable<Tuple<string, string>> userAndRes = users.Zip(results, (user, result) => new Tuple<string, string>(user, result));

            foreach (Tuple<string, string> tuple in userAndRes)
            {
                Console.WriteLine("{0}\t{1}", tuple.Item1, tuple.Item2);
            }
        }
    }
}
