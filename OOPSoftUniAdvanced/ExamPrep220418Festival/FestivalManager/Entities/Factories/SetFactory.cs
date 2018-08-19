using System;

using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
    using FestivalManager.Core;
    using Sets;

	public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            var assembly = Assembly.GetCallingAssembly();
            var setType = assembly.GetTypes().FirstOrDefault(x => x.Name == type);

            if (setType==null)
            {
                throw new ArgumentException(string.Format(Constants.SetIsNotSet, type));
            }
            if (!typeof(ISet).IsAssignableFrom(setType))
            {
                throw new ArgumentException(string.Format(Constants.SetIsNotSet, type));
            }

            ISet set = (ISet)Activator.CreateInstance(setType,new object[] {name});
            return set;
        }
	}




}
