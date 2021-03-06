﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Featureban.Domain.Enums;
using Featureban.Domain.PlayerBehave.Interface;

namespace Featureban.Domain.PlayerBehave.Single
{
    public class MoveAnotherPlayerCardForwardBehaviour:IPlayerBehaviour
    {
        private readonly Func<Card, string, Board, bool> _selector = ((c, id, b) =>
            !c.IsBlocked
            && c.CanMoveForward()
            && b.HasSlotsFor(c.State + 1)
            && c.PlayerName != id);
        public bool CanApply(string playerName, Board board, CoinSide coinSide)
        {
            return board.Cards.Any(c => _selector(c, playerName, board));

        }

        public Board Apply(string playerName, Board board, CoinSide coinSide)
        {
            var card = board.Cards.Where(c => _selector(c, playerName, board)).OrderBy(_ => Guid.NewGuid()).First();
            var newCard = card.MoveForward();

            return board.ReplaceCard(card,newCard);
        }
    }
}
