using System;

namespace StreamProcessing.Services
{
    public class StreamService : IStreamService
    {
        public int CalculateScore(string characters)
        {
            int score = 0;
            int depth = 0;
            bool garbage = false;
            bool ignore = false;

            foreach (var c in characters)
            {
                if (ignore == false)
                {
                    if (c.Equals('!'))
                    {
                        ignore = true;
                    }

                    if (garbage == false)
                    {
                        if (c.Equals('<'))
                        {
                            garbage = true;
                        }

                        if (c.Equals('{'))
                        {
                            depth += 1;
                            score += depth;
                        }

                        if (c.Equals('}'))
                        {
                            depth -= 1;
                        }

                    }

                    else
                    {
                        if (c.Equals('>'))
                        {
                            garbage = false;
                        }
                    }

                }

                else if (ignore == true)
                {
                    ignore = false;
                }

            }

            if (depth != 0)
            {
                return -1;
            }

            return score;
        }
    }
}
