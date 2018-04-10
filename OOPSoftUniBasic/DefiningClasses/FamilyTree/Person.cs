using System;
using System.Collections.Generic;
using System.Text;


    class Person
    {
        public string FullName { get; set; }
        public string Birthday { get; set; }
        public List<Child> Children { get; set; }
        public List<Parent> Parents { get; set; }

        public Person()
        {
            this.Children = new List<Child>();
            this.Parents = new List<Parent>();
        }

        public override string ToString()
        {
            var familyTree = new StringBuilder();
            familyTree.AppendLine(this.FullName +" "+this.Birthday);
            familyTree.AppendLine("Parents:");
            foreach (var parent in this.Parents)
            {
                if (parent.Birthday!=null&&parent.FullName!=null)
                {
                    familyTree.AppendLine(parent.FullName + " " + parent.Birthday);
                }
            }
            familyTree.AppendLine("Children:");
            foreach (var child in this.Children)
            {
                if (child.FullName!=null&&child.Birthday!=null)
                {
                    familyTree.AppendLine(child.FullName + " " + child.Birthday);
                }
            }

            return familyTree.ToString();
        }
    }

