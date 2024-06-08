namespace ez_park_platform.Shared.Infrastructure.Interfaces.Persistence.EPC.Configuration.Extensions
{
    public static class StringExtensions
    {
        public static string ToSnakeCase(this string value)
        {
            return new string(Convert(value.GetEnumerator()).ToArray());

            static IEnumerable<char> Convert(CharEnumerator e) 
            {
                if (!e.MoveNext()) yield break;

                yield return char.ToLower(e.Current);

                while(e.MoveNext()) 
                {
                    if (char.IsUpper(e.Current)) 
                    {
                        yield return '_';
                        yield return char.ToLower(e.Current) ;
                    }
                    else 
                    { 
                        yield return e.Current;
                    }
                }
            }
        }
    }
}
