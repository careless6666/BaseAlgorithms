namespace BaseAlgorithms.PopularTasks
{
    public class PossiblePolindrom
    {
        public static bool IsPossiblePolindrom(string str)
        {
            var offset = 0;

            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] == str[str.Length - 1 - i])
                {
                    
                }
                else if(str[i] ==str[str.Length - 2 - i - offset] && offset <= 0)
                {
                    if (offset == 0)
                    {
                        offset--;    
                    }
                    
                }
                else if(str[i + 1] == str[str.Length - 1 - i + offset] && offset >= 0)
                {
                    if (offset == 0)
                    {
                        offset++;    
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}