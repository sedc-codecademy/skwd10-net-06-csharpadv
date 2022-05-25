using Class11.Demo1.Entities;

namespace Class11.Demo1.Services
{
    public class OurJsonSerializer
    {
        //serialize Student object
        public string SerializeStudent(Student student)
        {
            string json = "{";
            json += ($"\"Id\":{student.Id},");
            json += ($"\"FirstName\":\"{student.FirstName}\",");
            json += ($"\"LastName\":\"{student.LastName}\",");
            json += ($"\"Age\":{student.Age},");
            json += ($"\"IsPartTime\":\"{student.IsPartTime.ToString().ToLower()}\"");
            json += ("}");

            return json;
        }

        //deserialize Student class
        /// <summary>
        /// Method that deserialize Student class
        /// 1. Remove json charavters {, }, ", \n \r ...
        /// 2. Split by , and add to properties array
        /// 3. Split by : each item in properties array and add first item as key in dictionary and second as value in dictionary
        /// 4. Assign items in dictionalry to accirding object propertirs
        /// </summary>
        /// <param name="json">Student oibject json as string</param>
        /// <returns>Student object</returns>
        public Student DeserializeStudent(string json)
        {
            // THE PROCESS
            /*
            0. {"FirstName" : "Bob","LastName" : "Bobsky","Age" : "40","IsPartTime" : "false"}
            1. FirstName : Bob, LastName : Bobsky,Age : 40,IsPartTime : false
            1.1 
            FirstName : Bob
            LastName : Bobsky
            Age : 40
            IsPartTime : false
            2. 
            Key: FirstName, Value: Bob
            Key: LastName, Value: Bobsky
            Key: Age, Value: 40
            Key: IsPartTime, Value: false
            3 all keys and values to Student properties
            */
            // Cleaning the json
            string cleanedJson = json.Substring(json.IndexOf("{") + 1, json.IndexOf("}") - 1)
                .Replace("\"", "")
                .Replace("\n", "")
                .Replace("\r", "");

            string[] properties = cleanedJson.Split(',');
            // Creating dictionary with clean keys( properties ) and values
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (string property in properties)
            {
                string[] pair = property.Split(':');
                result.Add(pair[0].Trim(), pair[1].Trim());
            }

            // Creating a Student object with the values from the dictionary
            Student student = new Student();
            student.Id = int.Parse(result["Id"]);
            student.FirstName = result["FirstName"];
            student.LastName = result["LastName"];
            student.Age = int.Parse(result["Age"]);
            student.IsPartTime = bool.Parse(result["IsPartTime"]);

            return student;
        }
    }
}
