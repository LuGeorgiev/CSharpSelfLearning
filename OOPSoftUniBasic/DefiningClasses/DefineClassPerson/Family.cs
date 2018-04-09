using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Family
{
    private List<Person> member;

    public List<Person> Member
    {
        get { return this.member; }
        set { this.member = value; }
    }
    public Family()
    {
        this.Member = new List<Person>();
    }

    public void AddMember(string name, int age)
    {
        this.Member.Add(new Person(age, name));
    }

    public Person GetOldestMember()
    {
        return member.OrderByDescending(x => x.Age).FirstOrDefault();
    }

    public List<Person> OlderThan(int olderThan)
    {
        return member.Where(x=>x.Age>olderThan).OrderBy(x => x.Name).ToList();
    }
}

