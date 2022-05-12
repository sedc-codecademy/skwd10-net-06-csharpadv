using System;

namespace CustomSerializationAndDeserialization
{
    using System.Collections.Generic;
    using System.Text;
    using Models;
    using Newtonsoft.Json;

    class Program
    {
        static void Main(string[] args)
        {
            Student bob = new Student
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Bobsky",
                Age = 30,
                IsPartTime = true
            };

            string json = SerializeStudent(bob);

            Console.WriteLine($"serialized bob info with custom {nameof(SerializeStudent)} method: {json}");

            bob = DeserializeStudent(json);

            Console.WriteLine($"deserialized bob info with custom {nameof(DeserializeStudent)} method: Id: {bob.Id} FirstName: {bob.FirstName}; LastName: {bob.LastName}; Age: {bob.Age}; IsPartTime: {bob.IsPartTime}");

            /*
             * Installing Newtonsoft.Json NuGet
             * ---------------------------
             * Go to Tools -> NuGet Package Manager -> Manage NuGet Packages for Solution...
             * Go to Browse tab, in the search type in what kind of package you are looking for (e.g. "json")
             * Choose the package you want, pick the project you want it installed to, and click install
             * Now the package you have chosen is integrated in your project!
             */

            // JsonConvert.SerializeObject does serialization for us
            // through second parameter we can specify whether we want
            // our json to be generated in a single line, or it to be pretty-printed
            json = JsonConvert.SerializeObject(bob, Formatting.Indented);

            Console.WriteLine($"serialized bob info with Newtonsoft.Json: {json}");

            // JsonConvert.DeserializeObject<T> deserializes json string into a class
            // instance of the specified generic type
            bob = JsonConvert.DeserializeObject<Student>(json);

            Console.WriteLine($"deserialized bob info with Newtonsoft.Json: Id: {bob.Id} FirstName: {bob.FirstName}; LastName: {bob.LastName}; Age: {bob.Age}; IsPartTime: {bob.IsPartTime}");
        }

        private static string SerializeStudent(Student student)
        {
            // standard string addition
            // slowest and probaby hardest to maintain
            string json = "{";
            json = json + $"\"Id\": {student.Id},";
            json += $"\"FirstName\": \"{student.FirstName}\",";
            json += $"\"LastName\": \"{student.LastName}\",";
            json += $"\"Age\": {student.Age},";
            json += $"\"IsPartTime\": {student.IsPartTime}";
            json += "}";
            return json;

            // variant of serialization logic with using verbatim string
            // faster than "adding" strings but can be hard to follow
            // for large strings
            //return $@"{{
            //    ""Id"": ""{student.Id}"",
            //    ""FirstName"": ""{student.FirstName}"",
            //    ""LastName"": ""{student.LastName}"",
            //    ""Age"": {student.Age},
            //    ""IsPartTime"": {student.IsPartTime}
            //}}";

            // variant of serialization logic with using StringBuilder
            // gives full control of formatting in multiple lines
            //StringBuilder builder = new StringBuilder();

            //builder.AppendLine("{");
            //builder.AppendLine($"  \"Id\": {student.Id},");
            //builder.AppendLine($"  \"FirstName\": \"{student.FirstName}\",");
            //builder.AppendLine($"  \"LastName\": \"{student.LastName}\",");
            //builder.AppendLine($"  \"Age\": {student.Age},");
            //builder.AppendLine($"  \"IsPartTime\": {student.IsPartTime}");
            //builder.AppendLine("}");

            //return builder.ToString();
        }

        private static Student DeserializeStudent(string json)
        {
            /* starting state of json (depending on chosen implementation,
             * new lines might not be present)
             * {
             *      "Id": 1,
             *      "FirstName": "Bob",
             *      "LastName": "Bobsky",
             *      "Age": 30,
             *      "IsPartTime": True
             * }
             */

            // remove start and end squigly braces
            string content = json.Substring(json.IndexOf('{') + 1, json.IndexOf('}') - 1);
            // remove new lines
            content = content.Replace("\r\n", "");
            // remove quotes
            content = content.Replace("\"", "");
            // content = "Id: 1, FirstName: Bob, LastName: Bobsky, Age: 30, IsPartTime: True"
            // after replace calls

            string[] properties = content.Split(",");
            // properties = [ "Id: 1", "FirstName: Bob", "LastName: Bobsky", "Age: 30", "IsPartTime: True" ]
            // after splitting

            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            foreach (string property in properties)
            {
                string[] pair = property.Split(":");
                // pair = [ "Id", " 1" ] for Id property after splitting
                dictionary.Add(pair[0].Trim(), pair[1].Trim());
                // add new dictionary element Key = "Id", Value = "1" (trim removes white space)
            }

            Student student = new Student();
            // convert Id to int
            student.Id = int.Parse(dictionary["Id"]);
            student.FirstName = dictionary["FirstName"];
            student.LastName = dictionary["LastName"];
            // convert Age to int
            student.Age = int.Parse(dictionary["Age"]);
            // convert IsPartTime to bool
            student.IsPartTime = bool.Parse(dictionary["IsPartTime"]);

            return student;
        }
    }
}
