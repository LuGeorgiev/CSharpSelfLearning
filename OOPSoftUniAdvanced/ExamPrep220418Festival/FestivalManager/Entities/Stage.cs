namespace FestivalManager.Entities
{
	using System.Collections.Generic;
    using System.Linq;
    using Contracts;

	public class Stage:IStage
	{		
		private readonly List<ISet> sets;
		private readonly List<ISong> songs;
		private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets;
         
        public IReadOnlyCollection<ISong> Songs => this.songs;
         
        public IReadOnlyCollection<IPerformer> Performers => this.performers;       

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);       
        }

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            var result = this.performers
                .FirstOrDefault(x => x.Name == name);
            return result;
        }

        public ISet GetSet(string name)
        {
            var result = this.sets
                .FirstOrDefault(x => x.Name == name);
            return result;
        }

        public ISong GetSong(string name)
        {
            var result = this.songs
                .FirstOrDefault(x => x.Name == name);
            return result;
        }

        public bool HasPerformer(string name)
        {
            var result = this.performers
               .Any(x => x.Name == name);
            return result;
        }

        public bool HasSet(string name)
        {
            var result = this.sets
              .Any(x => x.Name == name);
            return result;
        }

        public bool HasSong(string name)
        {
            var result = this.songs
              .Any(x => x.Name == name);
            return result;
        }
    }
}
