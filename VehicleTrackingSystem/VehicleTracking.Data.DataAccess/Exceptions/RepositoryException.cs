﻿using System;

namespace Domain
{
    [Serializable]
    public class RepositoryException : VTSystemException
    {
        public RepositoryException(string message) : base(message) { }
    }
}