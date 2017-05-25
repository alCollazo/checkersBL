using System.Collections.Generic;

namespace CheckersBL.CheckersGame.Entity
{
    
    public class GamePieces : ArrayList<GamePiece>{

    private int pieceCounter = 1;

    public GamePieces()
    {
    }

    public void createGamePieces()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                if (column % 2 != 0 && row % 2 == 0)
                {
                    GamePiece piece = new GamePiece(false, pieceCounter, row, column);
                    Add(piece);
                    pieceCounter++;
                }
                if (row == 1 && column % 2 == 0)
                {
                    GamePiece piece = new GamePiece(false, pieceCounter, row, column);
                    Add(piece);
                    pieceCounter++;
                }
            }
        }
        for (int row = 5; row < 8; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                if (column % 2 == 0 && row % 2 != 0)
                {
                    GamePiece piece = new GamePiece(false, pieceCounter, row, column);
                    add(piece);
                    pieceCounter++;
                }
                if (row == 6 && column % 2 != 0)
                {
                    GamePiece piece = new GamePiece(false, pieceCounter, row, column);
                    add(piece);
                    pieceCounter++;
                }
            }
        }
    }

    public GamePiece getPiece(int index)
    {
        return (GamePiece)this.get(index);
    }

    public void setPiece(GamePiece piece)
    {
        add(piece);
    }
}
}
