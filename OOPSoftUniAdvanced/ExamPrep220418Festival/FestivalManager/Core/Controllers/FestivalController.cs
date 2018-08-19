namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Contracts;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";
		//private const string TimeFormatLong = "{0:2D}:{1:2D}";
		//private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

		private readonly IStage stage;
        private readonly IInstrumentFactory instrumentFactory;
        private readonly IPerformerFactory performerFactory;
        private readonly ISetFactory setFactory;
        private readonly ISongFactory songFactory;

		public FestivalController(IStage stage, IInstrumentFactory instrumentFactory, IPerformerFactory performerFactory, ISetFactory setFactory, ISongFactory songFactor)
        {
            this.instrumentFactory = instrumentFactory;
            this.performerFactory = performerFactory;
            this.setFactory = setFactory;
            this.songFactory = songFactor;
            this.stage = stage;
		}
        
        //TODO accordind to descriptioni snot needed
		public string ProduceReport()
		{
            //var result = string.Empty;

            //var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            //result += ($"Festival length: {FormatTime(totalFestivalLength)}") + "\n";

            //foreach (var set in this.stage.Sets)
            //{
            //	result += ($"--{set.Name} ({FormatTime(set.ActualDuration)}):") + "\n";

            //	var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
            //	foreach (var performer in performersOrderedDescendingByAge)
            //	{
            //		var instruments = string.Join(", ", performer.Instruments
            //			.OrderByDescending(i => i.Wear));

            //		result += ($"---{performer.Name} ({instruments})") + "\n";
            //	}

            //	if (!set.Songs.Any())
            //		result += ("--No songs played") + "\n";
            //	else
            //	{
            //		result += ("--Songs played:") + "\n";
            //		foreach (var song in set.Songs)
            //		{
            //			result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
            //		}
            //	}
            //}

            //return result.ToString();
            return null;
		}

        
        //RegisterSet {name} {type}
        public string RegisterSet(string[] args)
		{
            string setName = args[0];
            string setType = args[1];

            ISet set = setFactory.CreateSet(setName,setType);
            this.stage.AddSet(set);

            return string.Format(Constants.SuccessfullyRegisterdSet , setType);
		}  
        
        //SignUpPerformer {name} {age} {instrument1} {instrument2} {instrumentN}
		public string SignUpPerformer(string[] args)
		{
			var name = args[0];
			var age = int.Parse(args[1]);
			var performer = this.performerFactory.CreatePerformer(name, age);

			var instrumentsString = args.Skip(2).ToArray();
            if (instrumentsString.Length>0)
            {
			    var instruments = instrumentsString
				    .Select(i => this.instrumentFactory.CreateInstrument(i))
				    .ToArray();
			    foreach (var instrument in instruments)
			    {
				    performer.AddInstrument(instrument);
			    }
            }

			this.stage.AddPerformer(performer);

			return string.Format(Constants.SuccessfullyRegisterdPerformer , name);
		}     
        
        //RegisterSong {name} {mm:ss}
        public string RegisterSong(string[] args)
		{
            string songName = args[0];
            TimeSpan duration = TimeSpan.ParseExact(args[1], "mm\\:ss",null);

            ISong song = songFactory.CreateSong(songName, duration);
            stage.AddSong(song);

			return string.Format(Constants.SongRegistered, song.ToString());
		}

        
        //AddSongToSet {songName} {setName}
        public string AddSongToSet(string[] args)
		{
			var songName = args[0];
			var setName = args[1];

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}

			if (!this.stage.HasSong(songName))
			{
				throw new InvalidOperationException("Invalid song provided");
			}

			var set = this.stage.GetSet(setName);
			var song = this.stage.GetSong(songName);

			set.AddSong(song);

            return string.Format(Constants.SuccessfullyAddedSongToSet, song, set.Name);
			
		}
		
		public string AddPerformerToSet(string[] args)
		{
			return PerformerRegistration(args);
		}

		public string PerformerRegistration(string[] args)
		{
			var performerName = args[0];
			var setName = args[1];

			if (!this.stage.HasPerformer(performerName))
			{
				throw new InvalidOperationException(Constants.PerformerNotFound);
			}

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException(Constants.SetNotFound);
			}            	

			var performer = this.stage.GetPerformer(performerName);
			var set = this.stage.GetSet(setName);

			set.AddPerformer(performer);

            return string.Format(Constants.SuccessfullyAddedPerformerToSet, performer.Name, set.Name);
		}

        //RepairInstruments
        public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear <= 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

            return string.Format(Constants.SuccessfullyRepairedInstruments, instrumentsToRepair.Length);
			//return $"Repaired {instrumentsToRepair.Length} instruments";
		}
	}
}