using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using P07_InfernoInfinity.Models;
using P07_InfernoInfinity.Attributes;

namespace P07_InfernoInfinity.Core
{
    public class AttributeTracker
    {
        private object[] attributes;

        public AttributeTracker()
        {
            var type = typeof(Weapon);
            this.attributes = type.GetCustomAttributes(false);
        }

        public void Author()
        {
            for (int i = 0; i < attributes.Length; i++)
            {
                var attr = (WeaponAttribute)this.attributes[i];
                Console.WriteLine($"Author: {attr.Author}");
            }
        }
        public void Revision()
        {
            for (int i = 0; i < attributes.Length; i++)
            {
                var attr = (WeaponAttribute)this.attributes[i];
                Console.WriteLine($"Revision: {attr.Revision}");

            }
        }
        public void Description()
        {
            for (int i = 0; i < attributes.Length; i++)
            {
                var attr = (WeaponAttribute)this.attributes[i];
                Console.WriteLine($"Class description: {attr.Description}");

            }
        }
        public void Reviewers()
        {
            for (int i = 0; i < attributes.Length; i++)
            {
                var attr = (WeaponAttribute)this.attributes[i];
                Console.Write($"Reviewers: ");
                Console.WriteLine(string.Join(", ", attr.Reviewers));

            }
        }
    }
}
