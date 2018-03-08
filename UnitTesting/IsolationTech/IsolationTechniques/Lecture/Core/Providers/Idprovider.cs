using Lecture.Core.Providers.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Core.Providers
{
    public class IdProvider : IIdProvider
    {
        private static int currentId = 0;
        public int NextId()
        {
            return currentId++;
        }
    }
}
