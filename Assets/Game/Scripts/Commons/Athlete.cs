public class Athlete
{
    //национальность, 
    //разряд
    // scills

    public int Id { get; }
    public string Name { get; }
    public string Surname { get; }
    public Gender Gender { get; }
    public string Team { get; set; }

    public Athlete() { }

    public Athlete(int id, string name, string surname, Gender gender, string team)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Gender = gender;
        Team = team;
    }

    public string GetFullName()
    {
        return Surname + " " + Name;
    }
}
