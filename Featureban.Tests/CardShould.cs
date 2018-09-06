﻿using System;
using System.Collections.Generic;
using System.Text;
using Featureban.Domain;
using Featureban.Domain.Enums;
using Featureban.Tests.DSL;
using Xunit;

namespace Featureban.Tests
{
    public class CardShould
    {
        [Fact]
        public void ThrowOnBlock_IfBlocked()
        {
            var card = Create.Card.WhichBlocked().Build();

            Assert.Throws<NotSupportedException>(()=>card.Block());
        }

        [Fact]
        public void ThrowOnUnBlock_IfNotBlocked()
        {
            var card = Create.Card.Build();

            Assert.Throws<NotSupportedException>(() => card.Unblock());
        }

        [Fact]
        public void ChangeState_OnChangeState()
        {
            var card = Create.Card.Build();

            var changedCard = card.ChangeStatus(CardState.InProgress);

            Assert.Equal(CardState.InProgress, changedCard.State);
        }

    }
}