﻿using System;
using System.Collections.Generic;
using System.Text;
using Featureban.Domain;
using Featureban.Domain.Enums;
using Featureban.Domain.Interfaces;

namespace Featureban.Tests.DSL
{
    public class GameBuilder
    {
        private ICoin coin = Create.Coin.WhichAlwaysDropOn(CoinSide.Tails).Build();
        private List<Player> players;
        private Board board = Create.Board.Build();
        private int _stagesLimit = 1;
        
        public GameBuilder WithTwoEagleCoin()
        {
            this.coin = Create.Coin.WhichAlwaysDropOn(CoinSide.Eagle).Build();
            return this;
        }

        public GameBuilder WithCoin(ICoin coin)
        {
            this.coin = coin;
            return this;
        }

        public GameBuilder WithTwoTailsCoin()
        {
            this.coin = Create.Coin.WhichAlwaysDropOn(CoinSide.Tails).Build();
            return this;
        }

        public GameBuilder WithStagesLimit(int stagesLimit)
        {
            this._stagesLimit = stagesLimit;
            return this;
        }

        public GameBuilder WithPlayers(List<Player> players)
        {
            this.players = players;
            return this;
        }

        public GameBuilder WithBoard(Board board)
        {
            this.board = board;
            return this;
        }

        public Game Build()
        {
            return new Game(players,coin,board,_stagesLimit); 
        }

    }
}
