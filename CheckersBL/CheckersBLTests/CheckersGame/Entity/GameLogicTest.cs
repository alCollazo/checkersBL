using Microsoft.VisualStudio.TestTools.UnitTesting;

using CheckersBL.CheckersGame.Logic;

namespace CheckersBL.CheckersGame.Entity.Tests
{
    [TestClass()]
    public class GameLogicTest
    {
        PieceMovement move;
        GameLogic logic;
        GamePieces currentPieces;
        GamePieces changedPieces;
        GamePieces changedPieces3;
        GamePieces changedPieces2;
        GamePieces changedPiecesKing;
        GamePieces changedPiecesKing2;

        public void setUp()
        {
            move = new PieceMovement();
            currentPieces = new GamePieces();
            changedPieces = new GamePieces();
            changedPieces2 = new GamePieces();
            changedPieces3 = new GamePieces();
            changedPiecesKing = new GamePieces();
            changedPiecesKing2 = new GamePieces();
            logic = new GameLogic();
            currentPieces.createGamePieces();
            changedPieces.createGamePieces();
            changedPieces3.createGamePieces();
            changedPieces2.createGamePieces();
            changedPiecesKing.createGamePieces();
            changedPiecesKing2.createGamePieces();
            changedPieces.getPiece(13).setRow(4);
            changedPieces.getPiece(13).setColumn(3);
            changedPieces2.getPiece(21).setColumn(3);
            changedPieces2.getPiece(21).setRow(6);

            changedPiecesKing.getPiece(13).setRow(3);
            changedPiecesKing.getPiece(13).setColumn(4);
            changedPiecesKing2.getPiece(13).setRow(4);
            changedPiecesKing2.getPiece(13).setColumn(3);
        }

        [TestMethod()]
        public void comparePiecesOnBoardTest()
        {
            Assert.IsTrue(logic.comparePiecesOnBoard(currentPieces, changedPieces));
        }

        [TestMethod()]
        public void comparePiecesOnBoardTest2()
        {
            logic.comparePiecesOnBoard(currentPieces, changedPieces);
            Assert.Equals(13, logic.getChangeIndex());
        }

        [TestMethod()]
        public void isOccupiedSpaceTestUnoccupied()
        {
            Assert.IsFalse(logic.isOccupiedSpace(currentPieces, changedPieces));
        }

        [TestMethod()]
        public void isIllegalMoveWrongSpotColumnTest()
        {
            changedPieces.getPiece(13).setColumn(2);
            Assert.IsFalse(logic.isLegalMove(currentPieces, changedPieces));
        }

        [TestMethod()]
        public void isIllegalMoveWrongSpotRowTest()
        {
            changedPieces.getPiece(13).setRow(3);
            Assert.IsFalse(logic.isLegalMovePawn(currentPieces, changedPieces));
        }

        [TestMethod()]
        public void isLegalMoveUpToTheRightTest()
        {
            Assert.IsTrue(logic.isLegalMove(currentPieces, changedPieces));
        }

        [TestMethod()]
        public void isLegalMoveUpToTheLeftTest()
        {
            changedPieces.getPiece(13).setColumn(1);
            Assert.IsTrue(logic.isLegalMovePawn(currentPieces, changedPieces));
        }

        [TestMethod()]
        public void isOccupiedSpaceTestOccupied()
        {
            Assert.IsTrue(logic.isOccupiedSpace(currentPieces, changedPieces2));
        }

        [TestMethod()]
        public void isIllegalMoveOccupiedSpaceTest()
        {
            Assert.IsFalse(logic.isLegalMovePawn(currentPieces, changedPieces2));
        }

        [TestMethod()]
        public void isLegalMoveUpToTheRightKingTest()
        {
            Assert.IsTrue(logic.isLegalMovePawn(currentPieces, changedPieces));
        }

        [TestMethod()]
        public void isLegalMoveUpToTheLeftKingTest()
        {
            changedPieces.getPiece(13).setColumn(1);
            Assert.IsTrue(logic.isLegalMove(currentPieces, changedPieces));
        }

        [TestMethod()]
        public void isLegalMoveDownToTheRightKingTest()
        {
            Assert.IsTrue(logic.isLegalMoveKing(changedPiecesKing, changedPiecesKing2));
        }

        [TestMethod()]
        public void isLegalDownUpToTheLeftKingTest()
        {
            changedPiecesKing2.getPiece(13).setColumn(5);
            Assert.IsTrue(logic.isLegalMoveKing(changedPiecesKing, changedPiecesKing2));
        }

        [TestMethod()]
        public void isAvailableJumpUpperLeftTest()
        {
            changedPieces.getPiece(8).setColumn(2);
            changedPieces.getPiece(8).setRow(3);
            Assert.IsTrue(logic.isAvailableJumpUpperLeft(changedPieces.getPiece(13), changedPieces));

        }

        [TestMethod()]
        public void isAvailableJumpUpperRightTest()
        {
            changedPieces.getPiece(10).setColumn(4);
            changedPieces.getPiece(10).setRow(3);
            Assert.IsTrue(logic.isAvailableJumpUpperRight(changedPieces.getPiece(13), changedPieces));

        }

        [TestMethod()]
        public void isAvailableJumpLowerLeftTest()
        {
            changedPieces.getPiece(13).setIsKing(true);
            changedPieces.getPiece(13).setColumn(4);
            changedPieces.getPiece(13).setRow(3);
            changedPieces.getPiece(10).setColumn(3);
            changedPieces.getPiece(10).setRow(4);
            Assert.IsTrue(logic.isAvailableJumpLowerLeft(changedPieces.getPiece(13), changedPieces));

        }

        [TestMethod()]
        public void isAvailableJumpLowerRightTest()
        {
            changedPieces.getPiece(14).setIsKing(true);
            changedPieces.getPiece(14).setColumn(2);
            changedPieces.getPiece(14).setRow(3);
            changedPieces.getPiece(8).setColumn(3);
            changedPieces.getPiece(8).setRow(4);
            Assert.IsTrue(logic.isAvailableJumpLowerRight(changedPieces.getPiece(14), changedPieces));

        }

        [TestMethod()]
        public void isLegalMoveJumpTest()
        {
            currentPieces.getPiece(10).setColumn(3);
            currentPieces.getPiece(10).setRow(4);
            changedPieces3.getPiece(10).setColumn(3);
            changedPieces3.getPiece(10).setRow(4);
            changedPieces3.getPiece(14).setRow(3);
            changedPieces3.getPiece(14).setColumn(2);
            Assert.IsTrue(logic.isLegalMove(currentPieces, changedPieces3));
        }

        [TestMethod()]
        public void isLegalMoveForceJumpTest()
        {
            currentPieces.getPiece(10).setColumn(3);
            currentPieces.getPiece(10).setRow(4);
            changedPieces3.getPiece(10).setColumn(3);
            changedPieces3.getPiece(10).setRow(4);
            changedPieces3.getPiece(15).setRow(4);
            changedPieces3.getPiece(15).setColumn(5);
            Assert.IsFalse(logic.isLegalMove(currentPieces, changedPieces3));
        }

        [TestMethod()]
        public void takenJumpLeftTest()
        {
            currentPieces.getPiece(10).setColumn(3);
            currentPieces.getPiece(10).setRow(4);
            changedPieces3.getPiece(10).setColumn(3);
            changedPieces3.getPiece(10).setRow(4);
            changedPieces3.getPiece(14).setRow(3);
            changedPieces3.getPiece(14).setColumn(2);
            Assert.IsTrue(logic.takenJumpLeft(currentPieces, changedPieces3));
        }

        [TestMethod()]
        public void takenJumpLeftResizeTest()
        {
            currentPieces.getPiece(10).setColumn(3);
            currentPieces.getPiece(10).setRow(4);
            changedPieces3.getPiece(10).setColumn(3);
            changedPieces3.getPiece(10).setRow(4);
            changedPieces3.getPiece(14).setRow(3);
            changedPieces3.getPiece(14).setColumn(2);
            logic.takenJumpLeft(currentPieces, changedPieces3);
            Assert.Equals(23, changedPieces3.size());
        }

        [TestMethod()]
        public void takenJumpLowerLeftTest()
        {
            currentPieces.getPiece(13).setIsKing(true);
            currentPieces.getPiece(13).setColumn(4);
            currentPieces.getPiece(13).setRow(3);
            currentPieces.getPiece(10).setColumn(3);
            currentPieces.getPiece(10).setRow(4);
            changedPieces3.getPiece(10).setColumn(3);
            changedPieces3.getPiece(10).setRow(4);
            Assert.IsTrue(logic.takenJumpLowerLeft(currentPieces, changedPieces3));
        }

        [TestMethod()]
        public void takenJumpLowerRightTest()
        {
            currentPieces.getPiece(14).setIsKing(true);
            currentPieces.getPiece(14).setColumn(2);
            currentPieces.getPiece(14).setRow(3);
            currentPieces.getPiece(8).setColumn(3);
            currentPieces.getPiece(8).setRow(4);
            changedPieces3.getPiece(8).setColumn(3);
            changedPieces3.getPiece(8).setRow(4);
            Assert.IsTrue(logic.takenJumpLowerRight(currentPieces, changedPieces3));
        }

        [TestMethod()]
        public void takenJumpRightTest()
        {
            currentPieces.getPiece(10).setColumn(3);
            currentPieces.getPiece(10).setRow(4);
            changedPieces3.getPiece(13).setRow(3);
            changedPieces3.getPiece(13).setColumn(4);
            Assert.IsTrue(logic.takenJumpRight(currentPieces, changedPieces3));
        }
    }
}