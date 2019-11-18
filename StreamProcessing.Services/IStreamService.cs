using System;
using System.Collections.Generic;
using System.Text;

namespace StreamProcessing.Services
{
    public interface IStreamService
    {
        int CalculateScore(string characters);
    }
}
