namespace PersonRegistry
{
    public class Male : Person
    {
        public Male(string prefix, string firstname, string lastname)
            : base(prefix, firstname, lastname)
        {
        }

        public override string GetPersonInfo()
        {
            return base.GetPersonInfo();
        }
    }
}
