using CheckersBL.CheckersGame.Logic;
using System;


namespace CheckersBL.CheckersGame.Entity
{
    
    public class GameLogic
    {

        private GamePieces gamePieces = new GamePieces();

        private int changeIndex;
        PieceMovement move = new PieceMovement();

        public GamePieces getGamePieces()
        {
            return gamePieces;
        }

        public void setGamePieces(GamePieces gamePieces)
        {
            this.gamePieces = gamePieces;
        }

        //gamePieces.createGamePieces();
    
    //Get the board with the requested move and compare to the current board
    //If there is a change, return true
        public bool comparePiecesOnBoard(GamePieces currentGamePieces, GamePieces changedGamePieces)
        {
            int i;
            for (i = 0; i < currentGamePieces.Size(); i++)
            {
                for (int j = 0; j < changedGamePieces.size(); j++)
                {
                    if (currentGamePieces.getPiece(i).getIdentifier() == changedGamePieces.getPiece(j).getIdentifier())
                    {
                        if (!(currentGamePieces.getPiece(i).getColumn() == changedGamePieces.getPiece(j).getColumn()))
                        {
                            changeIndex = j;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool isOccupiedSpace(GamePieces currentPieces, GamePieces changedGamePieces)
        {
            if (comparePiecesOnBoard(currentPieces, changedGamePieces))
            {

                for (int i = 0; i < currentPieces.size(); i++)
                {
                    if (currentPieces.getPiece(i).getRow() == changedGamePieces.getPiece(changeIndex).getRow() &&
                            currentPieces.getPiece(i).getColumn() == changedGamePieces.getPiece(changeIndex).getColumn())
                    {

                        return true;
                    }
                }
            }
            return false;
        }

        public bool isLegalMovePawn(GamePieces currentGamePieces, GamePieces changedGamePieces)
        {
            if (!(isOccupiedSpace(currentGamePieces, changedGamePieces)))
            {

                if (comparePiecesOnBoard(currentGamePieces, changedGamePieces))
                {

                    if ((currentGamePieces.getPiece(changeIndex).getRow() - changedGamePieces.getPiece(changeIndex).getRow() == 1) &&
                            Math.Abs(currentGamePieces.getPiece(changeIndex).getColumn() - changedGamePieces.getPiece(changeIndex).getColumn()) == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool isLegalMove(GamePieces currentGamePieces, GamePieces changedGamePieces)
        {
            if (checkForJump(currentGamePieces))
            {
                if (takenJump(currentGamePieces, changedGamePieces))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {

                comparePiecesOnBoard(currentGamePieces, changedGamePieces);
                if (currentGamePieces.getPiece(changeIndex).getIsKing())
                {
                    return isLegalMoveKing(currentGamePieces, changedGamePieces);
                }
                return isLegalMovePawn(currentGamePieces, changedGamePieces);
            }
        }

        public bool isLegalMoveKing(GamePieces currentGamePieces, GamePieces changedGamePieces)
        {
            if (!(isOccupiedSpace(currentGamePieces, changedGamePieces)))
            {

                if (comparePiecesOnBoard(currentGamePieces, changedGamePieces))
                {


                    if (Math.Abs(currentGamePieces.getPiece(changeIndex).getRow() - changedGamePieces.getPiece(changeIndex).getRow()) == 1 &&
                            Math.Abs(currentGamePieces.getPiece(changeIndex).getColumn() - changedGamePieces.getPiece(changeIndex).getColumn()) == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool isAvailableJumpUpperLeft(GamePiece piece, GamePieces board)
        {

            if (move.checkUpperLeft(piece, board).Equals(FRIENDLY) || move.checkUpperLeft(piece, board).Equals(FRIENDLY_KING))
            {
                int holdRow = piece.getRow();
                int holdColumn = piece.getColumn();
                piece.setRow(piece.getRow() - 1);
                piece.setColumn(piece.getColumn() - 1);
                if (move.checkUpperLeft(piece, board).Equals(EMPTY))
                {
                    piece.setRow(holdRow);
                    piece.setColumn(holdColumn);
                    return true;
                }
                piece.setRow(holdRow);
                piece.setColumn(holdColumn);

            }
            return false;
        }

        public bool isAvailableJumpUpperRight(GamePiece piece, GamePieces board)
        {
            if (move.checkUpperRight(piece, board).Equals(FRIENDLY) || move.checkLowerLeft(piece, board).Equals(FRIENDLY_KING))
            {
                int holdRow = piece.getRow();
                int holdColumn = piece.getColumn();
                piece.setRow(piece.getRow() - 1);
                piece.setColumn(piece.getColumn() + 1);
                if (move.checkUpperRight(piece, board).Equals(EMPTY))
                {
                    piece.setRow(holdRow);
                    piece.setColumn(holdColumn);
                    return true;
                }
                piece.setRow(holdRow);
                piece.setColumn(holdColumn);

            }
            return false;
        }

        public bool isAvailableJumpLowerLeft(GamePiece piece, GamePieces board)
        {
            if (piece.getIsKing() == true)
            {
                if (move.checkLowerLeft(piece, board).Equals(FRIENDLY) || move.checkLowerLeft(piece, board).Equals(FRIENDLY_KING))
                {
                    int holdRow = piece.getRow();
                    int holdColumn = piece.getColumn();
                    piece.setRow(piece.getRow() + 1);
                    piece.setColumn(piece.getColumn() - 1);
                    if (move.checkLowerLeft(piece, board).Equals(EMPTY))
                    {
                        piece.setRow(holdRow);
                        piece.setColumn(holdColumn);
                        return true;
                    }
                    piece.setRow(holdRow);
                    piece.setColumn(holdColumn);
                }
            }
            return false;
        }

        public bool isAvailableJumpLowerRight(GamePiece piece, GamePieces board)
        {
            if (piece.getIsKing() == true)
            {
                if (move.checkLowerRight(piece, board).Equals(FRIENDLY) || move.checkLowerRight(piece, board).Equals(FRIENDLY_KING))
                {
                    int holdRow = piece.getRow();
                    int holdColumn = piece.getColumn();
                    piece.setRow(piece.getRow() + 1);
                    piece.setColumn(piece.getColumn() + 1);
                    if (move.checkLowerRight(piece, board).Equals(EMPTY))
                    {
                        piece.setRow(holdRow);
                        piece.setColumn(holdColumn);
                        return true;
                    }
                    piece.setRow(holdRow);
                    piece.setColumn(holdColumn);

                }
            }
            return false;
        }

        public bool isAvailableJump(GamePiece piece, GamePieces board)
        {
            if (isAvailableJumpUpperLeft(piece, board) || isAvailableJumpUpperRight(piece, board) ||
                    isAvailableJumpLowerLeft(piece, board) || isAvailableJumpLowerRight(piece, board))
            {
                return true;
            }
            return false;
        }

        public bool checkForJump(GamePieces board)
        {
            for (int i = 12; i < board.size(); i++)
            {
                if (isAvailableJump(board.getPiece(i), board))
                {
                    return true;
                }
            }
            return false;
        }

        public bool takenJump(GamePieces current, GamePieces compare)
        {
            if (takenJumpLeft(current, compare) || takenJumpRight(current, compare) ||
                    takenJumpLowerLeft(current, compare) || takenJumpLowerRight(current, compare))
            {
                return true;
            }
            return false;
        }

        public bool takenJumpLeft(GamePieces current, GamePieces compare)
        {
            for (int i = 12; i < current.size(); i++)
            {
                if (isAvailableJumpUpperLeft(current.getPiece(i), current))
                {
                    comparePiecesOnBoard(current, compare);
                    if (current.getPiece(changeIndex).getRow() - 2 == compare.getPiece(changeIndex).getRow()
                            && current.getPiece(changeIndex).getColumn() - 2 == compare.getPiece(changeIndex).getColumn())
                    {
                        move.removePiece(move.findPiece(current.getPiece(changeIndex).getRow() - 1,
                                current.getPiece(changeIndex).getColumn() - 1, compare), compare);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool takenJumpLowerLeft(GamePieces current, GamePieces compare)
        {
            for (int i = 12; i < current.size(); i++)
            {
                if (isAvailableJumpLowerLeft(current.getPiece(i), current))
                {
                    comparePiecesOnBoard(current, compare);
                    if (current.getPiece(changeIndex).getRow() + 2 == compare.getPiece(changeIndex).getRow()
                            && current.getPiece(changeIndex).getColumn() - 2 == compare.getPiece(changeIndex).getColumn())
                    {
                        move.removePiece(move.findPiece(current.getPiece(changeIndex).getRow() + 1,
                                current.getPiece(changeIndex).getColumn() - 1, compare), compare);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool takenJumpLowerRight(GamePieces current, GamePieces compare)
        {
            for (int i = 12; i < current.size(); i++)
            {
                if (isAvailableJumpLowerRight(current.getPiece(i), current))
                {
                    comparePiecesOnBoard(current, compare);
                    if (current.getPiece(changeIndex).getRow() + 2 == compare.getPiece(changeIndex).getRow()
                            && current.getPiece(changeIndex).getColumn() + 2 == compare.getPiece(changeIndex).getColumn())
                    {
                        move.removePiece(move.findPiece(current.getPiece(changeIndex).getRow() + 1,
                                current.getPiece(changeIndex).getColumn() + 1, compare), compare);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool takenJumpRight(GamePieces current, GamePieces compare)
        {
            for (int i = 12; i < current.size(); i++)
            {
                if (isAvailableJumpUpperRight(current.getPiece(i), current))
                {
                    comparePiecesOnBoard(current, compare);
                    if (current.getPiece(changeIndex).getRow() - 2 == compare.getPiece(changeIndex).getRow()
                            && current.getPiece(changeIndex).getColumn() + 2 == compare.getPiece(changeIndex).getColumn())
                    {
                        move.removePiece(move.findPiece(current.getPiece(changeIndex).getRow() - 1,
                                current.getPiece(changeIndex).getColumn() + 1, compare), compare);
                        return true;
                    }
                }
            }
            return false;
        }

        public int getChangeIndex()
        {
            return changeIndex;
        }

    }
}

