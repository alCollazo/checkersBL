

namespace CheckersBL.CheckersGame.Entity
{
    public class GamePiece
    {

        private bool isKing = false;
        private int identifier;
        private int row;
        private int column;

        public GamePiece(bool isKing, int identifier, int row, int column)
        {
            this.isKing = isKing;
            this.identifier = identifier;
            this.row = row;
            this.column = column;
        }

        public GamePiece() { }

        public int getRow()
        {
            return row;
        }

        public void setRow(int row)
        {
            this.row = row;
        }

        public int getColumn()
        {
            return column;
        }

        public void setColumn(int column)
        {
            this.column = column;
        }

        public bool getIsKing()
        {

            return isKing;
        }

        public void setIsKing(bool king)
        {

            isKing = king;
        }

        public int getIdentifier()
        {
            return identifier;
        }

        public void setIdentifier(int identifier)
        {

            this.identifier = identifier;
        }
    }
}
