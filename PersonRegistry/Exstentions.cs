namespace PersonRegistry
{
    public static class Exstentions
    {
        public static bool CheckString(this Person p, string search)
        {
            if (p.Firstname.ToLower().Contains(search)
                || p.Lastname.ToLower().Contains(search)
                || p.Prefix.ToLower().Contains(search))
                return true;
            return false;
        }
    }
}
