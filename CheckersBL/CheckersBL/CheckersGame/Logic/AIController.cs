using CheckersBL.CheckersGame.Entity;


namespace CheckersBL.CheckersGame.Logic
{
    
     public class AIController
    {

        public byte highestCounter;
        public ArrayList<GamePiece> bestMovePiece = new ArrayList<GamePiece>();
        public ArrayList<int> bestMoveRow = new ArrayList<int>();
        public ArrayList<int> bestMoveColumn = new ArrayList<int>();

        PieceMovement pm = new PieceMovement();

        public GamePieces decideMove(GamePieces gameBoard)
        {
            for (int i = 0; i < gameBoard.size(); i++)
            {
                if (gameBoard.getPiece(i).getIdentifier() < 13)
                {
                    if (pm.checkAvailableJump(gameBoard.getPiece(i), gameBoard))
                    {
                        return gameBoard;
                    }
                    checkForMoves(gameBoard.getPiece(i), gameBoard);
                }
            }
            makeMove(bestMovePiece.get(0), bestMoveRow.get(0), bestMoveColumn.get(0));
            return gameBoard;
        }

        public void checkForMoves(GamePiece piece, GamePieces board)
        {
            if (pm.checkLowerLeft(piece, board) == EMPTY)
            {
                byte value = pm.determineValueOfMove(piece, piece.getRow() + 1, piece.getColumn() - 1, board);
                assignMove(piece, piece.getRow() + 1, piece.getColumn() - 1, value);
            }
            if (pm.checkLowerRight(piece, board) == EMPTY)
            {
                byte value = pm.determineValueOfMove(piece, piece.getRow() + 1, piece.getColumn() + 1, board);
                assignMove(piece, piece.getRow() + 1, piece.getColumn() + 1, value);
            }
            if (piece.getIsKing() == true && pm.checkUpperLeft(piece, board) == EMPTY)
            {
                byte value = pm.determineValueOfMove(piece, piece.getRow() - 1, piece.getColumn() - 1, board);
                assignMove(piece, piece.getRow() - 1, piece.getColumn() - 1, value);
            }
            if (piece.getIsKing() == true && pm.checkUpperRight(piece, board) == EMPTY)
            {
                byte value = pm.determineValueOfMove(piece, piece.getRow() - 1, piece.getColumn() + 1, board);
                assignMove(piece, piece.getRow() - 1, piece.getColumn() + 1, value);
            }
        }

        public void assignMove(GamePiece piece, int row, int column, byte moveValue)
        {
            if (moveValue > highestCounter)
            {
                highestCounter = moveValue;
                bestMovePiece = new ArrayList<>();
                bestMovePiece.add(piece);
                bestMoveColumn = new ArrayList<>();
                bestMoveColumn.add(column);
                bestMoveRow = new ArrayList<>();
                bestMoveRow.add(row);
            }
            if (moveValue == highestCounter)
            {
                bestMovePiece.add(piece);
                bestMoveColumn.add(column);
                bestMoveRow.add(row);
            }
        }

        public void makeMove(GamePiece piece, int row, int column)
        {
            if (piece.getIdentifier() > 0 && piece.getIdentifier() < 13)
            {
                piece.setRow(row);
                piece.setColumn(column);
            }
        }

    }
}
