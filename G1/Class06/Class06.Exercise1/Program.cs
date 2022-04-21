using Class06.Exercise1.Entities;
using Class06.Exercise1.Enums;
using Class06.Exercise1.Helpers;

DB.People.PrintEntities();

#region List Erin Rocha dogs

List<Dog> erinsDogs = DB.People.FirstOrDefault(x => x.FirstName == "Freddy" && x.LastName == "Gordon").Dogs.ToList();

erinsDogs.PrintEntities();

#endregion

#region Persons with 3 or more dogs

DB.People.Where(x => x.Dogs.Count >=3).ToList().PrintEntities();

#endregion

#region Different Race of dogs for Freddy Gordon

int raceCopunt = DB.People.Single(x => x.FirstName == "Freddy" && x.LastName == "Gordon").Dogs.Select(y => y.Race).Distinct().Count();

Console.WriteLine(raceCopunt);

#endregion

#region Print people that don't own a dog
DB.People.Where(x => x.Dogs.Count == 0).ToList().PrintEntities();
#endregion

#region Print all developers
DB.People.Where(x=> x.Occupation == Job.Developer).ToList().PrintEntities();
#endregion

#region Print all developers that own a dog from race Mutt
DB.People.Where(x => x.Occupation == Job.Developer)
    .Where(x => x.Dogs
        .Where(y => y.Race == Race.Mutt).ToList().Count > 0)
    .ToList().PrintEntities();
#endregion