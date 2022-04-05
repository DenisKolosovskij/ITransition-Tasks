using System;

namespace GeneralizedRockPaperScissors
{
    enum Outcome
    {
        WIN,
        LOSE,
        DRAW
    }
    class Judge
    {
        int MovesCount;

        public Judge(int movesCount)
        {
            MovesCount = movesCount;
        }

        public Outcome Decide(int firstMove, int secondMove)
        {
            if (firstMove == secondMove)
            {
                return Outcome.DRAW;
            }

            if ((secondMove > firstMove && secondMove - firstMove > MovesCount / 2) || (secondMove < firstMove && firstMove - secondMove <= MovesCount / 2))
            {
                return Outcome.WIN;
            }

            return Outcome.LOSE;
        }
    }
}