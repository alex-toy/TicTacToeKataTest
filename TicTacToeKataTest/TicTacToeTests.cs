using FluentAssertions;

namespace TicTacToeKataTest
{
    class TicTacToeTests
    {
        /*
         * 
    a game has nine fields in a 3x3 grid
    there are two players in the game (X and O)
    players take turns taking fields until the game is over
    a game is over when all fields are taken

    a game is over when all fields in a row are taken by a player
    a game is over when all fields in a diagonal are taken by a player
    a game is over when all fields in a column are taken by a player
    a player can take a field if not already taken

         */

        [Test]
        public void Should_Have_3x3_Grid_When_Start_Game()
        {
            TicTacToe ticTacToe = new TicTacToe();

            ticTacToe.Grid.Should().HaveCount(3);
            ticTacToe.Grid[0].Should().HaveCount(3);
            ticTacToe.Grid[1].Should().HaveCount(3);
            ticTacToe.Grid[2].Should().HaveCount(3);
        }

        [Test]
        public void Should_Have_Two_Players_When_Start_Game()
        {
            TicTacToe ticTacToe = new TicTacToe();

            ticTacToe.Players.Should().HaveCount(2);
            ticTacToe.Players.Should().Contain('X');
            ticTacToe.Players.Should().Contain('O');
        }

        [Test]
        public void Should_Have_Empty_Grid_When_Start_Game()
        {
            TicTacToe ticTacToe = new TicTacToe();
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ticTacToe.Grid[i][j].Should().Be(null);
                }
            }
        }

        [TestCase(0, 0)]
        public void Should_Set_Cell_Properly_When_First_Player_Plays(int row, int column)
        {
            TicTacToe ticTacToe = new TicTacToe();

            ticTacToe.Play(row, column);

            ticTacToe.Grid[row][column].Should().Be(ticTacToe.Players[0]);
        }

        [Test]
        public void Should_Set_Cell_Properly_When_Second_Player_Plays()
        {
            TicTacToe ticTacToe = new TicTacToe();
            ticTacToe.Play(0, 0);

            ticTacToe.Play(0, 1);

            ticTacToe.Grid[0][1].Should().Be(ticTacToe.Players[1]);
        }

        [Test]
        public void Should_Be_Game_Over_When_Grid_Is_Totally_Filled()
        {
            TicTacToe ticTacToe = new TicTacToe();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ticTacToe.Play(i, j);
                    ticTacToe.GameOver.Should().Be(false);
                }
            }

            ticTacToe.GameOver.Should().Be(true);
        }
    }
}
