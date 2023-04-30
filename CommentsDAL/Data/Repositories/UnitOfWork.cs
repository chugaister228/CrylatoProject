﻿using CommentsDAL.Interfaces;
using CommentsDAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentsDAL.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly CommentsContext databaseContext;

        public ICommentsRepository CommentsRepository { get; }

        public IReactionsRepository ReactionsRepository { get; }

        public async Task SaveChangesAsync()
        {
            await databaseContext.SaveChangesAsync();
        }

        public UnitOfWork(
            CommentsContext databaseContext,
            ICommentsRepository commentsRepository,
            IReactionsRepository reactionsRepository)
        {
            this.databaseContext = databaseContext;
            CommentsRepository = commentsRepository;
            ReactionsRepository = reactionsRepository;
        }
    }
}