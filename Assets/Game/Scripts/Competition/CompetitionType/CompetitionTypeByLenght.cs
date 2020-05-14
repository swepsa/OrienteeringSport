public abstract class CompetitionTypeByLenght
{
    public abstract int MinCountOfControlPoints { get; }
    public abstract int MaxCountOfControlPoints { get; }
    public abstract int MaxDistanceFromStartToControlPoint { get; }
    public abstract int TimeLimit { get; }
    public abstract override string ToString();

    public class Sprint : CompetitionTypeByLenght
    {
        public override int MinCountOfControlPoints => 5;

        public override int MaxCountOfControlPoints => 10;

        public override int MaxDistanceFromStartToControlPoint => 800;

        public override int TimeLimit => 90 * 60;

        public override string ToString()
        {
            return "sprint";
        }
    }

    public class Middle : CompetitionTypeByLenght
    {
        public override int MinCountOfControlPoints => 10;

        public override int MaxCountOfControlPoints => 15;

        public override int MaxDistanceFromStartToControlPoint => 2500;

        public override int TimeLimit => 120 * 60;
        public override string ToString()
        {
            return "classic";
        }
    }

    public class Long : CompetitionTypeByLenght
    {
        public override int MinCountOfControlPoints => 15;

        public override int MaxCountOfControlPoints => 20;

        public override int MaxDistanceFromStartToControlPoint => int.MaxValue;

        public override int TimeLimit => 180 * 60;

        public override string ToString()
        {
            return "long";
        }
    }
}
