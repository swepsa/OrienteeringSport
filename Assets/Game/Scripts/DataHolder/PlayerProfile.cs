public static class PlayerProfile
{
    public static int Id { get; set; }
    public static string Name { get; set; }
    public static string Surname { get; set; }
    public static Gender Gender { get; set; }
    public static Athlete Athlete { get; set; }
    public static string Team { get; set; }

    //club, национальность, разряд

    public static string GetFullName()
    {
        return Surname + " " + Name;
    }
}
