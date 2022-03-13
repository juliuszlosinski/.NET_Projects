using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MonstersApp.Services
{
    public class MonsterService
    {
        #region FIELDS
        /// <summary>
        /// Pointer to info about host.
        /// </summary>
        private readonly IWebHostEnvironment webHostEnvironment;
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public MonsterService(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Path to file with data (monsters).
        /// </summary>
        private string JsonFilePath { get { return Path.Combine(webHostEnvironment.WebRootPath, "Data", "monsters.json"); } }
        #endregion

        #region METHODS
        /// <summary>
        /// Getting the list of the monsters from the file.
        /// </summary>
        /// <returns> Data with monsters. </returns>
        public IEnumerable<Monster> GetAll()
        {
            using(var jsonFileReader = File.OpenText(JsonFilePath))
            {
                return JsonSerializer.Deserialize<Monster[]>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = false
                });
            }
        }

        /// <summary>
        /// Find the monster with specified name/ id.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Monster GetMonster(string name)
        {
            return GetAll().First(monster => monster.Name == name);
        }

        /// <summary>
        /// Delete monster by id/ name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string DeleteByName(String name)
        {
            List<Monster> data = GetAll().ToList();
            Monster toDelete = data.Find(m => m.Name == name);
            if(toDelete!=null)
            {
                data.Remove(toDelete);
                using (var outputStream = File.OpenWrite(JsonFilePath))
                {
                    JsonSerializer.Serialize<IEnumerable<Monster>>(
                            new Utf8JsonWriter(outputStream, new JsonWriterOptions
                            {
                                SkipValidation = true,
                                Indented = true
                            }),
                            data
                        );
                }
                return "Done!";
            }
            return "Missing object!";
        }

        /// <summary>
        /// Adding a monster to list.
        /// </summary>
        public String AddMonster(Monster monster)
        {
            List<Monster> data = GetAll().ToList();
            data.Add(monster);
            using(var outputStream = File.OpenWrite(JsonFilePath))
            {
                JsonSerializer.Serialize<IEnumerable<Monster>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation=true,
                        Indented=true
                    }),
                    data
                    );
            }
            return "Done!";
        }

        /// <summary>
        /// Updating JSON file ("database").
        /// </summary>
        private void Update(IEnumerable<Monster> monsters)
        {
           using(var outputStream = File.OpenWrite(JsonFilePath))
            {
                JsonSerializer.Serialize<IEnumerable<Monster>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    monsters
                    );
            }
        }

        /// <summary>
        /// Updating a monster from list.
        /// </summary>
        public string UpdateMonster(string name, Monster updatedMonster)
        {
            List<Monster> data = GetAll().ToList();
            Monster monsterToFind = data.Find(monster => monster.Name == name);
            if(monsterToFind!=null)
            {
                monsterToFind.Type = updatedMonster.Type;
                monsterToFind.Age = updatedMonster.Age;
                monsterToFind.Gender = updatedMonster.Gender;
                Update(data);
                return "Done!";
            }
            return "Monster is missing!";
        }
        #endregion
    }
}
