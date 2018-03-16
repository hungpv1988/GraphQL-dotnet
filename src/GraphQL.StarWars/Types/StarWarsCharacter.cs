namespace GraphQL.StarWars.Types
{
    public abstract class StarWarsCharacter
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string[] Friends { get; set; }
        public int[] AppearsIn { get; set; }
    }

    public class Human : StarWarsCharacter
    {
        public string HomePlanet { get; set; }
    }

    public class Droid : StarWarsCharacter
    {
        public string PrimaryFunction { get; set; }
    }

    public class EPiServerMan
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int EmployeeId { get; set; }

        public string EpiServerCode { get; set; }

        public string Department { get; set; }

        public string[] AddonsRelated { get; set; }
    }
}
