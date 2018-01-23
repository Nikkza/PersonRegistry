namespace PersonRegistry
{
    public class Child : Person
    {
        public Child(string prefix, string firstname, string lastname)
            : base(prefix, firstname, lastname)
        {
        }

        public override string GetPersonInfo()
        {
            return base.GetPersonInfo();
        }
    }
}
