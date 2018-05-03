using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P08_PetClinic
{
    public class PetClinic
    {
        private Pet[] pets;

        public PetClinic(int roomCount, string name)
        {
            this.ValidateRoomCount(roomCount);
            this.pets = new Pet[roomCount];
            this.Name = name;
        }

        public string  Name { get; private set; }
        public int Center => this.pets.Length / 2;

        public bool HasEmptyRooms => this.pets.Any(x => x == null);

        private void ValidateRoomCount(int roomCount)
        {
            if (roomCount % 2 == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }

        public bool Add(Pet pet)
        {
            int currentRoom = this.Center;
            for (int i = 0; i < this.pets.Length; i++)
            {
                if (i % 2 != 0)
                {
                    currentRoom -= i;
                }
                else
                {
                    currentRoom += i;
                }

                if (this.pets[currentRoom] == null)
                {
                    this.pets[currentRoom] = pet;
                    return true;
                }
            }
            return false;
        }

        public bool Release ()
        {
            for (int i = 0; i < this.pets.Length; i++)
            {
                int index = (this.Center + i) % this.pets.Length;
                if (this.pets[index]!=null)
                {
                    this.pets[index] = null;
                    return true;
                }
            }
            return false;
        }

        public string Print(int roomNumber)
        {
            return this.pets[roomNumber - 1]?.ToString() ?? $"Room empty";
        }

        public string PrintAll()
        {
            var sb = new StringBuilder();
            for (int i = 1; i <= this.pets.Length; i++)
            {
                sb.AppendLine(this.Print(i));
            }
            string result = sb.ToString().TrimEnd();

            return result;
        }

    }
}
