﻿using System;
using System.Collections.Generic;
using Dapper;
using Lesson_1_2.Models;
using Lesson_1_2.Interfaces;

namespace Lesson_1_2.Repositories
{
    public interface ICardsRepository
    {
        IList<Card> GetAll();
        Card Get(int id);
        void Create(Card card);
        void Update(Card card);
        void Delete(int id);
    }

    public class CardsRepository : ICardsRepository
    {

        public CardsRepository()
        {
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }

        public IList<Card> GetAll()
        {
            using (var connection = new ConnectionManager().GetOpenedConnection())
            {
                return connection.Query<Card>("SELECT Id, Number, HolderName, ExpirationDate, Type FROM cards").AsList();
            }
        }

        public void Create(Card card)
        {
            using (var connection = new ConnectionManager().GetOpenedConnection())
            {
                connection.Query<Card>("INSERT INTO cards(number, name, date, type) VALUES(@number, @name, @date, @type)",
                    new { number = card.Number, name = card.HolderName, date = card.ExpirationDate.ToUnixTimeSeconds(), type = card.Type });
            }
        }

        public Card Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Card card)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
