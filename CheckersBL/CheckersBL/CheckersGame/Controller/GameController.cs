using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckersBL.CheckersGame.Logic;
using CheckersBL.CheckersGame.Entity;
using Spring.Core.IO;

namespace CheckersBL.CheckersGame.Controller
{
    @CrossOrigin
@RestController
@RequestMapping("/board")
    class GameController
    {
        @Autowired
    private GameLogic gameLogic;

        @Autowired
    private AIController aiController;
    //Get the changed board that has a move made

    @RequestMapping(method = RequestMethod.GET)
    public GamePieces getAllPieces()
        {
            return gameLogic.getGamePieces();
        }

    //Get the requested board/move from the human player and return true if valid
    @RequestMapping(value = "/moveRequest", method = RequestMethod.POST, consumes = MediaType.APPLICATION_JSON_VALUE)
    public GamePieces getRequestedMove(@RequestBody GamePieces gamePiece)
        {
            //send note to GameLogic to see if move is legal (if not return board/pieces to front-end)

            //in Service, if move is legal, pass move and pieces to AI
            //  gameLogic.  ==> do we need to check for forcejump here?
            if (gameLogic.isLegalMove(gameLogic.getGamePieces(), gamePiece) == true)
            {
                gameLogic.setGamePieces(gamePiece);
                return aiController.decideMove(gamePiece);


            }
            else
            {
                return gameLogic.getGamePieces();
            }

        }
    }
}
