
namespace CamaraBazar.Data.Models
{
    using System;

    [Flags]
    public enum LightMetering
    {
        Spot = 1,
        CenterWeighted =2,
        Evaluative =4
    }
}
