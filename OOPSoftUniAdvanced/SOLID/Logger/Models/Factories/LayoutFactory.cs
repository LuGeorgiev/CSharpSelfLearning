using Logger.Models.Contracts;
using System;


namespace Logger.Models.Factories
{
    public class LayoutFactory
    {
        public ILayout CreateLayout(string layoutType)
        {
            ILayout  layout = null;

            switch (layoutType)
            {
                case "SimpleLayout":
                    layout = new SimpleLayout();
                    break;
                case "XmlLayout":
                    layout = new XMLLayout();
                    break;
                default:
                    throw new ArgumentException("Invalid Layout type");                   
            }

            return layout;
        }
    }
}
