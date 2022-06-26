using System;
using System.Collections.Generic;

namespace lesson_17_Collections_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a program to ‘vote’ for anything.Via the console interface users will create a ‘vote topic’ with options.
            //Voters will vote via console interface as well.
            //Users can see voting results via console interface.

            QuestionsAnswers voteQA = new QuestionsAnswers();
            voteQA.CreateVoteTopic();

            Vote vote = new Vote();
            vote.MakeAVote();
            vote.GetTheResult();
            vote.GetStatistics();
        }
    }
}
