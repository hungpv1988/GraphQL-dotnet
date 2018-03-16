using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.StarWars.Types;

namespace GraphQL.StarWars
{
    public class StarWarsData
    {
        private readonly List<Human> _humans = new List<Human>();
        private readonly List<Droid> _droids = new List<Droid>();

        public StarWarsData()
        {
            _humans.Add(new Human
            {
                Id = "1", Name = "Luke",
                Friends = new[] {"3", "4"},
                AppearsIn = new[] {4, 5, 6},
                HomePlanet = "Tatooine"
            });
            _humans.Add(new Human
            {
                Id = "2", Name = "Vader",
                AppearsIn = new[] {4, 5, 6},
                HomePlanet = "Tatooine"
            });

            _droids.Add(new Droid
            {
                Id = "3", Name = "R2-D2",
                Friends = new[] {"1", "4"},
                AppearsIn = new[] {4, 5, 6},
                PrimaryFunction = "Astromech"
            });
            _droids.Add(new Droid
            {
                Id = "4", Name = "C-3PO",
                AppearsIn = new[] {4, 5, 6},
                PrimaryFunction = "Protocol"
            });
        }

        public IEnumerable<StarWarsCharacter> GetFriends(StarWarsCharacter character)
        {
            if (character == null)
            {
                return null;
            }

            var friends = new List<StarWarsCharacter>();
            var lookup = character.Friends;
            if (lookup != null)
            {
                _humans.Where(h => lookup.Contains(h.Id)).Apply(friends.Add);
                _droids.Where(d => lookup.Contains(d.Id)).Apply(friends.Add);
            }
            return friends;
        }

        public Task<Human> GetHumanByIdAsync(string id)
        {
            return Task.FromResult(_humans.FirstOrDefault(h => h.Id == id));
        }

        public Task<Droid> GetDroidByIdAsync(string id)
        {
            return Task.FromResult(_droids.FirstOrDefault(h => h.Id == id));
        }

        public Human AddHuman(Human human)
        {
            human.Id = Guid.NewGuid().ToString();
            _humans.Add(human);
            return human;
        }

        public string[] GetAddonRelated(EPiServerMan man) {
            string[] addedRelated = null;

            switch (man.Id)
            {
                case "1": addedRelated = new string[] { "Forms", "LM" }; break;
                case "2": addedRelated = new string[] { "OP", "GA" }; break;
                case "3": addedRelated = new string[] { "CA", "Headless" }; break;
                default: addedRelated = new string[] { "ALL" }; break;
            }

            return addedRelated;
        }

        public EPiServerMan GetEPiServerManById(string id)
        {
            EPiServerMan man= null;

            switch (id)
            {
                case "1": man = new EPiServerMan() {
                    Department = "Addon",
                    EpiServerCode = "1",
                    EmployeeId = 1,
                    Name = "Phan Van Hung"
                } ; break;

                case "2":
                    man = new EPiServerMan()
                    {
                        Department = "Addon",
                        EpiServerCode = "2",
                        EmployeeId = 2,
                        Name = "Nguyen Dac Thach"
                    }; break;

                case "3":
                    man = new EPiServerMan()
                    {
                        Department = "Addon",
                        EpiServerCode = "3",
                        EmployeeId = 3,
                        Name = "Gile"
                    }; break;
                default:
                    man = new EPiServerMan()
                    {
                        Department = "Addon",
                        EpiServerCode = "4",
                        EmployeeId = 4,
                        Name = "Quan Kool"
                    }; break;
            }

            return man;
        }
    }
}
