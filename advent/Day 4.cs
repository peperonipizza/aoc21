using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent
{
    public class Day_4
    {
        private record struct Cell(int Value, bool Bingo);

        public void part1(string input)
        {
            (List<Cell[,]> boards, int[] numbers) = ParseInput(input);

            foreach (int number in numbers)
            {
                foreach (var board in boards)
                {
                    for (int r = 0; r < 5; ++r)
                    {
                        for (int c = 0; c < 5; ++c)
                        {
                            if (board[c, r].Value == number)
                                board[c, r].Bingo = true;

                            if (IsBingo(board))
                            {
                                int score = GetScore(board, number);
                                Console.WriteLine(score);
                                return;
                            }
                        }
                    }
                }
            }
        }

        public void part2(string input)
        {
            (List<Cell[,]> boards, int[] numbers) = ParseInput(input);
            List<(Cell[,] Board, int Score)> winningBoards = new();

            foreach (int number in numbers)
            {
                foreach (var board in boards)
                {
                    for (int r = 0; r < 5; ++r)
                    {
                        for (int c = 0; c < 5; ++c)
                        {
                            if (board[c, r].Value == number)
                                board[c, r].Bingo = true;

                            if (IsBingo(board))
                            {
                                int score = GetScore(board, number);
                                if (winningBoards.All(x => x.Board != board))
                                    winningBoards.Add((board, score));
                            }
                        }
                    }
                }
            }

            int result = winningBoards.Last().Score;
            Console.WriteLine(result);
        }

        private static (List<Cell[,]> Boards, int[] Number) ParseInput(string input)
        {
            string[] lines = File.ReadAllLines(input);
            int[] numbers = lines[0].Split(',').Select(x => int.Parse(x)).ToArray();
            List<Cell[,]> boards = new();
            int row = 0;

            for (int i = 1; i < lines.Length; ++i)
            {
                string line = lines[i];

                if (line == "")
                {
                    boards.Add(new Cell[5, 5]);
                    row = 0;
                }
                else
                {
                    int[] cols = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                    Cell[,] board = boards.Last();
                    for (int c = 0; c < cols.Length; ++c)
                        board[c, row] = new Cell(cols[c], false);
                    row++;
                }
            }

            return (boards, numbers);
        }

        private static int GetScore(Cell[,] board, int number)
        {
            int unmarkedSum = 0;
            for (int r = 0; r < 5; ++r)
                for (int c = 0; c < 5; ++c)
                    if (!board[c, r].Bingo)
                        unmarkedSum += board[c, r].Value;
            return unmarkedSum * number;
        }

        private static bool IsBingo(Cell[,] board)
        {
            for (int r = 0; r < 5; ++r)
            {
                int bingosInRow = 0;
                int bingosInCol = 0;
                for (int c = 0; c < 5; ++c)
                {
                    if (board[c, r].Bingo)
                        bingosInRow++;
                    if (board[r, c].Bingo)
                        bingosInCol++;
                }

                if (bingosInRow == 5 || bingosInCol == 5)
                    return true;
            }

            return false;
        }
    }
}
