using SerializeDeserialize.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeDeserialize.Helpers
{
    public class OurJsonSerializer
    {
        // Serializes only a student object
        public string SerializeStudent(Student student)
        {
            string jsonResult = "{";
            jsonResult += $"\"FirstName\" : \"{student.FirstName}\",";
            jsonResult += $"\"LastName\" : \"{student.LastName}\",";
            jsonResult += $"\"Age\" : \"{student.Age}\",";
            jsonResult += $"\"IsPartTime\" : \"{student.IsPartTime.ToString().ToLower()}\"";
            jsonResult += "}";

            return jsonResult;
        }

        // Deserialize only student object
        public Student DeserializeStudent(string jsonString)
        {
            string content = jsonString
                .Substring(jsonString.IndexOf("{") + 1, jsonString.IndexOf("}") - 1)
                .Replace("\n", "")
                .Replace("\r", "")
                .Replace("\"", "");

            string[] properties = content.Split(','); 
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach(string property in properties)
            {
                string[] pair = property.Split(':');
                result.Add(pair[0].Trim(), pair[1].Trim());
            } 

            Student student = new Student();
            student.FirstName = result["FirstName"];
            student.LastName = result["LastName"];
            student.Age = int.Parse(result["Age"]);
            student.IsPartTime = bool.Parse(result["IsPartTime"]);

            return student;
        } 
    }
}
