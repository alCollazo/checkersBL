using CheckersBL.CheckersGame.Entity;


namespace CheckersBL.CheckersGame.Logic
{
    public class PieceMovement
    {
        

        protected int multiJump = 4;
        protected int singleJump = 3;
        protected int defendFromImmediateJump = 2;
        protected int avoidImmediateJump = 2;
        protected int movingBackRow = -1;
        protected int movingIntoSpaceWillBeJumped = -2;
        protected int movingIntoSpaceWillBeMultiJumped = 2;
        protected int leavingOthersToBeJumped = -2;
        protected int settingUpOwnJump = 1;
        protected int gettingAKing = 5;
        protected int blockOwnJump = -2;
        protected int twoInARow = 1;
        protected int normalPieceBonus = 2;

        public void removePiece(GamePiece piece, GamePieces board)
        {
            for (int i = 0; i < board.size(); i++)
            {
                if (board.getPiece(i).getIdentifier() == piece.getIdentifier())
                {
                    board.remove(i);
                }
            }

        }

        public Pieces checkSpace(GamePiece space)
        {
            if (space.getIdentifier() > 12)
            {
                if (space.getIsKing() == true)
                {
                    return Pieces.ENEMY_KING;
                }
                return Pieces.ENEMY;
            }
            else if (space.getIdentifier() > 0)
            {
                if (space.getIsKing() == true)
                {
                    return Pieces.FRIENDLY_KING;
                }
                return Pieces.FRIENDLY;
            }
            else
            {
                return Pieces.EMPTY;
            }
        }

        public GamePiece findPiece(int row, int column, GamePieces board)
        {
            for (int i = 0; i < board.size(); i++)
            {
                if (board.getPiece(i).getRow() == row && board.getPiece(i).getColumn() == column)
                {
                    return board.getPiece(i);
                }
            }
            return null;
        }

        public Pieces checkUpperLeft(GamePiece piece, GamePieces board)
        {
            if (piece.getRow() != 0 && piece.getColumn() != 0)
            {
                for (int i = 0; i < board.size(); i++)
                {
                    GamePiece temp = board.getPiece(i);
                    if (temp.getRow() == piece.getRow() - 1 && temp.getColumn() == piece.getColumn() - 1)
                    {
                        return checkSpace(temp);
                    }
                }
            }
            else
            {
                return Pieces.EMPTY;
            }
            return Pieces.EMPTY;
        }

        public Pieces checkUpperLeft(int row, int column, GamePieces board)
        {
            if (row != 0 && column != 0)
            {
                for (int i = 0; i < board.size(); i++)
                {
                    GamePiece temp = board.getPiece(i);
                    if (temp.getRow() == row - 1 && temp.getColumn() == column - 1)
                    {
                        return checkSpace(temp);
                    }
                }
            }
            else
            {
                return Pieces.EMPTY;
            }
            return Pieces.EMPTY;
        }

        public Pieces checkUpperRight(GamePiece piece, GamePieces board)
        {
            if (piece.getRow() != 0 && piece.getColumn() != 7)
            {
                for (int i = 0; i < board.size(); i++)
                {
                    GamePiece temp = board.getPiece(i);
                    if (temp.getRow() == piece.getRow() - 1 && temp.getColumn() == piece.getColumn() + 1)
                    {
                        return checkSpace(temp);
                    }
                }
            }
            else
            {
                return Pieces.EMPTY;
            }
            return Pieces.EMPTY;
        }

        public Pieces checkUpperRight(int row, int column, GamePieces board)
        {
            if (row != 0 && column != 7)
            {
                for (int i = 0; i < board.size(); i++)
                {
                    GamePiece temp = board.getPiece(i);
                    if (temp.getRow() == row - 1 && temp.getColumn() == column + 1)
                    {
                        return checkSpace(temp);
                    }
                }
            }
            else
            {
                return Pieces.EMPTY;
            }
            return EMPTY;
        }

        public Pieces checkLowerLeft(GamePiece piece, GamePieces board)
        {
            if (piece.getRow() != 7 && piece.getColumn() != 0)
            {
                for (int i = 0; i < board.size(); i++)
                {
                    GamePiece temp = board.getPiece(i);
                    if (temp.getRow() == (piece.getRow() + 1) && temp.getColumn() == (piece.getColumn() - 1))
                    {
                        return checkSpace(temp);
                    }
                }
            }
            else
            {
                return Pieces.EMPTY;
            }
            return Pieces.EMPTY;
        }

        public Pieces checkLowerLeft(int row, int column, GamePieces board)
        {
            if (row != 7 && column != 0)
            {
                for (int i = 0; i < board.size(); i++)
                {
                    GamePiece temp = board.getPiece(i);
                    if (temp.getRow() == (row + 1) && temp.getColumn() == (column - 1))
                    {
                        return checkSpace(temp);
                    }
                }
            }
            else
            {
                return Pieces.EMPTY;
            }
            return Pieces.EMPTY;
        }

        public Pieces checkLowerRight(GamePiece piece, GamePieces board)
        {
            if (piece.getRow() != 7 && piece.getColumn() != 7)
            {
                for (int i = 0; i < board.size(); i++)
                {
                    GamePiece temp = board.getPiece(i);
                    if (temp.getRow() == (piece.getRow() + 1) && temp.getColumn() == (piece.getColumn() + 1))
                    {
                        return checkSpace(temp);
                    }
                }
            }
            else
            {
                return Pieces.EMPTY;
            }
            return Pieces.EMPTY;
        }

        public Pieces checkLowerRight(int row, int column, GamePieces board)
        {
            if (row != 7 && column != 7)
            {
                for (int i = 0; i < board.size(); i++)
                {
                    GamePiece temp = board.getPiece(i);
                    if (temp.getRow() == (row + 1) && temp.getColumn() == (column + 1))
                    {
                        return checkSpace(temp);
                    }
                }
            }
            else
            {
                return Pieces.EMPTY;
            }
            return Pieces.EMPTY;
        }

        public void makeMove(GamePiece piece, int row, int column)
        {
            if (piece.getIdentifier() > 0 && piece.getIdentifier() < 13)
            {
                piece.setRow(row);
                piece.setColumn(column);
            }
        }

        public bool checkAvailableJump(GamePiece piece, GamePieces board)
        {
            if (checkLowerRight(piece, board) == Pieces.ENEMY || checkLowerLeft(piece, board) == Pieces.ENEMY
                    || checkLowerRight(piece, board) == Pieces.ENEMY_KING || checkLowerLeft(piece, board) == Pieces.ENEMY_KING)
            {
                for (int i = 0; i < board.size(); i++)
                {
                    GamePiece temp = board.getPiece(i);
                    if (temp.getRow() == (piece.getRow() + 1)
                            && temp.getColumn() == (piece.getColumn() - 1)
                            && checkLowerLeft(temp, board) == Pieces.EMPTY)
                    {
                        makeMove(piece, piece.getRow() + 2, piece.getColumn() - 2);
                        removePiece(temp, board);
                        checkAvailableJump(piece, board);
                        return true;
                    }
                    if (temp.getRow() == piece.getRow() + 1
                            && temp.getColumn() == piece.getColumn() + 1
                            && checkLowerRight(temp, board) == Pieces.EMPTY)
                    {
                        makeMove(piece, piece.getRow() + 2, piece.getColumn() + 2);
                        removePiece(temp, board);
                        checkAvailableJump(piece, board);
                        return true;
                    }
                }
            }
            if (piece.getIsKing() == true && checkUpperRight(piece, board) == Pieces.ENEMY || checkUpperLeft(piece, board) == Pieces.ENEMY
                    || checkUpperRight(piece, board) == Pieces.ENEMY_KING || checkUpperLeft(piece, board) == Pieces.ENEMY_KING)
            {
                for (int i = 0; i < board.size(); i++)
                {
                    GamePiece temp = board.getPiece(i);
                    if (temp.getRow() == (piece.getRow() - 1)
                            && temp.getColumn() == (piece.getColumn() - 1)
                            && checkUpperLeft(temp, board) == Pieces.EMPTY)
                    {
                        makeMove(piece, piece.getRow() - 2, piece.getColumn() - 2);
                        removePiece(temp, board);
                        checkAvailableJump(piece, board);
                        return true;
                    }
                    if (temp.getRow() == piece.getRow() - 1
                            && temp.getColumn() == piece.getColumn() + 1
                            && checkUpperRight(temp, board) == Pieces.EMPTY)
                    {
                        makeMove(piece, piece.getRow() - 2, piece.getColumn() + 2);
                        removePiece(temp, board);
                        checkAvailableJump(piece, board);
                        return true;
                    }
                }
            }
            return false;
        }

        public int determineValueOfMove(GamePiece piece, int row, int column, GamePieces board)
        {
            int moveCounter = 0;
            if (isAvoidJump(piece, board)) { moveCounter += avoidImmediateJump; }
            if (isMovingBackRow(piece, board)) { moveCounter += movingBackRow; }
            if (isLeavingOthersForJump(piece, board)) { moveCounter += leavingOthersToBeJumped; }
            int originalRow = piece.getRow();
            int originalColumn = piece.getColumn();
            makeMove(piece, row, column);
            if (isGettingKing(piece)) { moveCounter += gettingAKing; }
            if (isMovingIntoJumpOnNextTurn(piece, board))
            {
                moveCounter += movingIntoSpaceWillBeJumped;
                if (isMovingIntoMultiJumpOnNextTurn(piece, board))
                {
                    moveCounter += movingIntoSpaceWillBeMultiJumped;
                }
            }
            if (isTwoInARow(piece, board))
            {
                moveCounter += twoInARow;
                if (isDefendFromImmediateJump(piece, board))
                {
                    moveCounter += defendFromImmediateJump;
                }
            }
            if (isSettingUpOwnJump(piece, board)) { moveCounter += settingUpOwnJump; }
            if (isBlockingOwnJump(piece, board)) { moveCounter += blockOwnJump; }
            if (piece.getIsKing() == false) { moveCounter += normalPieceBonus; }

            makeMove(piece, originalRow, originalColumn);
            return moveCounter;

        }

        public bool isAvoidJump(GamePiece piece, GamePieces board)
        {
            if ((checkLowerLeft(piece, board) == Pieces.ENEMY || checkLowerLeft(piece, board) == Pieces.ENEMY_KING) && checkUpperRight(piece, board) == Pieces.EMPTY)
            {
                return true;
            }
            if ((checkLowerRight(piece, board) == Pieces.ENEMY || checkLowerRight(piece, board) == Pieces.ENEMY_KING) && checkUpperLeft(piece, board) == EMPTY)
            {
                return true;
            }
            if (checkUpperLeft(piece, board) == Pieces.ENEMY_KING && checkLowerRight(piece, board) == Pieces.EMPTY)
            {
                return true;
            }
            if (checkUpperRight(piece, board) == Pieces.ENEMY_KING && checkLowerLeft(piece, board) == Pieces.EMPTY)
            {
                return true;
            }
            return false;
        }

        public bool isMovingBackRow(GamePiece piece, GamePieces board)
        {
            return piece.getRow() == 0;
        }

        public bool isLeavingOthersForJump(GamePiece piece, GamePieces board)
        {
            if (isTwoInARow(piece, board))
            {

                if (checkLowerRight(piece, board) == Pieces.FRIENDLY_KING || checkLowerRight(piece, board) == Pieces.FRIENDLY)
                {

                    if (checkLowerRight(piece.getRow() + 1, piece.getColumn() + 1, board) == Pieces.ENEMY ||
                            checkLowerRight(piece.getRow() + 1, piece.getColumn() + 1, board) == Pieces.ENEMY_KING)
                    {
                        return true;
                    }
                }

                if (checkLowerLeft(piece, board) == Pieces.FRIENDLY_KING || checkLowerLeft(piece, board) == Pieces.FRIENDLY)
                {
                    if (checkLowerLeft(piece.getRow() + 1, piece.getColumn() - 1, board) == Pieces.ENEMY ||
                            checkLowerLeft(piece.getRow() + 1, piece.getColumn() - 1, board) == Pieces.ENEMY_KING)
                    {
                        return true;
                    }
                }

                if (checkUpperLeft(piece, board) == Pieces.FRIENDLY_KING || checkUpperLeft(piece, board) == Pieces.FRIENDLY)
                {
                    if (checkUpperLeft(piece.getRow() - 1, piece.getColumn() - 1, board) == Pieces.ENEMY_KING)
                    {
                        return true;
                    }
                }
                if (checkUpperRight(piece, board) == Pieces.FRIENDLY_KING || checkUpperRight(piece, board) == Pieces.FRIENDLY)
                {
                    if (checkUpperRight(piece.getRow() - 1, piece.getColumn() + 1, board) == Pieces.ENEMY_KING)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool isMovingIntoJumpOnNextTurn(GamePiece piece, GamePieces board)
        {
            if (isAvoidJump(piece, board))
            {
                return true;
            }
            return false;
        }

        public bool isMovingIntoMultiJumpOnNextTurn(GamePiece piece, GamePieces board)
        {
            if ((checkLowerLeft(piece, board) == Pieces.ENEMY || checkLowerLeft(piece, board) == Pieces.ENEMY_KING) && checkUpperRight(piece, board) == EMPTY)
            {
                if ((checkUpperRight(piece.getRow() - 1, piece.getColumn() + 1, board) == Pieces.FRIENDLY_KING ||
                        checkUpperRight(piece.getRow() - 1, piece.getColumn() + 1, board) == Pieces.FRIENDLY) &&
                        checkUpperRight(piece.getRow() - 2, piece.getColumn() + 2, board) == Pieces.EMPTY)
                {
                    return true;
                }
                if ((checkUpperLeft(piece.getRow() - 1, piece.getColumn() + 1, board) == Pieces.FRIENDLY_KING ||
                        checkUpperLeft(piece.getRow() - 1, piece.getColumn() + 1, board) == Pieces.FRIENDLY) &&
                        checkUpperLeft(piece.getRow() - 3, piece.getColumn() - 1, board) == Pieces.EMPTY)
                {
                    return true;
                }
                if (checkLowerLeft(piece, board) == Pieces.ENEMY_KING &&
                        (checkLowerRight(piece.getRow(), piece.getColumn() + 2, board) == Pieces.FRIENDLY_KING ||
                        checkLowerRight(piece.getRow(), piece.getColumn() + 2, board) == Pieces.FRIENDLY) &&
                        checkLowerRight(piece.getRow() + 1, piece.getColumn() + 3, board) == Pieces.EMPTY)
                {
                    return true;
                }
            }
            if ((checkLowerRight(piece, board) == Pieces.ENEMY || checkLowerRight(piece, board) == Pieces.ENEMY_KING) && checkUpperLeft(piece, board) == EMPTY)
            {
                if ((checkUpperRight(piece.getRow() - 1, piece.getColumn() - 1, board) == Pieces.FRIENDLY_KING ||
                        checkUpperRight(piece.getRow() - 1, piece.getColumn() - 1, board) == Pieces.FRIENDLY) &&
                        checkUpperRight(piece.getRow() - 3, piece.getColumn() + 1, board) == Pieces.EMPTY)
                {
                    return true;
                }
                if ((checkUpperLeft(piece.getRow() - 1, piece.getColumn() - 1, board) == Pieces.FRIENDLY_KING ||
                        checkUpperLeft(piece.getRow() - 1, piece.getColumn() - 1, board) == Pieces.FRIENDLY) &&
                        checkUpperLeft(piece.getRow() - 3, piece.getColumn() - 3, board) == Pieces.EMPTY)
                {
                    return true;
                }
                if (checkLowerRight(piece, board) == Pieces.ENEMY_KING &&
                        (checkLowerRight(piece.getRow() - 1, piece.getColumn() - 1, board) == Pieces.FRIENDLY_KING ||
                        checkLowerRight(piece.getRow() - 1, piece.getColumn() - 1, board) == Pieces.FRIENDLY) &&
                        checkLowerRight(piece.getRow(), piece.getColumn() - 2, board) == Pieces.EMPTY)
                {
                    return true;
                }
            }
            if (checkUpperLeft(piece, board) == Pieces.ENEMY_KING && checkLowerRight(piece, board) == Pieces.EMPTY)
            {
                if ((checkUpperRight(piece.getRow() + 1, piece.getColumn() + 1, board) == Pieces.FRIENDLY_KING ||
                        checkUpperRight(piece.getRow() + 1, piece.getColumn() + 1, board) == Pieces.FRIENDLY) &&
                        checkUpperRight(piece.getRow(), piece.getColumn() + 2, board) == Pieces.EMPTY)
                {
                    return true;
                }
                if ((checkLowerRight(piece.getRow() + 1, piece.getColumn() + 1, board) == Pieces.FRIENDLY_KING ||
                        checkLowerRight(piece.getRow() + 1, piece.getColumn() + 1, board) == Pieces.FRIENDLY) &&
                        checkLowerRight(piece.getRow() + 2, piece.getColumn() + 2, board) == Pieces.EMPTY)
                {
                    return true;
                }
                if ((checkLowerLeft(piece.getRow() + 1, piece.getColumn() + 1, board) == Pieces.FRIENDLY_KING ||
                        checkLowerLeft(piece.getRow() + 1, piece.getColumn() + 1, board) == Pieces.FRIENDLY) &&
                        checkLowerLeft(piece.getRow() + 2, piece.getColumn(), board) == Pieces.EMPTY)
                {
                    return true;
                }
            }
            if (checkUpperRight(piece, board) == Pieces.ENEMY_KING && checkLowerLeft(piece, board) == Pieces.EMPTY)
            {
                if ((checkUpperLeft(piece.getRow() + 1, piece.getColumn() - 1, board) == Pieces.FRIENDLY_KING ||
                        checkUpperLeft(piece.getRow() + 1, piece.getColumn() - 1, board) == Pieces.FRIENDLY) &&
                        checkUpperLeft(piece.getRow(), piece.getColumn() - 2, board) == Pieces.EMPTY)
                {
                    return true;
                }
                if ((checkLowerLeft(piece.getRow() + 1, piece.getColumn() - 1, board) == Pieces.FRIENDLY_KING ||
                        checkLowerLeft(piece.getRow() + 1, piece.getColumn() - 1, board) == Pieces.FRIENDLY) &&
                        checkLowerLeft(piece.getRow() - 2, piece.getColumn() - 2, board) == Pieces.EMPTY)
                {
                    return true;
                }
                if ((checkLowerRight(piece.getRow() + 1, piece.getColumn() - 1, board) == Pieces.FRIENDLY_KING ||
                        checkLowerRight(piece.getRow() + 1, piece.getColumn() - 1, board) == Pieces.FRIENDLY) &&
                        checkLowerRight(piece.getRow() + 2, piece.getColumn(), board) == Pieces.EMPTY)
                {
                    return true;
                }
            }
            return false;
        }

        public bool isTwoInARow(GamePiece piece, GamePieces board)
        {
            if (checkLowerLeft(piece, board) == FRIENDLY || checkLowerLeft(piece, board) == FRIENDLY_KING ||
                    checkLowerRight(piece, board) == FRIENDLY || checkLowerRight(piece, board) == FRIENDLY_KING ||
                    checkUpperLeft(piece, board) == FRIENDLY || checkUpperLeft(piece, board) == FRIENDLY_KING ||
                    checkUpperRight(piece, board) == FRIENDLY || checkUpperRight(piece, board) == FRIENDLY_KING)
            {
                return true;
            }
            return false;
        }

        public bool isDefendFromImmediateJump(GamePiece piece, GamePieces board)
        {
            if ((checkLowerLeft(piece, board) == FRIENDLY_KING || checkLowerLeft(piece, board) == FRIENDLY) &&
                    (checkLowerLeft(piece.getRow() + 1, piece.getColumn() - 1, board) == ENEMY_KING ||
                    checkLowerLeft(piece.getRow() + 1, piece.getColumn() - 1, board) == ENEMY))
            {
                return true;
            }
            if ((checkLowerRight(piece, board) == FRIENDLY_KING || checkLowerRight(piece, board) == FRIENDLY) &&
                    (checkLowerRight(piece.getRow() + 1, piece.getColumn() + 1, board) == ENEMY_KING ||
                    checkLowerRight(piece.getRow() + 1, piece.getColumn() + 1, board) == ENEMY))
            {
                return true;
            }
            if ((checkUpperLeft(piece, board) == FRIENDLY_KING || checkUpperLeft(piece, board) == FRIENDLY) &&
                    (checkUpperLeft(piece.getRow() - 1, piece.getColumn() - 1, board) == ENEMY_KING ||
                    checkUpperLeft(piece.getRow() - 1, piece.getColumn() - 1, board) == ENEMY))
            {
                return true;
            }
            if ((checkUpperRight(piece, board) == FRIENDLY_KING || checkUpperRight(piece, board) == FRIENDLY) &&
                    (checkUpperRight(piece.getRow() - 1, piece.getColumn() + 1, board) == ENEMY_KING ||
                    checkUpperRight(piece.getRow() - 1, piece.getColumn() + 1, board) == ENEMY))
            {
                return true;
            }
            return false;
        }

        public bool isSettingUpOwnJump(GamePiece piece, GamePieces board)
        {
            if (checkUpperRight(piece, board) == FRIENDLY || checkUpperRight(piece, board) == FRIENDLY_KING)
            {
                if ((checkLowerLeft(piece, board) == ENEMY || checkLowerRight(piece, board) == ENEMY_KING) && isAJump(piece, board))
                {
                    return true;
                }
            }
            if (checkUpperLeft(piece, board) == FRIENDLY || checkUpperLeft(piece, board) == FRIENDLY_KING)
            {
                if ((checkLowerRight(piece, board) == ENEMY || checkLowerRight(piece, board) == ENEMY_KING) && isAJump(piece, board))
                {
                    return true;
                }
            }
            if (piece.getIsKing() == true && (checkLowerLeft(piece, board) == FRIENDLY || checkLowerLeft(piece, board) == FRIENDLY_KING))
            {
                if ((checkUpperRight(piece, board) == ENEMY || checkUpperRight(piece, board) == ENEMY_KING) && isAJump(piece, board))
                {
                    return true;
                }
            }
            if (piece.getIsKing() == true && (checkLowerRight(piece, board) == FRIENDLY || checkLowerRight(piece, board) == FRIENDLY_KING))
            {
                if ((checkUpperLeft(piece, board) == ENEMY || checkUpperLeft(piece, board) == ENEMY_KING) && isAJump(piece, board))
                {
                    return true;
                }
            }
            return false;
        }

        public bool isGettingKing(GamePiece piece)
        {
            return piece.getRow() == 7;
        }

        public bool isBlockingOwnJump(GamePiece piece, GamePieces board)
        {
            if ((checkUpperLeft(piece, board) == ENEMY || checkUpperLeft(piece, board) == ENEMY_KING) &&
                    (checkUpperLeft(piece.getRow() - 1, piece.getColumn() - 1, board) == FRIENDLY_KING ||
                    checkUpperLeft(piece.getRow() - 1, piece.getColumn() - 1, board) == FRIENDLY))
            {
                return true;
            }
            if ((checkUpperRight(piece, board) == ENEMY || checkUpperRight(piece, board) == ENEMY_KING) &&
                    (checkUpperRight(piece.getRow() - 1, piece.getColumn() + 1, board) == FRIENDLY_KING ||
                    checkUpperRight(piece.getRow() - 1, piece.getColumn() + 1, board) == FRIENDLY))
            {
                return true;
            }
            if ((checkLowerLeft(piece, board) == ENEMY || checkLowerLeft(piece, board) == ENEMY_KING) &&
                    checkLowerLeft(piece.getRow() + 1, piece.getColumn() - 1, board) == FRIENDLY_KING)
            {
                return true;
            }
            if ((checkLowerRight(piece, board) == ENEMY || checkLowerRight(piece, board) == ENEMY_KING) &&
                    checkLowerRight(piece.getRow() + 1, piece.getColumn() + 1, board) == FRIENDLY_KING)
            {
                return true;
            }
            return false;
        }

        public bool isAJump(GamePiece piece, GamePieces board)
        {
            if ((checkLowerLeft(piece, board) == ENEMY || checkLowerLeft(piece, board) == ENEMY_KING) &&
                    checkLowerLeft(piece.getRow() + 1, piece.getColumn() - 1, board) == EMPTY)
            {
                return true;
            }
            if ((checkLowerRight(piece, board) == ENEMY || checkLowerRight(piece, board) == ENEMY_KING) &&
                    checkLowerRight(piece.getRow() + 1, piece.getColumn() + 1, board) == EMPTY)
            {
                return true;
            }
            if (piece.getIsKing() == true && (checkUpperLeft(piece, board) == ENEMY || checkUpperLeft(piece, board) == ENEMY_KING) &&
                    checkUpperLeft(piece.getRow() - 1, piece.getColumn() - 1, board) == EMPTY)
            {
                return true;
            }
            if (piece.getIsKing() == true && (checkUpperRight(piece, board) == ENEMY || checkUpperRight(piece, board) == ENEMY_KING) &&
                    checkLowerRight(piece.getRow() - 1, piece.getColumn() + 1, board) == EMPTY)
            {
                return true;
            }
            return false;
        }
    }
}
