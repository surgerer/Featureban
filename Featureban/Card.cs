﻿using System;
using System.Collections.Generic;
using System.Text;
using Featureban.Domain.Enums;

namespace Featureban.Domain
{
    public class Card
    {
        public CardState State { get; private set; }
        public bool IsBlocked { get; private set; }

        public Card(CardState state = CardState.Free, bool isBlocked = false)
        {
            this.State = state;
            this.IsBlocked = isBlocked;
        }

        public void ChangeStatus(CardState newStatus)
        {
            State = newStatus;
        }

        public void Block()
        {
            if(IsBlocked)
                throw new NotSupportedException("Card is already blocked");
            IsBlocked = true;

        }

        public void Unblock()
        {
            if(!IsBlocked)
                throw new NotSupportedException("Card is not blocked");
        }
    }
}
