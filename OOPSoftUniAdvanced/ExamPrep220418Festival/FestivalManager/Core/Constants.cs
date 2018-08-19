using System;
using System.Collections.Generic;
using System.Text;

namespace FestivalManager.Core
{
    public static class Constants
    {
        //SONG messages
        public const string SongOverLimit = "Song is over the set limit!";
        public const string SongRegistered = "Registered song {0}";
        public const string SongNotFound = "Invalid song provided";

        //SET messsgaes
        public const string SetNotFound = "Set type: {0} was not found";
        public const string SetIsNotSet= "{0} is not Set";
        public const string SetNotFount= "Invalid set provided";

        //PERFORMER Messages
        public const string PerformerNotFound = "Invalid performer provided";

        //INSTRUMENT messages
        public const string InstrumentNotFound = "Instrument type: {0} was not found";
        public const string InstrumentIsNotInstrument = "{0} is not Instrument";

        //Successfully Added
        public const string SuccessfullyRegisterdSet = "Registered {0} set";
        public const string SuccessfullyRegisterdPerformer = "Registered performer {0}";
        public const string SuccessfullyAddedSongToSet = "Added {0} to {1}";
        public const string SuccessfullyAddedPerformerToSet = "Added {0} to {1}";
        public const string SuccessfullyRepairedInstruments = "Repaired {0} instruments";
    }    

}
