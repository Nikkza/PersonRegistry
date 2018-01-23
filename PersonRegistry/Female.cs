namespace PersonRegistry
{
    public class Female : Person
    {
        public Female(string prefix, string firstname, string lastname)
            : base(prefix, firstname, lastname)
        {
        }

        public override string GetPersonInfo()
        {
            return base.GetPersonInfo();
        }
    }
}
