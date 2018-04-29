using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Contracts
{
    public interface IAppender:ILevalable
    {
        ILayout Layout { get; }        

        void Append(IError error);
    }
}
